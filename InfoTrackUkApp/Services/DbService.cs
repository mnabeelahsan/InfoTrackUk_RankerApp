using InfoTrackUkApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace InfoTrackUkApp.Services
{
    public class DbService
    {
        public List<SearchResultModel> GetAllSearchResults()
        {
            using (var _entities = new InfoTrackSEOAppEntities())
            {
                List<SearchResultModel> modelList = new List<SearchResultModel>();
                var searchResults = _entities.GetAllSearchResults().ToList();
                foreach (var sr in searchResults)
                {
                    SearchResultModel model = new SearchResultModel();
                    model.SearchEngineName = sr.SearchEngineName;
                    model.KeywordToSearch = sr.KeywordToSearch;
                    model.Url = sr.Url;
                    model.Ranks = sr.Ranks;
                    model.SearchDate = sr.SearchDate.ToString("dd MMMM yyyy HH:mm:ss");
                    modelList.Add(model);
                }
                return modelList;
            }

        }

        public void AddSearchResults(SearchResultModel model)
        {
            using (var _entities = new InfoTrackSEOAppEntities())
            {
                _entities.AddSearchResults(model.SearchEngineName, model.KeywordToSearch, model.Url, model.Ranks);
            }
        }
    }
}