using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DNTBreadCrumb.Core;
using DNTCaptcha.Core;
using DNTCommon.Web.Core;
using DNTPersianUtils.Core;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using QtasHelpDesk.Common.GuardToolkit;
using QtasHelpDesk.CrossCutting.IdentityToolkit;
using QtasHelpDesk.Domain.Identity;
using QtasHelpDesk.Services.Contracts.Content;
using QtasHelpDesk.Services.Contracts.Identity;

using QtasHelpDesk.Services.Identity;
using QtasHelpDesk.ViewModels.Identity;

namespace QtasHelpDesk.Areas.Admin.Controllers
{
    [Authorize(Roles = ConstantRoles.Admin)]
    [Area(AreaConstants.AdminArea)]
    [BreadCrumb(Title = "مدیریت کاربران", UseDefaultRouteUrl = true, Order = 0)]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IApplicationUserManager _userManager;
        private readonly IProtectionProviderService _protectionProviderService;
        private readonly IUserValidator<User> _userValidator;
        private readonly IUsedPasswordsService _usedPasswordsService;
        private readonly IApplicationSignInManager _signInManager;
        private readonly IToastNotification _toastNotification;
        private readonly IGroupService _groupService;
     

        public UserController(IApplicationUserManager userManager, IProtectionProviderService protectionProviderService,
            IUserValidator<User> userValidator, IUsedPasswordsService usedPasswordsService, IApplicationSignInManager signInManager, IToastNotification toastNotification, IMapper mapper, IGroupService groupService)
        {
            _userManager = userManager;
            _protectionProviderService = protectionProviderService;
            _userValidator = userValidator;
            _usedPasswordsService = usedPasswordsService;
            _signInManager = signInManager;
            _toastNotification = toastNotification;
          
            _mapper = mapper;
            _groupService = groupService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        [BreadCrumb(Title = "لیست کاربران", Order = 1)]
        public IActionResult List()
        {
            return View();
        }

        public IActionResult User_Read([DataSourceRequest] DataSourceRequest request)
        {
            var userViewModels = _mapper.Map<List<UserViewModel>>(_userManager.Users);

            foreach (var userViewModel in userViewModels.Skip((request.Page - 1) * request.PageSize).Take(request.Page * request.PageSize))
            {
                
               
            }
            return Json(userViewModels.ToDataSourceResult(request));

        }

        [BreadCrumb(Title = "ایجاد کاربر جدید", Order = 1)]
        public IActionResult Create()
        {
            return View(new RegisterUserViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(model);
                user.PersonCode = int.Parse(user.UserName);
                user.Email = user.UserName + "@a.com";
                user.UserConfirmed = true;
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _toastNotification.AddSuccessToastMessage("عملیات با موفقیت انجام شد");
                    return RedirectToAction("List");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [BreadCrumb(Title = "ویرایش کاربران", Order = 1)]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return RedirectToAction("List");
            }

            var userViewModel = _mapper.Map<UserViewModel>(user);

            if (user.BirthDate != null)
            {
                userViewModel.DateOfBirthDay = user.BirthDate.ToPersianYearMonthDay().Day;
                userViewModel.DateOfBirthMonth = user.BirthDate.ToPersianYearMonthDay().Month;
                userViewModel.DateOfBirthYear = user.BirthDate.ToPersianYearMonthDay().Year;
            }

            return View(userViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(UserViewModel model)
        {
            if (model == null)
            {
                return View("Error");
            }

            var user = await _userManager.FindByIdAsync(model.Id.ToString());
            if (user == null)
            {
                return RedirectToAction("List");
            }

            if (model.DateOfBirthYear.HasValue &&
                model.DateOfBirthMonth.HasValue &&
                model.DateOfBirthDay.HasValue)
            {
                var date =
                    $"{model.DateOfBirthYear.Value.ToString()}/{model.DateOfBirthMonth.Value:00}/{model.DateOfBirthDay.Value:00}";
                user.BirthDate = date.ToGregorianDateTimeOffset();
            }
            else
            {
                user.BirthDate = null;
            }

            user.NationalIdentity = model.NationalIdentity.IsValidIranianNationalCode() ? model.NationalIdentity : null;

            user.UserName = model.UserName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.NationalIdentity = model.NationalIdentity;
            user.Mobile = model.Mobile;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return View(model);
            }
            _toastNotification.AddSuccessToastMessage("عملیات با موفقیت انجام شد");
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> ValidateUsername(string username, string id)
        {
            //var result = await _userValidator.ValidateAsync(
            //    (UserManager<User>) _userManager, new User {UserName = username});
            //return Json(result.Succeeded ? "true" : result.DumpErrors(useHtmlNewLine: true));

            if (string.IsNullOrWhiteSpace(id))
            {
                return Json("اطلاعات وارد شده معتبر نیست.");
            }

            var user = await _userManager.FindByIdAsync(id);
            user.UserName = username;

            var result = await _userValidator.ValidateAsync((UserManager<User>)_userManager, user);
            return Json(result.Succeeded ? "true" : result.DumpErrors(useHtmlNewLine: true));

        }

        [BreadCrumb(Title = "سطح دسترسی کاربران", Order = 1)]

        public async Task<IActionResult> EditUserGroup(int userId)
        {
            userId.CheckArgumentIsNull(nameof(userId));
             return View();
        }

        public async Task<IActionResult> UserGroup_Read([DataSourceRequest]DataSourceRequest request, int userId)
        {
          var userGroupsViewModel=  _groupService.GetUserGroups(userId);

          return Json(userGroupsViewModel.ToDataSourceResult(request));
        }
    }
}
