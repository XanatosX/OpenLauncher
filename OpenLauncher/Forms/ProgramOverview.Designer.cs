namespace OpenLauncher.Forms
{
    partial class ProgramOverview
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fORMFILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fORMCreateNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fORMLoadProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadProjectDialog = new System.Windows.Forms.OpenFileDialog();
            this.LV_Projects = new System.Windows.Forms.ListView();
            this.IL_ProjectImages = new System.Windows.Forms.ImageList(this.components);
            this.P_ProjectPanel = new System.Windows.Forms.Panel();
            this.reloadProjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fORMFILEToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fORMFILEToolStripMenuItem
            // 
            this.fORMFILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fORMCreateNewToolStripMenuItem,
            this.fORMLoadProjectToolStripMenuItem,
            this.reloadProjectsToolStripMenuItem});
            this.fORMFILEToolStripMenuItem.Name = "fORMFILEToolStripMenuItem";
            this.fORMFILEToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fORMFILEToolStripMenuItem.Text = "File";
            // 
            // fORMCreateNewToolStripMenuItem
            // 
            this.fORMCreateNewToolStripMenuItem.Name = "fORMCreateNewToolStripMenuItem";
            this.fORMCreateNewToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fORMCreateNewToolStripMenuItem.Text = "Create new project";
            this.fORMCreateNewToolStripMenuItem.Click += new System.EventHandler(this.CreateNewProject_Click);
            // 
            // fORMLoadProjectToolStripMenuItem
            // 
            this.fORMLoadProjectToolStripMenuItem.Name = "fORMLoadProjectToolStripMenuItem";
            this.fORMLoadProjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fORMLoadProjectToolStripMenuItem.Text = "Load project";
            this.fORMLoadProjectToolStripMenuItem.Click += new System.EventHandler(this.LoadProject_Click);
            // 
            // LoadProjectDialog
            // 
            this.LoadProjectDialog.Filter = "\"Project-JSON|*.json\"";
            // 
            // LV_Projects
            // 
            this.LV_Projects.Location = new System.Drawing.Point(0, 27);
            this.LV_Projects.Name = "LV_Projects";
            this.LV_Projects.Size = new System.Drawing.Size(143, 411);
            this.LV_Projects.TabIndex = 1;
            this.LV_Projects.UseCompatibleStateImageBehavior = false;
            this.LV_Projects.ItemActivate += new System.EventHandler(this.LV_Projects_ItemActivate);
            // 
            // IL_ProjectImages
            // 
            this.IL_ProjectImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.IL_ProjectImages.ImageSize = new System.Drawing.Size(16, 16);
            this.IL_ProjectImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // P_ProjectPanel
            // 
            this.P_ProjectPanel.Location = new System.Drawing.Point(149, 27);
            this.P_ProjectPanel.Name = "P_ProjectPanel";
            this.P_ProjectPanel.Size = new System.Drawing.Size(639, 411);
            this.P_ProjectPanel.TabIndex = 2;
            // 
            // reloadProjectsToolStripMenuItem
            // 
            this.reloadProjectsToolStripMenuItem.Name = "reloadProjectsToolStripMenuItem";
            this.reloadProjectsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reloadProjectsToolStripMenuItem.Text = "Reload projects";
            this.reloadProjectsToolStripMenuItem.Click += new System.EventHandler(this.reloadProjects_Click);
            // 
            // ProgramOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.P_ProjectPanel);
            this.Controls.Add(this.LV_Projects);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ProgramOverview";
            this.Text = "Project Overview";
            this.Load += new System.EventHandler(this.ProgrammOverview_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fORMFILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fORMCreateNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fORMLoadProjectToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog LoadProjectDialog;
        private System.Windows.Forms.ListView LV_Projects;
        private System.Windows.Forms.ImageList IL_ProjectImages;
        private System.Windows.Forms.Panel P_ProjectPanel;
        private System.Windows.Forms.ToolStripMenuItem reloadProjectsToolStripMenuItem;
    }
}