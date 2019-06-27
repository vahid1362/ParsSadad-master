using QtasHelpDesk.Domain.Content;
using System.Collections.Generic;
using QtasHelpDesk.ViewModels.Content;
using QtasHelpDesk.ViewModels.Search;

namespace QtasHelpDesk.Services.Contracts.Content
{
    public interface IPostService
    {

        void Add(PostViewModel post);

        void Edit(PostViewModel post);

        List<PostViewModel> GetPosts();

        List<PostViewModel> GetLastPosts();
        PostViewModel GetPostById(int id);

        List<SearchResultViewModel> Search(string text);

        List<PostViewModel> GetPostsByGroupId(int groupId,int numRecord);

       void  Delete(int postId);


    }
}
