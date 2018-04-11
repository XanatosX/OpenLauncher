using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Projects.DataModel
{
    /// <summary>
    /// This is a data holder for all the available projects in the launcher
    /// </summary>
    public class ProjectListJson
    {
        private List<ProjectDataJson> _dataJSON;
        public List<ProjectDataJson> DataJson
        {
            get
            {
                return _dataJSON;
            }
            set
            {
                _dataJSON = value;
            }
        }
            
    }
}
