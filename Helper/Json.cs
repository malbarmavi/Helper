using System.Web.Script.Serialization;

namespace Helper
{
    public static class Json
    {
        public static string Stringify(object obj) => new JavaScriptSerializer().Serialize(obj);

        public static T parse<T>(string obj) => new JavaScriptSerializer().Deserialize<T>(obj);
    }
}