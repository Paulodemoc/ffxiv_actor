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
    public partial class ActorGUIForm : Form
    {
        private string installPath;
        private int nextButtonLocation = 120;
        public static Component[] actComponents;
        public ActorGUIForm()
        {
            InitializeComponent();
            this.btnClose.BringToFront();

            InstallationHelper.setConsoleBox(this.txtConsole);
            ucAdvancedCombatTracker1.setTxtConsole(this.txtConsole);

            var systemInteractions = new SystemInteractions();
            var webInteractions = new WebInteractions();
            systemInteractions.KillProcess("Advanced Combat Tracker");

            actComponents = webInteractions.LoadConfiguration(() =>
            {
                //tratamento de erro ao ler os componentes
            });

            btnACT.Click += (s, e) =>
            {
                pnlSelectedMenu.Location = new Point(pnlSelectedMenu.Location.X, btnACT.Location.Y);
                ucAdvancedCombatTracker1.BringToFront();
                btnClose.BringToFront();
                this.txtConsole.BringToFront();
            };

            foreach (var component in actComponents.Where(x => !x.IsPrerequisite && x.InstallOrder != 3).OrderBy(x => x.InstallOrder))
            {

                UCComponentInstaller ucCI = new UCComponentInstaller(component, this.txtConsole);
                ucCI.BackColor = System.Drawing.Color.White;
                ucCI.Location = new System.Drawing.Point(0, 0);
                ucCI.Name = "ucCI" + component.Name.Replace(" ", "");
                ucCI.Size = new System.Drawing.Size(718, 232);
                ucCI.TabIndex = 4;
                this.pnlContent.Controls.Add(ucCI);
                ucCI.SendToBack();

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
                btnComponent.Click += (s, e) =>
                {
                    pnlSelectedMenu.Location = new Point(pnlSelectedMenu.Location.X, btnComponent.Location.Y);
                    ucCI.installationPath = ucAdvancedCombatTracker1.installationPath;
                    ucCI.BringToFront();
                    btnClose.BringToFront();
                    this.txtConsole.BringToFront();
                };
                this.pnlMenu.Controls.Add(btnComponent);
                nextButtonLocation += 60;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
