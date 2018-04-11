using Newtonsoft.Json;
using OpenLauncher.Core.Projects.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Projects
{
    /// <summary>
    /// This class is the manager for the project overview in the main window. 
    /// The class can load, save and edit all the project shown in the main window.
    /// </summary>
    public class ProjectManager
    {
        readonly string _projectFile;

        private ProjectList _projects;
        public List<ProjectDataJson> Projects => _projects.DataJson;

        /// <summary>
        /// Create an empty instance of the project
        /// </summary>
        public ProjectManager()
        {
            _projects = new ProjectList();
            string settingsFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            settingsFolder = settingsFolder + "\\OpenLauncher";

            if (!Directory.Exists(settingsFolder))
            {
                Directory.CreateDirectory(settingsFolder);
            }

            _projectFile = settingsFolder + "\\projects.json";
        }

        /// <summary>
        /// Add a new project to the application
        /// You need to save the manager after adding an entry!
        /// </summary>
        /// <param name="Filename">A link to the file you want to load</param>
        public void Add(string Filename)
        {
            if (!File.Exists(Filename))
            {
                return;
            }
            string fileData;
            using (StreamReader reader = new StreamReader(Filename))
            {
                fileData = reader.ReadToEnd();
            }
            
            try
            {
                ProjectDataJson loadetObject = JsonConvert.DeserializeObject<ProjectDataJson>(fileData);
                if (loadetObject.DisplayImage == null && loadetObject.HomeUrl == null)
                {
                    return;
                }
                Add(loadetObject);
            }
            catch (Exception)
            {
                return;
            }
        }

        /// <summary>
        /// Add a new ProjectDataJSON to the project manager
        /// You need to save the manager after adding an entry!
        /// </summary>
        /// <param name="newData">The new dataset to add</param>
        public void Add(ProjectDataJson newData)
        {
            string GUID = Guid.NewGuid().ToString();
            newData.Guid = GUID;

            _projects.Add(newData);
        }

        /// <summary>
        /// Remove a dataset from the manager, you need to save the manager after removing an entry!
        /// </summary>
        /// <param name="GUID"></param>
        public void Remove(string GUID)
        {
            _projects.Remove(GUID);
        }

        /// <summary>
        /// Load the configuration file from the settings folder
        /// </summary>
        /// <returns></returns>
        public bool Load()
        {
            if (!File.Exists(_projectFile))
            {
                return false;
            }

            string fileData;
            using (StreamReader reader = new StreamReader(_projectFile))
            {
                fileData = reader.ReadToEnd();
            }
            ProjectListJson loadetObject = JsonConvert.DeserializeObject<ProjectListJson>(fileData);

            try
            {
                _projects = new ProjectList(loadetObject);
            }
            catch (Exception)
            {
                return false;
            }
            foreach (ProjectDataJson currentJSON in _projects.DataJson)
            {
                currentJSON.CreateEnrichedContent();
            }

            return true;
        }

        /// <summary>
        /// Save the vonfiguration file to the settings folder
        /// </summary>
        /// <returns></returns>
        public void Save()
        {
            string saveString = JsonConvert.SerializeObject(_projects, Formatting.Indented);

            using (StreamWriter writer = new StreamWriter(_projectFile))
            {
                writer.Write(saveString);
            }
        }

    }
}
