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
    public partial class CreateProjectConfig : Form
    {
        private string _baseFolder;

        private ProjectConfigJSON _projectConfigJSON;
        public ProjectConfigJSON ProjectConfigJSON => _projectConfigJSON;

        public CreateProjectConfig(string baseFolder)
        {
            InitializeComponent();

            _baseFolder = baseFolder;
        }

        private void CreateProjectConfig_Load(object sender, EventArgs e)
        {
            LV_Executables.AllowDrop = true;
            LV_Executables.DragDrop += ListView1_DragDrop;
            LV_Executables.DragEnter += ListView1_DragEnter;

            LV_Executables.FullRowSelect = true;
            LV_Executables.ContextMenuStrip = CMS_ItemSelect;
            LV_Executables.MultiSelect = false;
        }

        private void ListView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

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

        private void LV_Executables_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (LV_Executables.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    CMS_ItemSelect.Show(Cursor.Position);
                }
            }
        }

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

        private void TSMI_Delete_Click(object sender, EventArgs e)
        {
            if (LV_Executables.SelectedItems.Count > 0)
            {
                LV_Executables.SelectedItems[0].Remove();
            }
            
        }

        private void B_Done_Click(object sender, EventArgs e)
        {
            _projectConfigJSON = new ProjectConfigJSON();
            foreach (ListViewItem item in LV_Executables.Items)
            {
                LaunchableJSON launchableJSON = new LaunchableJSON();
                launchableJSON.DisplayName = item.SubItems[1].Text;
                launchableJSON.Executable = item.Text;

                _projectConfigJSON.Launchables.Add(launchableJSON);
            }

            this.Close();
        }
    }
}
