using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Rutinus.Global
{
    public static  class SHA512Helper
    {
        public static string EncryptSHA512(string rawData)
        {
            string result = string.Empty;
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(rawData);
                byte[] hashBytes = sha512.ComputeHash(bytes);
                
                StringBuilder sb = new StringBuilder ();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("X2"));
                }
                result = sb.ToString();
            }

            return result;
        }
    }
}
