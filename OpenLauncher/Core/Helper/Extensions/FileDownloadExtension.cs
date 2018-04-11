using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Helper
{
    /// <summary>
    /// This is a helper class to download a file from an URL as String or as Byte array
    /// </summary>
    public static class FileDownloadExtension
    {
        /// <summary>
        /// This will download the file as String
        /// </summary>
        /// <returns>The file content as string</returns>
        public static string DownloadString(this string fileToDownload)
        {
            Uri testUri = null;
            Uri.TryCreate(fileToDownload, UriKind.Absolute, out testUri);

            if (testUri == null)
            {
                return "";
            }

            WebRequest request = WebRequest.Create(fileToDownload);
            WebResponse response = null;
            try
            {
                response = request.GetResponse();
            }
            catch (Exception)
            {
                return "";
            }

            Stream responseStream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(responseStream))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// This will download the file as a bianry 
        /// </summary>
        /// <returns>Returns the content as a binary array</returns>
        public static byte[] DownloadBinary(this string fileToDownload)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(fileToDownload);
            webRequest.Method = "GET";
            webRequest.Timeout = 3000;
             

            WebResponse response = null;
            try
            {
                response = webRequest.GetResponse();
            }
            catch (Exception)
            {
                return new byte[0];
            }
            byte[] returnData;
            Stream responseStream = response.GetResponseStream();
            using (BinaryReader reader = new BinaryReader(responseStream))
            {
                int bufferSize = 4096;
                using (MemoryStream ms = new MemoryStream())
                {
                    byte[] buffer = new byte[bufferSize];
                    int count;

                    while ((count = reader.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        ms.Write(buffer, 0, count);
                    }
                    returnData = ms.ToArray();
                }
            }
            return returnData;
        }
    }
}
