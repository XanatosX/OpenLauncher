using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Helper
{
    public class ChecksumCalculator
    {
        public string GetChecksum(string fileToCheck)
        {
            if (!File.Exists(fileToCheck))
            {
                return "";
            }
            byte[] fileBytes = File.ReadAllBytes(fileToCheck);

            string hash = "";
            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, fileBytes);
            }
            return hash;
        }

        private string GetMd5Hash(MD5 md5Hash, byte[] input)
        {
            byte[] data = md5Hash.ComputeHash(input);

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
