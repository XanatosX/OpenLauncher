using Newtonsoft.Json;
using OpenLauncher.Core.Settings.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Settings
{
    /// <summary>
    /// This class is the manager for the available settings
    /// </summary>
    public class SettingsManager
    {
        readonly string _settingsFile;

        private SettingsJson _settings;
        public SettingsJson Settings => _settings;

        /// <summary>
        /// This will create a new empty instance of this class
        /// </summary>
        public SettingsManager()
        {
            _settingsFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\OpenLauncher";
            _settingsFile += "\\settings.json";
        }

        /// <summary>
        /// This will update the settings file on the HDD
        /// </summary>
        /// <param name="newSettings">This is the new settings file to parse and save</param>
        public void Update(SettingsJson newSettings)
        {
            _settings = newSettings;
            Save();
        }

        /// <summary>
        /// This will load the settings file from the local HDD
        /// </summary>
        public void Load()
        {
            if (!File.Exists(_settingsFile))
            {
                _settings = new SettingsJson();
                return;
            }
            string settingsContent = "";
            using (StreamReader reader = new StreamReader(_settingsFile))
            {
                settingsContent = reader.ReadToEnd();
            }

            _settings =  JsonConvert.DeserializeObject<SettingsJson>(settingsContent);
        }

        /// <summary>
        /// This will save the current setting file to the HDD
        /// </summary>
        public void Save()
        {
            string saveData = JsonConvert.SerializeObject(_settings, Formatting.Indented);
            using (StreamWriter writer = new StreamWriter(_settingsFile))
            {
                writer.Write(saveData);
            }
        }
    }
}
