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
    public partial class UCComponentInstaller : UserControl
    {
        private Component component;
        public string installationPath = "";
        private TextBox txtConsole;
        public UCComponentInstaller()
        {
            InitializeComponent();
        }

        public UCComponentInstaller(Component comp, TextBox txtConsole)
        {
            InitializeComponent();
            this.txtConsole = txtConsole;
            this.component = comp;
            lblComponent.Text = comp.Name;
        }

        public void setTxtConsole(TextBox txtConsole)
        {
            this.txtConsole = txtConsole;
        }

        public void setComponent(Component comp)
        {
            this.component = comp;
        }

        private void BtnInstall_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.installationPath))
            {
                MessageBox.Show("Please select the folder where ACT is installed or install it first.", "Atention!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!Directory.Exists(this.installationPath))
                    Directory.CreateDirectory(this.installationPath);

                var systemInteractions = new SystemInteractions();
                var webInteractions = new WebInteractions();
                var downloadPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "download");

                InstallationHelper.Handle(webInteractions, systemInteractions, this.component, downloadPath, this.installationPath);

                txtConsole.Text = $"{component.Name} Installation Done. {Environment.NewLine}{Environment.NewLine}{txtConsole.Text}";
            }
        }
    }
}
