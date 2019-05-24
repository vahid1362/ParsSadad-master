using System;
using System.Collections;
using System.Collections.Generic;
using QtasHelpDesk.Domain.AuditableEntity;

namespace QtasHelpDesk.Domain.Content
{
    public class Group : BaseEntity<int>
    {

        public Group()
        {
            Posts = new HashSet<Post>();
        }
        public string Title { get; set; }

        public int Priority { get; set; }

      
        public string Description { get; set; }

        public bool IsPrivate { get; set; }

        public bool DisplayInMain { get; set; }

        public  int? ParentId { get; set; }

        public virtual Group Parent { get; set; }

        public  virtual ICollection<Post>   Posts { get; set; }


    }
}
