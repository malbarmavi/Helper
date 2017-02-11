using System;

namespace Helper.Extenstion
{
  public static partial class Extenstion
  {
    public static string ToHex(this int value) => Numbers.ToHex(value);

    public static string ToBinary(this int value) => Numbers.ToBinary(value);

    public static void Times(this int count, Action action)
    {
      for (int i = 0; i < count; i++)
      {
        action();
      }
    }

    public static void Times(this int count, Action<int> action)
    {
      for (int i = 0; i < count; i++)
      {
        action(i);
      }
    }

    public static double ToFixed ( this double value, int length = 0 ) => Numbers.ToFixed(value, length);
  }

}
