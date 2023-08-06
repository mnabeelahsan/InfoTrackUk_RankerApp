namespace InfoTrackUkApp.Services
{
    public class SearchEngineDecisionService
    {
        public string GetSearchEngineUrl(string searchEngine)
        {
            string linkUrl = string.Empty;
            if (searchEngine.ToUpper() == "GOOGLE")
            {
                linkUrl = "https://www.google.co.uk/";
            }
            else if (searchEngine.ToUpper() == "BING")
            {
                linkUrl = "https://www.bing.com/";
            }
            return linkUrl;
        }
    }
}