using QtasHelpDesk.Entities.AuditableEntity;
using Microsoft.AspNetCore.Identity;
using QtasHelpDesk.Domain.AuditableEntity;
using QtasHelpDesk.Domain.Identity;

namespace QtasHelpDesk.Entities.Identity
{
    /// <summary>
    /// More info: http://www.dotnettips.info/post/2577
    /// and http://www.dotnettips.info/post/2578
    /// </summary>
    public class UserLogin : IdentityUserLogin<int>, IAuditableEntity
    {
        public virtual User User { get; set; }
    }
}