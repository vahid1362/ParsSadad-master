using System.Collections.Generic;
using System.Linq;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using QtasHelpDesk.Common.GuardToolkit;
using QtasHelpDesk.CrossCutting.IdentityToolkit;
using QtasHelpDesk.Domain.Content;
using QtasHelpDesk.Services.Content;
using QtasHelpDesk.Services.Contracts.Content;
using QtasHelpDesk.ViewModels.Content;

namespace QtasHelpDesk.Areas.Admin.Controllers
{   
    [Area("Admin")]
    public class PostController : Controller
    {
        #region Feild
        private readonly IPostService _postService;
        private readonly IToastNotification _toastNotification;
        private readonly  IGroupService _groupService;

        public PostController(IPostService postService, IToastNotification toastNotification, IGroupService groupService)
        {
            _postService = postService;
            _toastNotification = toastNotification;
            _groupService = groupService;
        }

        #endregion
       

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            return View();
        }


        public IActionResult Create()
        {  var groups = PrepareGroupSelectedListItem();
            return View(new PostViewModel()
            {
                SelectListItems = groups
            });
        }
        
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(PostViewModel model)
        {
            if (ModelState.IsValid)
            {
                _postService.Add(new Post()
                {   Title = model.Title,
                    Summary = model.Summary,
                    GroupId = model.GroupId,
                    Decription = model.Decription,
                   IsArticle=true,
                
                });
              
                _toastNotification.AddSuccessToastMessage("محتوی با موفقیت درج شد");
                return RedirectToAction("List");
            }
            var groups = PrepareGroupSelectedListItem();
            model.SelectListItems = groups;
            return View(model);
        }

        public IActionResult Edit(int? postId)
        {
            postId.CheckArgumentIsNull(nameof(postId));

          var post=_postService.GetPostById(postId.GetValueOrDefault());
          if (post == null)
          {
              _toastNotification.AddErrorToastMessage("چنین محتوایی یافت نشد");
            return  RedirectToAction("List");
          }
          var groups = PrepareGroupSelectedListItem();
            return View(new PostViewModel()
            {
                Id = post.Id,
                Title = post.Title,
                Summary = post.Summary,
                Decription = post.Decription,
                GroupId = post.GroupId,
                SelectListItems = groups

            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(PostViewModel postViewModel)
        {
            postViewModel.CheckArgumentIsNull(nameof(postViewModel));

            var post = _postService.GetPostById(postViewModel.Id);
            if (post == null)
            {
                _toastNotification.AddErrorToastMessage("چنین محتوایی یافت نشد");
                return RedirectToAction("List");
            }

            post.Title = postViewModel.Title;
            post.Summary = postViewModel.Summary;
            post.Decription = postViewModel.Decription;
            post.GroupId = postViewModel.GroupId;
            _postService.Edit(post);

            _toastNotification.AddSuccessToastMessage("چنین محتوایی یافت نشد");
            return RedirectToAction("List");


        }

        public IActionResult Post_Read([DataSourceRequest]DataSourceRequest request)
        {
            var postViewModels = _postService.GetPosts().Select(x => new PostViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Rate = x.Rate
            }).ToList();
            return Json(postViewModels.ToDataSourceResult(request));
        }

        private List<SelectListItem> PrepareGroupSelectedListItem()
        {
            var groups = _groupService.GetGroups().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.GetFormattedBreadCrumb(_groupService)
            }).ToList();
            groups.Insert(0,new SelectListItem(null,null));
            return groups;
        }

      
    }
}