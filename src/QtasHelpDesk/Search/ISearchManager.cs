using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QtasHelpDesk.ViewModels.Content;

namespace QtasHelpDesk.Search
{
    public interface ISearchManager
    {
        void AddToIndex(params Searchable[] searchables);

        void DeleteFromIndex(params PostViewModel[] searchables);

        void Clear();
        SearchResultCollection Search(string searchQuery, int hitsStart, int hitsStop, string[] fields);
    }
}
