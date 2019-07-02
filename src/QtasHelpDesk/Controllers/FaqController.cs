using System.Collections.Generic;
using DNTBreadCrumb.Core;
using DNTPersianUtils.Core;
using Microsoft.AspNetCore.Mvc;
using QtasHelpDesk.Common.GuardToolkit;
using QtasHelpDesk.Services.Contracts.Content;
using QtasHelpDesk.ViewModels.Content;

namespace QtasHelpDesk.Controllers
{
    [BreadCrumb(Title = "سوالات نتداول", UseDefaultRouteUrl = true, RemoveAllDefaultRouteValues = true,
        Order = 0, GlyphIcon = "glyphicon glyphicon-link")]
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
        [BreadCrumb(Title = "ایندکس", Order = 1)]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowFaq(int? faqId)
        {
            faqId.CheckArgumentIsNull(nameof(faqId));
           
            var faqViewModel= _faqService.GetFaqById(faqId.GetValueOrDefault());
            this.SetCurrentBreadCrumbTitle(faqViewModel.Question);
            return View(faqViewModel);
        }


        public IActionResult GetFaqs()
        {
            var faqViewModels = GetLastFaq();
          
            return PartialView("_faqs", faqViewModels);
        }

        private List<FaqViewModel> GetLastFaq()
        {
            var faqViewModels = _faqService.GetFaqs();
            return faqViewModels;
        }
    }
}