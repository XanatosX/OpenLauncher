namespace OpenLauncher.Forms
{
    partial class Settings
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
            this.L_ProjectFolder = new System.Windows.Forms.Label();
            this.TB_MainProjectFolder = new System.Windows.Forms.TextBox();
            this.B_ChooseFolder = new System.Windows.Forms.Button();
            this.B_SaveAndClose = new System.Windows.Forms.Button();
            this.B_Close = new System.Windows.Forms.Button();
            this.FBD_FolderSelect = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // L_ProjectFolder
            // 
            this.L_ProjectFolder.AutoSize = true;
            this.L_ProjectFolder.Location = new System.Drawing.Point(12, 15);
            this.L_ProjectFolder.Name = "L_ProjectFolder";
            this.L_ProjectFolder.Size = new System.Drawing.Size(97, 13);
            this.L_ProjectFolder.TabIndex = 0;
            this.L_ProjectFolder.Text = "Main project folder:";
            // 
            // TB_MainProjectFolder
            // 
            this.TB_MainProjectFolder.Location = new System.Drawing.Point(115, 12);
            this.TB_MainProjectFolder.Name = "TB_MainProjectFolder";
            this.TB_MainProjectFolder.Size = new System.Drawing.Size(245, 20);
            this.TB_MainProjectFolder.TabIndex = 1;
            // 
            // B_ChooseFolder
            // 
            this.B_ChooseFolder.Location = new System.Drawing.Point(366, 10);
            this.B_ChooseFolder.Name = "B_ChooseFolder";
            this.B_ChooseFolder.Size = new System.Drawing.Size(92, 23);
            this.B_ChooseFolder.TabIndex = 2;
            this.B_ChooseFolder.Text = "Choose folder";
            this.B_ChooseFolder.UseVisualStyleBackColor = true;
            this.B_ChooseFolder.Click += new System.EventHandler(this.B_ChooseFolder_Click);
            // 
            // B_SaveAndClose
            // 
            this.B_SaveAndClose.Location = new System.Drawing.Point(347, 226);
            this.B_SaveAndClose.Name = "B_SaveAndClose";
            this.B_SaveAndClose.Size = new System.Drawing.Size(104, 23);
            this.B_SaveAndClose.TabIndex = 3;
            this.B_SaveAndClose.Text = "Save and close";
            this.B_SaveAndClose.UseVisualStyleBackColor = true;
            this.B_SaveAndClose.Click += new System.EventHandler(this.B_SaveAndClose_Click);
            // 
            // B_Close
            // 
            this.B_Close.Location = new System.Drawing.Point(12, 226);
            this.B_Close.Name = "B_Close";
            this.B_Close.Size = new System.Drawing.Size(75, 23);
            this.B_Close.TabIndex = 4;
            this.B_Close.Text = "Close";
            this.B_Close.UseVisualStyleBackColor = true;
            this.B_Close.Click += new System.EventHandler(this.B_Close_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 261);
            this.Controls.Add(this.B_Close);
            this.Controls.Add(this.B_SaveAndClose);
            this.Controls.Add(this.B_ChooseFolder);
            this.Controls.Add(this.TB_MainProjectFolder);
            this.Controls.Add(this.L_ProjectFolder);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L_ProjectFolder;
        private System.Windows.Forms.TextBox TB_MainProjectFolder;
        private System.Windows.Forms.Button B_ChooseFolder;
        private System.Windows.Forms.Button B_SaveAndClose;
        private System.Windows.Forms.Button B_Close;
        private System.Windows.Forms.FolderBrowserDialog FBD_FolderSelect;
    }
}