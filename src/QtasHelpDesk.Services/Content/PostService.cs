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
   public class PostService:IPostService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Post> _posts;

        public PostService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.CheckArgumentIsNull(nameof(_uow));
            _posts = _uow.Set<Post>();
        }

        public void  Add(Post post)
        {
            _posts.Add(post);
            _uow.SaveChanges();
        }

        public void Edit(Post post)
        {
            throw new NotImplementedException();
        }

        public Post GetPostById(int id)
        {
            return _posts.FirstOrDefault(x => x.Id == id && x.IsArticle);
        }

        public List<Post> GetPostsByGroupId(int groupId)
        {
            return _posts.Where(x => x.GroupId == groupId).ToList();
        }

        public List<Post> GetPosts()
        {
            return _posts.Where(x=>x.IsArticle).ToList();
        }
    }
}
