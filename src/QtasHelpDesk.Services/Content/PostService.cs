using Microsoft.EntityFrameworkCore;
using QtasHelpDesk.DataLayer.Context;
using QtasHelpDesk.Domain.Content;
using QtasHelpDesk.Services.Contracts.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using DNTPersianUtils.Core;
using QtasHelpDesk.Common.GuardToolkit;
using QtasHelpDesk.ViewModels.Content;
using QtasHelpDesk.ViewModels.Search;

namespace QtasHelpDesk.Services.Content
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Post> _posts;

        public PostService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.CheckArgumentIsNull(nameof(_uow));
            _posts = _uow.Set<Post>();
        }

        public void Add(Post post)
        {
            _posts.Add(post);
            _uow.SaveChanges();
        }

        public void Edit(Post post)
        {
            throw new NotImplementedException();
        }

        public List<PostViewModel> GetLastPosts()
        {
            return _posts.Where(x => x.IsArticle).Select(x => new PostViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Summary = x.Summary,
                UserFullName = x.User.DisplayName,
                Date = x.RegisteDate.ToLongPersianDateString()
            }).OrderByDescending(x => x.Id).Take(10).ToList();
        }

        public Post GetPostById(int id)
        {
            return _posts.FirstOrDefault(x => x.Id == id && x.IsArticle);
        }

        public List<SearchResultViewModel> Search(string text)
        {
            var result = _posts.Where(x => EF.Functions.Like(x.Title, "%" + text + "%")).Select(x=>new SearchResultViewModel
            {
                Id = x.Id,
                Title = x.Title
                
            }).ToList();
            return result;

        }

        public List<PostViewModel> GetPostsByGroupId(int groupId)
        {
            return _posts.Where(x => x.GroupId == groupId).Select(x => new PostViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Summary = x.Summary,
                UserFullName = x.User.DisplayName,
                Date = x.RegisteDate.ToLongPersianDateString()
            }).OrderByDescending(x => x.Id).Take(5).ToList();
        }

        public List<PostViewModel> GetPosts()
        {
            return _posts.Where(x => x.IsArticle).Select(x => new PostViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Summary = x.Summary,
                UserFullName = x.User.DisplayName,
                Date = x.RegisteDate.ToLongPersianDateString()
            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
