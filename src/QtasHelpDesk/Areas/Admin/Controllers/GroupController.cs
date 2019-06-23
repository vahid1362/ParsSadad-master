using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DNTBreadCrumb.Core;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Net.Http.Headers;
using NToastNotify;
using QtasHelpDesk.Domain.Content;
using QtasHelpDesk.Services.Content;
using QtasHelpDesk.Services.Contracts.Content;
using QtasHelpDesk.Services.Identity;
using QtasHelpDesk.ViewModels.Content;

namespace QtasHelpDesk.Areas.Admin.Controllers
{
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [DisplayName("بخش گروه")]
    [Area("Admin")]
    [BreadCrumb(Title = "گروه ها", UseDefaultRouteUrl = false, RemoveAllDefaultRouteValues = true,
        Order = 0, GlyphIcon = "glyphicon glyphicon-link")]
    public class GroupController : Controller
    {
        #region Feild

        private readonly IMapper _mapper;
        private readonly IGroupService _groupService;
        private readonly IToastNotification _toastNotification;
 

        #endregion

        #region Ctor

        public GroupController(IMapper mapper,  IToastNotification toastNotification, IGroupService groupService)
        {
            _mapper = mapper;
         
            _toastNotification = toastNotification;
            _groupService = groupService;
        }


        #endregion

        [DisplayName("ایندکس")]
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        [DisplayName("نمایش گروه ها")]
        [BreadCrumb(Title = "لیست گروه ها", Order = 1)]
        public IActionResult List()
        {
            return View();
        }
        [DisplayName("نمایش صفحه  ایجاد گروه")]
        [BreadCrumb(Title = "ایجاد گروه جدید", Order = 1)]
        public IActionResult Create()
        {
            var groups = PrepareGroupSelectedListItem();

            return View(new GroupViewModel()
            {
                AvaiableGroup = groups
               

            });
            
        }

        [DisplayName("ایجاد گروه")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GroupViewModel groupViewModel)
        {
            if (ModelState.IsValid)
            {
                var group = _mapper.Map<Group>(groupViewModel);
                _groupService.AddGroup(group);
                if (group.Id > 0)
                {
                    _toastNotification.AddSuccessToastMessage("عملیات  با موفقیت صورت پذیرفت");
                    return RedirectToAction("List");
                }
                _toastNotification.AddErrorToastMessage("خطا در انجام عملیات");

            }

            return View(new GroupViewModel());
        }

        [DisplayName("نمایش صفحه  ویرایش گروه")]
        [BreadCrumb(Title = "ویرایش گروه", Order = 1)]
        public IActionResult Edit(long? groupId)
        {
            if (groupId == null)
            {
                _toastNotification.AddErrorToastMessage("خطا در پار متر ورودی");
                RedirectToAction("List");
            }

            var group = _groupService.GetGroupById(groupId.GetValueOrDefault());

            if (group == null)
                RedirectToAction("List");

            var groupViewModel = _mapper.Map<GroupViewModel>(group);

            var groups = PrepareGroupSelectedListItem();
            
            groupViewModel.AvaiableGroup = groups;
           return View(groupViewModel);
        }

        [DisplayName("ویرایش گروه")]
        [HttpPost]
        public IActionResult Edit(GroupViewModel model)
        {
            if (model == null)
                _toastNotification.AddErrorToastMessage("خطا در پار متر ورودی");

            var group = _groupService.GetGroupById(model.Id);

            if (group == null)
             return   RedirectToAction("List");

        
                group.Title = model.Title;
                group.ParentId = model.ParentId;
                group.Priority = model.Priority;
              group.IsPrivate = model.IsPrivate;

            _groupService.EditGroup(@group);
           

            _toastNotification.AddSuccessToastMessage("عملیات  با موفقیت صورت پذیرفت");

            return RedirectToAction("List");
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

        [DisplayName("لیست تمامی گروه ها")]
        public JsonResult Group_Read([DataSourceRequest] DataSourceRequest request)
        {
            var groupViewModels = _groupService.GetGroups().Select(x => new GroupViewModel
            {
                Id = x.Id,
                BreadCrumbName = x.GetFormattedBreadCrumb(_groupService),
                Title = x.Title,
                IsPrivate = x.IsPrivate,
                Priority = x.Priority
            }).ToList();


            return Json(groupViewModels.ToDataSourceResult(request));
        }

        public async Task<IActionResult> Get_Group()
        {
    

            return Json(PrepareGroupSelectedListItem());
        }
    }
}