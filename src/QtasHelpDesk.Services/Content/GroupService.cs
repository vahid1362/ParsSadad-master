using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QtasHelpDesk.DataLayer.Context;
using QtasHelpDesk.Domain.Content;
using QtasHelpDesk.Services.Contracts.Content;
using QtasHelpDesk.ViewModels.Content;


namespace QtasHelpDesk.Services.Content
{
   public class GroupService:IGroupService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Group> _groups;
        public GroupService(IUnitOfWork uow)
        {
            _uow = uow;
            _groups = _uow.Set<Group>();
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
            return _groups.FirstOrDefault(x => x.Id==groupId)?.Title;
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
                Title =  x.Title



            }).ToList();
        }

        public List<GroupViewModel> GetParentGroup(int? parentId)
        {
            return _groups.Where(x => x.ParentId == parentId).Select(x=>new GroupViewModel()
            {
                Id = x.Id,
                Title = x.Title,
               hasChildren=_groups.Any(y=>y.ParentId==x.Id)
              
            }).ToList();
        }
      
    }
}
