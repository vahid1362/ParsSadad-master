using System.Linq;
using System.Text;
using Kendo.Mvc.UI;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using QtasHelpDesk.Common.GuardToolkit;
using QtasHelpDesk.Services.Contracts.Content;
using QtasHelpDesk.ViewModels.Content;

namespace QtasHelpDesk.Controllers
{
    [BreadCrumb]
    public class PostController : Controller
    {
        #region  Field

        private readonly IPostService _postService;
        private readonly IHostingEnvironment _hostingEnvironment;

        #endregion

        #region Ctor

        public PostController(IPostService postService, IHostingEnvironment hostingEnvironment)
        {
            _postService = postService;
            _postService.CheckArgumentIsNull(nameof(_postService));
            _hostingEnvironment = hostingEnvironment;
            _hostingEnvironment.CheckArgumentIsNull(nameof(_hostingEnvironment));
        }

        #endregion

        [BreadCrumb(Title = "مقالات", Order = 1)]
        public IActionResult Index()
        {
            var postViewModels = _postService.GetPosts().Select(x => new PostViewModel()
            {
                Title = x.Title,
                Summary = x.Summary,

            }).OrderByDescending(x => x.Id).ToList();
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
                var postUrl = this.Url.Action("ShowPost", "Post", new { postId = item.Id }, protocol: "http");

                result.AppendLine(item.Title+"|"+postUrl);
            }

            return Content(result.ToString());



        }

        public IActionResult ShowPost(int? postId)
        {
            postId.CheckArgumentIsNull(nameof(postId));

            var post = _postService.GetPostById(postId.GetValueOrDefault());
            if (post == null)
            {
                return View("~/views/shared/Error.cshtml");
            }

            byte[] pdfContent =
                System.IO.File.ReadAllBytes(_hostingEnvironment.WebRootPath + @"\Files\" + post.FilePath);

            if (pdfContent == null)
            {
                return null;
            }

            var contentDispositionHeader = new System.Net.Mime.ContentDisposition
            {
                Inline = true,
                FileName = "someFilename.pdf"
            };
            Response.Headers.Add("Content-Disposition", contentDispositionHeader.ToString());
            return File(pdfContent, System.Net.Mime.MediaTypeNames.Application.Pdf);


        }
    }
}