﻿using QtasHelpDesk.Domain.Content;
using System.Collections.Generic;
using QtasHelpDesk.ViewModels.Content;

namespace QtasHelpDesk.Services.Contracts.Content
{
    public interface IFaqService
    {

        void Add(Faq post);

        void Edit(Faq post);

        List<FaqViewModel> GetFaqs();

        List<FaqViewModel> GetLastFaqs();

        Faq GetFaqById(int id);

        List<FaqViewModel> Search(string text);

        List<FaqViewModel> GetFaqsByGroupId(int groupId);

        void Delete(int id);
    }
}
