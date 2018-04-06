using OpenLauncher.Core.Projects;
using OpenLauncher.Core.Projects.DataModel;
using OpenLauncher.Forms.FromControls;
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
    public partial class ProgramOverview : Form
    {
        private ProjectManager manager;

        public ProgramOverview()
        {
            InitializeComponent();

            LV_Projects.ContextMenuStrip = CMS_projectManagment;

            LV_Projects.AllowDrop = true;
            LV_Projects.DragDrop += LV_Projects_DragDrop;
            LV_Projects.DragEnter += LV_Projects_DragEnter;
        }

        private void LV_Projects_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void LV_Projects_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string currentFile in files)
            {
                manager.Add(currentFile);
            }
            manager.Save();
            loadProjects();
        }

        private void CreateNewProject_Click(object sender, EventArgs e)
        {
            NewProject newProject = new NewProject();
            newProject.StartPosition = FormStartPosition.CenterParent;
            newProject.ShowDialog();

            if (newProject.AddProject)
            {
                manager.Add(newProject.ProjectData);
                manager.Save();
                loadProjects();
            }
        }

        private void LoadProject_Click(object sender, EventArgs e)
        {
            LoadProjectDialog.ShowDialog();

            manager.Add(LoadProjectDialog.FileName);
            manager.Save();
            loadProjects();
        }

        private void ProgrammOverview_Load(object sender, EventArgs e)
        {
            LV_Projects.Activation = ItemActivation.OneClick;

            manager = new ProjectManager();
            loadProjects();
        }

        private void loadProjects()
        {
            manager.Load();

            IL_ProjectImages.Images.Clear();
            LV_Projects.Items.Clear();
            IL_ProjectImages.ImageSize = new Size(64, 64);
            LV_Projects.LargeImageList = IL_ProjectImages;

            for (int i = 0; i < manager.Projects.Count; i++)
            {
                ProjectDataJSON currentProject = manager.Projects[i];
                if (currentProject.DisplayImage != null)
                {
                    IL_ProjectImages.Images.Add(currentProject.DisplayImage);
                }
                

                ListViewItem item = new ListViewItem(currentProject.Name);
                item.Tag = currentProject;
                item.ImageIndex = i;
                LV_Projects.Items.Add(item);

            }
        }

        private void LV_Projects_ItemActivate(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(ListView))
            {
                ListView listView = (ListView)sender;
                ListViewItem item = listView.SelectedItems[0];
                if (item.Tag.GetType() == typeof(ProjectDataJSON))
                {
                    P_ProjectPanel.Controls.Clear();
                    ProjectDataJSON projectData = (ProjectDataJSON)item.Tag;

                    ProjectControl projectController = new ProjectControl(projectData);
                    P_ProjectPanel.Controls.Add(projectController);
                }
            }
        }

        private void reloadProjects_Click(object sender, EventArgs e)
        {
            loadProjects();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings SettingForm = new Settings();
            SettingForm.StartPosition = FormStartPosition.CenterParent;
            SettingForm.ShowDialog();
        }

        private void CreateServerDownloadables_Click(object sender, EventArgs e)
        {
            CreateServerDownloadable serverDownloadableForm = new CreateServerDownloadable();
            serverDownloadableForm.StartPosition = FormStartPosition.CenterParent;

            serverDownloadableForm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LV_Projects.SelectedItems.Count > 0)
            {
                ListViewItem item = LV_Projects.SelectedItems[0];
                if (item.Tag.GetType() == typeof(ProjectDataJSON))
                {
                    ProjectDataJSON data = (ProjectDataJSON)item.Tag;
                    manager.Remove(data.GUID);
                    manager.Save();
                    P_ProjectPanel.Controls.Clear();
                }
                    
                
                LV_Projects.SelectedItems[0].Remove();
            }
        }
    }
}
