using Microsoft.EntityFrameworkCore;
using QtasHelpDesk.DataLayer.Context;
using QtasHelpDesk.Domain.Content;
using QtasHelpDesk.Services.Contracts.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QtasHelpDesk.Common.GuardToolkit;

namespace QtasHelpDesk.Services.Content
{
   public class FaqService : IFaqService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Faq> _faqs;

        public FaqService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.CheckArgumentIsNull(nameof(_uow));
            _faqs = _uow.Set<Faq>();
        }

        public void  Add(Faq post)
        {
            _faqs.Add(post);
            _uow.SaveChanges();
        }

        public void Edit(Faq faq)
        {
            _uow.SaveChanges();
        }

        public Faq GetFaqById(int id)
        {
            return _faqs.FirstOrDefault(x => x.Id == id );
        }

     

        public List<Faq> Search(string text)
        {
            return _faqs.Where(x => x.Question.Contains(text)).ToList();
        }

        public List<Faq> GetFaqsByGroupId(int groupId)
        {
            return _faqs.Where(x => x.GroupId == groupId).ToList();
        }

        public List<Faq> GetFaqs()
        {
            return _faqs.ToList();
        }
    }
}
