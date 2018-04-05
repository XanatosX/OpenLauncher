using Newtonsoft.Json;
using OpenLauncher.Core.Helper;
using OpenLauncher.Core.Projects;
using OpenLauncher.Core.Projects.DataModel;
using OpenLauncher.Core.Settings;
using OpenLauncher.Core.Settings.DataModel;
using OpenLauncher.Core.Updater.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Updater
{
    public class ProjectUpdateManager
    {
        private ProjectDataJSON _data;
        private ProjectConfigManager _projectManager;

        private SettingsManager _settingsManager;
        private SettingsJSON _settings;

        private bool _readyForUpdate;
        public bool ReadyForUpdate => _readyForUpdate;

        public ProjectUpdateManager(ProjectDataJSON projectData)
        {
            _data = projectData;
            _settingsManager = new SettingsManager();

            _projectManager = new ProjectConfigManager(_data);

            _settingsManager.Load();
            _settings = _settingsManager.Settings;

            setupProject();
        }

        private void setupProject()
        {
            DirectoryInfo projectDirectory = new DirectoryInfo(_settings.MainProjectFolder + "\\" + _data.Name);
            if (!projectDirectory.Exists)
            {
                try
                {
                    projectDirectory.Create();
                    _readyForUpdate = true;
                }
                catch (Exception)
                {
                    triggerErrorEvent("Missing rights to create a folder. Please check the user rights for " + projectDirectory.FullName);
                }
            }
            else
            {
                _readyForUpdate = true;
            }
        }

        public bool UpdateAvailable()
        {
            UpdaterConfigJSON serverConfig = getUpdaterConfigJSON();
            if (serverConfig == null)
            {
                return false;
            }
            string baseFolder = _settings.MainProjectFolder + "\\" + _data.Name;
            ChecksumCalculator ChecksumCreator = new ChecksumCalculator();
            foreach (UpdateableFile currentServerFile in serverConfig.Files)
            {
                string localFile = baseFolder + "\\" + currentServerFile.Name;


                string localChecksum = ChecksumCreator.GetChecksum(localFile);
                if (localChecksum != currentServerFile.Checksum)
                {
                    return true;
                }
            }

            return false;
        }

        public void Update()
        {
            if (!_readyForUpdate)
            {
                triggerErrorEvent("Not ready for update yet!");
                return;
            }

            UpdaterConfigJSON updaterConfig = getUpdaterConfigJSON();

            if (updaterConfig == null)
            {
                return;
            }

            List<UpdateableFile> onlineFiles = updaterConfig.Files;
            ChecksumCalculator ChecksumCreator = new ChecksumCalculator();
            foreach (UpdateableFile currentServerFile in onlineFiles)
            {
                string currentFile = _settings.MainProjectFolder + "\\" + _data.Name + "\\" + currentServerFile.Name;
                string localChecksum = ChecksumCreator.GetChecksum(currentFile);

                if (localChecksum != currentServerFile.Checksum)
                {
                    DownloadFile(_data.HomeURL + "/" + _projectManager.LauncherSettings.DownloadMainFolder + "/" + currentServerFile.Name, currentServerFile.Name);
                }
            }
        }

        private UpdaterConfigJSON getUpdaterConfigJSON()
        {
            FileDownloader downloader = new FileDownloader(_projectManager.UpdateInfo);
            string updateInfo = downloader.DownloadString();

            UpdaterConfigJSON updaterConfig = null;

            try
            {
                updaterConfig = JsonConvert.DeserializeObject<UpdaterConfigJSON>(updateInfo);
            }
            catch (Exception)
            {
                return null;
            }
            return updaterConfig;
        }

        private void DownloadFile(string URLPath, string fileName)
        {
            FileDownloader downloader = new FileDownloader(URLPath);
            byte[] data = downloader.DownloadBinary();

            string file = _settings.MainProjectFolder + "\\" + _data.Name + "\\" + fileName;

            FileInfo fi = new FileInfo(file);
            if (!Directory.Exists(fi.DirectoryName))
            {
                Directory.CreateDirectory(fi.DirectoryName);
            }

            FileStream output = File.Create(file);
            using (BinaryWriter writer = new BinaryWriter(output))
            {
                writer.Write(data);
            }
        }

        private void triggerErrorEvent(string errorMessage)
        {

        }
    }
}
