﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QtasHelpDesk.DataLayer.Context;
using QtasHelpDesk.Domain.Content;
using QtasHelpDesk.Services.Contracts.Content;

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
            return _groups.AsNoTracking().ToList();
        }

        public void AddGroup(Group @group)
        {
            _groups.Add(group);
            _uow.SaveChanges();
        }

        public Group GetGroupById(long id)
        {
            return _groups.FirstOrDefault(x => x.Id == id);
        }

        public void EditGroup(Group @group)
        {
            _uow.SaveChanges();
        }

        public List<Group> GetSubGroup(int groupId)
        {
            return _groups.Where(x => x.ParentId == groupId).ToList();
        }
    }
}
