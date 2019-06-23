using System.Collections.Generic;

namespace QtasHelpDesk.Domain.Content
{
    public class Group : BaseEntity<int>
    {

        public Group()
        {
            Posts = new HashSet<Post>();
            UserGroups=new HashSet<UserGroup>();
        }
        public string Title { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        public bool IsPrivate { get; set; }

        public bool DisplayInMain { get; set; }

        public  int? ParentId { get; set; }

        public virtual Group Parent { get; set; }

        public  virtual ICollection<Post>   Posts { get; set; }

        public virtual  ICollection<UserGroup> UserGroups { get; set; }


    }
}
