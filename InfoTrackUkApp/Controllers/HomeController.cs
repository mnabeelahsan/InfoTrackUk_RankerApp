using InfoTrackUkApp.Models;
using InfoTrackUkApp.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace InfoTrackUkApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebScraperService _webScraperService;
        private readonly DbService _dbService;
        private readonly HtmlProcessService _htmlProcessService;
        private readonly SearchEngineDecisionService _searchEngineDecisionService;

        public HomeController(WebScraperService webScraperService, DbService dbService, HtmlProcessService htmlProcessService, SearchEngineDecisionService searchEngineDecisionService)
        {
            _webScraperService = webScraperService;
            _dbService = dbService;
            _htmlProcessService = htmlProcessService;
            _searchEngineDecisionService = searchEngineDecisionService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetSearchResultsHistory()
        {
            var searchHistory = _dbService
                                .GetAllSearchResults()
                                .OrderByDescending(r => r.SearchDate)
                                .ToList();
            return Json(searchHistory,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetInfoTrackRanks(string keywordToSearch, string url,string searchEngine)
        {
            try
            {
                if (string.IsNullOrEmpty(keywordToSearch) == true || string.IsNullOrEmpty(url) == true || string.IsNullOrEmpty(searchEngine) == true)
                {
                    return Json(new { Error = "Keyword,URL and Search Engine are required" });
                }
                string searchEngineUrl = _searchEngineDecisionService.GetSearchEngineUrl(searchEngine);
                string searchResults = _webScraperService.ScarpeUrlData(keywordToSearch,searchEngineUrl);
                string ranks = _htmlProcessService.GetRanks(searchResults, url);

                if (string.IsNullOrEmpty(ranks) == true)
                {
                    ranks = "0";
                }

                var sm = new SearchResultModel()
                {
                    SearchEngineName = searchEngine,
                    KeywordToSearch = keywordToSearch,
                    Url = url,
                    Ranks = ranks
                };


                _dbService.AddSearchResults(sm);

                return Json(new { Ranks = ranks });

            }
            catch (Exception ex)
            {
                return Json(new { Error = "An error occurred: " + ex.Message });
            }
        }
    }
}
