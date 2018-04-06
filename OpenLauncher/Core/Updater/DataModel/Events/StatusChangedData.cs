using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Updater.DataModel.Events
{
    public class StatusChangedData
    {
        private int _lastStatus;
        public int LastStatus => _lastStatus;

        private int _newStatus;
        public int NewStatus => _newStatus;

        private int _maxStatus;
        public int MaxStatus => _maxStatus;

        private UpdateableFile _currentFile;
        public UpdateableFile CurrentFile => _currentFile;

        private float _percentDone;
        public float PercentDone => _percentDone;

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
