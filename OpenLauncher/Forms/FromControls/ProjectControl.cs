﻿using System;
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
using OpenLauncher.Core.Updater;
using OpenLauncher.Core.Settings;
using OpenLauncher.Core.Settings.DataModel;

namespace OpenLauncher.Forms.FromControls
{

    public enum ActionButtonMode
    {
        Download,
        Update,
        Launch
    }

    public partial class ProjectControl : UserControl
    {
        private ProjectDataJSON _data;

        private SettingsManager _settingsManager;
        private SettingsJSON _settings;

        private string _projectFolder;

        private string _currentExecutable;

        public ProjectControl(ProjectDataJSON data)
        {
            InitializeComponent();
            _data = data;
            _settingsManager = new SettingsManager();
            _settingsManager.Load();
            _settings = _settingsManager.Settings;

            _projectFolder = _settings.MainProjectFolder + "\\" + _data.Name;


            WB_ProjectMainPage.ScriptErrorsSuppressed = true;
            LV_Launchables.MultiSelect = false;
            LV_Launchables.FullRowSelect = true;
            LV_Launchables.HeaderStyle = ColumnHeaderStyle.None;


            init();
            if (_data.WebURL != null)
            {
                //NOTE find a way to speed up the page loading. Maybe if the web browser is async
                WB_ProjectMainPage.Url = _data.WebURL;
            }
            else
            {
                TemplateInterface templateEngine = new WebsiteTemplate();
                templateEngine.SetTemplateFile("ProjectBasic.html");
                templateEngine.AddReplacement("projectname", data.Name);
                templateEngine.AddReplacement("imgsource", data.ImageUrl);

                WB_ProjectMainPage.DocumentText = templateEngine.Get();
                B_OpenSite.Enabled = false;
            }
            
        }

        private void init()
        {
            ProjectConfigManager projectConfigManager = new ProjectConfigManager(_data);
            List<LaunchableJSON> launchables = projectConfigManager.GetLaunchables();

            B_OpenSite.Enabled = true;
            B_MainAction.Enabled = true;
            B_OpenFolder.Enabled = true;
            LV_Launchables.Visible = true;
            LV_Launchables.Enabled = true;

            PB_DownloadProgress.Visible = false;
            L_Progress.Visible = false;

            LV_Launchables.Items.Clear();

            if (!Directory.Exists(_projectFolder))
            {
                B_OpenFolder.Enabled = false;
            }

            if (launchables.Count == 0)
            {
                B_MainAction.Enabled = false;
                B_MainAction.Visible = false;
                if (projectConfigManager.Downloadable)
                {
                    B_MainAction.Enabled = true;
                    B_MainAction.Visible = true;
                    B_MainAction.Text = "Download";
                    B_MainAction.Tag = ActionButtonMode.Download;
                    LV_Launchables.Visible = false;
                    LV_Launchables.Enabled = false;
                    return;
                }
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

            LV_Launchables.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void B_MainAction_Click(object sender, EventArgs e)
        {
            ActionButtonMode currentMode = ActionButtonMode.Download;
            if (sender.GetType() == typeof(Button))
            {
                Button currentButton = (Button)sender;
                if (currentButton.Tag.GetType() == typeof(ActionButtonMode))
                {
                    currentMode = (ActionButtonMode)currentButton.Tag;
                }
            }

            switch (currentMode)
            {
                case ActionButtonMode.Download:
                    DownloadProject();
                    break;
                case ActionButtonMode.Update:
                    DownloadProject();
                    break;
                case ActionButtonMode.Launch:
                    LaunchProject();
                    break;
                default:
                    break;
            }
        }

        private void DownloadProject()
        {
            B_MainAction.Enabled = false;

            ProjectUpdateManager updater = new ProjectUpdateManager(_data);
            updater.DownloadProgressChanged += Updater_DownloadProgressChanged;
            updater.DownloadComplete += Updater_DownloadComplete;


            if (updater.ReadyForUpdate)
            {
                updater.UpdateAsync();
            }

        }

        private void Updater_DownloadComplete(object sender, EventArgs e)
        {
            PB_DownloadProgress.Value = PB_DownloadProgress.Maximum;
            L_Progress.Text = "Done";
            init();
        }

        private void Updater_DownloadProgressChanged(object sender, Core.Updater.DataModel.Events.StatusChangedData e)
        {
            PB_DownloadProgress.Visible = true;
            L_Progress.Visible = true;
            PB_DownloadProgress.Maximum = e.MaxStatus;
            PB_DownloadProgress.Value = e.NewStatus;

            L_Progress.Text = $"{e.PercentDone}% downloaded";
        }

        private void LaunchProject()
        {

            if (File.Exists(_currentExecutable))
            {
                Process.Start(_currentExecutable);
            }
            else
            {
                MessageBox.Show("Seems like the executable is missing, please check your folder or redownload the project", "Missing executable", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void B_OpenSite_Click(object sender, EventArgs e)
        {
            Process.Start(_data.HomeURL);
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
                if (needUpdate())
                {
                    B_MainAction.Text = "Update";
                    B_MainAction.Tag = ActionButtonMode.Update;
                }
                else
                {
                    B_MainAction.Text = "Launch";
                    B_MainAction.Tag = ActionButtonMode.Launch;
                }
            }
            else
            {
                B_MainAction.Text = "Download";
                B_MainAction.Tag = ActionButtonMode.Download;
            }
        }

        private bool needUpdate()
        {
            ProjectUpdateManager updater = new ProjectUpdateManager(_data);
            return updater.UpdateAvailable();
        }

        private void B_OpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start(_settings.MainProjectFolder + "\\" + _data.Name + "\\");
        }

        private void ProjectControl_Load(object sender, EventArgs e)
        {

        }
    }
}
