using System.Collections.Generic;
using QtasHelpDesk.Domain.Content;

namespace QtasHelpDesk.Services.Contracts.Content
{
    public interface IGroupService
    {
        List<Group> GetGroups();

        void AddGroup(Group group);

        Group GetGroupById(long id);

        void EditGroup(Group group);

        List<Group> GetSubGroup(int groupId);
    }
}
