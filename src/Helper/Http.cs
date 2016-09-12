using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
  public static class Http
  {
    public static readonly WebClient webClient = GetWebClient();

    public static async Task<string> DownloadStringAsync(string url)
    {
      WebClient wc = GetWebClient();
      return await wc.DownloadStringTaskAsync(url);
    }

    public static async Task<string> GetAsync(string url)
    {
      WebClient wc = GetWebClient();
      wc.Headers[HttpRequestHeader.ContentType] = "application/json";
      return await wc.DownloadStringTaskAsync(url);
    }

    public static async Task<string> GetAsync(string url, NameValueCollection queryString)
    {
      WebClient wc = GetWebClient();
      wc.QueryString = queryString;
      wc.Headers[HttpRequestHeader.ContentType] = "application/json";
      return await wc.DownloadStringTaskAsync(url);
    }


    public static string Get(string url)
    {
      WebClient wc = GetWebClient();
      wc.Headers[HttpRequestHeader.ContentType] = "application/json";
      return wc.DownloadString(url);
    }

    public static string Get(string url, NameValueCollection queryString)
    {
      WebClient wc = GetWebClient();
      wc.QueryString = queryString;
      wc.Headers[HttpRequestHeader.ContentType] = "application/json";
      return wc.DownloadString(url);
    }

    public static async Task Post(string url)
    {
      throw new NotImplementedException();
    }


    private static WebClient GetWebClient()
    {
      WebClient wc = new WebClient();
      wc.Encoding = Encoding.UTF8;
      return wc;
    }
  }
}
