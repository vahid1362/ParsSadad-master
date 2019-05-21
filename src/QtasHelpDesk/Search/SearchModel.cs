using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QtasHelpDesk.Search
{
    public class SearchModel : PageModel
    {
        public SearchResultCollection Results { get; set; }
        [BindProperty(SupportsGet = true)] public string Search { get; set; }

        public void OnGet()
        {
            Results = new SearchResultCollection();
        }
    }
}
