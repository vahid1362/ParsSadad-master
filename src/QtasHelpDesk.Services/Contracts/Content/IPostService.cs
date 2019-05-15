using QtasHelpDesk.Domain.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace QtasHelpDesk.Services.Contracts.Content
{
    public interface IPostService
    {

        void Add(Post post);

        void Edit(Post post);

        List<Post> GetPosts();

        Post GetPostById(int id);

        List<Post> Search(string text);



    }
}
