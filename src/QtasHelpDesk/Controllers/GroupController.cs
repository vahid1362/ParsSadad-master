using System.Collections.Generic;
using System.Linq;
using DNTBreadCrumb.Core;
using DNTPersianUtils.Core;
using Microsoft.AspNetCore.Mvc;
using QtasHelpDesk.Common.GuardToolkit;
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
            var groupName = _groupService.GetGroupName(groupId.GetValueOrDefault());

            var postViewModels = GetLastPosts(groupId.GetValueOrDefault());
            var faqViewModels = GetLastFaq(groupId.GetValueOrDefault());

            var informationViewModel = new InformationViewModel();
            informationViewModel.PostViewModels = postViewModels;
            informationViewModel.FaqViewModels = faqViewModels;
            this.SetCurrentBreadCrumbTitle(groupName);
            return View(informationViewModel);
        }
        private List<FaqViewModel> GetLastFaq(int groupId)
        {
            var faqViewModels = _faqService.GetFaqsByGroupId(groupId,int.MaxValue);
            return faqViewModels;
        }

        private List<PostViewModel> GetLastPosts(int groupId)
        {
            var postViewModels = _postService.GetPostsByGroupId(groupId,int.MaxValue);
            return postViewModels;
        }
    }
}