using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Extenstion
{
  public static partial class Extenstion
  {
    public static bool IsEven(this int value) => (value % 2) == 0;

    public static bool IsOdd(this int value) => (value % 2) != 0;

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
  }

}
