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
    public class CreateDownloadableManager
    {
        private string _inputFolder;
        private string _outputFolder;

        private UpdaterConfigJSON _updateConfiguration;

        private ChecksumCalculator _checksumCalculator;

        public CreateDownloadableManager(string input, string output)
        {
            _inputFolder = input;
            _outputFolder = output;

            _checksumCalculator = new ChecksumCalculator();
            _updateConfiguration = new UpdaterConfigJSON();
        }

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

        public bool CreateServerData()
        {
            List<string> files = getAllFiles(_inputFolder);

            foreach (string currentFile in files)
            {
                UpdateableFile updateableFile = new UpdateableFile();
                updateableFile.Name = currentFile;
                updateableFile.Checksum = _checksumCalculator.GetChecksum(_inputFolder + "\\" + currentFile);

                _updateConfiguration.Files.Add(updateableFile);
            }

            return true;
        }



        public void SaveServerData(ProjectConfigJSON projectConfig = null)
        {
            CopyFiles();

            if (projectConfig != null)
            {
                saveProjectConfig(projectConfig);
            }

            saveUpdateInfo();
        }

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
            updateableFile.Checksum = _checksumCalculator.GetChecksum(fileName);

            _updateConfiguration.Files.Add(updateableFile);
        }

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
