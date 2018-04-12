using OpenLauncher.Core.Helper.Extensions;
using OpenLauncher.Core.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenLauncher.Forms
{
    public partial class About : Form
    {
        readonly string _applicationExistingYears;
        readonly string _licenseLink;

        private bool _firstNavigate;

        public About()
        {
            InitializeComponent();
            _licenseLink = "https://www.gnu.org/licenses/gpl-3.0.en.html";
            _applicationExistingYears = "2018";
            _firstNavigate = true;

            string currentYear = DateTime.Now.Year.ToString();

            if (currentYear != _applicationExistingYears)
            {
                _applicationExistingYears += $" - {currentYear}";
            }

            ITemplate templateEngine = new WebsiteTemplate();
            string websiteToShow = "About.html";
            templateEngine.SetTemplateFile(websiteToShow);
            templateEngine.AddReplacement("licenseLink", _licenseLink);
            templateEngine.AddReplacement("existingYears", _applicationExistingYears);

            string cssPath = new FileInfo(Application.ExecutablePath).DirectoryName + "\\Templates\\Websites\\css\\creditsStyle.css";
            templateEngine.AddReplacement("forceCssStyle", cssPath.GetFileContent());

            WB_creditBrowser.DocumentText = templateEngine.Get();

            _firstNavigate = false;
        }

        private void WB_creditBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {   if (!_firstNavigate)
            {
                e.Cancel = true;

                Process.Start(e.Url.ToString());
            }
        }

        private void About_Load(object sender, EventArgs e)
        {

        }
    }
}
