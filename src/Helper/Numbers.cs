using System;
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
    public static int[] CalcFibonacciSequence(long maximumValue)
    {
      var fibs = new List<int>() { 0, 1 };
      if (maximumValue == 0) return new int[] { 0 };
      if (maximumValue == 1) return fibs.ToArray();
      while ((fibs[fibs.Count - 1] + fibs[fibs.Count - 2]) <= maximumValue)
      {
        fibs.Add(fibs[fibs.Count - 1] + fibs[fibs.Count - 2]);
      }
      return fibs.ToArray();
    }

    public static bool IsEven(int value) => (value % 2) == 0;

    public static bool IsOdd(int value) => (value % 2) != 0;

  }
}