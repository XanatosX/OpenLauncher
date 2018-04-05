using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Projects.DataModel
{
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
    }
}
