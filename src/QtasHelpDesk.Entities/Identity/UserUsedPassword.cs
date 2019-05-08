using QtasHelpDesk.Domain.AuditableEntity;
using QtasHelpDesk.Domain.Identity;
using QtasHelpDesk.Entities.AuditableEntity;

namespace QtasHelpDesk.Entities.Identity
{
    public class UserUsedPassword : IAuditableEntity
    {
        public int Id { get; set; }

        public string HashedPassword { get; set; }

        public virtual User User { get; set; }
        public int UserId { get; set; }
    }
}