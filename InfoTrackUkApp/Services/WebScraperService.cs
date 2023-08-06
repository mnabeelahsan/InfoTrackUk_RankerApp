using System.Net;

namespace InfoTrackUkApp.Services
{
    public class WebScraperService
    {
        public string ScarpeUrlData(string keywordToSearch, string searchEngineUrl)
        {
            string result;
            using (var webClient = new WebClient())
            {
                webClient.Proxy = null;
                string googleUrl = $"{searchEngineUrl}search?num=100&q={WebUtility.UrlEncode(keywordToSearch)}";
                result = webClient.DownloadString(googleUrl);
            }
            return result;
        }
    }
}