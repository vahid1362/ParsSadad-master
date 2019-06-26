using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QtasHelpDesk.Services.Contracts.Content;
using QtasHelpDesk.ViewModels.Content;

namespace QtasHelpDesk.ViewComponents
{
    public class LastFaqViewComponent:ViewComponent
    {
        private readonly IFaqService _faqService;

        public LastFaqViewComponent(IFaqService faqService)
        {
            _faqService = faqService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var faqViewModel = _faqService.GetLastFaq();
            return View(viewName: "~/Views/Shared/Components/LastFaq/Default.cshtml",
                model: faqViewModel);
        }
    }
}