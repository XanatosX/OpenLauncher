using OpenLauncher.Core.Projects.DataModel;
using OpenLauncher.Core.Updater;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenLauncher.Forms
{
    /// <summary>
    /// This form will allow oyu to create a downloadable folder for the server 
    /// </summary>
    public partial class CreateServerDownloadable : Form
    {
        /// <summary>
        /// This will create a new instance of the class
        /// </summary>
        public CreateServerDownloadable()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This button event will create a new downloadable and open up the folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_CreateAndOpen_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(TB_OutputFolder.Text))
            {
                Process.Start(TB_OutputFolder.Text);
            }
            B_Create.PerformClick();
        }

        /// <summary>
        /// This button will close the form without any adjustments
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// This will create the create the checksums and start coping the files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Create_Click(object sender, EventArgs e)
        {
            string inputFolder = TB_InputFolder.Text;
            string outputFolder = TB_OutputFolder.Text;

            DirectoryInfo inputFolderInfo = new DirectoryInfo(inputFolder);
            if (!inputFolderInfo.Exists)
            {
                MessageBox.Show($"The given input folder {inputFolder} is not existing", "Input folder not existing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CreateDownloadableManager createDownloadable = new CreateDownloadableManager(inputFolder, outputFolder);
            if (!createDownloadable.CreateServerData())
            {
                MessageBox.Show($"The was an error while processing the input folder!", "Error while creating server data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CreateProjectConfig projectConfig = null;
            if (DialogResult.Yes == MessageBox.Show("Do you want to create the project config as well?", "Create project config", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                projectConfig = new CreateProjectConfig(inputFolder)
                {
                    StartPosition = FormStartPosition.CenterParent
                };

                projectConfig.ShowDialog();

            }

            ProjectConfigJson dataJSON = null;
            if (projectConfig != null)
            {
                dataJSON = projectConfig.ProjectConfigJSON;
            }

            createDownloadable.SaveServerData(dataJSON);

            B_Close.PerformClick();
        }

        /// <summary>
        /// This will allow you to select an input folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_SelectInputFolder_Click(object sender, EventArgs e)
        {
            FBD_SelectFolder.ShowDialog();
            TB_InputFolder.Text = FBD_SelectFolder.SelectedPath;
        }

        /// <summary>
        /// This will allow you to select the output folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_SelectTargetFolder_Click(object sender, EventArgs e)
        {
            FBD_SelectFolder.ShowDialog();
            TB_OutputFolder.Text = FBD_SelectFolder.SelectedPath;
        }
    }
}
