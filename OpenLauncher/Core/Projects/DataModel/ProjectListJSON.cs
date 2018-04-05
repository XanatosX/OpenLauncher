using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Projects.DataModel
{
    public class ProjectListJSON
    {
        private List<ProjectDataJSON> _dataJSON;
        public List<ProjectDataJSON> DataJson
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
