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
    public class ProjectConfigManager
    {
        private string _baseURL;
        private ProjectDataJSON _data;

        private SettingsManager _settingsManager;
        private SettingsJSON _settings;

        private OpenLauncherSettingJSON _launcherSettings;
        public OpenLauncherSettingJSON LauncherSettings => _launcherSettings;


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


        public ProjectConfigManager(ProjectDataJSON data)
        {
            _settingsManager = new SettingsManager();
            _settingsManager.Load();
            _settings = _settingsManager.Settings;

            _data = data;

            _downloadable = false;

            _baseURL = _data.HomeURL;
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

        public List<LaunchableJSON> GetLaunchables()
        {
            if (!_localLauncherFileAvailable)
            {
                return new List<LaunchableJSON>();
            }
            string projectConfig = _settings.MainProjectFolder + "\\" + _data.Name + "\\ProjectConfig.json";
            if (!File.Exists(projectConfig))
            {
                return new List<LaunchableJSON>();
            }

            using (StreamReader reader = new StreamReader(projectConfig))
            {
                try
                {
                    return JsonConvert.DeserializeObject<ProjectConfigJSON>(reader.ReadToEnd()).Launchables;
                }
                catch (Exception)
                {
                    return new List<LaunchableJSON>();
                }
                
            }
        }

        private void getOpenLauncherInfo()
        {
            FileDownloader downloader = new FileDownloader(_openLauncherInfo);
            string openLauncherInfo = downloader.DownloadString();
            try
            {
                _launcherSettings = JsonConvert.DeserializeObject<OpenLauncherSettingJSON>(openLauncherInfo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool checkProjectConfig()
        {
            FileDownloader downloader = new FileDownloader(_serverProjectConfig);
            string projectConfig = downloader.DownloadString();

            try
            {
                JsonConvert.DeserializeObject<ProjectConfigJSON>(projectConfig);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool checkLocalConfig()
        {
            string localLauncherConfig = "";
            using (StreamReader reader = new StreamReader(_localProjectConfig))
            {
                localLauncherConfig = reader.ReadToEnd();
            }

            try
            {
                JsonConvert.DeserializeObject<ProjectConfigJSON>(localLauncherConfig);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool checkUpdateInfo()
        {
            FileDownloader downloader = new FileDownloader(_updateInfo);
            string projectConfig = downloader.DownloadString();

            return true;
        }
    }
}
