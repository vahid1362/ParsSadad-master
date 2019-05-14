using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QtasHelpDesk.Common.GuardToolkit;
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
            _postService.CheckArgumentIsNull(nameof(_postService));
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

        public IActionResult ShowPost(int? postId)
        {
            var postViewModels = _postService.GetPosts().Select(x => new PostViewModel()
            {
                Title = x.Title,
                Summary = x.Summary,

            }).OrderByDescending(x => x.Id).ToList();
            return View(postViewModels);
        }
    }
}