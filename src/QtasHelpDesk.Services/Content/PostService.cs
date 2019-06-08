using Microsoft.EntityFrameworkCore;
using QtasHelpDesk.DataLayer.Context;
using QtasHelpDesk.Domain.Content;
using QtasHelpDesk.Services.Contracts.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using DNTPersianUtils.Core;
using Microsoft.AspNetCore.Hosting;
using QtasHelpDesk.Common.GuardToolkit;
using QtasHelpDesk.ViewModels.Content;
using QtasHelpDesk.ViewModels.Search;
using System.IO;

namespace QtasHelpDesk.Services.Content
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Post> _posts;
        private readonly DbSet<Group> _groups;
        private readonly IGroupService _groupService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public PostService(IUnitOfWork uow,IHostingEnvironment hostingEnvironment,IGroupService groupService)
        {
            _uow = uow;
            _uow.CheckArgumentIsNull(nameof(_uow));
            _posts = _uow.Set<Post>();
            _groups = _uow.Set<Group>();
            _hostingEnvironment = hostingEnvironment;
            _hostingEnvironment.CheckArgumentIsNull(nameof(_hostingEnvironment));
            _groupService = groupService;
            _groupService.CheckArgumentIsNull(nameof(_groupService));
        }

        public void Add(Post post)
        {
            _posts.Add(post);
            _uow.SaveChanges();
        }

        public void Edit(PostViewModel postViewModel)
        {
            var post = _posts.FirstOrDefault(x=>x.Id==postViewModel.Id);

            post.CheckArgumentIsNull(nameof(post));
            post.Title = postViewModel.Title;
            post.Summary = postViewModel.Summary;
            post.Decription = postViewModel.Decription;
            post.GroupId = postViewModel.GroupId;

            if(postViewModel.DeletePreviousFile)
            {
                DeleteFile(post.FilePath);
            }
            else
            {
                DeleteFile(postViewModel.FilePath);
            }

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



            var groups = _groups.FromSql($"[dbo].[GetChildGroup] {groupId}").Select(x=>
             
                x.Id
            ).ToList();
            groups.Add(groupId);
           
            return _posts.Where(x =>groups.Contains(x.GroupId)).Include(x=>x.User).Select(x => new PostViewModel()
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
                //GroupName=x.Group.GetFormattedBreadCrumb(_groupService,"-->"),
                Summary = x.Summary,
                UserFullName = x.User.DisplayName,
                Date = x.RegisteDate.ToLongPersianDateString()
            }).OrderByDescending(x => x.Id).ToList();
        }

        public void Delete(int postId)
        {
           postId.CheckArgumentIsNull(nameof(postId));
           var post = _posts.FirstOrDefault(x => x.Id == postId);
           _posts.Remove(post);
           _uow.SaveChanges();
           if(!string.IsNullOrEmpty(post.FilePath))
              DeleteFile(post.FilePath);




        }

        private void DeleteFile(string fileName)
        {
            var filePath = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/files",
                fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
