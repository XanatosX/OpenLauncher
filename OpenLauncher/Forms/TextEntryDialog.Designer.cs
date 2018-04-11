namespace OpenLauncher.Forms
{
    partial class TextEntryDialog
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
            this.B_OK = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.L_Text = new System.Windows.Forms.Label();
            this.TB_Text = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // B_OK
            // 
            this.B_OK.Location = new System.Drawing.Point(283, 38);
            this.B_OK.Name = "B_OK";
            this.B_OK.Size = new System.Drawing.Size(75, 23);
            this.B_OK.TabIndex = 0;
            this.B_OK.Text = "OK";
            this.B_OK.UseVisualStyleBackColor = true;
            this.B_OK.Click += new System.EventHandler(this.B_OK_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.Location = new System.Drawing.Point(12, 38);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(75, 23);
            this.B_Cancel.TabIndex = 1;
            this.B_Cancel.Text = "Cancel";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // L_Text
            // 
            this.L_Text.AutoSize = true;
            this.L_Text.Location = new System.Drawing.Point(12, 15);
            this.L_Text.Name = "L_Text";
            this.L_Text.Size = new System.Drawing.Size(31, 13);
            this.L_Text.TabIndex = 2;
            this.L_Text.Text = "Text:";
            // 
            // TB_Text
            // 
            this.TB_Text.Location = new System.Drawing.Point(53, 12);
            this.TB_Text.Name = "TB_Text";
            this.TB_Text.Size = new System.Drawing.Size(305, 20);
            this.TB_Text.TabIndex = 3;
            // 
            // TextEntryDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 73);
            this.Controls.Add(this.TB_Text);
            this.Controls.Add(this.L_Text);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "TextEntryDialog";
            this.Text = "TextEntryDialog";
            this.Shown += new System.EventHandler(this.TextEntryDialog_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_OK;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Label L_Text;
        private System.Windows.Forms.TextBox TB_Text;
    }
}