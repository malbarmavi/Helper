using System.Web.Script.Serialization;

namespace Helper.Web
{
  public static class Json
  {
    /// <summary>
    /// Converts a object to a JSON string
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string Stringify(object obj) => new JavaScriptSerializer().Serialize(obj);

    /// <summary>
    ///  Parses a JSON string into T type object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static T Parse<T>(string obj) => new JavaScriptSerializer().Deserialize<T>(obj);
  }
}