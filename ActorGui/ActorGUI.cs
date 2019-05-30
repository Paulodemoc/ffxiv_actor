using Actor.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Component = Actor.Core.Component;

namespace ActorGUI
{
    public partial class ActorGUI : Form
    {
        private string installPath;
        private int nextButtonLocation = 120;
        public static Component[] actComponents;
        public ActorGUI()
        {
            InitializeComponent();
            this.btnClose.BringToFront();

            InstallationHelper.setConsoleBox(this.txtConsole);

            //Console.WriteLine("##### To ensure that ACT works correctly you should first install:");
            //Console.WriteLine("#####   1. Microsoft Visual C++ Redistributable");
            //Console.WriteLine("#####   2. Microsoft .NET Framework 4.7");
            //Console.WriteLine("#####   3. Win10Pcap");
            //Console.WriteLine("##### If you have already installed then you can skip this step.");

            var systemInteractions = new SystemInteractions();
            var webInteractions = new WebInteractions();
            systemInteractions.KillProcess("Advanced Combat Tracker");

            actComponents = webInteractions.LoadConfiguration(() =>
            {
                //tratamento de erro ao ler os componentes
            });

            foreach (var component in actComponents.Where(x => !x.IsPrerequisite && x.InstallOrder != 3).OrderBy(x => x.InstallOrder))
            {
                Button btnComponent = new Button();
                btnComponent.FlatAppearance.BorderColor = System.Drawing.Color.Black;
                btnComponent.FlatAppearance.BorderSize = 0;
                btnComponent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
                btnComponent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
                btnComponent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnComponent.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
                btnComponent.ForeColor = System.Drawing.Color.White;
                btnComponent.Image = global::ActorGUI.Properties.Resources.plugin32;
                btnComponent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                btnComponent.Location = new System.Drawing.Point(0, nextButtonLocation);
                btnComponent.Name = $"btn{component.Name.Replace(" ", "")}";
                btnComponent.Size = new System.Drawing.Size(178, 42);
                btnComponent.TabIndex = 1;
                btnComponent.Text = component.Name.Replace(" Plugin", "");
                btnComponent.UseVisualStyleBackColor = true;
                btnComponent.Click += BtnComponent_Click;
                btnComponent.Tag = component;
                this.pnlMenu.Controls.Add(btnComponent);
                nextButtonLocation += 60;

            }

            //if (Iterate(_ => YesOrNoIteration(), switches, "##### Do you want to install the prerequisites? [Y/n] ", DefaultIterationErrorMessage))
            //{
            //    foreach (var component in components.Where(x => x.IsPrerequisite).OrderBy(x => x.InstallOrder))
            //    {
            //        Handle(webInteractions, systemInteractions, component, switches, downloadPath);
            //    }
            //}

            //foreach (var component in components.Where(x => !x.IsPrerequisite).OrderBy(x => x.InstallOrder))
            //{
            //    Handle(webInteractions, systemInteractions, component, switches, downloadPath, installPath);
            //}

            var actComponent = actComponents.First(x => x.InstallOrder == 3);
            var actConfiguration = actComponent.Configurations.First();
            //ActConfigurationHelper.SaveConfiguration(actConfiguration.Key, actConfiguration.Value, true, _ =>
            //{
            //if (switches != CommandLineSwitches.UserInput)
            //    return true;

            //return Iterate(__ =>
            //{
            //    var result = YesOrNoIteration();
            //    return result.HasValue && result.Value;
            //}, CommandLineSwitches.UserInput,
            //    $"##### Do you want to overwrite the existing configuration for {actComponent.Name}? [Y/n] ",
            //    DefaultIterationErrorMessage);
            //});

            var firewallHelper = FirewallHelper.Instance;
            //var actExePath = Path.Combine(installPath, actComponent.Name + ".exe");
            //if (firewallHelper.IsFirewallInstalled && firewallHelper.IsFirewallEnabled)
            //{
            //    if (Iterate(_ => YesOrNoIteration(), switches, $"##### Would you like to add {actComponent.Name} to the Firewall Exceptions? [Y/n] ", DefaultIterationErrorMessage))
            //    {
            //        var actPath = actExePath;
            //        try
            //        {
            //            firewallHelper.GrantAuthorization(actPath, actComponent.Name);
            //        }
            //        catch (Exception e)
            //        {
            //            Console.WriteLine(e.Message);
            //        }
            //    }
            //}

            //SystemInteractions.ApplyCompatibilityChanges(actExePath, CompatibilityMode.RUNASADMIN, CompatibilityMode.GDIDPISCALING, CompatibilityMode.DPIUNAWARE);

            //systemInteractions.CreateProcess(actExePath).Start();
        }

        private void BtnComponent_Click(object sender, EventArgs e)
        {
            pnlSelectedMenu.Location = new Point(pnlSelectedMenu.Location.X, (sender as Button).Location.Y);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UcAdvancedCombatTracker1_Load(object sender, EventArgs e)
        {

        }
    }
}
