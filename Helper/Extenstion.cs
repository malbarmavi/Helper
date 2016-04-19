using System;

namespace Helper
{
    namespace Extention
    {
        public static class Extenstion
        {
            public static int ToInt(this string value) => Numbers.ToInt(value);
            public static bool IsEven(this int value) => (value % 2) == 0;
            public static bool IsOdd(this int value) => (value % 2) != 0;
            public static string ToHex(this int value) => Numbers.ToHex(value);
            public static string ToBinary(this int value) => Numbers.ToBinary(value);
            public static double ToDouble(this string value) => Numbers.ToDouble(value);
            public static bool ToBool(this string value) => Numbers.Map<bool>(value);
            public static DateTime ToDateTime(this string value) => Numbers.Map<DateTime>(value);
            public static string Join(this string[] value, string separator) => string.Join(separator, value);
            public static string ToMD5(this string value) => Cryptography.GenerateMD5(value);
        }

    }
}
