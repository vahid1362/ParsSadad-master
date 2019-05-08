using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QtasHelpDesk.ViewModels.Content
{
   public class PostViewModel
    {
        [Required(ErrorMessage = "وارد کردن عنوان ضروری است")]
        [DisplayName("عنوان")]
        public string Title { get; set; }

        [Required(ErrorMessage = "وارد کردن عنوان ضروری است")]
        [DisplayName("عنوان")]
        public string Decription { get; set; }

        [DisplayName("عنوان")]
        public decimal Rate { get; set; }

        [DisplayName("آیا مقاله می باشد")]
        public bool IsArticle { get; set; }
    }
}
