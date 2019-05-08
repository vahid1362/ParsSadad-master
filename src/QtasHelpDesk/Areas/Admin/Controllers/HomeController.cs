using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QtasHelpDesk.Services.Identity;

namespace QtasHelpDesk.Areas.Admin.Controllers
{
    [Area(AreaConstants.AdminArea)]
    [Authorize(Roles = ConstantRoles.Admin)]
    [BreadCrumb(Title = "خانه", UseDefaultRouteUrl = true, Order = 0)]
    public class HomeController : Controller
    {
        [BreadCrumb(Title = "ایندکس", Order = 1)]
        public IActionResult Index() => View();

        
    }
}