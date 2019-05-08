using QtasHelpDesk.Domain.AuditableEntity;
using QtasHelpDesk.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace QtasHelpDesk.Domain.Content
{
    public class Response : BaseEntity<int>, IAuditableEntity
    {
        public string ReplyText { get; set; }

        public Post Post { get; set; }

        public int PostId { get; set; }

        public decimal Rate { get; set; }

    }
}
