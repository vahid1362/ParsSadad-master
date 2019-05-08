using System.ComponentModel.DataAnnotations;

namespace QtasHelpDesk.ViewModels.Identity.Employee
{
   public class EmployeeViewModel
    {
        [Display(Name = "کد پرسنلی")]
        public int PersonId { get; set; }

        [Display(Name = "نام")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Display(Name = "مبلغ حقوق")]
        public decimal PaymentAmount { get; set; }

    }
}
