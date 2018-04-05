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

        private List<string> _filesToUpdate;

        public ProjectUpdateManager(ProjectDataJSON projectData)
        {
            _filesToUpdate = new List<string>();

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

        public void Update()
        {
            if (!_readyForUpdate)
            {
                triggerErrorEvent("Not ready for update yet!");
                return;
            }

            FileDownloader downloader = new FileDownloader(_projectManager.UpdateInfo);
            string updateInfo = downloader.DownloadString();

            UpdaterConfigJSON updaterConfig = null;
            
            try
            {
                updaterConfig = JsonConvert.DeserializeObject<UpdaterConfigJSON>(updateInfo);
                

            }
            catch (Exception)
            {
                return;
            }
            List<UpdateableFile> onlineFiles = updaterConfig.Files;
            ChecksumCalculator ChecksumCreator = new ChecksumCalculator();
            foreach (UpdateableFile currentOnlineFile in onlineFiles)
            {
                string currentFile = _settings.MainProjectFolder + "\\" + _data.Name + "\\" + currentOnlineFile.Name;
                string localChecksum = ChecksumCreator.GetChecksum(currentFile);

                if (localChecksum != currentOnlineFile.Checksum)
                {
                    DownloadFile(_data.HomeURL + "/" + _projectManager.LauncherSettings.DownloadMainFolder + "/" + currentOnlineFile.Name, currentOnlineFile.Name);
                }
            }
        }

        private void DownloadFile(string URLPath, string fileName)
        {
            FileDownloader downloader = new FileDownloader(URLPath);
            byte[] data = downloader.DownloadBinary();

            FileStream output = File.Create(_settings.MainProjectFolder + "\\" + _data.Name + "\\" + fileName);
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
