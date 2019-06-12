using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using DNTBreadCrumb.Core;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using QtasHelpDesk.Common.GuardToolkit;
using QtasHelpDesk.Domain.Content;

using QtasHelpDesk.Services.Content;
using QtasHelpDesk.Services.Contracts.Content;
using QtasHelpDesk.Services.Contracts.Identity;
using QtasHelpDesk.Services.Identity;
using QtasHelpDesk.ViewModels.Content;

namespace QtasHelpDesk.Areas.Admin.Controllers
{
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [DisplayName("بخش مقالات")]
    [Area("Admin")]
    [BreadCrumb(Title = "مقالات", UseDefaultRouteUrl = true, Order = 0)]
    public class PostController : Controller
    {
        #region Feild
        private readonly IPostService _postService;
        private readonly IToastNotification _toastNotification;
        private readonly  IGroupService _groupService;
        private readonly IApplicationUserManager _userManager;
        private readonly IHostingEnvironment _hostingEnvironment;

        

        #endregion


        #region Ctor

        public PostController(IPostService postService, IToastNotification toastNotification, IGroupService groupService, IApplicationUserManager userManager, IHostingEnvironment hostingEnvironment)
        {
            _postService = postService;
            _toastNotification = toastNotification;
            _groupService = groupService;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
  

        }
        #endregion

        [DisplayName("ایندکس")]
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        [DisplayName("نمایش مقالات")]
        [BreadCrumb(Title = "لیست",  Order = 1)]
        public IActionResult List()
        {
            return View();
        }
        [DisplayName("صفحه ایجاد مقاله")]
        [BreadCrumb(Title = "ایجاد", Order = 1)]
        public IActionResult Create()
        {  var groups = PrepareGroupSelectedListItem();
            return View(new PostViewModel()
            {
                SelectListItems = groups
            });
        }

        [DisplayName("صفحه ثبت مقاله جدید")]
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(PostViewModel model)
        {
            if (ModelState.IsValid)
            {
                var post = new Post()
                {
                    Title = model.Title,
                    Summary = model.Summary,
                    GroupId = model.GroupId,
                    Decription = model.Decription,
                    FilePath = model.FilePath,
                    User = _userManager.GetCurrentUser(),
                    RegisteDate = DateTime.Now,
                    IsArticle = true,

                };
                _postService.Add(post);
                _toastNotification.AddSuccessToastMessage("محتوی با موفقیت درج شد");
              return RedirectToAction("List");
            }
            var groups = PrepareGroupSelectedListItem();
            model.SelectListItems = groups;
            return View(model);
        }
        [DisplayName("صفحه ویرایش مقاله")]
        [BreadCrumb(Title = "ویرایش", Order = 1)]
        public IActionResult Edit(int? postId)
        {
            postId.CheckArgumentIsNull(nameof(postId));

          var postViewModel=_postService.GetPostById(postId.GetValueOrDefault());

          var groups = PrepareGroupSelectedListItem();
            postViewModel.SelectListItems = groups;
            return View(postViewModel);
        }

        [DisplayName("صفحه ثبت ویرایش مقاله")]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(PostViewModel postViewModel)
        {
            postViewModel.CheckArgumentIsNull(nameof(postViewModel));

           
            _postService.Edit(postViewModel);

           
            _toastNotification.AddSuccessToastMessage("چنین محتوایی یافت نشد");
            return RedirectToAction("List");


        }
        [DisplayName("لیست کردن مقاله")]
        public IActionResult Post_Read([DataSourceRequest]DataSourceRequest request)
        {
            var postViewModels = _postService.GetPosts();
            return Json(postViewModels.ToDataSourceResult(request));
        }
        [DisplayName("آپلود فایل")]
        public IActionResult SaveFile(List<IFormFile> files,string  filePath)
        {
            var file = files.FirstOrDefault();

            if (file == null || file.Length == 0)
                return Content("file not selected");
            var fileExtension = Path.GetExtension(file.FileName);
            var randomFileName = Guid.NewGuid()+fileExtension;
          
            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/files",
                randomFileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            var relativePath =  randomFileName;

            return Json(new
            {
                success = true,
               filePath= relativePath
            });
        }
        [DisplayName("حذف پست")]
        public ActionResult Post_Delete([DataSourceRequest] DataSourceRequest request, PostViewModel model)
        {
            if (model != null)
            {
            
               _postService.Delete(model.Id);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        private List<SelectListItem> PrepareGroupSelectedListItem()
        {
            var groups = _groupService.GetGroups().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.GetFormattedBreadCrumb(_groupService)
            }).ToList();
       
            return groups;
        }

      
    }
}