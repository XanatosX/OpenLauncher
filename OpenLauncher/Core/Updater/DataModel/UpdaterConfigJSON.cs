using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Updater.DataModel
{
    /// <summary>
    /// This is a dataholder for all the updateable files on the server
    /// </summary>
    public class UpdaterConfigJSON
    {
        private List<UpdateableFile> _files;
        public List<UpdateableFile> Files
        { 
            get
            {
                return _files;
            }
            set
            {
                _files = value;
            }
        }

        public UpdaterConfigJSON()
        {
            _files = new List<UpdateableFile>();
        }
    }
}
