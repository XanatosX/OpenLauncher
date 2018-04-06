using Newtonsoft.Json;
using OpenLauncher.Core.Helper;
using OpenLauncher.Core.Projects;
using OpenLauncher.Core.Projects.DataModel;
using OpenLauncher.Core.Settings;
using OpenLauncher.Core.Settings.DataModel;
using OpenLauncher.Core.Updater.DataModel;
using OpenLauncher.Core.Updater.DataModel.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private BackgroundWorker _asyncUpdateProvider;
        private int _lastUpdateState;
        private int _maxUpdateStatus;

        public event EventHandler<StatusChangedData> DownloadProgressChanged;
        public event EventHandler DownloadComplete;
        public event EventHandler Error;


        public ProjectUpdateManager(ProjectDataJSON projectData)
        {
            _data = projectData;
            _settingsManager = new SettingsManager();

            _projectManager = new ProjectConfigManager(_data);

            _settingsManager.Load();
            _settings = _settingsManager.Settings;

            _asyncUpdateProvider = new BackgroundWorker();
            _asyncUpdateProvider.DoWork += _asyncProvider_DoAsyncUpdate;
            _asyncUpdateProvider.WorkerReportsProgress = true;
            _asyncUpdateProvider.ProgressChanged += _asyncUpdateProvider_UpdateStatusChanged;
            _asyncUpdateProvider.RunWorkerCompleted += _asyncUpdateProvider_UpdateCompleted;

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

        public void UpdateAsync()
        {
            _asyncUpdateProvider.RunWorkerAsync();
        }


        private void _asyncProvider_DoAsyncUpdate(object sender, DoWorkEventArgs e)
        {
            performUpdate(true);
            e.Result = "done";
        }

        private void _asyncUpdateProvider_UpdateStatusChanged(object sender, ProgressChangedEventArgs e)
        {
            int currentStatus = e.ProgressPercentage;
            UpdateableFile currentFile = null;

            if (e.UserState.GetType() == typeof(UpdateableFile))
            {
                currentFile = (UpdateableFile)e.UserState;
            }

            StatusChangedData dataSet = new StatusChangedData(_lastUpdateState, currentStatus, _maxUpdateStatus, currentFile);
            EventHandler<StatusChangedData> handle = DownloadProgressChanged;
            handle?.Invoke(this, dataSet);


            _lastUpdateState = currentStatus;
        }

        private void _asyncUpdateProvider_UpdateCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EventHandler handle = DownloadComplete;
            handle?.Invoke(this, null);
        }

        public void Update()
        {
            performUpdate();
        }

        private void performUpdate(bool async = false)
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
            int currentCount = 0;
            _maxUpdateStatus = onlineFiles.Count;
            foreach (UpdateableFile currentServerFile in onlineFiles)
            {
                string currentFile = _settings.MainProjectFolder + "\\" + _data.Name + "\\" + currentServerFile.Name;
                string localChecksum = ChecksumCreator.GetChecksum(currentFile);

                if (localChecksum != currentServerFile.Checksum)
                {
                    DownloadFile(_data.HomeURL + "/" + _projectManager.LauncherSettings.DownloadMainFolder + "/" + currentServerFile.Name, currentServerFile.Name);
                    if (async)
                    {
                        _asyncUpdateProvider.ReportProgress(currentCount, currentServerFile);
                    }
                }
                currentCount++;
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
