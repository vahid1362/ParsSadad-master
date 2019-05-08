using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QtasHelpDesk.ViewModels.Product
{
    public class ProductRequestViewModel
    {
        public int Req_ID { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public int Req_Date { get; set; }

        [Display(Name = "تاریخ درخواست")]
        public string Req_Datestr
        {
            get { return Req_Date.ToString("####/##/##"); }
        }
        
        [Display(Name = "کد ثبت کننده")]
        public int Per_Code { get; set; }

        [Display(Name = "آخرین  وضعیت")]
        public int Last_State { get; set; }

        [Display(Name = "آخرین  وضعیت")]
        public string Last_StateStr { get; set; }



    }


    public class AddProductProductRequestViewModel
    {

        [Display(Name = "تاریخ ثبت")]
        public int Req_Date { get; set; }

        [Display(Name = "کد شعبه")]
        public int Branch_Code { get; set; }

        [Display(Name = "تعداد")]
        public int Qty { get; set; }

        [Display(Name = "محل مورد استفاده")]
        public int Use_Place { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "توضیحات")]
        public string Note { get; set; }

        public int Group_Digit_Code { get; set; }

        [Display(Name = "کد ثبت کننده")]
        public int Per_Code { get; set; }

        [Display(Name = "آخرین  وضعیت")]
        public int Last_State { get; set; }

    }
}
