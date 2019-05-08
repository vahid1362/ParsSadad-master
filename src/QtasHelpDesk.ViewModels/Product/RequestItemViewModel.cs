using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QtasHelpDesk.ViewModels.Product
{
   public class RequestItemViewModel
    {
  
        public int ID { get; set; }

        [Display(Name = "تعداد")]
        public int Qty { get; set; }

        [Display(Name = "کد محل استفاده")]
        public int Use_Place { get; set; }

        [Display(Name = "نام محل مورد استفاده")]
        public string Use_Place_Str { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "توضیحات")]
        public string Note { get; set; }

        [Display(Name = "کد کالا")]
        public int Group_Digit_Code { get; set; }

        [Display(Name = " نام کالا")]
        public string Group_Digit_Code_Str{ get; set; }

        public  int  Req_Id { get; set; }
       
        public int BranchId { get; set; }


        public int PersonCode { get; set; }

        public List<SelectListItem> AvailabeProducts { get; set; }

        public List<SelectListItem> AvailabeUsePlace { get; set; }

    }
}
