using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Updater.DataModel
{
    public class UpdateableFile
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Checksum { get; set; }
    }
}
