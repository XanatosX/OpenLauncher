using OpenLauncher.Core.Projects.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenLauncher.Forms
{
    /// <summary>
    /// This form will allow you to create a ProjectConfiguration file for the server
    /// </summary>
    public partial class CreateProjectConfig : Form
    {
        readonly string _baseFolder;

        private ProjectConfigJson _projectConfigJson;
        public ProjectConfigJson ProjectConfigJson => _projectConfigJson;

        /// <summary>
        /// This will create a new instance of this form
        /// </summary>
        /// <param name="baseFolder">This is the base folder (The input folder for creating the server files)</param>
        public CreateProjectConfig(string baseFolder)
        {
            InitializeComponent();

            _baseFolder = baseFolder;
        }

        /// <summary>
        /// This function will setup the drag and drop functionality
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateProjectConfig_Load(object sender, EventArgs e)
        {
            LV_Executables.AllowDrop = true;
            LV_Executables.DragDrop += ListView1_DragDrop;
            LV_Executables.DragEnter += ListView1_DragEnter;

            LV_Executables.FullRowSelect = true;
            LV_Executables.ContextMenuStrip = CMS_ItemSelect;
            LV_Executables.MultiSelect = false;
        }

        /// <summary>
        /// This will handle the drag and drop effect shown on the mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        /// <summary>
        /// Handles the drag and drop event on the listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string currentFile in files)
            {
                string fileToUse = currentFile.Replace(_baseFolder + "\\", "");
                fileToUse = fileToUse.Replace("\\", "/");
                ListViewItem item = new ListViewItem(fileToUse);

                FileInfo fi = new FileInfo(currentFile);
                string launchName = fi.Name;
                launchName = launchName.Replace(fi.Extension, "");

                item.SubItems.Add(launchName);
                LV_Executables.Items.Add(item);
            }
            LV_Executables.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        /// <summary>
        /// This will show the right click menu if you click on one of the entries in the list view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LV_Executables_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (LV_Executables.FocusedItem.Bounds.Contains(e.Location))
                {
                    CMS_ItemSelect.Show(Cursor.Position);
                }
            }
        }

        /// <summary>
        /// This is the rename button in the context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSMI_Rename_Click(object sender, EventArgs e)
        {
            if (LV_Executables.SelectedItems.Count == 0)
            {
                return;
            }

            ListViewItem item = LV_Executables.SelectedItems[0];

            string executable = item.Text;

            TextEntryDialog RenameDialog = new TextEntryDialog($"Add new name for {executable}", item.SubItems[1].Text);
            RenameDialog.ShowDialog();

            if (RenameDialog.TextEntered)
            {
                item.SubItems[1].Text = RenameDialog.EnteredText;
            }
           
        }

        /// <summary>
        /// This function will delete the currently selected entrie in the list view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSMI_Delete_Click(object sender, EventArgs e)
        {
            if (LV_Executables.SelectedItems.Count > 0)
            {
                LV_Executables.SelectedItems[0].Remove();
            }
            
        }

        /// <summary>
        /// This is the event for the done button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Done_Click(object sender, EventArgs e)
        {
            _projectConfigJson = new ProjectConfigJson();
            foreach (ListViewItem item in LV_Executables.Items)
            {
                LaunchableJson launchableJSON = new LaunchableJson
                {
                    DisplayName = item.SubItems[1].Text,
                    Executable = item.Text
                };

                _projectConfigJson.Launchables.Add(launchableJSON);
            }

            this.Close();
        }
    }
}
