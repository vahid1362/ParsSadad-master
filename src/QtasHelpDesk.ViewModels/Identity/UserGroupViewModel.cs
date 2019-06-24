
using System.ComponentModel.DataAnnotations;

namespace QtasHelpDesk.ViewModels.Identity
{
  public  class UserGroupViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "کاربر انتخاب نشده است")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "گروه انتخاب نشده است")]
        public int GroupId { get; set; }

        [Display(Name ="عنوان گروه")]
        public string GroupTitle { get; set; }
    }
}
