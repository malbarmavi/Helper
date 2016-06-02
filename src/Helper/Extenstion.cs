using System;

namespace Helper
{
  namespace Extention
  {
    public static class Extenstion
    {
      // Int
      public static bool IsEven(this int value) => (value % 2) == 0;

      public static bool IsOdd(this int value) => (value % 2) != 0;

      public static string ToHex(this int value) => Numbers.ToHex(value);

      public static string ToBinary(this int value) => Numbers.ToBinary(value);

      // String
      public static int ToInt(this string value) => Numbers.ToInt(value);

      public static double ToDouble(this string value) => Numbers.ToDouble(value);

      public static bool ToBool(this string value) => Numbers.Map<bool>(value);

      public static DateTime ToDateTime(this string value) => Numbers.Map<DateTime>(value);

      public static bool IsValidString(this string value) => Strings.IsValidString(value);

      public static string ToMD5(this string value) => Cryptography.GenerateMD5(value);

      // String Array
      public static string Join(this string[] value, string separator) => string.Join(separator, value);
    }
  }
}