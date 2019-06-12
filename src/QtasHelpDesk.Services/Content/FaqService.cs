using Microsoft.EntityFrameworkCore;
using QtasHelpDesk.DataLayer.Context;
using QtasHelpDesk.Domain.Content;
using QtasHelpDesk.Services.Contracts.Content;
using System.Collections.Generic;
using System.Linq;
using DNTPersianUtils.Core;
using QtasHelpDesk.Common.GuardToolkit;
using QtasHelpDesk.ViewModels.Content;

namespace QtasHelpDesk.Services.Content
{
   public class FaqService : IFaqService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Faq> _faqs;
        private readonly DbSet<Group> _groups;

        public FaqService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.CheckArgumentIsNull(nameof(_uow));
            _faqs = _uow.Set<Faq>();
            _groups = _uow.Set<Group>();
        }

        public void  Add(Faq post)
        {
            _faqs.Add(post);
            _uow.SaveChanges();
        }

        public void Edit(FaqViewModel faqViewModel)
        {
            var faq = _faqs.FirstOrDefault(x => x.Id == faqViewModel.Id);
            faq.CheckArgumentIsNull(nameof(faq));
            faq.Question = faqViewModel.Question;
            faq.Reply = faqViewModel.Reply;
            _uow.SaveChanges();
        }

        public List<FaqViewModel> GetLastFaqs()
        {
            return _faqs.OrderByDescending(x => x.Id).Select(x => new FaqViewModel()
            {
                Id = x.Id,
                Question = x.Question,
                Reply = x.Reply,
                UserFullName = x.User.DisplayName,
                Date = x.RegisteDate.ToLongPersianDateString()
            }).OrderByDescending(x => x.Id).Take(10).ToList();
        }

        public FaqViewModel GetFaqById(int id)
        {

            var faq = _faqs.Include(x=>x.User).FirstOrDefault(x => x.Id == id);
            faq.CheckArgumentIsNull(nameof(faq));
            return new FaqViewModel() {
                Id = faq.Id,
                Question = faq.Question,
                Reply = faq.Reply,
                GroupId=faq.GroupId,
                UserFullName = faq.User?.DisplayName,
                Date = faq.RegisteDate.ToLongPersianDateString()

            }
                ;
        }

     

        public List<FaqViewModel> Search(string text)
        {
            return _faqs.Where(x => EF.Functions.Like(x.Question, "%" + text + "%")).Select(x=> new FaqViewModel()
            {
                Id = x.Id,
                Question = x.Question
               
            }).ToList();
        }

        public List<FaqViewModel> GetFaqsByGroupId(int groupId ,int numRecord=10)
        {

            var groups = _groups.FromSql($"[dbo].[GetChildGroup] {groupId}").Select(x =>

                x.Id
            ).ToList();
            groups.Add(groupId);
            return _faqs.Where(x => groups.Contains(x.GroupId)).OrderByDescending(x=>x.Id).Take(numRecord).Select(x => new FaqViewModel()
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
            }).OrderByDescending(x => x.Id).ToList();
        }

        public void Delete(int id)
        {
            var faq=_faqs.FirstOrDefault(x => x.Id == id);
            _faqs.Remove(faq);
            _uow.SaveChanges();

        }
    }
}
