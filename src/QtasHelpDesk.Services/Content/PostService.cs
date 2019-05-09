﻿using Microsoft.EntityFrameworkCore;
using QtasHelpDesk.DataLayer.Context;
using QtasHelpDesk.Domain.Content;
using QtasHelpDesk.Services.Contracts.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QtasHelpDesk.Services.Content
{
   public class PostService:IPostService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Post> _posts;

        public PostService(IUnitOfWork uow)
        {
            _uow = uow;
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
            throw new NotImplementedException();
        }

        public List<Post> GetPosts()
        {
            return _posts.ToList();
        }
    }
}
