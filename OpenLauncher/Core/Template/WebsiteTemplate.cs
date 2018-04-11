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
    public class WebsiteTemplate : ITemplate
    {
        readonly string _templateFolder;
        private string _templateFile;

        private Dictionary<string, string> _replaceDict;

        /// <summary>
        /// This will create a new empty instance of the class
        /// </summary>
        public WebsiteTemplate()
        {
            _replaceDict = new Dictionary<string, string>();

            FileInfo appInfo = new FileInfo(Application.ExecutablePath);

            _templateFolder = appInfo.DirectoryName + "\\Templates\\Websites";

        }

        /// <inheritdoc />
        public void SetTemplateFile(string filename)
        {
            string newTemplate = _templateFolder + "\\";
            newTemplate += filename;
            if (File.Exists(newTemplate))
            {
                _templateFile = newTemplate;
            }
        }

        /// <inheritdoc />
        public void AddReplacement(string needle, string replacement)
        {
            _replaceDict.Add(needle, replacement);
        }

        /// <inheritdoc />
        public string Get()
        {
            if (!File.Exists(_templateFile))
            {
                return "";
            }

            string finalTemplate = Load();
            finalTemplate = Replace(finalTemplate);

            return finalTemplate;
        }

        /// <summary>
        /// This will load the template from the HDD
        /// </summary>
        /// <returns>Returns the content as string</returns>
        private string Load()
        {
            string template;
            using (StreamReader reader = new StreamReader(_templateFile))
            {
                template = reader.ReadToEnd();
            }

            return template;
        }

        /// <summary>
        /// This will replace a needle in the string
        /// </summary>
        /// <param name="baseTemplate"></param>
        /// <returns>Returns the template with the changed values</returns>
        private string Replace(string baseTemplate)
        {
            foreach (KeyValuePair<string, string> dataPair in _replaceDict)
            {
                baseTemplate = baseTemplate.Replace("%" + dataPair.Key + "%", dataPair.Value);
            }

            return baseTemplate;
        }
    }
}
