﻿using QtasHelpDesk.Domain.Identity;
using QtasHelpDesk.Entities.Identity;

namespace QtasHelpDesk.ViewModels.Identity.Emails
{
    public class ChangePasswordNotificationViewModel : EmailsBase
    {
        public User User { set; get; }
    }
}