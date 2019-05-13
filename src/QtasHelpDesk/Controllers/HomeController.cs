using System;
using System.Linq;
using System.Threading.Tasks;
using DNTBreadCrumb.Core;
using DNTCaptcha.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NToastNotify;
using QtasHelpDesk.Areas.Admin.Controllers;
using QtasHelpDesk.CrossCutting.IdentityToolkit;
using QtasHelpDesk.Domain.Identity;
using QtasHelpDesk.Services.Contracts;
using QtasHelpDesk.Services.Contracts.Identity;
using QtasHelpDesk.ViewModels.Identity;
using QtasHelpDesk.ViewModels.Identity.Settings;
using SmsServiceReference;

namespace QtasHelpDesk.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IApplicationSignInManager _signInManager;
        private readonly IApplicationUserManager _userManager;
        private readonly IOptionsSnapshot<SiteSettings> _siteOptions;
        private readonly IRandomNumberProvider _randomNumberProvider;
        private readonly IToastNotification _toastNotification;
     

        public HomeController(ILogger<LoginController> logger, IApplicationSignInManager signInManager, IApplicationUserManager userManager, IOptionsSnapshot<SiteSettings> siteOptions, IRandomNumberProvider randomNumberProvider,  IToastNotification toastNotification)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _siteOptions = siteOptions;
            _randomNumberProvider = randomNumberProvider;
            _toastNotification = toastNotification;
           
        }

        [BreadCrumb(Title = "ایندکس", Order = 1)]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "post");
            }
            
            return RedirectToAction("Login");
        }

        [BreadCrumb(Title = "لاگین", Order = 1)]
        public IActionResult Login()
        {
            return View(new LoginViewModel());

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateDNTCaptcha(CaptchaGeneratorLanguage = DNTCaptcha.Core.Providers.Language.Persian)]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "نام کاربری و یا کلمه‌ی عبور وارد شده معتبر نیستند.");
                    return View(model);

                }
             
                if (!user.IsActive)
                {
                    ModelState.AddModelError(string.Empty, "اکانت شما غیرفعال شده‌است.");
                    return View(model);
                }

                if (_siteOptions.Value.EnableEmailConfirmation &&
                    !await _userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError("", "لطفا به پست الکترونیک خود مراجعه کرده و ایمیل خود را تائید کنید!");
                    return View(model);
                }

               
                var result = await _signInManager.PasswordSignInAsync(
                                        model.Username,
                                        model.Password,
                                        model.RememberMe,
                                        lockoutOnFailure: true);
        
                if (result.Succeeded)
                {
            

                    _logger.LogInformation(1, $"{model.Username} logged in.");
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    
                    return RedirectToAction("index","Post");
                }

                if (result.RequiresTwoFactor)
                {
                    return RedirectToAction(
                        nameof(TwoFactorController.SendCode),
                        "TwoFactor",
                        new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                }

                if (result.IsLockedOut)
                {
                    _logger.LogWarning(2, $"{model.Username} قفل شده‌است.");
                    return View("~/Areas/Admin/Views/TwoFactor/Lockout.cshtml");
                }

                if (result.IsNotAllowed)
                {
                    ModelState.AddModelError(string.Empty, "عدم دسترسی ورود.");
                    return View(model);
                }

                ModelState.AddModelError(string.Empty, "نام کاربری و یا کلمه‌ی عبور وارد شده معتبر نیستند.");
                return View(model);
            }
        
        
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public IActionResult NewPassword(string userName)
        {
            return View(new NewPasswordViewModel()
            {
                UserName = userName
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateDNTCaptcha(CaptchaGeneratorLanguage = DNTCaptcha.Core.Providers.Language.Persian)]
        public async Task<IActionResult> NewPassword(NewPasswordViewModel model)
       {
           
            if (ModelState.IsValid)
            {
                User user = null;
                if (model.UserName == null)
                {
                 user=_userManager.Users.FirstOrDefault(x => x.Mobile == model.Mobile);
                }
                else
                {
                    user = await _userManager.FindByNameAsync(model.UserName);
                }
             if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "کاربر موجود نمی باشد");
                    return View(model);
                }

                var password = ChanegePassword(user);
                SendSms(password, user);
                await _userManager.UpdateAsync(user);
                _toastNotification.AddInfoToastMessage("رمز عبور برای شما پیامک شده است");
                return RedirectToAction("Login");
                   
                }

                   
            return View(model);
        }

        private string ChanegePassword(User user)
        {
            var password = _randomNumberProvider.GeneratePassword();
            var hashPassword = _userManager.PasswordHasher.HashPassword(user, password);
            user.PasswordHash = hashPassword;
            user.UserConfirmed = true;
            user.Email = user.UserName + "@qtas.ir";
            return password;
        }

        private static void SendSms(string password, User user)
        {
            var client = new SendSMSClient();
            var text = "کاربر گرامی رمز سامانه شما" + password + " می باشد";
            var smsResult = client.SendSMSTextAsync(user.Mobile, text);
        }


        [BreadCrumb(Title = "خطا", Order = 1)]
        public IActionResult Error()
        {
            return View();
        }

    
        /// <summary>
        /// To test automatic challenge after redirecting from another site
        /// Sample URL: http://localhost:5000/Home/CallBackResult?token=1&status=2&orderId=3&terminalNo=4&rrn=5
        /// </summary>
        [Authorize]
        public IActionResult CallBackResult(long token, string status, string orderId, string terminalNo, string rrn)
        {
            var userId = User.Identity.GetUserId();
            return Json(new { userId, token, status, orderId, terminalNo, rrn });
        }

        public async Task<IActionResult> LogOff()
        {
            var user = User.Identity.IsAuthenticated ? await _userManager.FindByNameAsync(User.Identity.Name) : null;
            await _signInManager.SignOutAsync();
            if (user != null)
            {
                await _userManager.UpdateSecurityStampAsync(user);
                _logger.LogInformation(4, $"{user.UserName} logged out.");
            }

            return RedirectToAction("Index");
        }
        
        public string ConvertImageToBase64(byte[] binaryPicture)
        {
            if (binaryPicture == null)
                return string.Empty;
            var imageBase64 = Convert.ToBase64String(binaryPicture);
            string imageSrc = string.Format("data:image/png;base64,{0}", imageBase64);
            return imageSrc;
        }
    }
}