//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InfoTrackUkApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SearchResult
    {
        public int Id { get; set; }
        public string SearchEngineName { get; set; }
        public string KeywordToSearch { get; set; }
        public string Url { get; set; }
        public string Ranks { get; set; }
        public System.DateTime SearchDate { get; set; }
    }
}
