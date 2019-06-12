using QtasHelpDesk.Domain.Content;
using System.Collections.Generic;
using QtasHelpDesk.ViewModels.Content;

namespace QtasHelpDesk.Services.Contracts.Content
{
    public interface IFaqService
    {

        void Add(Faq post);

        void Edit(FaqViewModel faq);

        List<FaqViewModel> GetFaqs();

        List<FaqViewModel> GetLastFaqs();

        FaqViewModel GetFaqById(int id);

        List<FaqViewModel> Search(string text);

        List<FaqViewModel> GetFaqsByGroupId(int groupId,int numRecord);

        void Delete(int id);
    }
}
