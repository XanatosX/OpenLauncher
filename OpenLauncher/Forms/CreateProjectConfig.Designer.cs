namespace OpenLauncher.Forms
{
    partial class CreateProjectConfig
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
            this.components = new System.ComponentModel.Container();
            this.LV_Executables = new System.Windows.Forms.ListView();
            this.CH_DisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CH_Filepath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.L_Executable = new System.Windows.Forms.Label();
            this.B_Done = new System.Windows.Forms.Button();
            this.CMS_ItemSelect = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMI_Rename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMI_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.CMS_ItemSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // LV_Executables
            // 
            this.LV_Executables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CH_Filepath,
            this.CH_DisplayName});
            this.LV_Executables.Location = new System.Drawing.Point(21, 25);
            this.LV_Executables.Name = "LV_Executables";
            this.LV_Executables.Size = new System.Drawing.Size(431, 126);
            this.LV_Executables.TabIndex = 0;
            this.LV_Executables.UseCompatibleStateImageBehavior = false;
            this.LV_Executables.View = System.Windows.Forms.View.Details;
            this.LV_Executables.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LV_Executables_MouseClick);
            // 
            // CH_DisplayName
            // 
            this.CH_DisplayName.DisplayIndex = 0;
            this.CH_DisplayName.Text = "Displayname";
            this.CH_DisplayName.Width = 91;
            // 
            // CH_Filepath
            // 
            this.CH_Filepath.DisplayIndex = 1;
            this.CH_Filepath.Text = "Filepath";
            this.CH_Filepath.Width = 331;
            // 
            // L_Executable
            // 
            this.L_Executable.AutoSize = true;
            this.L_Executable.Location = new System.Drawing.Point(18, 9);
            this.L_Executable.Name = "L_Executable";
            this.L_Executable.Size = new System.Drawing.Size(127, 13);
            this.L_Executable.TabIndex = 1;
            this.L_Executable.Text = "Executable for launching:";
            // 
            // B_Done
            // 
            this.B_Done.Location = new System.Drawing.Point(377, 157);
            this.B_Done.Name = "B_Done";
            this.B_Done.Size = new System.Drawing.Size(75, 23);
            this.B_Done.TabIndex = 2;
            this.B_Done.Text = "Done";
            this.B_Done.UseVisualStyleBackColor = true;
            this.B_Done.Click += new System.EventHandler(this.B_Done_Click);
            // 
            // CMS_ItemSelect
            // 
            this.CMS_ItemSelect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Rename,
            this.toolStripSeparator1,
            this.TSMI_Delete});
            this.CMS_ItemSelect.Name = "CMS_ItemSelect";
            this.CMS_ItemSelect.Size = new System.Drawing.Size(118, 54);
            // 
            // TSMI_Rename
            // 
            this.TSMI_Rename.Name = "TSMI_Rename";
            this.TSMI_Rename.Size = new System.Drawing.Size(117, 22);
            this.TSMI_Rename.Text = "Rename";
            this.TSMI_Rename.Click += new System.EventHandler(this.TSMI_Rename_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
            // 
            // TSMI_Delete
            // 
            this.TSMI_Delete.Name = "TSMI_Delete";
            this.TSMI_Delete.Size = new System.Drawing.Size(117, 22);
            this.TSMI_Delete.Text = "Delete";
            this.TSMI_Delete.Click += new System.EventHandler(this.TSMI_Delete_Click);
            // 
            // CreateProjectConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 185);
            this.Controls.Add(this.B_Done);
            this.Controls.Add(this.L_Executable);
            this.Controls.Add(this.LV_Executables);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CreateProjectConfig";
            this.Text = "Create project config";
            this.Load += new System.EventHandler(this.CreateProjectConfig_Load);
            this.CMS_ItemSelect.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LV_Executables;
        private System.Windows.Forms.ColumnHeader CH_DisplayName;
        private System.Windows.Forms.ColumnHeader CH_Filepath;
        private System.Windows.Forms.Label L_Executable;
        private System.Windows.Forms.Button B_Done;
        private System.Windows.Forms.ContextMenuStrip CMS_ItemSelect;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Rename;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Delete;
    }
}