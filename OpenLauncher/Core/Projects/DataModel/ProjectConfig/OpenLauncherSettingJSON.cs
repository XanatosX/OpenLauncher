using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Projects.DataModel
{
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
