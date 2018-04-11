namespace OpenLauncher.Forms
{
    partial class CreateServerDownloadable
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
            this.L_Folder = new System.Windows.Forms.Label();
            this.TB_InputFolder = new System.Windows.Forms.TextBox();
            this.B_SelectInputFolder = new System.Windows.Forms.Button();
            this.FBD_SelectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.B_CreateAndOpen = new System.Windows.Forms.Button();
            this.B_Create = new System.Windows.Forms.Button();
            this.B_Close = new System.Windows.Forms.Button();
            this.L_OutputFolder = new System.Windows.Forms.Label();
            this.TB_OutputFolder = new System.Windows.Forms.TextBox();
            this.B_SelectTargetFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // L_Folder
            // 
            this.L_Folder.AutoSize = true;
            this.L_Folder.Location = new System.Drawing.Point(12, 9);
            this.L_Folder.Name = "L_Folder";
            this.L_Folder.Size = new System.Drawing.Size(111, 13);
            this.L_Folder.TabIndex = 0;
            this.L_Folder.Text = "Folder with base data:";
            // 
            // TB_InputFolder
            // 
            this.TB_InputFolder.Location = new System.Drawing.Point(129, 6);
            this.TB_InputFolder.Name = "TB_InputFolder";
            this.TB_InputFolder.Size = new System.Drawing.Size(348, 20);
            this.TB_InputFolder.TabIndex = 1;
            // 
            // B_SelectInputFolder
            // 
            this.B_SelectInputFolder.Location = new System.Drawing.Point(483, 4);
            this.B_SelectInputFolder.Name = "B_SelectInputFolder";
            this.B_SelectInputFolder.Size = new System.Drawing.Size(75, 23);
            this.B_SelectInputFolder.TabIndex = 2;
            this.B_SelectInputFolder.Text = "Select folder";
            this.B_SelectInputFolder.UseVisualStyleBackColor = true;
            this.B_SelectInputFolder.Click += new System.EventHandler(this.B_SelectInputFolder_Click);
            // 
            // B_CreateAndOpen
            // 
            this.B_CreateAndOpen.Location = new System.Drawing.Point(426, 59);
            this.B_CreateAndOpen.Name = "B_CreateAndOpen";
            this.B_CreateAndOpen.Size = new System.Drawing.Size(132, 23);
            this.B_CreateAndOpen.TabIndex = 3;
            this.B_CreateAndOpen.Text = "Create and open folder";
            this.B_CreateAndOpen.UseVisualStyleBackColor = true;
            this.B_CreateAndOpen.Click += new System.EventHandler(this.B_CreateAndOpen_Click);
            // 
            // B_Create
            // 
            this.B_Create.Location = new System.Drawing.Point(345, 59);
            this.B_Create.Name = "B_Create";
            this.B_Create.Size = new System.Drawing.Size(75, 23);
            this.B_Create.TabIndex = 4;
            this.B_Create.Text = "Create";
            this.B_Create.UseVisualStyleBackColor = true;
            this.B_Create.Click += new System.EventHandler(this.B_Create_Click);
            // 
            // B_Close
            // 
            this.B_Close.Location = new System.Drawing.Point(15, 59);
            this.B_Close.Name = "B_Close";
            this.B_Close.Size = new System.Drawing.Size(75, 23);
            this.B_Close.TabIndex = 5;
            this.B_Close.Text = "Close";
            this.B_Close.UseVisualStyleBackColor = true;
            this.B_Close.Click += new System.EventHandler(this.B_Close_Click);
            // 
            // L_OutputFolder
            // 
            this.L_OutputFolder.AutoSize = true;
            this.L_OutputFolder.Location = new System.Drawing.Point(12, 35);
            this.L_OutputFolder.Name = "L_OutputFolder";
            this.L_OutputFolder.Size = new System.Drawing.Size(71, 13);
            this.L_OutputFolder.TabIndex = 6;
            this.L_OutputFolder.Text = "Output folder:";
            // 
            // TB_OutputFolder
            // 
            this.TB_OutputFolder.Location = new System.Drawing.Point(129, 32);
            this.TB_OutputFolder.Name = "TB_OutputFolder";
            this.TB_OutputFolder.Size = new System.Drawing.Size(348, 20);
            this.TB_OutputFolder.TabIndex = 7;
            // 
            // B_SelectTargetFolder
            // 
            this.B_SelectTargetFolder.Location = new System.Drawing.Point(483, 30);
            this.B_SelectTargetFolder.Name = "B_SelectTargetFolder";
            this.B_SelectTargetFolder.Size = new System.Drawing.Size(75, 23);
            this.B_SelectTargetFolder.TabIndex = 8;
            this.B_SelectTargetFolder.Text = "Select folder";
            this.B_SelectTargetFolder.UseVisualStyleBackColor = true;
            this.B_SelectTargetFolder.Click += new System.EventHandler(this.B_SelectTargetFolder_Click);
            // 
            // CreateServerDownloadable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 94);
            this.Controls.Add(this.B_SelectTargetFolder);
            this.Controls.Add(this.TB_OutputFolder);
            this.Controls.Add(this.L_OutputFolder);
            this.Controls.Add(this.B_Close);
            this.Controls.Add(this.B_Create);
            this.Controls.Add(this.B_CreateAndOpen);
            this.Controls.Add(this.B_SelectInputFolder);
            this.Controls.Add(this.TB_InputFolder);
            this.Controls.Add(this.L_Folder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CreateServerDownloadable";
            this.Text = "Create server downloadable";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L_Folder;
        private System.Windows.Forms.TextBox TB_InputFolder;
        private System.Windows.Forms.Button B_SelectInputFolder;
        private System.Windows.Forms.FolderBrowserDialog FBD_SelectFolder;
        private System.Windows.Forms.Button B_CreateAndOpen;
        private System.Windows.Forms.Button B_Create;
        private System.Windows.Forms.Button B_Close;
        private System.Windows.Forms.Label L_OutputFolder;
        private System.Windows.Forms.TextBox TB_OutputFolder;
        private System.Windows.Forms.Button B_SelectTargetFolder;
    }
}