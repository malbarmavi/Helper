using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class Strings
    {
        public static bool IsNullOrEmptyOrWhiteSpacce(this string value)
        {
            var result = false;
            try
            {
                if (value == null || String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    result = true;
                }
            }
            catch (Exception)
            {
                result = true;
            }
            return result;
        }
        private static string stringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string GetRandomString(int length=25)
        {
            var sb = new StringBuilder();
            for(int i =0;i<=length;i++)
            {
                sb.Append(stringValue[Numbers.getRandomNumber(0, 25)]);
            }
            return sb.ToString();
        }
    }
}
