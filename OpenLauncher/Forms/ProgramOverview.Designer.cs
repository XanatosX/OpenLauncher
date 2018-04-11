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
            this.MS_MainStrip = new System.Windows.Forms.MenuStrip();
            this.fORMFILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadProjectsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.createNewProjectFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createServerDownloadablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadProjectDialog = new System.Windows.Forms.OpenFileDialog();
            this.LV_Projects = new System.Windows.Forms.ListView();
            this.IL_ProjectImages = new System.Windows.Forms.ImageList(this.components);
            this.P_ProjectPanel = new System.Windows.Forms.Panel();
            this.CMS_projectManagment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MS_MainStrip.SuspendLayout();
            this.CMS_projectManagment.SuspendLayout();
            this.SuspendLayout();
            // 
            // MS_MainStrip
            // 
            this.MS_MainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fORMFILEToolStripMenuItem,
            this.projectToolStripMenuItem});
            this.MS_MainStrip.Location = new System.Drawing.Point(0, 0);
            this.MS_MainStrip.Name = "MS_MainStrip";
            this.MS_MainStrip.Size = new System.Drawing.Size(800, 24);
            this.MS_MainStrip.TabIndex = 0;
            this.MS_MainStrip.Text = "menuStrip1";
            // 
            // fORMFILEToolStripMenuItem
            // 
            this.fORMFILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.fORMFILEToolStripMenuItem.Name = "fORMFILEToolStripMenuItem";
            this.fORMFILEToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fORMFILEToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadProjectToolStripMenuItem,
            this.reloadProjectsToolStripMenuItem1,
            this.toolStripSeparator1,
            this.createNewProjectFileToolStripMenuItem,
            this.createServerDownloadablesToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // loadProjectToolStripMenuItem
            // 
            this.loadProjectToolStripMenuItem.Name = "loadProjectToolStripMenuItem";
            this.loadProjectToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.loadProjectToolStripMenuItem.Text = "Load project";
            this.loadProjectToolStripMenuItem.Click += new System.EventHandler(this.LoadProject_Click);
            // 
            // reloadProjectsToolStripMenuItem1
            // 
            this.reloadProjectsToolStripMenuItem1.Name = "reloadProjectsToolStripMenuItem1";
            this.reloadProjectsToolStripMenuItem1.Size = new System.Drawing.Size(225, 22);
            this.reloadProjectsToolStripMenuItem1.Text = "Reload projects";
            this.reloadProjectsToolStripMenuItem1.Click += new System.EventHandler(this.ReloadProjects_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(222, 6);
            // 
            // createNewProjectFileToolStripMenuItem
            // 
            this.createNewProjectFileToolStripMenuItem.Name = "createNewProjectFileToolStripMenuItem";
            this.createNewProjectFileToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.createNewProjectFileToolStripMenuItem.Text = "Create new project file";
            this.createNewProjectFileToolStripMenuItem.Click += new System.EventHandler(this.CreateNewProject_Click);
            // 
            // createServerDownloadablesToolStripMenuItem
            // 
            this.createServerDownloadablesToolStripMenuItem.Name = "createServerDownloadablesToolStripMenuItem";
            this.createServerDownloadablesToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.createServerDownloadablesToolStripMenuItem.Text = "Create server downloadables";
            this.createServerDownloadablesToolStripMenuItem.Click += new System.EventHandler(this.CreateServerDownloadables_Click);
            // 
            // LoadProjectDialog
            // 
            this.LoadProjectDialog.Filter = "Project-JSON|*.json";
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
            // CMS_projectManagment
            // 
            this.CMS_projectManagment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.CMS_projectManagment.Name = "CMS_projectManagment";
            this.CMS_projectManagment.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // ProgramOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.P_ProjectPanel);
            this.Controls.Add(this.LV_Projects);
            this.Controls.Add(this.MS_MainStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.MS_MainStrip;
            this.Name = "ProgramOverview";
            this.Text = "Open launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgramOverview_FormClosing);
            this.Load += new System.EventHandler(this.ProgrammOverview_Load);
            this.MS_MainStrip.ResumeLayout(false);
            this.MS_MainStrip.PerformLayout();
            this.CMS_projectManagment.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MS_MainStrip;
        private System.Windows.Forms.ToolStripMenuItem fORMFILEToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog LoadProjectDialog;
        private System.Windows.Forms.ListView LV_Projects;
        private System.Windows.Forms.ImageList IL_ProjectImages;
        private System.Windows.Forms.Panel P_ProjectPanel;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadProjectsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem createNewProjectFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createServerDownloadablesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip CMS_projectManagment;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}