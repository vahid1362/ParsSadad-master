using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QtasHelpDesk.ViewModels.PayRoll
{
    /// <summary> فیش حقوقی </summary>
    public class PayslipViewModel
    {
        public int Id { get; set; }
        [Display(Name = "سال")]
        /// <summary> سال  </summary>
        public int Year { get; set; }
        [Display(Name = "ماه")]
        /// <summary> مبلغ </summary>
        public int Month { get; set; }
        [Display(Name = "مبلغ فیش حقوقی")]
        /// <summary> فیش حقوقی </summary>
        public decimal  Amount { get; set; }
    }
}
