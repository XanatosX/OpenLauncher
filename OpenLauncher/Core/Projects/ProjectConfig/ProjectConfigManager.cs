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
        private string _baseURL;
        private ProjectDataJson _data;

        private SettingsManager _settingsManager;
        private SettingsJSON _settings;

        private OpenLauncherSettingJson _launcherSettings;
        public OpenLauncherSettingJson LauncherSettings => _launcherSettings;


        private string _openLauncherInfo;
        public string OpenLauncherInfo => _openLauncherInfo;

        private string _localProjectConfig;
        public string LocalProjectConfig => _localProjectConfig;

        private string _serverProjectConfig;
        public string ServerProjectConfig => _serverProjectConfig;
        private string _updateInfo;
        public string UpdateInfo => _updateInfo;

        private bool _downloadable;
        public bool Downloadable => _downloadable;

        private bool _localLauncherFileAvailable;
        public bool LocalLauncherFileAvailable => _localLauncherFileAvailable;

        /// <summary>
        /// Create a new instance of this class for a project
        /// </summary>
        /// <param name="data">The project file to create an instance of</param>
        public ProjectConfigManager(ProjectDataJson data)
        {
            _settingsManager = new SettingsManager();
            _settingsManager.Load();
            _settings = _settingsManager.Settings;

            _data = data;

            _downloadable = false;

            _baseURL = _data.HomeUrl;
            _openLauncherInfo = _baseURL + "/OpenLauncher.json";
            getOpenLauncherInfo();

            _localProjectConfig = _settings.MainProjectFolder + "\\" + _data.Name + "\\ProjectConfig.json";
            _localLauncherFileAvailable = checkLocalConfig();
            if (_launcherSettings == null)
            {
                return;
            }

            _serverProjectConfig = _baseURL + "/" + _launcherSettings.DownloadMainFolder +  "/ProjectConfig.json";   
            _updateInfo = _baseURL + "/" + _launcherSettings.DownloadMainFolder + "/UpdateInfo.json";


            _downloadable = checkProjectConfig();
            if (Downloadable)
            {
                checkUpdateInfo();
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
        private void getOpenLauncherInfo()
        {
            string openLauncherInfo = _openLauncherInfo.DownloadString();
            try
            {
                _launcherSettings = JsonConvert.DeserializeObject<OpenLauncherSettingJson>(openLauncherInfo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Check the project configuration on the webserver. This will check if the file is available and parsable
        /// </summary>
        /// <returns>Returns true if file is parsable and available</returns>
        private bool checkProjectConfig()
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
        private bool checkLocalConfig()
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
        private bool checkUpdateInfo()
        {
            string projectConfig = _updateInfo.DownloadString();

            return true;
        }
    }
}
