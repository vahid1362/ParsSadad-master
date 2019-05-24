using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QtasHelpDesk.ViewModels.Content
{
   public class PostViewModel
    {
        public PostViewModel()
        {
            SelectListItems=new List<SelectListItem>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "وارد کردن عنوان ضروری است")]
        [DisplayName("عنوان")]
        public string Title { get; set; }

        //[Required(ErrorMessage = "وارد کردن چکیده ضروری است")]
        [DisplayName("چکیده")]
     
        public string Summary { get; set; }

        //[Required(ErrorMessage = "وارد کردن عنوان ضروری است")]
        //[DisplayName("محتوی")]
        public string Decription { get; set; }

        [DisplayName("رتبه")]
        public decimal Rate { get; set; }

        [DisplayName("نام گروه مربوطه")]
        public string GroupName { get; set; }

        [DisplayName("فایل قبلی حفظ شود")]
        public bool DeletePreviousFile { get; set; }

        [DisplayName("آیا مقاله می باشد")]
        public bool IsArticle { get; set; }

        public string  FilePath { get; set; }

        public string  UserFullName { get; set; }

        public string Date { get; set; }

        public int GroupId { get; set; }

        public List<SelectListItem> SelectListItems { get; set; }
    }
}
