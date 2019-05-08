using System;
using System.Collections;
using System.Collections.Generic;
using QtasHelpDesk.Domain.AuditableEntity;

namespace QtasHelpDesk.Domain.Content
{
    public class Group : BaseEntity<int>,IAuditableEntity
    {

        public Group()
        {
            Posts = new HashSet<Post>();
        }
        public string Title { get; set; }

        public int Priority { get; set; }

        public long? ParentId { get; set; }

        public string Description { get; set; }

        public bool IsPrivate { get; set; }

        public bool DisplayInMain { get; set; }

        public  ICollection<Post>   Posts { get; set; }


    }
}
