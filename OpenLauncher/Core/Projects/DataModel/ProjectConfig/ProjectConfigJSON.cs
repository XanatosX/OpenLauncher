using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Projects.DataModel
{
    /// <summary>
    /// A dataholder containing all the launchables for one project
    /// </summary>
    public class ProjectConfigJson
    {
        private List<LaunchableJson> _launchables;
        public List<LaunchableJson> Launchables
        {
            get
            {
                return _launchables;
            }
            set
            {
                _launchables = value;
            }
        }

        /// <summary>
        /// This function will create an empty instance of tis object
        /// </summary>
        public ProjectConfigJson()
        {
            _launchables = new List<LaunchableJson>();
        }
    }
}
