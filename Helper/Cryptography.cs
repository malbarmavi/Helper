using System;
using System.Text;
using System.Security.Cryptography;

namespace Helper
{
    public static class Cryptography
    {
        public static string generateMD5(string input)
        {
            byte[] hash;
            if (input.IsNullOrEmptyOrWhiteSpacce())
            {
                return string.Empty;
            }
            using (var md5 = MD5.Create())
            {
                hash = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
            }
            return BitConverter.ToString(hash);

        }
    }
}
