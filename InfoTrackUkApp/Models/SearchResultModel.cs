using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoTrackUkApp.Models
{
    public class SearchResultModel
    {
            public string SearchEngineName { get; set; }
            public string KeywordToSearch { get; set; }
            public string Url { get; set; }
            public string Ranks { get; set; }
            public string SearchDate { get; set; }
        }
    
}