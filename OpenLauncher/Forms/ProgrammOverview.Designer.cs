namespace OpenLauncher.Forms
{
    partial class ProgrammOverview
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
            this.fORMLoadProjectToolStripMenuItem});
            this.fORMFILEToolStripMenuItem.Name = "fORMFILEToolStripMenuItem";
            this.fORMFILEToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.fORMFILEToolStripMenuItem.Text = "FORM_FILE";
            // 
            // fORMCreateNewToolStripMenuItem
            // 
            this.fORMCreateNewToolStripMenuItem.Name = "fORMCreateNewToolStripMenuItem";
            this.fORMCreateNewToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fORMCreateNewToolStripMenuItem.Text = "FORM_CreateNew";
            this.fORMCreateNewToolStripMenuItem.Click += new System.EventHandler(this.CreateNewProject_Click);
            // 
            // fORMLoadProjectToolStripMenuItem
            // 
            this.fORMLoadProjectToolStripMenuItem.Name = "fORMLoadProjectToolStripMenuItem";
            this.fORMLoadProjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fORMLoadProjectToolStripMenuItem.Text = "FORM_LoadProject";
            this.fORMLoadProjectToolStripMenuItem.Click += new System.EventHandler(this.LoadProject_Click);
            // 
            // LoadProjectDialog
            // 
            this.LoadProjectDialog.Filter = "\"Project-JSON|*.json\"";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(0, 27);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(172, 411);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ProgrammOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ProgrammOverview";
            this.Text = "ProjecOverview";
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
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
    }
}