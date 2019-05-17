using QtasHelpDesk.Domain.Content;
using System.Collections.Generic;
using QtasHelpDesk.ViewModels.Content;

namespace QtasHelpDesk.Services.Contracts.Content
{
    public interface IFaqService
    {

        void Add(Faq post);

        void Edit(Faq post);

        List<FaqViewModel> GetFaqs();

        Faq GetFaqById(int id);

        List<Faq> Search(string text);

        List<FaqViewModel> GetFaqsByGroupId(int groupId);



    }
}
