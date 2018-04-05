using OpenLauncher.Core.Projects;
using OpenLauncher.Core.Projects.DataModel;
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
    public partial class ProgrammOverview : Form
    {
        private ProjectManager manager;

        public ProgrammOverview()
        {
            InitializeComponent();
        }

        private void CreateNewProject_Click(object sender, EventArgs e)
        {
            NewProject newProject = new NewProject();
            newProject.StartPosition = FormStartPosition.CenterParent;
            newProject.ShowDialog();
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
            manager = new ProjectManager();
            loadProjects();
        }

        private void loadProjects()
        {
            manager.Load();

            imageList1.Images.Clear();
            imageList1.ImageSize = new Size(64, 64);
            listView1.LargeImageList = imageList1;

            for (int i = 0; i < manager.Projects.Count; i++)
            {
                ProjectDataJSON currentProject = manager.Projects[i];
                imageList1.Images.Add(currentProject.DisplayImage);

                ListViewItem item = new ListViewItem(currentProject.Name);
                item.Tag = currentProject;
                item.ImageIndex = i;
                listView1.Items.Add(item);

            }
        }
    }
}
