using OpenLauncher.Core.Settings;
using OpenLauncher.Core.Settings.DataModel;
using OpenLauncher.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenLauncher.Forms
{
    public partial class Settings : Form
    {
        private SettingsManager _settingManager;
        private SettingsJson _settings;

        public Settings()
        {
            InitializeComponent();
            _settingManager = new SettingsManager();
            _settingManager.Load();
            _settings = _settingManager.Settings;

            FillForm();
        }

        private void FillForm()
        {
            TB_MainProjectFolder.Text = _settings.MainProjectFolder;
        }

        private void UpdateSettings()
        {
            _settings.MainProjectFolder = TB_MainProjectFolder.Text;
        }

        private void B_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void B_SaveAndClose_Click(object sender, EventArgs e)
        {
            UpdateSettings();
            _settingManager.Update(_settings);

            B_Close.PerformClick();
        }

        private void B_ChooseFolder_Click(object sender, EventArgs e)
        {
            FBD_FolderSelect.ShowDialog();

            TB_MainProjectFolder.Text = FBD_FolderSelect.SelectedPath;
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }
    }
}
