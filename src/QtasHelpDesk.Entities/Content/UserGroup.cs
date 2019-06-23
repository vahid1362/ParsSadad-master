using System;
using QtasHelpDesk.Domain.AuditableEntity;
using QtasHelpDesk.Domain.Identity;

namespace QtasHelpDesk.Domain.Content
{
    public class UserGroup : BaseEntity<int>, IAuditableEntity
    {
            
        public int UserId { get; set; }
        public virtual User  User{ get; set; }
        
        public int GroupId { get; set; }
        public virtual Group Group{ get; set; }

    }
}
