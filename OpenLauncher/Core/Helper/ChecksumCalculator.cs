using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Helper
{
    /// <summary>
    /// This class will calculate the checksum from a file. The checksum will be created from the binary data.
    /// </summary>
    public class ChecksumCalculator
    {
        /// <summary>
        /// This will generate a Checksum out of the binary file data
        /// </summary>
        /// <param name="fileToCheck">The path to the file to check</param>
        /// <returns>Returns an md5 hashed string</returns>
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

        /// <summary>
        /// The functions calculates the md5 hash out of an byte array
        /// </summary>
        /// <param name="md5Hash"></param>
        /// <param name="input"></param>
        /// <returns>An md5 hash</returns>
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
