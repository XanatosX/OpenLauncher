using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Projects.DataModel
{
    /// <summary>
    /// This is the dataholder for the main configuration file on a server for an project
    /// </summary>
    public class OpenLauncherSettingJSON
    {
        private string _downloadMainFolder;
        public string DownloadMainFolder
        {
            get
            {
                return _downloadMainFolder;
            }
            set
            {
                _downloadMainFolder = value;
            }
        }
    }
}
