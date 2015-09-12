using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt
{
    static class MD5Encrypt
    {
        public static string Encrypt(byte[] bytes, bool includeSplit = true)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(bytes);
            return BitConverter.ToString(output);
        }

        public static string Encrypt(string text, bool includeSplit = true)
        {
            byte[] result = Encoding.Default.GetBytes(text);
            string md5Str = Encrypt(result, includeSplit);
            return md5Str;
        }
    }
}