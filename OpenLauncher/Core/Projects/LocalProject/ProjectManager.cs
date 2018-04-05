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
    public class ProjectManager
    {
        private string _settingsFolder;
        private string _projectFile;

        private ProjectList _projects;
        public List<ProjectDataJSON> Projects => _projects.DataJson;

        public ProjectManager()
        {
            _projects = new ProjectList();
            _settingsFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _settingsFolder = _settingsFolder + "\\OpenLauncher";

            if (!Directory.Exists(_settingsFolder))
            {
                Directory.CreateDirectory(_settingsFolder);
            }

            _projectFile = _settingsFolder + "\\projects.json";
        }


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
                ProjectDataJSON loadetObject = JsonConvert.DeserializeObject<ProjectDataJSON>(fileData);
                Add(loadetObject);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void Add(ProjectDataJSON newData)
        {
            string GUID = Guid.NewGuid().ToString();
            newData.GUID = GUID;

            _projects.Add(newData);
        }

        public void Remove(string GUID)
        {
            _projects.Remove(GUID);
        }

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
            ProjectListJSON loadetObject = JsonConvert.DeserializeObject<ProjectListJSON>(fileData);

            try
            {
                _projects = new ProjectList(loadetObject);
            }
            catch (Exception ex)
            {
                return false;
            }
            foreach (ProjectDataJSON currentJSON in _projects.DataJson)
            {
                currentJSON.CreateEnrichedContent();
            }

            return true;
        }


        public bool Save()
        {
            string saveString = JsonConvert.SerializeObject(_projects, Formatting.Indented);

            using (StreamWriter writer = new StreamWriter(_projectFile))
            {
                writer.Write(saveString);
            }
            return true;
        }

    }
}
