using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Projects.DataModel
{
    /// <summary>
    /// This class representd a launchable entry in a project. There is a string for the executable relativ to the main project folder
    /// </summary>
    public class LaunchableJSON
    {
        private string _displayName;
        public string DisplayName
        {
            get
            {
                return _displayName;
            }
            set
            {
                _displayName = value;
            }
        }

        private string _executable;
        public string Executable
        {
            get
            {
                return _executable;
            }
            set
            {
                _executable = value;
            }
        }
    }
}
