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
            this.WB_ProjectMainPage = new System.Windows.Forms.WebBrowser();
            this.LV_Launchables = new System.Windows.Forms.ListView();
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
            this.B_OpenSite.Location = new System.Drawing.Point(0, 388);
            this.B_OpenSite.Name = "B_OpenSite";
            this.B_OpenSite.Size = new System.Drawing.Size(97, 23);
            this.B_OpenSite.TabIndex = 1;
            this.B_OpenSite.Text = "Open Website";
            this.B_OpenSite.UseVisualStyleBackColor = true;
            this.B_OpenSite.Click += new System.EventHandler(this.B_OpenSite_Click);
            // 
            // WB_ProjectMainPage
            // 
            this.WB_ProjectMainPage.Location = new System.Drawing.Point(0, 0);
            this.WB_ProjectMainPage.MinimumSize = new System.Drawing.Size(20, 20);
            this.WB_ProjectMainPage.Name = "WB_ProjectMainPage";
            this.WB_ProjectMainPage.Size = new System.Drawing.Size(636, 353);
            this.WB_ProjectMainPage.TabIndex = 2;
            // 
            // LV_Launchables
            // 
            this.LV_Launchables.Location = new System.Drawing.Point(359, 359);
            this.LV_Launchables.Name = "LV_Launchables";
            this.LV_Launchables.Size = new System.Drawing.Size(161, 49);
            this.LV_Launchables.TabIndex = 3;
            this.LV_Launchables.UseCompatibleStateImageBehavior = false;
            this.LV_Launchables.View = System.Windows.Forms.View.List;
            this.LV_Launchables.SelectedIndexChanged += new System.EventHandler(this.LV_Launchables_SelectedIndexChanged);
            // 
            // ProjectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LV_Launchables);
            this.Controls.Add(this.WB_ProjectMainPage);
            this.Controls.Add(this.B_OpenSite);
            this.Controls.Add(this.B_MainAction);
            this.Name = "ProjectControl";
            this.Size = new System.Drawing.Size(639, 411);
            this.Load += new System.EventHandler(this.ProjectControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B_MainAction;
        private System.Windows.Forms.Button B_OpenSite;
        private System.Windows.Forms.WebBrowser WB_ProjectMainPage;
        private System.Windows.Forms.ListView LV_Launchables;
    }
}
