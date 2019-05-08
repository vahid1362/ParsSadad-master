using System;
using System.ComponentModel.DataAnnotations;
using DNTPersianUtils.Core;
using Microsoft.AspNetCore.Mvc;

namespace QtasHelpDesk.ViewModels.Identity
{
  public  class UserViewModel
    {
        [HiddenInput]
        public int  Id { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "نام کاربری")]
        //[Remote("ValidateUsername", "User",
        //    AdditionalFields = nameof(Id) + "," + ViewModelConstants.AntiForgeryToken, HttpMethod = "POST",ErrorMessage = "نام کاربری تکراری می باشد")]
        [RegularExpression("^[1-9]*$", ErrorMessage = "لطفا تنها از  اعداد استفاده نمائید")]
        public string UserName { get; set; }
   
        [Display(Name = "نام")]
        [Required(ErrorMessage = "(*)")]
        [StringLength(450)]
        [RegularExpression(@"^[\u0600-\u06FF,\u0590-\u05FF\s]*$",
            ErrorMessage = "لطفا تنها از حروف فارسی استفاده نمائید")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "(*)")]
        [StringLength(450)]
        [RegularExpression(@"^[\u0600-\u06FF,\u0590-\u05FF\s]*$",
            ErrorMessage = "لطفا تنها از حروف فارسی استفاده نمائید")]
        public string LastName { get; set; }

        [Display(Name = "تلفن همراه")]
        [ValidIranianMobileNumber(ErrorMessage = "شماره موبایل معتبر نمی باشد")]
        public string Mobile { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

       
        public byte[] Image { get; set; }

        public string Image64
        {
            get
            {
                return Image != null ? Convert.ToBase64String(Image) : null;
            }
        }

        public int  PictureId { get; set; }

        [Display(Name = "کد ملی")]
        [ValidIranianNationalCode(ErrorMessage =" کد ملی معتبر نمی باشد")]
        public string NationalIdentity { get; set; }

        public int? DateOfBirthYear { set; get; }

        public int? DateOfBirthMonth { set; get; }

        public int? DateOfBirthDay { set; get; }

        [Display(Name = "محل اقامت")]
        public string Location { set; get; }

        //[Display(Name = "نمایش عمومی ایمیل")]
        //public bool IsEmailPublic { set; get; }

        //[Display(Name = "فعال‌سازی اعتبار سنجی دو مرحله‌ای")]
        //public bool TwoFactorEnabled { set; get; }


        [HiddenInput]
        public string Pid { set; get; }



    }
}
