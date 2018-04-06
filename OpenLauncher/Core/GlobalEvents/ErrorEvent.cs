using OpenLauncher.Core.GlobalEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.GlobalEvents
{
    /// <summary>
    /// This is a argument class for the error event
    /// </summary>
    public class ErrorEvent : EventArgs
    {
        private ErrorEnum _errorLevel;
        public ErrorEnum ErrorLevel => _errorLevel;

        private string _errorMessage;
        public string ErrorMessage;

        private string _shortMessage;
        public string ShortErrorMessage;

        private DateTime _errorTriggerTime;
        public DateTime ErrorTriggerTime => _errorTriggerTime;

        /// <summary>
        /// This will create a new instance of an error event argument
        /// </summary>
        /// <param name="errorlevel">The level of the error</param>
        /// <param name="errorMessage">The error message</param>
        /// <param name="shortMessage">A shorter version of the error</param>
        public ErrorEvent(ErrorEnum errorlevel, string errorMessage, string shortMessage = "")
        {
            _errorLevel = errorlevel;
            _errorMessage = errorMessage;
            _shortMessage = shortMessage;

            _errorTriggerTime = DateTime.Now;
        }
    }
}
