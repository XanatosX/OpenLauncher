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
    /// <summary>
    /// This is the main window form of this application
    /// </summary>
    public partial class ProgramOverview : Form
    {
        private ProjectManager manager;

        /// <summary>
        /// This will create a new instance of this class
        /// </summary>
        public ProgramOverview()
        {
            InitializeComponent();

            LV_Projects.ContextMenuStrip = CMS_projectManagment;

            LV_Projects.AllowDrop = true;
            LV_Projects.DragDrop += LV_Projects_DragDrop;
            LV_Projects.DragEnter += LV_Projects_DragEnter;
        }

        /// <summary>
        /// This will set the mouse effect for the drag and drop functionality
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LV_Projects_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        /// <summary>
        /// This will perform the drop action and add the file to the projects if possible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LV_Projects_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string currentFile in files)
            {
                manager.Add(currentFile);
            }
            manager.Save();
            LoadProjects();
        }

        /// <summary>
        /// This is the function for the create new project button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateNewProject_Click(object sender, EventArgs e)
        {
            NewProject newProject = new NewProject
            {
                StartPosition = FormStartPosition.CenterParent
            };
            newProject.ShowDialog();

            if (newProject.AddProject)
            {
                manager.Add(newProject.ProjectData);
                manager.Save();
                LoadProjects();
            }
        }

        /// <summary>
        /// This is the function to load an project file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadProject_Click(object sender, EventArgs e)
        {
            LoadProjectDialog.ShowDialog();

            manager.Add(LoadProjectDialog.FileName);
            manager.Save();
            LoadProjects();
        }

        /// <summary>
        /// This is the load function of this form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgrammOverview_Load(object sender, EventArgs e)
        {
            LV_Projects.Activation = ItemActivation.OneClick;

            manager = new ProjectManager();
            LoadProjects();
        }

        /// <summary>
        /// This function will load all the availables projects and set the up in the form
        /// </summary>
        private void LoadProjects()
        {
            manager.Load();

            IL_ProjectImages.Images.Clear();
            LV_Projects.Items.Clear();
            IL_ProjectImages.ImageSize = new Size(64, 64);
            LV_Projects.LargeImageList = IL_ProjectImages;

            for (int i = 0; i < manager.Projects.Count; i++)
            {
                ProjectDataJson currentProject = manager.Projects[i];
                if (currentProject.DisplayImage != null)
                {
                    IL_ProjectImages.Images.Add(currentProject.DisplayImage);
                }

                ListViewItem item = new ListViewItem(currentProject.Name)
                {
                    Tag = currentProject,
                    ImageIndex = i
                };
                LV_Projects.Items.Add(item);

            }
        }

        /// <summary>
        /// This function will be triggered if you select a new project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LV_Projects_ItemActivate(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(ListView))
            {
                ListView listView = (ListView)sender;
                ListViewItem item = listView.SelectedItems[0];
                if (item.Tag.GetType() == typeof(ProjectDataJson))
                {
                    P_ProjectPanel.Controls.Clear();
                    ProjectDataJson projectData = (ProjectDataJson)item.Tag;

                    ProjectControl projectController = new ProjectControl(projectData);
                    P_ProjectPanel.Controls.Add(projectController);
                }
            }
        }

        /// <summary>
        /// This will reload all the projects
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReloadProjects_Click(object sender, EventArgs e)
        {
            LoadProjects();
        }

        /// <summary>
        /// This will show the settings form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings SettingForm = new Settings
            {
                StartPosition = FormStartPosition.CenterParent
            };
            SettingForm.ShowDialog();
        }

        /// <summary>
        /// This will allow you to create a new server file folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateServerDownloadables_Click(object sender, EventArgs e)
        {
            CreateServerDownloadable serverDownloadableForm = new CreateServerDownloadable
            {
                StartPosition = FormStartPosition.CenterParent
            };

            serverDownloadableForm.ShowDialog();
        }

        /// <summary>
        /// This will delete a project from the overview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LV_Projects.SelectedItems.Count > 0)
            {
                ListViewItem item = LV_Projects.SelectedItems[0];
                if (item.Tag.GetType() == typeof(ProjectDataJson))
                {
                    ProjectDataJson data = (ProjectDataJson)item.Tag;
                    manager.Remove(data.Guid);
                    manager.Save();
                    P_ProjectPanel.Controls.Clear();
                }
                    
                LV_Projects.SelectedItems[0].Remove();
            }
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About credits = new About();
            credits.StartPosition = FormStartPosition.CenterParent;

            credits.ShowDialog();
        }
    }
}
