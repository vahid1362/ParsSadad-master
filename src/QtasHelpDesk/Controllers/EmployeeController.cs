using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using QtasHelpDesk.Services.Contracts.Identity;

namespace QtasHelpDesk.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
       
        private readonly IApplicationUserManager _userManager;
        private readonly IToastNotification _toastNotification;

        public EmployeeController(IApplicationUserManager userManager,  IToastNotification toastNotification)
        {
            _userManager = userManager;
          
            _toastNotification = toastNotification;
           
        }
       

        [BreadCrumb(Title = "ایندکس", Order = 1)]
        public IActionResult Index()
        {
            return View();
        }

       




       


       

    }
}