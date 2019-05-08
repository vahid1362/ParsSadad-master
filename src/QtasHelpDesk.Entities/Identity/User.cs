using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;
using Microsoft.AspNetCore.Identity;
using QtasHelpDesk.Domain.AuditableEntity;
using QtasHelpDesk.Domain.Content;
using QtasHelpDesk.Domain.Media;
using QtasHelpDesk.Entities.AuditableEntity;
using QtasHelpDesk.Entities.Identity;

namespace QtasHelpDesk.Domain.Identity
{
    /// <summary>
    /// More info: http://www.dotnettips.info/post/2577
    /// and http://www.dotnettips.info/post/2578
    /// plus http://www.dotnettips.info/post/2559
    /// </summary>
    public class User : IdentityUser<int>, IAuditableEntity
    {
        public User()
        {
            UserUsedPasswords = new HashSet<UserUsedPassword>();
            UserTokens = new HashSet<UserToken>();
                      EmailConfirmed = true;
            Email = UserName + "@a.com";
            //PersonCode = int.Parse(UserName);
        }

        [StringLength(450)]
        public string FirstName { get; set; }

        public int PersonCode { get; set; } 

        [StringLength(20)]
        public string Mobile { get; set; }

        [StringLength(450)]
        public string LastName { get; set; }
       
        public bool UserConfirmed { get; set; }

        [NotMapped]
        public string DisplayName
        {
            get
            {
                var displayName = $"{FirstName} {LastName}";
                return string.IsNullOrWhiteSpace(displayName) ? UserName : displayName;
            }
        }

        [StringLength(450)]
        public string PhotoFileName { get; set; }

        public DateTimeOffset? BirthDate { get; set; }

        public DateTimeOffset? CreatedDateTime { get; set; }

        public DateTimeOffset? LastVisitDateTime { get; set; }

        public bool IsEmailPublic { get; set; }

        public string Location { set; get; }

        public bool IsActive { get; set; } = true;
        
        public  string NationalIdentity { get; set;}

        public int BranchId { get; set; }

        [ForeignKey("Picture")]
        public int? PictureId { get; set; }
        public virtual Picture Picture { get; set; }

        public virtual ICollection<UserUsedPassword> UserUsedPasswords { get; set; }

        public virtual ICollection<UserToken> UserTokens { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; }

        public virtual ICollection<UserLogin> Logins { get; set; }

        public virtual ICollection<UserClaim> Claims { get; set; }

    
    }
}