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
    public partial class NewProject : Form
    {
        public NewProject()
        {
            InitializeComponent();
        }

        private void B_Save_Click(object sender, EventArgs e)
        {
            ProjectDataJSON jsonData = new ProjectDataJSON()
            {
                Name = TB_ProjectName.Text,
                ImageUrl = TB_ImageURL.Text,
                HomeURL = TB_ProjectHomeURL.Text,
            };
            string saveString = JsonConvert.SerializeObject(jsonData,Formatting.Indented);
            SaveProject.ShowDialog();
            using (StreamWriter writer = new StreamWriter(SaveProject.FileName))
            {
                writer.Write(saveString);
            }
            this.Close();

        }

        private void NewProject_Load(object sender, EventArgs e)
        {

        }
    }
}
