using DNTPersianUtils.Core;
using Microsoft.AspNetCore.Mvc;
using QtasHelpDesk.Common.GuardToolkit;
using QtasHelpDesk.Services.Contracts.Content;
using QtasHelpDesk.ViewModels.Content;

namespace QtasHelpDesk.Controllers
{
    public class FaqController : Controller
    {
        #region Feild

        private readonly IFaqService _faqService;

        #endregion

        #region Ctor
        public FaqController(IFaqService faqService)
        {
            _faqService = faqService;
        }


        #endregion
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowFaq(int? faqId)
        {
            faqId.CheckArgumentIsNull(nameof(faqId));
            var faq= _faqService.GetFaqById(faqId.GetValueOrDefault());
            var faqViewModel = new FaqViewModel(
            )
            {
                Question = faq.Question,
                Reply = faq.Reply,
                UserFullName = faq.User.DisplayName,
                Date = faq.RegisteDate.ToShortPersianDateString()
            };
            return View(faqViewModel);
        }
    }
}