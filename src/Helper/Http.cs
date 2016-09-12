using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
  public static class Http
  {
    public static async Task<string> DownloadString(string url)
    {
      WebClient wc = GetWebClient();
      return await wc.DownloadStringTaskAsync(url);
    }

    public static async Task<string> Get(string url)
    {
      WebClient wc = GetWebClient();
      wc.Headers[HttpRequestHeader.ContentType] = "application/json";
      return await wc.DownloadStringTaskAsync(url);
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
