using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
  public static class Http
  {
    public static readonly WebClient webClient = GetWebClient();

    /// <summary>
    /// Download string from url
    /// </summary>
    /// <param name="url">url</param>
    /// <returns>string</returns>
    public static async Task<string> DownloadStringAsync(string url)
    {
      using (WebClient wc = GetWebClient())
      {
        return await wc.DownloadStringTaskAsync(url);
      }
    }

    /// <summary>
    /// Async http get request 
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public static async Task<string> GetAsync(string url)
    {
      using (WebClient wc = GetWebClient())
      {
        wc.Headers[HttpRequestHeader.ContentType] = "application/json";
        return await wc.DownloadStringTaskAsync(url);
      }
    }

    /// <summary>
    /// Async http get request 
    /// </summary>
    /// <param name="url"></param>
    /// <param name="queryString"></param>
    /// <returns></returns>
    public static async Task<string> GetAsync(string url, NameValueCollection queryString)
    {
      using (WebClient wc = GetWebClient())
      {
        wc.QueryString = queryString;
        wc.Headers[HttpRequestHeader.ContentType] = "application/json";
        return await wc.DownloadStringTaskAsync(url);
      }
    }

    /// <summary>
    /// Http get request
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public static string Get(string url)
    {
      using (WebClient wc = GetWebClient())
      {
        wc.Headers[HttpRequestHeader.ContentType] = "application/json";
        return wc.DownloadString(url);
      }
    }

    /// <summary>
    /// Http get request
    /// </summary>
    /// <param name="url"></param>
    /// <param name="queryString"></param>
    /// <returns></returns>
    public static string Get(string url, NameValueCollection queryString)
    {
      using (WebClient wc = GetWebClient())
      {
        wc.QueryString = queryString;
        wc.Headers[HttpRequestHeader.ContentType] = "application/json";
        return wc.DownloadString(url);
      }
    }

    /// <summary>
    /// Async http post request
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="url"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public static async Task PostAsync<T>(string url, T data)
    {
      using (WebClient wc = GetWebClient())
      {
        await wc.UploadStringTaskAsync(url, Json.Stringify(data));
      }
    }

    /// <summary>
    /// Http post request
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="url"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public static void Post<T>(string url, T data)
    {
      using (WebClient wc = GetWebClient())
      {
        wc.UploadString(url, Json.Stringify(data));
      }
    }

    private static WebClient GetWebClient()
    {
      using (WebClient wc = new WebClient())
      {
        wc.Encoding = Encoding.UTF8;
        return wc;
      }
    }
  }
}