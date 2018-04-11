using Newtonsoft.Json;
using OpenLauncher.Core.GlobalEnums;
using OpenLauncher.Core.GlobalEvents;
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
    /// <summary>
    /// This is the manager class for update the project
    /// </summary>
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
        public event EventHandler<ErrorEvent> Error;

        /// <summary>
        /// This will create a a new updater for a project
        /// </summary>
        /// <param name="projectData">This is the dataset for the project to create an updater for</param>
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

        /// <summary>
        /// This will setup all the needed project variables
        /// </summary>
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
                    triggerErrorEvent(ErrorEnum.error ,"Missing rights to create a folder. Please check the user rights for " + projectDirectory.FullName);
                }
            }
            else
            {
                _readyForUpdate = true;
            }
        }

        /// <summary>
        /// This functions checks if there is a local file differenting from the server files
        /// </summary>
        /// <returns>Returns true if one or more checksums are not identical with the server</returns>
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

        /// <summary>
        /// This will update the project async
        /// This will call the following events
        /// DownloadProgressChanged => There was a new file downloaded
        /// DownloadComplete  => All the files are successfully downloaded
        /// </summary>
        public void UpdateAsync()
        {
            _asyncUpdateProvider.RunWorkerAsync();
        }

        /// <summary>
        /// This is the function to start the async update process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _asyncProvider_DoAsyncUpdate(object sender, DoWorkEventArgs e)
        {
            performUpdate(true);
            e.Result = "done";
        }

        /// <summary>
        /// This function will be called if there is a new file downloaded and the status changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">This contains a number of how many files are downloaded, 
        /// how many files must be checked or downloaded and the last file successfully downloaded</param>
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

        /// <summary>
        /// This function will be called if the async update is done
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _asyncUpdateProvider_UpdateCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EventHandler handle = DownloadComplete;
            handle?.Invoke(this, null);
        }

        /// <summary>
        /// This will update the project
        /// </summary>
        public void Update()
        {
            performUpdate();
        }

        /// <summary>
        /// This is the real function for the update process the public functions just refer to this one
        /// </summary>
        /// <param name="async">This can be set to true to send out event updates</param>
        private void performUpdate(bool async = false)
        {
            if (!_readyForUpdate)
            {
                triggerErrorEvent(ErrorEnum.warning, "Not ready for update yet!");
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

        /// <summary>
        /// This will download the file list from the server containing the filename and the checksum
        /// </summary>
        /// <returns>Returns the server instance of the update list</returns>
        private UpdaterConfigJSON getUpdaterConfigJSON()
        {
            string updateInfo = _projectManager.UpdateInfo.DownloadString();

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

        /// <summary>
        /// This function will download a file as binary and save it to the project folder
        /// </summary>
        /// <param name="URLPath">The path to the server file</param>
        /// <param name="fileName">The filenam on the server</param>
        private void DownloadFile(string URLPath, string fileName)
        {
            byte[] data = URLPath.DownloadBinary();

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

        /// <summary>
        /// This function will trigger an error event
        /// </summary>
        /// <param name="errorMessage"></param>
        private void triggerErrorEvent(ErrorEnum errorLevel, string errorMessage)
        {
            EventHandler<ErrorEvent> handler = Error;
            ErrorEvent errorEvent = new ErrorEvent(errorLevel, errorMessage);
            handler?.Invoke(this, null);
        }
    }
}
