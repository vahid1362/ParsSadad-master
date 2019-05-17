using System.Collections.Generic;
using System.Linq;
using System.Text;
using DNTBreadCrumb.Core;
using DNTPersianUtils.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using QtasHelpDesk.Common.GuardToolkit;
using QtasHelpDesk.Services.Contracts.Content;
using QtasHelpDesk.ViewModels.Content;

namespace QtasHelpDesk.Controllers
{
    [BreadCrumb(Title = "پست ها", UseDefaultRouteUrl = true, RemoveAllDefaultRouteValues = true,
        Order = 0, GlyphIcon = "glyphicon glyphicon-link")]
    public class PostController : Controller
    {
        #region  Field

        private readonly IPostService _postService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IFaqService _faqService;

        #endregion

        #region Ctor

        public PostController(IPostService postService, IHostingEnvironment hostingEnvironment, IFaqService faqService)
        {
            _postService = postService;
            _postService.CheckArgumentIsNull(nameof(_postService));
            _hostingEnvironment = hostingEnvironment;
            _faqService = faqService;
            _hostingEnvironment.CheckArgumentIsNull(nameof(_hostingEnvironment));
        }

        #endregion

        [BreadCrumb(Title = "ایندکس", Order = 1)]
        public IActionResult Index()
        {
            var postViewModels = GetLastPosts();
            var faqViewModels = GetLastFaq();

            var informationViewModel=new InformationViewModel();
            informationViewModel.PostViewModels = postViewModels;
            informationViewModel.FaqViewModels = faqViewModels;
            return View(informationViewModel);
        }

        private List<FaqViewModel> GetLastFaq()
        {
            var faqViewModels = _faqService.GetFaqs().Select(x => new FaqViewModel()
            {
                Id = x.Id,
                Question = x.Question,
                Reply = x.Reply,
                UserFullName = x.User.DisplayName,
                Date = x.RegisteDate.ToFriendlyPersianDateTextify()
            }).OrderByDescending(x => x.Id).Take(5).ToList();
            return faqViewModels;
        }

        private List<PostViewModel> GetLastPosts()
        {
            var postViewModels = _postService.GetPosts().Select(x => new PostViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Summary = x.Summary,
                UserFullName = x.User.DisplayName,
                Date = x.RegisteDate.ToFriendlyPersianDateTextify(),
            }).OrderByDescending(x => x.Id).Take(5).ToList();
            return postViewModels;
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
        [BreadCrumb(Title = "ایندکس", Order = 1)]
        public IActionResult ShowPost(int? postId)
        {
            postId.CheckArgumentIsNull(nameof(postId));

            var post = _postService.GetPostById(postId.GetValueOrDefault());
            if (post == null)
            {
                return View("~/views/shared/Error.cshtml");
            }
            var postViewModel=new PostViewModel()
            {   Id = post.Id,
                Title = post.Title,
                Summary = post.Summary,
               Date= post.RegisteDate.ToFriendlyPersianDateTextify(),
               UserFullName = post.User.DisplayName
               
            };
            this.SetCurrentBreadCrumbTitle(post.Title);
            return View(postViewModel);
            
        }

        public IActionResult ShowPdf(int? postId)
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