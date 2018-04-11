using Newtonsoft.Json;
using OpenLauncher.Core.Helper;
using OpenLauncher.Core.Projects.DataModel;
using OpenLauncher.Core.Updater.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Updater
{
    /// <summary>
    /// This class will create a the server files from a project.
    /// </summary>
    public class CreateDownloadableManager
    {
        private string _inputFolder;
        private string _outputFolder;

        private UpdaterConfigJSON _updateConfiguration;

        /// <summary>
        /// Create a new instance of this class
        /// </summary>
        /// <param name="input">The path to the folder containing the base files</param>
        /// <param name="output">The path to the folder to put the finished ready to upload files to</param>
        public CreateDownloadableManager(string input, string output)
        {
            _inputFolder = input;
            _outputFolder = output;
            
            _updateConfiguration = new UpdaterConfigJSON();
        }

        /// <summary>
        /// This will get all the files recursive in the root directory
        /// </summary>
        /// <param name="root"></param>
        /// <returns>Returns a list with all the files</returns>
        private List<string> getAllFiles(string root)
        {
            DirectoryInfo directoryData = new DirectoryInfo(root);
            List<string> filesToReturn = new List<string>();

            foreach (FileInfo currentFile in directoryData.GetFiles())
            {
                string file = currentFile.FullName;
                file = file.Replace(_inputFolder + "\\", "");
                file = file.Replace("\\", "/");

                filesToReturn.Add(file);
            }

            foreach (DirectoryInfo currentDirectory in directoryData.GetDirectories())
            {
                filesToReturn.AddRange(getAllFiles(currentDirectory.FullName));
            }

            return filesToReturn;
        }

        /// <summary>
        /// This function will generate all the needed data to save and copy the server data to the output folder
        /// </summary>
        /// <returns>Returns true if there was no error</returns>
        public bool CreateServerData()
        {
            List<string> files = getAllFiles(_inputFolder);

            foreach (string currentFile in files)
            {
                UpdateableFile updateableFile = new UpdateableFile();
                updateableFile.Name = currentFile;
                string currentLocalFile = _inputFolder + "\\" + currentFile;
                updateableFile.Checksum = currentLocalFile.GetChecksum();

                _updateConfiguration.Files.Add(updateableFile);
            }

            return true;
        }

        /// <summary>
        /// This will finaly copy all the data you need for the server
        /// </summary>
        /// <param name="projectConfig">This is the project configuration file containing all the launchables.</param>
        public void SaveServerData(ProjectConfigJSON projectConfig = null)
        {
            CopyFiles();

            if (projectConfig != null)
            {
                saveProjectConfig(projectConfig);
            }

            saveUpdateInfo();
        }

        /// <summary>
        /// This will save the project config file and add it to the update info file
        /// </summary>
        /// <param name="projectConfig"></param>
        private void saveProjectConfig(ProjectConfigJSON projectConfig)
        {
            string dataToSave = JsonConvert.SerializeObject(projectConfig);
            string fileName = _outputFolder + "\\" + "ProjectConfig.json";

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.Write(dataToSave);
            }

            string newFilename = fileName.Replace(_outputFolder + "\\", "");

            UpdateableFile updateableFile = new UpdateableFile();
            updateableFile.Name = newFilename;
            updateableFile.Checksum = fileName.GetChecksum();

            _updateConfiguration.Files.Add(updateableFile);
        }

        /// <summary>
        /// This functions copies all the files from the input to the output folder.
        /// </summary>
        private void CopyFiles()
        {
            foreach (UpdateableFile currentUpdateFile in _updateConfiguration.Files)
            {
                string copyInput = _inputFolder + "\\" + currentUpdateFile.Name;
                string copyOutput = _outputFolder + "\\" + currentUpdateFile.Name;
                FileInfo fi = new FileInfo(copyOutput);
                if (!Directory.Exists(fi.DirectoryName))
                {
                    Directory.CreateDirectory(fi.DirectoryName);
                }
                File.Copy(copyInput, copyOutput, true);
            }
        }

        /// <summary>
        /// This function will save the update info file
        /// </summary>
        private void saveUpdateInfo()
        {
            string dataToSave = JsonConvert.SerializeObject(_updateConfiguration, Formatting.Indented);
            _updateConfiguration = new UpdaterConfigJSON();
            string fileName = _outputFolder + "\\" + "UpdateInfo.json";

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.Write(dataToSave);
            }
        }
    }
}
