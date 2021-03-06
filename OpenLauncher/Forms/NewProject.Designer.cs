﻿namespace OpenLauncher.Forms
{
    partial class NewProject
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
            this.B_Save = new System.Windows.Forms.Button();
            this.SaveProject = new System.Windows.Forms.SaveFileDialog();
            this.TB_ImageURL = new System.Windows.Forms.TextBox();
            this.L_ProjectImageURL = new System.Windows.Forms.Label();
            this.L_ProjectName = new System.Windows.Forms.Label();
            this.TB_ProjectName = new System.Windows.Forms.TextBox();
            this.L_ProjectHome = new System.Windows.Forms.Label();
            this.TB_ProjectHomeURL = new System.Windows.Forms.TextBox();
            this.CB_AddProject = new System.Windows.Forms.CheckBox();
            this.B_Preview = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // B_Save
            // 
            this.B_Save.Location = new System.Drawing.Point(604, 84);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(75, 23);
            this.B_Save.TabIndex = 0;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // SaveProject
            // 
            this.SaveProject.Filter = "\"Project-json|*.json\"";
            // 
            // TB_ImageURL
            // 
            this.TB_ImageURL.Location = new System.Drawing.Point(121, 32);
            this.TB_ImageURL.Name = "TB_ImageURL";
            this.TB_ImageURL.Size = new System.Drawing.Size(569, 20);
            this.TB_ImageURL.TabIndex = 1;
            // 
            // L_ProjectImageURL
            // 
            this.L_ProjectImageURL.AutoSize = true;
            this.L_ProjectImageURL.Location = new System.Drawing.Point(12, 35);
            this.L_ProjectImageURL.Name = "L_ProjectImageURL";
            this.L_ProjectImageURL.Size = new System.Drawing.Size(68, 13);
            this.L_ProjectImageURL.TabIndex = 2;
            this.L_ProjectImageURL.Text = "Project URL:";
            // 
            // L_ProjectName
            // 
            this.L_ProjectName.AutoSize = true;
            this.L_ProjectName.Location = new System.Drawing.Point(12, 9);
            this.L_ProjectName.Name = "L_ProjectName";
            this.L_ProjectName.Size = new System.Drawing.Size(74, 13);
            this.L_ProjectName.TabIndex = 3;
            this.L_ProjectName.Text = "Project Name:";
            // 
            // TB_ProjectName
            // 
            this.TB_ProjectName.Location = new System.Drawing.Point(121, 6);
            this.TB_ProjectName.Name = "TB_ProjectName";
            this.TB_ProjectName.Size = new System.Drawing.Size(569, 20);
            this.TB_ProjectName.TabIndex = 4;
            // 
            // L_ProjectHome
            // 
            this.L_ProjectHome.AutoSize = true;
            this.L_ProjectHome.Location = new System.Drawing.Point(12, 61);
            this.L_ProjectHome.Name = "L_ProjectHome";
            this.L_ProjectHome.Size = new System.Drawing.Size(74, 13);
            this.L_ProjectHome.TabIndex = 5;
            this.L_ProjectHome.Text = "Project Home:";
            // 
            // TB_ProjectHomeURL
            // 
            this.TB_ProjectHomeURL.Location = new System.Drawing.Point(121, 58);
            this.TB_ProjectHomeURL.Name = "TB_ProjectHomeURL";
            this.TB_ProjectHomeURL.Size = new System.Drawing.Size(569, 20);
            this.TB_ProjectHomeURL.TabIndex = 6;
            // 
            // CB_AddProject
            // 
            this.CB_AddProject.AutoSize = true;
            this.CB_AddProject.Location = new System.Drawing.Point(435, 88);
            this.CB_AddProject.Name = "CB_AddProject";
            this.CB_AddProject.Size = new System.Drawing.Size(163, 17);
            this.CB_AddProject.TabIndex = 7;
            this.CB_AddProject.Text = "Add the project after creating";
            this.CB_AddProject.UseVisualStyleBackColor = true;
            // 
            // B_Preview
            // 
            this.B_Preview.Location = new System.Drawing.Point(121, 84);
            this.B_Preview.Name = "B_Preview";
            this.B_Preview.Size = new System.Drawing.Size(75, 23);
            this.B_Preview.TabIndex = 8;
            this.B_Preview.Text = "Preview";
            this.B_Preview.UseVisualStyleBackColor = true;
            // 
            // NewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 113);
            this.Controls.Add(this.B_Preview);
            this.Controls.Add(this.CB_AddProject);
            this.Controls.Add(this.TB_ProjectHomeURL);
            this.Controls.Add(this.L_ProjectHome);
            this.Controls.Add(this.TB_ProjectName);
            this.Controls.Add(this.L_ProjectName);
            this.Controls.Add(this.L_ProjectImageURL);
            this.Controls.Add(this.TB_ImageURL);
            this.Controls.Add(this.B_Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "NewProject";
            this.Text = "NewProject";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.SaveFileDialog SaveProject;
        private System.Windows.Forms.TextBox TB_ImageURL;
        private System.Windows.Forms.Label L_ProjectImageURL;
        private System.Windows.Forms.Label L_ProjectName;
        private System.Windows.Forms.TextBox TB_ProjectName;
        private System.Windows.Forms.Label L_ProjectHome;
        private System.Windows.Forms.TextBox TB_ProjectHomeURL;
        private System.Windows.Forms.CheckBox CB_AddProject;
        private System.Windows.Forms.Button B_Preview;
    }
}