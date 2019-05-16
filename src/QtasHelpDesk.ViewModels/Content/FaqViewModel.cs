using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QtasHelpDesk.ViewModels.Content
{
   public class FaqViewModel
    {
        public FaqViewModel()
        {
            SelectListItems=new List<SelectListItem>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "وارد کردن سوال ضروری است")]
        [DisplayName("سوال")]
        public string Question { get; set; }

        [Required(ErrorMessage = "وارد کردن پاسخ ضروری است")]
        [DisplayName("پاسخ")]
        public string Reply { get; set; }

        public string UserFullName { get; set; }
        public string Date { get; set; }


        public int GroupId { get; set; }

        public List<SelectListItem> SelectListItems { get; set; }
    }
}
