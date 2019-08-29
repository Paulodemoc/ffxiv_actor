namespace ActorGUI
{
    partial class ActorGUIForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActorGUIForm));
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlSelectedMenu = new System.Windows.Forms.Panel();
            this.btnPrerequisites = new System.Windows.Forms.Button();
            this.btnACT = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.ucAdvancedCombatTracker1 = new UCAdvancedCombatTracker();
            this.pnlMenu.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Black;
            this.pnlMenu.Controls.Add(this.panel1);
            this.pnlMenu.Controls.Add(this.pnlSelectedMenu);
            this.pnlMenu.Controls.Add(this.btnPrerequisites);
            this.pnlMenu.Controls.Add(this.btnACT);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(237, 599);
            this.pnlMenu.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Location = new System.Drawing.Point(232, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 599);
            this.panel1.TabIndex = 3;
            // 
            // pnlSelectedMenu
            // 
            this.pnlSelectedMenu.BackColor = System.Drawing.Color.DimGray;
            this.pnlSelectedMenu.Location = new System.Drawing.Point(219, 0);
            this.pnlSelectedMenu.Name = "pnlSelectedMenu";
            this.pnlSelectedMenu.Size = new System.Drawing.Size(16, 52);
            this.pnlSelectedMenu.TabIndex = 2;
            // 
            // btnPrerequisites
            // 
            this.btnPrerequisites.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPrerequisites.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnPrerequisites.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnPrerequisites.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrerequisites.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnPrerequisites.ForeColor = System.Drawing.Color.White;
            this.btnPrerequisites.Image = global::ActorGUI.Properties.Resources.plugin32;
            this.btnPrerequisites.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrerequisites.Location = new System.Drawing.Point(0, 60);
            this.btnPrerequisites.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrerequisites.Name = "btnPrerequisites";
            this.btnPrerequisites.Size = new System.Drawing.Size(237, 52);
            this.btnPrerequisites.TabIndex = 1;
            this.btnPrerequisites.Text = "Prerequisites";
            this.btnPrerequisites.UseVisualStyleBackColor = true;
            // 
            // btnACT
            // 
            this.btnACT.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnACT.FlatAppearance.BorderSize = 0;
            this.btnACT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnACT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnACT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnACT.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnACT.ForeColor = System.Drawing.Color.White;
            this.btnACT.Image = global::ActorGUI.Properties.Resources.act32;
            this.btnACT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnACT.Location = new System.Drawing.Point(0, 0);
            this.btnACT.Margin = new System.Windows.Forms.Padding(4);
            this.btnACT.Name = "btnACT";
            this.btnACT.Size = new System.Drawing.Size(237, 52);
            this.btnACT.TabIndex = 0;
            this.btnACT.Text = "ACT";
            this.btnACT.UseVisualStyleBackColor = true;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.txtConsole);
            this.pnlContent.Controls.Add(this.btnClose);
            this.pnlContent.Controls.Add(this.ucAdvancedCombatTracker1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(237, 0);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(718, 599);
            this.pnlContent.TabIndex = 1;
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.Color.Black;
            this.txtConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConsole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtConsole.Location = new System.Drawing.Point(0, 232);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.Size = new System.Drawing.Size(718, 367);
            this.txtConsole.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = global::ActorGUI.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(676, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(37, 32);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 3;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // ucAdvancedCombatTracker1
            // 
            this.ucAdvancedCombatTracker1.BackColor = System.Drawing.Color.White;
            this.ucAdvancedCombatTracker1.Location = new System.Drawing.Point(0, 0);
            this.ucAdvancedCombatTracker1.Name = "ucAdvancedCombatTracker1";
            this.ucAdvancedCombatTracker1.Size = new System.Drawing.Size(718, 232);
            this.ucAdvancedCombatTracker1.TabIndex = 4;
            // 
            // ActorGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 599);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ActorGUI";
            this.Text = "FFXIV Actor";
            this.pnlMenu.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Button btnACT;
        private System.Windows.Forms.Button btnPrerequisites;
        private System.Windows.Forms.Panel pnlSelectedMenu;
        private UCAdvancedCombatTracker ucAdvancedCombatTracker1;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Panel panel1;
    }
}

