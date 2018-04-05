using Newtonsoft.Json;
using OpenLauncher.Core.Projects.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Projects
{
    public class ProjectConfigManager
    {
        private string _baseURL;
        private string _openLauncherFolder;

        private string _projectConfig;
        private string _updateInfo;

        public ProjectConfigManager(string baseURL)
        {
            _baseURL = baseURL;
            _openLauncherFolder = _baseURL + "/OpenLauncher/";
            _projectConfig = _openLauncherFolder + "ProjectConfig.json";
            _updateInfo = _openLauncherFolder + "UpdateInfo.json";
        }

        public List<LaunchableJSON> getLaunchable()
        {
            WebRequest request = WebRequest.Create(_projectConfig);
            WebResponse response = null;
            try
            {
                response = request.GetResponse();
            }
            catch (Exception)
            {
                return new List<LaunchableJSON>();
            }
            
            Stream responseStream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(responseStream))
            {
                string jsonData = reader.ReadToEnd();
                try
                {
                    ProjectConfigJSON configJSON = JsonConvert.DeserializeObject<ProjectConfigJSON>(jsonData);
                    return configJSON.Launchables;

                }
                catch (Exception)
                {
                }
                
            }

            return new List<LaunchableJSON>();

        }
    }
}
