using System;
using System.Collections.Generic;
using System.Linq;
using DNTBreadCrumb.Core;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
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
    [BreadCrumb(Title = "سوالات متداول", UseDefaultRouteUrl = true, Order = 0)]
    public class FaqController : Controller
    {
        #region Feild
        private readonly IFaqService _faqService;
        private readonly IToastNotification _toastNotification;
        private readonly  IGroupService _groupService;
        private readonly IApplicationUserManager _userManager;

        public FaqController(IFaqService faqService, IToastNotification toastNotification, IGroupService groupService, IApplicationUserManager userManager)
        {
            _faqService = faqService;
            _toastNotification = toastNotification;
            _groupService = groupService;
            _userManager = userManager;
        }

        #endregion
       

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        [BreadCrumb(Title = "لیست",  Order = 1)]
        public IActionResult List()
        {
            return View();
        }

        [BreadCrumb(Title = "ایجاد", Order = 1)]
        public IActionResult Create()
        {  var groups = PrepareGroupSelectedListItem();
            return View(new FaqViewModel()
            {
                SelectListItems = groups
            });
        }
        
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(FaqViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                _faqService.Add(new Faq()
                {   Question= model.Question,
                    Reply = model.Reply,
                    GroupId = model.GroupId,
                    User = _userManager.GetCurrentUser(),
                    RegisteDate = DateTime.Now
                });
                _toastNotification.AddSuccessToastMessage("محتوی با موفقیت درج شد");
                return RedirectToAction("List");
            }
            
            var groups = PrepareGroupSelectedListItem();
            model.SelectListItems = groups;
            return View(model);
        }
        [BreadCrumb(Title = "ویرایش", Order = 1)]
        public IActionResult Edit(int? faqId)
        {
            faqId.CheckArgumentIsNull(nameof(faqId));

          var faq=_faqService.GetFaqById(faqId.GetValueOrDefault());
          if (faq == null)
          {
              _toastNotification.AddErrorToastMessage("چنین محتوایی یافت نشد");
            return  RedirectToAction("List");
          }
          var groups = PrepareGroupSelectedListItem();
            return View(new FaqViewModel()
            {
                Id = faq.Id,
                Question = faq.Question,
                Reply = faq.Reply,
                GroupId = faq.GroupId,
                SelectListItems = groups

            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(FaqViewModel faqViewModel)
        {
            faqViewModel.CheckArgumentIsNull(nameof(faqViewModel));
            _faqService.Edit(faqViewModel);
            _toastNotification.AddSuccessToastMessage("ویرایش با موفقیت انجام شد");
            return RedirectToAction("List");


        }

        public IActionResult Faq_Read([DataSourceRequest]DataSourceRequest request)
        {
            var postViewModels = _faqService.GetFaqs().Select(x => new FaqViewModel()
            {
                Id = x.Id,
                Question = x.Question
                
            }).ToList();
            return Json(postViewModels.ToDataSourceResult(request));
        }


        public ActionResult Faq_Delete([DataSourceRequest] DataSourceRequest request, FaqViewModel model)
        {
            if (model != null)
            {

                _faqService.Delete(model.Id);
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
            groups.Insert(0,new SelectListItem(null,null));
            return groups;
        }

      
    }
}