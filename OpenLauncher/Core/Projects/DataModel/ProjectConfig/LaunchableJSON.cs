using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Projects.DataModel
{
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
