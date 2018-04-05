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
    public class SettingsManager
    {
        private string _settingsFile;

        private SettingsJSON _settings;
        public SettingsJSON Settings => _settings;

        public SettingsManager()
        {
            _settingsFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\OpenLauncher";
            _settingsFile += "\\settings.json";
        }

        public void Update(SettingsJSON newSettings)
        {
            _settings = newSettings;
            Save();
        }

        public void Load()
        {
            if (!File.Exists(_settingsFile))
            {
                _settings = new SettingsJSON();
                return;
            }
            string settingsContent = "";
            using (StreamReader reader = new StreamReader(_settingsFile))
            {
                settingsContent = reader.ReadToEnd();
            }

            _settings =  JsonConvert.DeserializeObject<SettingsJSON>(settingsContent);
        }

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
