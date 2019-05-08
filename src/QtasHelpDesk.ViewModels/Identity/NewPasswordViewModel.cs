using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace QtasHelpDesk.ViewModels.Identity
{
 public   class NewPasswordViewModel
    {
        [HiddenInput]
        public string UserName { get; set; }
        [Display(Name = "تلفن همراه")]

         public string Mobile{set; get; }

        




       
    }
}
