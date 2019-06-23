using System.Collections.Generic;
using QtasHelpDesk.Domain.Content;
using QtasHelpDesk.ViewModels.Content;
using QtasHelpDesk.ViewModels.Identity;

namespace QtasHelpDesk.Services.Contracts.Content
{
    public interface IGroupService
    {
        List<Group> GetGroups();

        void AddGroup(Group group);

        string GetGroupName(int groupId);

        Group GetGroupById(long id);

        void EditGroup(Group group);

        List<GroupViewModel> GetSubGroup(int groupId);

        List<GroupViewModel> GetParentGroup(int? parentId);

        List<UserGroupViewModel> GetUserGroups(int userId);

    }
}
