using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenLauncher.Core.Projects.DataModel;
using System.Diagnostics;
using OpenLauncher.Core.Template;
using OpenLauncher.Core.Projects;
using System.IO;

namespace OpenLauncher.Forms.FromControls
{
    public partial class ProjectControl : UserControl
    {
        private ProjectDataJSON _data;
        private string _projectFolder;

        private string _currentExecutable;

        public ProjectControl(ProjectDataJSON data)
        {
            InitializeComponent();
            _data = data;

            WB_ProjectMainPage.ScriptErrorsSuppressed = true;
            LV_Launchables.MultiSelect = false;

            if (_data.WebURL != null)
            {
                WB_ProjectMainPage.Url = _data.WebURL;
            }
            else
            {
                WebsiteTemplate templateEngine = new WebsiteTemplate();
                templateEngine.SetTemplateFile("ProjectBasic.html");
                templateEngine.AddReplacement("projectname", data.Name);
                templateEngine.AddReplacement("imgsource", data.ImageUrl);

                WB_ProjectMainPage.DocumentText = templateEngine.Get();
                B_OpenSite.Enabled = false;
            }


            ProjectConfigManager projectConfigManager = new ProjectConfigManager(_data.HomeURL);
            List<LaunchableJSON> launchables = projectConfigManager.getLaunchable();



            if (launchables.Count == 0)
            {
                B_MainAction.Enabled = false;
            }

            if (launchables.Count <= 1)
            {
                LV_Launchables.Visible = false;
                LV_Launchables.Enabled = false;
            }

            foreach (LaunchableJSON launchable in launchables)
            {
                ListViewItem item = new ListViewItem(launchable.DisplayName);
                item.Tag = launchable.Executable;
                LV_Launchables.Items.Add(item);
            }
            if (B_MainAction.Enabled)
            {
                LV_Launchables.Items[0].Selected = true;
            }
            
        }

        private void B_MainAction_Click(object sender, EventArgs e)
        {

            if (File.Exists(_currentExecutable))
            {
                Process.Start(_currentExecutable);
            }
            else
            {

            }
        }

        private void B_OpenSite_Click(object sender, EventArgs e)
        {
            Process.Start(_data.HomeURL);
        }

        private void ProjectControl_Load(object sender, EventArgs e)
        {

        }

        private void LV_Launchables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LV_Launchables.SelectedItems.Count == 0)
            {
                return;
            }
            string executable = LV_Launchables.SelectedItems[0].Tag.ToString();
            _currentExecutable = _projectFolder + "\\" + executable;

            if (File.Exists(_currentExecutable))
            {
                B_MainAction.Text = "Launch";
            }
            else
            {
                B_MainAction.Text = "Download";
            }
        }
    }
}
