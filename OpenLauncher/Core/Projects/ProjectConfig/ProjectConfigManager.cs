using Newtonsoft.Json;
using OpenLauncher.Core.Helper;
using OpenLauncher.Core.Projects.DataModel;
using OpenLauncher.Core.Settings;
using OpenLauncher.Core.Settings.DataModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace OpenLauncher.Core.Projects
{
    /// <summary>
    /// This class is a manager for all the project relevant data. It will generate all the needed path strings
    /// It will check if the project is ready for download
    /// It will check if you can launch the project locally
    /// </summary>
    public class ProjectConfigManager
    {
        readonly ProjectDataJson _data;
        
        readonly SettingsJson _settings;

        private OpenLauncherSettingJson _launcherSettings;
        public OpenLauncherSettingJson LauncherSettings => _launcherSettings;


        readonly string _openLauncherInfo;
        public string OpenLauncherInfo => _openLauncherInfo;

        readonly string _localProjectConfig;
        public string LocalProjectConfig => _localProjectConfig;

        readonly string _serverProjectConfig;
        public string ServerProjectConfig => _serverProjectConfig;

        readonly string _updateInfo;
        public string UpdateInfo => _updateInfo;

        readonly bool _downloadable;
        public bool Downloadable => _downloadable;

        readonly bool _localLauncherFileAvailable;
        public bool LocalLauncherFileAvailable => _localLauncherFileAvailable;

        /// <summary>
        /// Create a new instance of this class for a project
        /// </summary>
        /// <param name="data">The project file to create an instance of</param>
        public ProjectConfigManager(ProjectDataJson data)
        {
            SettingsManager settingsManager = new SettingsManager();
            settingsManager.Load();
            _settings = settingsManager.Settings;

            _data = data;

            _downloadable = false;

            string baseURL = _data.HomeUrl;
            _openLauncherInfo = baseURL + "/OpenLauncher.json";
            GetOpenLauncherInfo();

            _localProjectConfig = _settings.MainProjectFolder + "\\" + _data.Name + "\\ProjectConfig.json";
            _localLauncherFileAvailable = CheckLocalConfig();
            if (_launcherSettings == null)
            {
                return;
            }

            _serverProjectConfig = baseURL + "/" + _launcherSettings.DownloadMainFolder +  "/ProjectConfig.json";   
            _updateInfo = baseURL + "/" + _launcherSettings.DownloadMainFolder + "/UpdateInfo.json";


            _downloadable = CheckProjectConfig();
            if (Downloadable)
            {
                _downloadable = CheckUpdateInfo();
            }
        }

        /// <summary>
        /// Get all the launchable paths to show in the main window
        /// </summary>
        /// <returns>Returns a list with all the launchables of this project. This will be empty if there is no local file!</returns>
        public List<LaunchableJson> GetLaunchables()
        {
            if (!_localLauncherFileAvailable)
            {
                return new List<LaunchableJson>();
            }
            string projectConfig = _settings.MainProjectFolder + "\\" + _data.Name + "\\ProjectConfig.json";
            if (!File.Exists(projectConfig))
            {
                return new List<LaunchableJson>();
            }

            using (StreamReader reader = new StreamReader(projectConfig))
            {
                try
                {
                    return JsonConvert.DeserializeObject<ProjectConfigJson>(reader.ReadToEnd()).Launchables;
                }
                catch (Exception)
                {
                    return new List<LaunchableJson>();
                }
                
            }
        }

        /// <summary>
        /// Get the basic information from the webserver where the main path can be found containing the project on the server.
        /// </summary>
        private void GetOpenLauncherInfo()
        {
            string openLauncherInfo = _openLauncherInfo.DownloadString();
            try
            {
                _launcherSettings = JsonConvert.DeserializeObject<OpenLauncherSettingJson>(openLauncherInfo);
            }
            catch (Exception)
            {
                _launcherSettings = null;
            }
        }

        /// <summary>
        /// Check the project configuration on the webserver. This will check if the file is available and parsable
        /// </summary>
        /// <returns>Returns true if file is parsable and available</returns>
        private bool CheckProjectConfig()
        {
            string projectConfig = _serverProjectConfig.DownloadString();

            try
            {
                JsonConvert.DeserializeObject<ProjectConfigJson>(projectConfig);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// This will check if there is local configuration file, this will return true if the file is present and parsable
        /// </summary>
        /// <returns>True if the file is parsable and available</returns>
        private bool CheckLocalConfig()
        {
            string localLauncherConfig = "";
            if (!File.Exists(_localProjectConfig))
            {
                return false;
            }
            using (StreamReader reader = new StreamReader(_localProjectConfig))
            {
                localLauncherConfig = reader.ReadToEnd();
            }

            try
            {
                JsonConvert.DeserializeObject<ProjectConfigJson>(localLauncherConfig);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if there is a update info file on the server which is parsable
        /// </summary>
        /// <returns>Returns true if the file is available and parsable</returns>
        private bool CheckUpdateInfo()
        {
            string projectConfig = _updateInfo.DownloadString();

            return projectConfig == string.Empty ? false : true;
        }
    }
}
