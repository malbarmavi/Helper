using System;
using System.Collections;
using System.Collections.Generic;

namespace Helper
{
  public static class Numbers
  {
    private static readonly Random randomNumber = new Random();
    private static readonly object syncLock = new object();

    /// <summary>
    /// Convert objects to T type
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    /// <param name="number">Number</param>
    /// <returns>T Type</returns>
    public static T Map<T>(object number)
    {
      try
      {
        return (T)Convert.ChangeType(number, typeof(T));
      }
      catch (Exception)
      {
        return default(T);
      }
    }

    public static int GetRandomNumber(int min, int max)
    {
      lock (syncLock)
      {
        return (randomNumber).Next(min, max);
      }
    }

    public static int GetRandomNumber() => randomNumber.Next(int.MinValue, int.MaxValue);

    public static int GetRandomNumber(int max) => GetRandomNumber(0, max);

    public static int ToInt(string value) => Map<int>(value);

    public static double ToDouble(string value) => Map<double>(value);

    public static string ToBinary(int value) => Convert.ToString(value, 2);

    public static string ToHex(int value) => value.ToString("X");

    /// <summary>
    /// Generate Fibonacci Sequence
    /// </summary>
    /// <param name="maximumValue">Maximum value in the sequence</param>
    /// <returns></returns>
    public static long[] GetFibonacciSequence(long maximumValue)
    {
      var fibs = new List<long>();
      while ((fibs[fibs.Count - 1] + fibs[fibs.Count - 2]) <= maximumValue)
      {
        fibs.Add(fibs[fibs.Count - 1] + fibs[fibs.Count - 2]);
      }
      return fibs.ToArray();
    }


  }
}