using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Helper
{
    public class FileDownloader
    {
        private string _fileToDownload;


        public FileDownloader(string fileToDownload)
        {
            _fileToDownload = fileToDownload;
        }

        public string DownloadString()
        {
            WebRequest request = WebRequest.Create(_fileToDownload);
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

            return "";
        }

        public byte[] DownloadBinary()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(_fileToDownload);
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
