namespace OpenLauncher.Forms
{
    partial class About
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
            this.WB_creditBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // WB_creditBrowser
            // 
            this.WB_creditBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WB_creditBrowser.Location = new System.Drawing.Point(0, 0);
            this.WB_creditBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.WB_creditBrowser.Name = "WB_creditBrowser";
            this.WB_creditBrowser.Size = new System.Drawing.Size(745, 439);
            this.WB_creditBrowser.TabIndex = 0;
            this.WB_creditBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.WB_creditBrowser_Navigating);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 439);
            this.Controls.Add(this.WB_creditBrowser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "About";
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser WB_creditBrowser;
    }
}