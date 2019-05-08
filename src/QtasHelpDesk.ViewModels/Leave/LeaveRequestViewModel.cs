using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QtasHelpDesk.ViewModels.Leave
{
    public class LeaveRequestViewModel
    {
        [Display(Name = "تاریخ شروع")]
        public int FromDate { get; set; }
        [Display(Name = "تا تاریخ")]
        public int ToDate { get; set; }
        [Display(Name = "کد پرسنلی")]
        public int PersonCode { get; set; }

        [Display(Name = "تاریخ شروع")]
        public string FromDateStr => FromDate.ToString("####/##/##");

        [Display(Name = "تا تاریخ")] public string ToDateStr => ToDate.ToString("####/##/##");
    }


}
