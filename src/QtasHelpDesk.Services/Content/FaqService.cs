using Microsoft.EntityFrameworkCore;
using QtasHelpDesk.DataLayer.Context;
using QtasHelpDesk.Domain.Content;
using QtasHelpDesk.Services.Contracts.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DNTPersianUtils.Core;
using QtasHelpDesk.Common.GuardToolkit;
using QtasHelpDesk.ViewModels.Content;

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

        public List<FaqViewModel> GetFaqsByGroupId(int groupId)
        {
            return _faqs.Where(x => x.GroupId == groupId).Select(x => new FaqViewModel()
            {
                Id = x.Id,
                Question = x.Question,
                Reply = x.Reply,
                UserFullName = x.User.DisplayName,
                Date = x.RegisteDate.ToLongPersianDateString()
            }).ToList();
        }

        public List<FaqViewModel> GetFaqs()
        {
            return _faqs.OrderByDescending(x=>x.Id).Select(x => new FaqViewModel()
            {
                Id = x.Id,
                Question = x.Question,
                Reply = x.Reply,
                UserFullName = x.User.DisplayName,
                Date = x.RegisteDate.ToLongPersianDateString()
            }).OrderByDescending(x => x.Id).Take(5).ToList().ToList();
        }
    }
}
