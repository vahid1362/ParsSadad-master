using System.Collections.Generic;
using QtasHelpDesk.Domain.Content;
using QtasHelpDesk.ViewModels.Content;

namespace QtasHelpDesk.Services.Contracts.Content
{
    public interface IGroupService
    {
        List<Group> GetGroups();

        void AddGroup(Group group);

        string GetGroupName(int groupId);

        Group GetGroupById(long id);

        void EditGroup(Group group);

        List<Group> GetSubGroup(int groupId);
        List<GroupViewModel> GetParentGroup();

    }
}
