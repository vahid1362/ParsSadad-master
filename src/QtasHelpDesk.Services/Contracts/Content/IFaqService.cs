using QtasHelpDesk.Domain.Content;
using System.Collections.Generic;

namespace QtasHelpDesk.Services.Contracts.Content
{
    public interface IFaqService
    {

        void Add(Faq post);

        void Edit(Faq post);

        List<Faq> GetFaqs();

        Faq GetFaqById(int id);

        List<Faq> Search(string text);

        List<Faq> GetFaqsByGroupId(int groupId);



    }
}
