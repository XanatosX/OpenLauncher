using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Helper.Extensions
{
    public static class FileLoaderExtension
    {
        public static string GetFileContent(this string filePath)
        {
            string content = "";
            using (StreamReader reader = new StreamReader(filePath))
            {
                content = reader.ReadToEnd();
            }
            return content;
        }
    }
}
