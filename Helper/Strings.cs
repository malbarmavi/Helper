using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{

    using Model;
    public static class Strings
    {
        private readonly static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly static string numbers = "0123456789";
        private readonly static string symbles = @"!@#$%^&*()_+-=*/?{}<>";

        public static bool IsValidString(this string value)
        {


            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            return true;
        }
        public static string GetRandomString(int length, RandomOptions options)
        {
            var result = string.Empty;

            if (options.Apphabet == true)
            {
                result = alphabet;
            }

            if (options.Symble == true)
            {
                result += symbles;
            }

            if (options.Number == true)
            {
                result += numbers;
            }
            var stringCounts = result.Length;
            var sb = new StringBuilder();
            int index = Numbers.GetRandomNumber(0, stringCounts);
            for (int i = 0; i <= length; i++)
            {
                index = Numbers.GetRandomNumber(0, stringCounts);
                sb.Append(Case(result[index], options.LetterCase));
            }
            return sb.ToString();
        }
        public static string GetRandomString(int length = 26)
            => GetRandomString(length,
                new RandomOptions { Apphabet = true, Number = false, Symble = false, LetterCase = StringCase.Both });
        public static string GetSpace(int length = 4)
        {
            var result = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                result.Append(" ");
            }

            return result.ToString();
        }
        private static string Case(char value, StringCase option)
        {
            switch (option)
            {
                case StringCase.LowerCase:
                    return value.ToString().ToLower();
                case StringCase.UppearCase:
                    return value.ToString().ToUpper();
                case StringCase.Both:
                    return RandomCase(value);
            }
            return value.ToString();
        }
        private static string RandomCase(char value)
        {
            var state = Numbers.GetRandomNumber(0, 2);
            if (state == 0)
            {
                return Case(value, StringCase.LowerCase);
            }
            else
            {
                return Case(value, StringCase.UppearCase);
            }
        }


    }
}
