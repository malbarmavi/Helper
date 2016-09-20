using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
  public static class Utility
  {
    /// <summary>
    /// Convert objects to T type
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    /// <param name="value">Value</param>
    /// <returns>T Type</returns>
    public static T Map<T>(object value)
    {
      try
      {
        return (T)Convert.ChangeType(value, typeof(T));
      }
      catch (Exception)
      {
        return default(T);
      }
    }

  }
}
