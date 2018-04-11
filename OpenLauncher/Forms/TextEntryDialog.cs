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

        /// <summary>
        /// This will create a new instance of the input form. 
        /// </summary>
        /// <param name="dialogName">This is the name of the window</param>
        /// <param name="preset">This is the default value of the textbox on the input form</param>
        public TextEntryDialog(string dialogName, string preset)
        {
            InitializeComponent();
            Text = dialogName;
            _textEntered = false;
            TB_Text.Text = preset;
        }

        /// <summary>
        /// This will abort the data entering
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// This will send the form with the entered text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// This will be triggerd if the form is shown the first time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextEntryDialog_Shown(object sender, EventArgs e)
        {
            TB_Text.SelectionStart = 0;
            TB_Text.SelectionLength = TB_Text.Text.Length;
        }
    }
}
