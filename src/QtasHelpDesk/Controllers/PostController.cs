using System.Linq;
using System.Text;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using QtasHelpDesk.Services.Contracts.Content;
using QtasHelpDesk.ViewModels.Content;

namespace QtasHelpDesk.Controllers
{
    public class PostController : Controller
    {
        #region  Field

        private readonly IPostService _postService;

        #endregion

        #region Ctor
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        #endregion



        public IActionResult Index()
        {
            var postViewModels = _postService.GetPosts().Select(x => new PostViewModel()
            {
                Title = x.Title,
                Summary = x.Summary,
            
            }).OrderByDescending(x=>x.Id).ToList();
            return View(postViewModels);
        }
        public virtual ActionResult Search(string q)
        {
            if (string.IsNullOrWhiteSpace(q))
                return Content(string.Empty);

            var result = new StringBuilder();
            var items = _postService.Search(q);
            foreach (var item in items)
            {
                var postUrl = this.Url.Action( "Index",  "Home", new { id = item.Id }, protocol: "http");
                result.AppendLine(item.Title + "|" + postUrl);
            }

            return Content(result.ToString());
        }
    }
}