using System.Collections.Generic;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Mvc;
using QtasHelpDesk.Common.GuardToolkit;
using QtasHelpDesk.Services.Content;
using QtasHelpDesk.Services.Contracts.Content;
using QtasHelpDesk.ViewModels.Content;

namespace QtasHelpDesk.Controllers
{
    [BreadCrumb(Title = "گروه", UseDefaultRouteUrl = true, RemoveAllDefaultRouteValues = true,
        Order = 0, GlyphIcon = "glyphicon glyphicon-link")]
    public class GroupController : Controller
    {
        #region Properties
        private readonly  IPostService  _postService;
        private readonly IFaqService _faqService;
        private readonly IGroupService _groupService;
        
        #endregion

        #region Ctor
        public GroupController( IPostService postService, IFaqService faqService, IGroupService groupService)
        {
           _postService = postService;
           _faqService = faqService;
           _groupService = groupService;
           _postService.CheckArgumentIsNull(nameof(_postService));
        }

        #endregion
        [BreadCrumb(Title = "ایندکس", Order = 1)]
        public IActionResult Index(int? groupId)
        {
            groupId.CheckArgumentIsNull(nameof(groupId));
            var group = _groupService.GetGroupById(groupId.GetValueOrDefault());

            //var postViewModels = GetLastPosts(groupId.GetValueOrDefault());
            //var faqViewModels = GetLastFaqs(groupId.GetValueOrDefault());

            var informationViewModel = new InformationViewModel();
            //informationViewModel.PostViewModels = postViewModels;
            //informationViewModel.FaqViewModels = faqViewModels;
            this.SetCurrentBreadCrumbTitle(group.GetFormattedBreadCrumb(_groupService, "/"));
            return View();
        }
        private List<FaqViewModel> GetLastFaqs(int groupId)
        {
            var faqViewModels = _faqService.GetFaqsByGroupId(groupId,int.MaxValue);
            return faqViewModels;
        }

        private List<PostViewModel> GetLastPosts(int groupId)
        {
            var postViewModels = _postService.GetPostsByGroupId(groupId,int.MaxValue);
            return postViewModels;
        }


        [Route("/post/FilterContent/{showPost}/{showfaq}/{groupId}")]
        [HttpPost]
        public IActionResult FilterContent(bool showPost, bool showFaq, int groupId)
        {
            if ((showPost && !showFaq))
            {
                var postViewModels = GetLastPosts(groupId);
                return PartialView("_Posts", postViewModels);
            }
            if (!showPost && showFaq)
            {
                var faqViewModels = GetLastFaqs(groupId);


                return PartialView("_faqs", faqViewModels);
            }

            if (showPost && showFaq)
            {
                var faqViewModels = GetLastFaqs(groupId);
                var postViewModels = GetLastPosts(groupId);

                return PartialView("_MainContent", new InformationViewModel()
                {
                    FaqViewModels = faqViewModels,
                    PostViewModels = postViewModels
                });
            }

            return PartialView("");
        }

    }


}