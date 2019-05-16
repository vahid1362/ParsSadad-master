using System;
using QtasHelpDesk.Domain.AuditableEntity;
using QtasHelpDesk.Domain.Identity;

namespace QtasHelpDesk.Domain.Content
{
  public   class Faq:BaseEntity<int>,IAuditableEntity
    {
        public string  Question { get; set; }

        public string Reply { get; set; }

        public DateTime  RegisteDate { get; set; }

        public virtual User User { get; set; }

        public virtual Group Group { get; set; }

        public int GroupId { get; set; }

    }
}
