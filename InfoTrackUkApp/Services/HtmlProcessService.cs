using System.Text.RegularExpressions;

namespace InfoTrackUkApp.Services
{
    public class HtmlProcessService
    {
        public string GetRanks(string searchResults, string url)
        {
            string pattern = $@"\b{Regex.Escape(url)}\b";
            MatchCollection matches = Regex.Matches(searchResults, pattern, RegexOptions.IgnoreCase);

            string ranks = "";
            int matchCount = matches.Count;
            if (matchCount > 0)
            {
                for (int i = 0; i < matchCount; i++)
                {
                    ranks += matches[i].Index.ToString();
                    if (i < matchCount - 1)
                    {
                        ranks += ",";
                    }
                }
                return ranks;
            }
            else
            {
                return "0"; // URL not found in results
            }
        }
    }
}
