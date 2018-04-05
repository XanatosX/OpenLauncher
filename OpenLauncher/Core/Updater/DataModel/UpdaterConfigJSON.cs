using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Updater.DataModel
{
    public class UpdaterConfigJSON
    {
        public string UpdaterDownloadPathBase { get; set; }
        public List<UpdateableFile> Files { get; set; }
    }
}
