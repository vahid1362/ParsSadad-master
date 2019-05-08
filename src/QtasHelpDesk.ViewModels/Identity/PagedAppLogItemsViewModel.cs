using System.Collections.Generic;
using QtasHelpDesk.Entities.Identity;
using cloudscribe.Web.Pagination;
using QtasHelpDesk.Domain.Identity;

namespace QtasHelpDesk.ViewModels.Identity
{
    public class PagedAppLogItemsViewModel
    {
        public PagedAppLogItemsViewModel()
        {
            Paging = new PaginationSettings();
        }

        public string LogLevel { get; set; } = string.Empty;

        public List<AppLogItem> AppLogItems { get; set; }

        public PaginationSettings Paging { get; set; }
    }
}