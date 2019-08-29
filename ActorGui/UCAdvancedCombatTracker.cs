using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Actor.Core;
using Component = Actor.Core.Component;

namespace ActorGUI
{
    public partial class UCAdvancedCombatTracker : UserControl
    {
        public string installationPath = "";
        private TextBox txtConsole;
        public UCAdvancedCombatTracker()
        {
            InitializeComponent();
        }

        public void setTxtConsole(TextBox txtConsole)
        {
            this.txtConsole = txtConsole;
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = browseDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtInstallationPath.Text = this.installationPath = browseDialog.SelectedPath;
                ActConfigurationHelper.UpdateActInstallPath(this.installationPath);
            }
        }

        private void BtnInstall_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.installationPath))
            {
                MessageBox.Show("Please select the destination folder for the ACT installation.", "Atention!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                bool continueInstall = true;
                //check if folder is empty
                if (Directory.Exists(this.installationPath) && Directory.EnumerateFiles(this.installationPath).Count() > 0)
                {
                    continueInstall = (MessageBox.Show("The installation folder is not empty, all files will be erased. Continue?", "Atention!",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes);
                }

                if (!continueInstall) return;

                if (!Directory.Exists(this.installationPath))
                    Directory.CreateDirectory(this.installationPath);

                var systemInteractions = new SystemInteractions();
                var webInteractions = new WebInteractions();
                var downloadPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "download");
                var actComponent = ActorGUIForm.actComponents.First(x => x.InstallOrder == 3);

                InstallationHelper.Handle(webInteractions, systemInteractions, actComponent, downloadPath, this.installationPath);

                var actConfiguration = actComponent.Configurations.First();
                ActConfigurationHelper.SaveConfiguration(actConfiguration.Key, actConfiguration.Value, true, _ =>
                {
                    return (MessageBox.Show($"Do you want to overwrite the existing configuration for {actComponent.Name}?", "Atention!",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes);
                });

                var firewallHelper = FirewallHelper.Instance;
                var actExePath = Path.Combine(this.installationPath, actComponent.Name + ".exe");
                if (firewallHelper.IsFirewallInstalled && firewallHelper.IsFirewallEnabled)
                {
                    if ((MessageBox.Show($"Would you like to add {actComponent.Name} to the Firewall Exceptions?", "Atention!",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                    {
                        var actPath = actExePath;
                        try
                        {
                            firewallHelper.GrantAuthorization(actPath, actComponent.Name);
                        }
                        catch (Exception err)
                        {
                            txtConsole.Text = $"{err.Message}{Environment.NewLine}{txtConsole.Text}";
                        }
                    }
                }

                SystemInteractions.ApplyCompatibilityChanges(actExePath, CompatibilityMode.RUNASADMIN, CompatibilityMode.GDIDPISCALING, CompatibilityMode.DPIUNAWARE);

                txtConsole.Text = $"Installation Done. Proceed to plugin installation.{Environment.NewLine}{Environment.NewLine}{txtConsole.Text}";
            }
        }
    }
}
