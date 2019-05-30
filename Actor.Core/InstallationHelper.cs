using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Actor.Core
{
    public class InstallationHelper
    {
        private static TextBox txtConsole;

        public static void setConsoleBox(TextBox txtConsole)
        {
            InstallationHelper.txtConsole = txtConsole;
        }

        public static void Handle(WebInteractions webInteractions,
                                   SystemInteractions systemInteractions,
                                   Component component,
                                   string downloadTo,
                                   string installTo = "")
        {
            var componentVersionCheck = component.IsPrerequisite ? component.VersionCheck : Path.Combine(installTo, component.VersionCheck);
            if (systemInteractions.CheckVersion(componentVersionCheck, component.Version, () => txtConsole.Text = $"##### Unable to check the version for {component.Name}...{Environment.NewLine} {txtConsole.Text}"))
            {
                txtConsole.Text = $"##### The latest version of {component.Name} is already installed!{Environment.NewLine}{txtConsole.Text}";
                if (component.IsPlugin)
                    UpdatePluginConfiguration(component, UpdatePluginInstallPath(component, installTo));
                return;
            }

            var downloadToFullPath = Path.Combine(downloadTo, component.FileName);
            var parsingText = $"##### Parsing latest github api for {component.Name}...";
            var downloadingText = $"##### Downloading {component.Name} -> ";
            const string installText = "##### {0} {1}...";

            var downloadFrom = component.Url;
            if (component.IsFromGitHub)
            {
                var isWin7 = !string.IsNullOrWhiteSpace(component.Win7InstallArguments)
                             && Environment.OSVersion.Version.Major == 6
                             && Environment.OSVersion.Version.Minor == 1;

                var installArguments = isWin7 ? component.Win7InstallArguments : component.InstallArguments;
                downloadFrom = webInteractions.ParseAssetFromGitHub(downloadFrom, int.Parse(installArguments), () => txtConsole.Text = $"{parsingText}{Environment.NewLine}{txtConsole.Text}");
            }

            var bundle = webInteractions.Download(downloadFrom, downloadToFullPath, () => txtConsole.Text = $"{downloadingText}{Environment.NewLine}{txtConsole.Text}", DownloadProgress(downloadingText), DownloadComplete());
            if (bundle.Result == WebInteractionsResultType.Fail)
            {
                txtConsole.Text = $"{Environment.NewLine}There was an error while downloading {component.Name}.{Environment.NewLine}{txtConsole.Text}";
            }

            var file = bundle.DownloadedFile;
            if (component.ComponentType == ComponentType.Executable)
            {
                txtConsole.Text = string.Format(installText + $"{Environment.NewLine}{txtConsole.Text}", "Installing", component.Name);
                systemInteractions.Install(file.FullName, component.InstallArguments);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(installTo))
                {
                    txtConsole.Text = $"{Environment.NewLine}There was an error while unzipping {component.Name}.{Environment.NewLine}The install path was not valid{Environment.NewLine}{txtConsole.Text}";
                }

                if (component.IsPlugin)
                {
                    installTo = UpdatePluginInstallPath(component, installTo);
                    UpdatePluginConfiguration(component, installTo);
                }

                try
                {
                    if (Directory.Exists(installTo))
                        Directory.Delete(installTo);
                }
                catch (Exception)
                {
                    // do nothing
                }

                txtConsole.Text = string.Format(installText + $"{Environment.NewLine}{txtConsole.Text}", "Unzipping", component.Name);
                systemInteractions.Unzip(file.FullName, installTo);
            }
        }

        private static Action DownloadComplete()
        {
            return () => txtConsole.Text = $"{Environment.NewLine}{txtConsole.Text}";
        }

        private static Action<System.Net.DownloadProgressChangedEventArgs> DownloadProgress(string downloadingText)
        {
            return args => txtConsole.Text = $"\r{downloadingText} {args.ProgressPercentage}%{Environment.NewLine}{txtConsole.Text}";
        }

        private static string UpdatePluginInstallPath(Component component, string installTo)
        {
            installTo = Path.Combine(installTo, "plugin");
            if (!Directory.Exists(installTo))
                Directory.CreateDirectory(installTo);

            installTo = Path.Combine(installTo, component.Name);
            return installTo;
        }

        private static void UpdatePluginConfiguration(Component component, string destination)
        {
            foreach (var componentLibrary in component.Libraries)
            {
                ActConfigurationHelper.AddPlugin(Path.Combine(destination, componentLibrary));
            }

            if (component.Configurations == null) return;

            foreach (var componentConfiguration in component.Configurations)
            {
                var url = componentConfiguration.Key;
                var confDestination = componentConfiguration.Value;

                ActConfigurationHelper.SaveConfiguration(url, confDestination, onDuplicatd: _ =>
                {
                    return (MessageBox.Show($"Do you want to overwrite the existing configuration for {component.Name}? [Y/n] ", "Atention!",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes);
                });
            }
        }
    }
}
