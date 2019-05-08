using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DNTCommon.Web.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QtasHelpDesk.ViewModels.Media
{
    public class GalleryPictureViewModel
    {
  
        [HiddenInput]
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Display(Name = "گروه تصاویر")]
        public int GalleryId { get; set; }
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


    }
}
