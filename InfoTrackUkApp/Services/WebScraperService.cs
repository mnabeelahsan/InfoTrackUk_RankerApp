using System;
using System.IO;
using System.Net;

namespace InfoTrackUkApp.Services
{
    public class WebScraperService
    {
        public string ScarpeUrlData(string keywordToSearch, string searchEngineUrl)
        {
            string content = string.Empty;
            try
            {
                string googleUrl = $"{searchEngineUrl}search?num=100&q={WebUtility.UrlEncode(keywordToSearch)}";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(googleUrl);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    content = reader.ReadToEnd();
                }
            }
            catch (Exception)
            {
            }
            return content;
        }
    }
}