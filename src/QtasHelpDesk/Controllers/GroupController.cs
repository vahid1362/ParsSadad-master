using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QtasHelpDesk.Common.GuardToolkit;
using QtasHelpDesk.Services.Contracts.Content;
using QtasHelpDesk.ViewModels.Content;

namespace QtasHelpDesk.Controllers
{
    public class GroupController : Controller
    {
        #region Properties
        private readonly  IPostService  _postService;
        
        #endregion

        #region Ctor
        public GroupController( IPostService postService)
        {
           _postService = postService;
           _postService.CheckArgumentIsNull(nameof(_postService));
        }
        
        #endregion
        public IActionResult Index(int? groupId)
        {
            groupId.CheckArgumentIsNull(nameof(groupId));
            var postViewModels=_postService.GetPostsByGroupId(groupId.GetValueOrDefault()).Select(x=>new PostViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Summary = x.Summary
            }).ToList();
            return View(postViewModels);
        }
    }
}