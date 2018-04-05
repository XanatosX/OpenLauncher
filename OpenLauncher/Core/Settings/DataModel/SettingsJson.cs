using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Settings.DataModel
{
    public class SettingsJSON
    {
        private string _mainProjectFolder;
        public string MainProjectFolder
        {
            get { return _mainProjectFolder; }
            set { _mainProjectFolder = value; }
        }
    }
}
