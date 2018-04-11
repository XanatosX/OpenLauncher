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
using Newtonsoft.Json;
using System.IO;

namespace OpenLauncher.Forms
{
    /// <summary>
    /// This form will create a new project file, ready to use with the launcher
    /// </summary>
    public partial class NewProject : Form
    {
        private bool _addProject;
        public bool AddProject => _addProject;

        private ProjectDataJson _projectData;
        public ProjectDataJson ProjectData => _projectData;

        /// <summary>
        /// This will create a new instance of this class
        /// </summary>
        public NewProject()
        {
            InitializeComponent();
            _addProject = false;
            _projectData = null;
        }

        /// <summary>
        /// This will show up the save dialog and create the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Save_Click(object sender, EventArgs e)
        {
            _addProject = CB_AddProject.Checked;
            ProjectDataJson jsonData = new ProjectDataJson()
            {
                Name = TB_ProjectName.Text,
                ImageUrl = TB_ImageURL.Text,
                HomeUrl = TB_ProjectHomeURL.Text,
            };

            if (_addProject)
            {
                _projectData = jsonData;
            }

            string saveString = JsonConvert.SerializeObject(jsonData,Formatting.Indented);
            SaveProject.ShowDialog();
            using (StreamWriter writer = new StreamWriter(SaveProject.FileName))
            {
                writer.Write(saveString);
            }
            this.Close();

        }
    }
}
