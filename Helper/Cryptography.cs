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
            var result = string.Empty;
            for (int i = 0; i < hash.Length; i++)
            {
                result += hash[i].ToString("X2");
            }
            
            return result.ToLower();

        }
        //public static string GetRandomNumber()
        //{
        //    var d = new byte[10];
        //    System.Security.Cryptography.RandomNumberGenerator.Create().GetBytes(d);
        //    var result="";
        //    foreach(var i in d)
        //    {
        //        result += i.ToString("D");
        //    }         
        //    return result;
        //}

        
    }
}
