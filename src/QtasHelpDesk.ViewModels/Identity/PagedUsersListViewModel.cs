using System.Collections.Generic;
using QtasHelpDesk.Entities.Identity;
using cloudscribe.Web.Pagination;
using QtasHelpDesk.Domain.Identity;

namespace QtasHelpDesk.ViewModels.Identity
{
    public class PagedUsersListViewModel
    {
        public PagedUsersListViewModel()
        {
            Paging = new PaginationSettings();
        }

        public List<User> Users { get; set; }

        public List<Role> Roles { get; set; }

        public PaginationSettings Paging { get; set; }
    }
}
