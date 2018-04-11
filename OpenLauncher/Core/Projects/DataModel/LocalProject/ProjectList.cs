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
        readonly List<ProjectDataJson> _dataJson;
        public List<ProjectDataJson> DataJson => _dataJson;

        /// <summary>
        /// Construct an empty instance of the class
        /// </summary>
        public ProjectList()
        {
            _dataJson = new List<ProjectDataJson>();
        }

        /// <summary>
        /// This will create a instance with a ProjectListJSON as database
        /// </summary>
        /// <param name="json"></param>
        public ProjectList(ProjectListJson json)
        {
            _dataJson = json.DataJson;
        }

        /// <summary>
        /// This will add a new ProjectDataJSON to the class storage
        /// </summary>
        /// <param name="dataJSON">The dataJSON to add to the data storage</param>
        public void Add(ProjectDataJson dataJSON)
        {
            _dataJson.Add(dataJSON);
        }

        public void Remove(string GUID)
        {
            for (int i = 0; i < _dataJson.Count; i++)
            {
                if (_dataJson[i].Guid == GUID)
                {
                    _dataJson.RemoveAt(i);
                    return;
                }
            }
        }

        /// <summary>
        /// This will create a saveable JSON class out of this class
        /// </summary>
        /// <returns>A saveable JSON class object</returns>
        public ProjectListJson GetSaveable()
        {
            return new ProjectListJson
            {
                DataJson = _dataJson,
            };
        }
    }
}
