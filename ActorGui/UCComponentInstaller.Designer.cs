namespace ActorGUI
{
    partial class UCComponentInstaller
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnInstall = new System.Windows.Forms.Button();
            this.browseDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.lblComponent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnInstall
            // 
            this.btnInstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnInstall.FlatAppearance.BorderSize = 0;
            this.btnInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstall.ForeColor = System.Drawing.Color.White;
            this.btnInstall.Location = new System.Drawing.Point(65, 129);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(591, 36);
            this.btnInstall.TabIndex = 3;
            this.btnInstall.Text = "Download && Install";
            this.btnInstall.UseVisualStyleBackColor = false;
            this.btnInstall.Click += new System.EventHandler(this.BtnInstall_Click);
            // 
            // lblComponent
            // 
            this.lblComponent.AutoSize = true;
            this.lblComponent.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComponent.Location = new System.Drawing.Point(59, 59);
            this.lblComponent.Name = "lblComponent";
            this.lblComponent.Size = new System.Drawing.Size(0, 36);
            this.lblComponent.TabIndex = 4;
            // 
            // UCComponentInstaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblComponent);
            this.Controls.Add(this.btnInstall);
            this.Name = "UCComponentInstaller";
            this.Size = new System.Drawing.Size(718, 232);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.FolderBrowserDialog browseDialog;
        private System.Windows.Forms.Label lblComponent;
    }
}
