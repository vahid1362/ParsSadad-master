
using System.ComponentModel.DataAnnotations;

namespace QtasHelpDesk.ViewModels.Identity
{
  public  class UserGroupViewModel
    {

        public int Id { get; set; }

        public int UserId { get; set; }

        public int GroupId { get; set; }

        [Display(Name ="عنوان گروه")]
        public string GroupTitle { get; set; }
    }
}
