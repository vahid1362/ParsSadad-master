using QtasHelpDesk.Domain.Identity;
using QtasHelpDesk.Entities.Identity;

namespace QtasHelpDesk.ViewModels.Identity.Emails
{
    public class RegisterEmailConfirmationViewModel : EmailsBase
    {
        public User User { set; get; }
        public string EmailConfirmationToken { set; get; }
    }
}
