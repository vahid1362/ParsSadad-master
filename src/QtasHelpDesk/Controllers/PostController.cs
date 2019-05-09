using Microsoft.AspNetCore.Mvc;

namespace QtasHelpDesk.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}