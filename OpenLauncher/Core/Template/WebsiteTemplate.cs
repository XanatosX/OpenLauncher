using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenLauncher.Core.Template
{
    /// <summary>
    /// This is a class for
    /// </summary>
    public class WebsiteTemplate : TemplateInterface
    {
        private string _templateFolder;
        private string _templateFile;

        private Dictionary<string, string> _replaceDict;

        public WebsiteTemplate()
        {
            _replaceDict = new Dictionary<string, string>();

            FileInfo appInfo = new FileInfo(Application.ExecutablePath);

            _templateFolder = appInfo.DirectoryName + "\\Templates\\Websites";
            
        }

        public void SetTemplateFile(string filename)
        {
            string newTemplate = _templateFolder + "\\";
            newTemplate += filename;
            if (File.Exists(newTemplate))
            {
                _templateFile = newTemplate;
            }
        }

        public void AddReplacement(string needle, string replacement)
        {
            _replaceDict.Add(needle, replacement);
        }

        public string Get()
        {
            if (!File.Exists(_templateFile))
            {
                return "";
            }

            string finalTemplate = load();
            finalTemplate = replace(finalTemplate);

            return finalTemplate;
        }

        private string load()
        {
            string template;
            using (StreamReader reader = new StreamReader(_templateFile))
            {
                template = reader.ReadToEnd();
            }

            return template;
        }

        private string replace(string baseTemplate)
        {
            foreach (KeyValuePair<string, string> dataPair in _replaceDict)
            {
                baseTemplate = baseTemplate.Replace("%" + dataPair.Key + "%", dataPair.Value);
            }

            return baseTemplate;
        }
    }
}
