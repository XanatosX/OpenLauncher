using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenLauncher.Forms
{
    public partial class TextEntryDialog : Form
    {
        private string _enteredText;
        public string EnteredText => _enteredText;

        private bool _textEntered;
        public bool TextEntered => _textEntered;

        public TextEntryDialog(string dialogName, string preset = "")
        {
            InitializeComponent();
            Text = dialogName;
            _textEntered = false;
            TB_Text.Text = preset;

            
        }

        private void B_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void B_OK_Click(object sender, EventArgs e)
        {
            if (TB_Text.Text == string.Empty)
            {
                B_Cancel.PerformClick();
            }

            _enteredText = TB_Text.Text;
            _textEntered = true;

            this.Close();
        }

        private void TextEntryDialog_Shown(object sender, EventArgs e)
        {
            TB_Text.SelectionStart = 0;
            TB_Text.SelectionLength = TB_Text.Text.Length;
        }

        private void TextEntryDialog_Load(object sender, EventArgs e)
        {
        }
    }
}
