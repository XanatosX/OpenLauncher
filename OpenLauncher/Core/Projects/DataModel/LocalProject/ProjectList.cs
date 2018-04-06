using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Projects.DataModel
{
    /// <summary>
    /// This class is a dataholder for all the avaiable ProjectDataJSON classes
    /// </summary>
    public class ProjectList
    {
        private List<ProjectDataJSON> _dataJSON;
        public List<ProjectDataJSON> DataJson => _dataJSON;

        /// <summary>
        /// Construct an empty instance of the class
        /// </summary>
        public ProjectList()
        {
            _dataJSON = new List<ProjectDataJSON>();
        }

        /// <summary>
        /// This will create a instance with a ProjectListJSON as database
        /// </summary>
        /// <param name="json"></param>
        public ProjectList(ProjectListJSON json)
        {
            _dataJSON = json.DataJson;
        }

        /// <summary>
        /// This will add a new ProjectDataJSON to the class storage
        /// </summary>
        /// <param name="dataJSON">The dataJSON to add to the data storage</param>
        public void Add(ProjectDataJSON dataJSON)
        {
            _dataJSON.Add(dataJSON);
        }

        public void Remove(string GUID)
        {
            for (int i = 0; i < _dataJSON.Count; i++)
            {
                if (_dataJSON[i].GUID == GUID)
                {
                    _dataJSON.RemoveAt(i);
                    return;
                }
            }
        }

        /// <summary>
        /// This will create a saveable JSON class out of this class
        /// </summary>
        /// <returns>A saveable JSON class object</returns>
        public ProjectListJSON getSaveable()
        {
            return new ProjectListJSON()
            {
                DataJson = _dataJSON,
            };
        }
    }
}
