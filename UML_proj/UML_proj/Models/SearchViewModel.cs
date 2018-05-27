using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UML_proj.Models
{
    public class SearchViewModel
    {
        public SearchParameters SearchEntry { get; set; } 
        public List<Dictionary<String, String>> SearchResult;
    }
}