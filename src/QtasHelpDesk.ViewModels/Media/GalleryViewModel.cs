using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DNTCommon.Web.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QtasHelpDesk.ViewModels.Media
{
   public class GalleryViewModel
   
    {
        public GalleryViewModel()
        {
            RegisterTime=DateTime.Now;
        }
        [HiddenInput]
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        [MaxLength(500)]
        public string Title { get; set; }
        [Display(Name = "توضیحات")]
        [MaxLength(1500)]
        public string Content { get; set; }
        [Display(Name = "زمان ثبت")]
        public DateTime RegisterTime { get; set; }
        
        public int PictureId { get; set; }
        [Display(Name = "تصویر")]
        public byte[] Picture { get; set; }
        [Display(Name = "تصویر")]
        public string Picture64
        {
            get
            {
                return Picture != null ? Convert.ToBase64String(Picture) : null;
            }
        }
        [Display(Name = "تاریخ ایجاد گالری")]
        public string PersianDateTime
        {
            get { return DNTPersianUtils.Core.PersianDateTimeUtils.ToShortPersianDateTimeString(RegisterTime); }
        }

        [Display(Name = "تاریخ ایجاد گالری")]
        public string PersianDate
        {
            get { return DNTPersianUtils.Core.PersianDateTimeUtils.ToShortPersianDateString(RegisterTime); }
        }
    }
}
