using System.Collections.Generic;
using QtasHelpDesk.Domain.Identity;
using QtasHelpDesk.Entities.Identity;

namespace QtasHelpDesk.ViewModels.Identity
{
    public class OnlineUsersViewModel
    {
        public List<User> Users { set; get; }
        public int NumbersToTake { set; get; }
        public int MinutesToTake { set; get; }
        public bool ShowMoreItemsLink { set; get; }
    }
}