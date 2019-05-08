using QtasHelpDesk.Domain.AuditableEntity;
using QtasHelpDesk.Domain.Identity;
using System.Collections.Generic;

namespace QtasHelpDesk.Domain.Content
{
    public class Post:BaseEntity<int>, IAuditableEntity
    {
        public Post()
        {
            Responses = new HashSet<Response>();
        }
       
        public string Title { get; set; }
        
        public string Decription { get; set; }

        public decimal  Rate { get; set; }

        public bool IsArticle { get; set; }

        public Group Group { get; set; }

        public int GroupId { get; set; }

        public int UserId { get; set; }

        public  User User { get; set; }

        public ICollection<Response> Responses { get; set; } 

    }
}
