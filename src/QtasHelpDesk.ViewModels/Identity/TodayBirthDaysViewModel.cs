using System.Collections.Generic;
using QtasHelpDesk.Domain.Identity;
using QtasHelpDesk.Entities.Identity;

namespace QtasHelpDesk.ViewModels.Identity
{
    public class TodayBirthDaysViewModel
    {
        public List<User> Users { set; get; }

        public AgeStatViewModel AgeStat { set; get; }
    }
}