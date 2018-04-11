namespace OpenLauncher.Forms.FromControls
{
    partial class ProjectControl
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.B_MainAction = new System.Windows.Forms.Button();
            this.B_OpenSite = new System.Windows.Forms.Button();
            this.LV_Launchables = new System.Windows.Forms.ListView();
            this.TH_starter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.B_OpenFolder = new System.Windows.Forms.Button();
            this.PB_DownloadProgress = new System.Windows.Forms.ProgressBar();
            this.L_Progress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // B_MainAction
            // 
            this.B_MainAction.Location = new System.Drawing.Point(526, 359);
            this.B_MainAction.Name = "B_MainAction";
            this.B_MainAction.Size = new System.Drawing.Size(113, 52);
            this.B_MainAction.TabIndex = 0;
            this.B_MainAction.Text = "B_Action";
            this.B_MainAction.UseVisualStyleBackColor = true;
            this.B_MainAction.Click += new System.EventHandler(this.B_MainAction_Click);
            // 
            // B_OpenSite
            // 
            this.B_OpenSite.Location = new System.Drawing.Point(0, 359);
            this.B_OpenSite.Name = "B_OpenSite";
            this.B_OpenSite.Size = new System.Drawing.Size(97, 52);
            this.B_OpenSite.TabIndex = 1;
            this.B_OpenSite.Text = "Open Website";
            this.B_OpenSite.UseVisualStyleBackColor = true;
            this.B_OpenSite.Click += new System.EventHandler(this.B_OpenSite_Click);
            // 
            // LV_Launchables
            // 
            this.LV_Launchables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TH_starter});
            this.LV_Launchables.Location = new System.Drawing.Point(359, 359);
            this.LV_Launchables.Name = "LV_Launchables";
            this.LV_Launchables.Size = new System.Drawing.Size(161, 49);
            this.LV_Launchables.TabIndex = 3;
            this.LV_Launchables.UseCompatibleStateImageBehavior = false;
            this.LV_Launchables.View = System.Windows.Forms.View.Details;
            this.LV_Launchables.SelectedIndexChanged += new System.EventHandler(this.LV_Launchables_SelectedIndexChanged);
            // 
            // TH_starter
            // 
            this.TH_starter.Text = "Starter";
            // 
            // B_OpenFolder
            // 
            this.B_OpenFolder.Location = new System.Drawing.Point(103, 359);
            this.B_OpenFolder.Name = "B_OpenFolder";
            this.B_OpenFolder.Size = new System.Drawing.Size(75, 52);
            this.B_OpenFolder.TabIndex = 4;
            this.B_OpenFolder.Text = "Open folder";
            this.B_OpenFolder.UseVisualStyleBackColor = true;
            this.B_OpenFolder.Click += new System.EventHandler(this.B_OpenFolder_Click);
            // 
            // PB_DownloadProgress
            // 
            this.PB_DownloadProgress.Location = new System.Drawing.Point(184, 359);
            this.PB_DownloadProgress.Name = "PB_DownloadProgress";
            this.PB_DownloadProgress.Size = new System.Drawing.Size(169, 23);
            this.PB_DownloadProgress.TabIndex = 5;
            // 
            // L_Progress
            // 
            this.L_Progress.Location = new System.Drawing.Point(181, 385);
            this.L_Progress.Name = "L_Progress";
            this.L_Progress.Size = new System.Drawing.Size(172, 23);
            this.L_Progress.TabIndex = 6;
            this.L_Progress.Text = "L_PercentDone";
            this.L_Progress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProjectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.L_Progress);
            this.Controls.Add(this.PB_DownloadProgress);
            this.Controls.Add(this.B_OpenFolder);
            this.Controls.Add(this.LV_Launchables);
            this.Controls.Add(this.B_OpenSite);
            this.Controls.Add(this.B_MainAction);
            this.Name = "ProjectControl";
            this.Size = new System.Drawing.Size(639, 411);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B_MainAction;
        private System.Windows.Forms.Button B_OpenSite;
        private System.Windows.Forms.ListView LV_Launchables;
        private System.Windows.Forms.ColumnHeader TH_starter;
        private System.Windows.Forms.Button B_OpenFolder;
        private System.Windows.Forms.ProgressBar PB_DownloadProgress;
        private System.Windows.Forms.Label L_Progress;
    }
}
