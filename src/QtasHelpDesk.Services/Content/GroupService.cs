using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QtasHelpDesk.Common.GuardToolkit;
using QtasHelpDesk.DataLayer.Context;
using QtasHelpDesk.Domain.Content;
using QtasHelpDesk.Services.Contracts.Content;
using QtasHelpDesk.ViewModels.Content;
using QtasHelpDesk.ViewModels.Identity;


namespace QtasHelpDesk.Services.Content
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Group> _groups;
        private readonly DbSet<UserGroup> _userGroups;

        public GroupService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.CheckArgumentIsNull(nameof(_uow));
            _groups = _uow.Set<Group>();
            _userGroups = _uow.Set<UserGroup>();
        }
        public List<Group> GetGroups()
        {
            return _groups.AsNoTracking().IgnoreQueryFilters().ToList();
        }

        public void AddGroup(Group @group)
        {
            _groups.Add(group);
            _uow.SaveChanges();
        }

        public string GetGroupName(int groupId)
        {
            return _groups.FirstOrDefault(x => x.Id == groupId)?.Title;
        }

        public Group GetGroupById(long id)
        {
            return _groups.IgnoreQueryFilters().FirstOrDefault(x => x.Id == id);
        }

        public void EditGroup(Group group)
        {
            _uow.SaveChanges();
        }

        public List<GroupViewModel> GetSubGroup(int groupId)
        {
            return _groups.Where(x => x.ParentId == groupId).Select(x => new GroupViewModel()
            {
                Id = x.Id,
                Title = x.Title


            }).ToList();
        }

        public List<GroupViewModel> GetParentGroup(int? parentId)
        {
            return _groups.Where(x => x.ParentId == parentId).Select(x => new GroupViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                hasChildren = _groups.Any(y => y.ParentId == x.Id)

            }).ToList();
        }

        public List<UserGroupViewModel> GetUserGroups(int userId)
        {
            return _userGroups.Where(x => x.UserId == userId).Select(x => new UserGroupViewModel()
            {
                Id = x.Id,
                UserId = x.UserId,
                GroupTitle = x.Group.Title,
                GroupId = x.GroupId
            }).ToList();
        }

        public void DeleteUserGroup(int userGroupId)
        {
            var userGroup = _userGroups.FirstOrDefault(x => x.Id == userGroupId);
            userGroup.CheckArgumentIsNull(nameof(userGroup));
            _userGroups.Remove(userGroup);
            _uow.SaveChanges();
        }
    }
}
