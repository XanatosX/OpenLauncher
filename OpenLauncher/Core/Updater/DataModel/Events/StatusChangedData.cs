using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Updater.DataModel.Events
{
    //NOTE maybe this class must be split into a base and an extended class later on!
    /// <summary>
    /// This class is a container for the status changed event
    /// </summary>
    public class StatusChangedData
    {
        readonly int _lastStatus;
        public int LastStatus => _lastStatus;

        readonly int _newStatus;
        public int NewStatus => _newStatus;

        readonly int _maxStatus;
        public int MaxStatus => _maxStatus;

        readonly UpdateableFile _currentFile;
        public UpdateableFile CurrentFile => _currentFile;

        readonly float _percentDone;
        public float PercentDone => _percentDone;

        /// <summary>
        /// This will create a new instance of this class
        /// </summary>
        /// <param name="lastStatus"></param>
        /// <param name="newStatus"></param>
        /// <param name="maxStatus"></param>
        /// <param name="currentFile"></param>
        public StatusChangedData(int lastStatus, int newStatus, int maxStatus, UpdateableFile currentFile)
        {
            _lastStatus = lastStatus;
            _newStatus = newStatus;
            _maxStatus = maxStatus;
            _currentFile = currentFile;
            double baseValue = (float)_lastStatus / (float)_maxStatus;
            baseValue *= 100;

            _percentDone = (float)Math.Round(baseValue, 2);
        }
    }
}
