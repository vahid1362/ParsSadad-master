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
using QtasHelpDesk.ViewModels.Search;

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
        private readonly IGroupService _groupService;
        


        #endregion

        #region Ctor

        public PostController(IPostService postService, IHostingEnvironment hostingEnvironment, IFaqService faqService,
             IGroupService groupService)
        {
            _postService = postService;
            _postService.CheckArgumentIsNull(nameof(_postService));
            _hostingEnvironment = hostingEnvironment;
            _faqService = faqService;
            _hostingEnvironment.CheckArgumentIsNull(nameof(_hostingEnvironment));

            _groupService = groupService;
        }

        #endregion

        [BreadCrumb(Title = "ایندکس", Order = 1)]
        public IActionResult Index()
        {

            //var postViewModels = GetLastPosts();
            //var faqViewModels = GetLastFaq();

            var informationViewModel = new InformationViewModel();
            //informationViewModel.PostViewModels = postViewModels;
            //informationViewModel.FaqViewModels = faqViewModels;
            return PartialView(informationViewModel);



        }

        public IActionResult GetPosts()
        {
            var postViewModels = GetLastPosts();

            return PartialView("_Posts", postViewModels);
        }

        private List<FaqViewModel> GetLastFaq()
        {
            var faqViewModels = _faqService.GetFaqs();
            return faqViewModels;
        }

        private List<PostViewModel> GetLastPosts()
        {
            var postViewModels = _postService.GetLastPosts();
            return postViewModels;
        }

        public virtual ActionResult Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return Content(string.Empty);

            var result = new StringBuilder();

            var faqs = _faqService.Search(keyword.Trim());

            var items = _postService.Search(keyword.Trim());

            var searchResults = new List<SearchResultViewModel>();
            foreach (var item in items)
            {
                var postUrl = this.Url.Action("ShowPost", "Post", new { postId = item.Id });
                searchResults.Add(new SearchResultViewModel()
                {
                    Title = item.Title,
                    Link = postUrl
                });
                //result.AppendLine(item.Title + "|" + postUrl);
            }

            foreach (var faq in faqs)
            {
                var postUrl = this.Url.Action("ShowFaq", "Faq", new { faqId = faq.Id });

                searchResults.Add(new SearchResultViewModel()
                {
                    Title = faq.Question,
                    Link = postUrl
                });  //result.AppendLine(faq.Question + "|" + postUrl);
            }

            return Json(searchResults);



        }

        [BreadCrumb(Title = "ایندکس", Order = 1)]
        public IActionResult ShowPost(int? postId)
        {
            postId.CheckArgumentIsNull(nameof(postId));

            var postViewModel = _postService.GetPostById(postId.GetValueOrDefault());
            if (postViewModel == null)
            {
                return View("~/views/shared/Error.cshtml");
            }

           
            this.SetCurrentBreadCrumbTitle(postViewModel.Title);
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
            if (!System.IO.File.Exists(_hostingEnvironment.WebRootPath + @"\Files\" + post.FilePath))
            {
                
                return View("~/views/shared/NotFound.cshtml");
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


        public IActionResult GetGroups([FromQuery]int? parentId)
        {

            var groupViewModels = _groupService.GetParentGroup(parentId);

            foreach (var groupViewModel in groupViewModels)
            {
                groupViewModel.Title = "<a href='" +
                                         @Url.Action("index", "Group", new { groupId = groupViewModel.Id }) + "' > " +
                                         groupViewModel.Title + "</a>";
            }

            return Json(groupViewModels);



            //      groupViewModel.Title = "<a href='" +
            //                               @Url.Action("index", "Group", new {groupId = groupViewModel.Id}) + "' > " +
            //                               groupViewModel.Title + "</a>";


            //foreach (var groupViewModel in groupViewModels)
            //{
            //    var subgroups= _groupService.GetSubGroup(groupViewModel.Id);
            //      groupViewModel.Title = "<a href='" +
            //                               @Url.Action("index", "Group", new {groupId = groupViewModel.Id}) + "' > " +
            //                               groupViewModel.Title + "</a>";


            //    //groupViewModel.children = subgroups;

            //    //foreach (var  subgroup in subgroups)
            //    //{
            //    //    var childGroupViewModel = _groupService.GetSubGroup(subgroup.Id);

            //    //        subgroup.Title = "<a href='" +
            //    //                               @Url.Action("index", "Group", new { groupId = subgroup.Id }) + "' > " +
            //    //                               subgroup.Title + "</a>";


            //    //    subgroup.children = childGroupViewModel;
            //    //    foreach (var childSubGroup in subgroup.children)
            //    //    {
            //    //        childSubGroup.Title = "<a href='" +
            //    //                         @Url.Action("index", "Group", new { groupId = childSubGroup.Id }) + "' > " +
            //    //                         childSubGroup.Title + "</a>";


            //    //    }

            //    //}

            //}



        }
    }
}