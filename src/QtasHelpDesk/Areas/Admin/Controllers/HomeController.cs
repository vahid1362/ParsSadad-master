using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Mvc;

namespace QtasHelpDesk.Areas.Admin.Controllers
{
  
    [BreadCrumb(Title = "خانه", UseDefaultRouteUrl = true, Order = 0)]
    [Area("Admin")]
    public class HomeController : Controller
    {
        [BreadCrumb(Title = "ایندکس", Order = 1)]
        public IActionResult Index() => View();

        
    }
}