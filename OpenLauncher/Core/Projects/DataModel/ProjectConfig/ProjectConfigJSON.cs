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
    public class ProjectConfigJSON
    {
        private List<LaunchableJSON> _launchables;
        public List<LaunchableJSON> Launchables
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
        public ProjectConfigJSON()
        {
            _launchables = new List<LaunchableJSON>();
        }
    }
}
