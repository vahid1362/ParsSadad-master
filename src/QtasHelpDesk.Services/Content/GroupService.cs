using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QtasHelpDesk.Common.GuardToolkit;
using QtasHelpDesk.DataLayer.Context;
using QtasHelpDesk.Domain.Content;
using QtasHelpDesk.Services.Contracts.Content;
using QtasHelpDesk.Services.Contracts.Identity;
using QtasHelpDesk.ViewModels.Content;
using QtasHelpDesk.ViewModels.Identity;


namespace QtasHelpDesk.Services.Content
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _uow;
        private readonly IApplicationUserManager _userManager;
        private readonly DbSet<Group> _groups;
        private readonly DbSet<UserGroup> _userGroups;

        public GroupService(IUnitOfWork uow, IApplicationUserManager userManager)
        {
            _uow = uow;
            _uow.CheckArgumentIsNull(nameof(_uow));
            _groups = _uow.Set<Group>();
            _groups.CheckArgumentIsNull(nameof(_groups));
            _userGroups = _uow.Set<UserGroup>();
            _userGroups.CheckArgumentIsNull(nameof(_userGroups));
            _userManager = userManager;
        }

        public List<Group> GetGroups()
        {
            var user = _userManager.GetCurrentUser();
            if (IsUserAdmin())
            {
                return _groups.AsNoTracking().IgnoreQueryFilters().ToList();

            }
            return _userGroups.Where(x => x.UserId == user.Id).Select(x => x.Group).ToList();
        }

        public void AddGroup(Group @group)
        {
            if (!IsUserAdmin())
            {
                if (group.ParentId == null)
                    return;
            }


            _groups.Add(group);
            _uow.SaveChanges();
        }

        private bool IsUserAdmin()
        {
            var user = _userManager.GetCurrentUser();
            var isUserInAdminRole = _userManager.IsInRoleAsync(user, "Admin");
            return isUserInAdminRole.Result;
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
