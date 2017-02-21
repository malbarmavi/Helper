using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Helper.Models;

namespace Helper.Cryptography
{
  using Extenstion;
  
  public static class Cryptographyx
  {

    public static string ToHash(string value, Algorithm alogorithm)
    {
      if (!value.IsValid())
      {
        return string.Empty;
      }
      byte[] hash;
      switch (alogorithm)
      {
        case Algorithm.Md5:
          hash = CalcMd5(value);
          break;
        case Algorithm.Sha1:
          hash = CalcSha1(value);
          break;
        case Algorithm.sha256:
          hash = CalcSha256(value);
          break;
        case Algorithm.Sha384:
          hash = CalcSha384(value);
          break;
        case Algorithm.sha512:
          hash = CalcSha512(value);
          break;
        default:
          hash = CalcMd5(value);
          break;
      }
      return ConvertHashToString(hash);
    }

    private static byte[] CalcMd5(string value)
    {
      using (var md5 = MD5.Create())
      {
        return md5.ComputeHash(Encoding.ASCII.GetBytes(value));
      }

    }

    private static byte[] CalcSha1(string value)
    {
      using (var sha1 = SHA1.Create())
      {
        return sha1.ComputeHash(Encoding.ASCII.GetBytes(value));
      }
    }

    private static byte[] CalcSha256(string value)
    {
      using (var sha1 = SHA256.Create())
      {
        return sha1.ComputeHash(Encoding.ASCII.GetBytes(value));
      }
    }

    private static byte[] CalcSha384(string value)
    {
      using (var sha1 = SHA384.Create())
      {
        return sha1.ComputeHash(Encoding.ASCII.GetBytes(value));
      }

    }

    private static byte[] CalcSha512(string value)
    {
      using (var sha1 = SHA512.Create())
      {
        return sha1.ComputeHash(Encoding.ASCII.GetBytes(value));
      }
    }

    private static string ConvertHashToString(byte[] hash)
      => hash.Select(c => c.ToString("x2")).Aggregate((partialSum, item) => $"{partialSum}{item}");

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
    //[Obsolete]
    //private static string GetResult(byte[] hash)
    //{
    //    var result = string.Empty;
    //    for (int i = 0; i < hash.Length; i++)
    //    {
    //        result += hash[i].ToString("x2");
    //    }
    //    return result;
    //}
  }
}