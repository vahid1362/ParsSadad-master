using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QtasHelpDesk.Services.Contracts.Content;
using QtasHelpDesk.ViewModels.Content;

namespace QtasHelpDesk.Controllers
{
    [Authorize]
    public class ForumController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;
        public ForumController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        public IActionResult Index()
        {

            var groupViewModels = _groupService.GetGroups().Where(x => x.ParentId == null).Select(x =>
                new GroupViewModel()
                {
                    Id = x.Id,
                    Description = x.Description,
                    Title = x.Title
                }).ToList();

            return View(GetGeroupsWithSubGroup(groupViewModels));
        }

        private List<GroupViewModel> GetGeroupsWithSubGroup(List<GroupViewModel> groupViewModels)
        {
            foreach (var groupviewModel in groupViewModels)
            {
                var groups = _groupService.GetSubGroup(groupviewModel.Id);
                if (!groups.Any())
                    continue;
                var subggroups = groups;

                groupviewModel.children = subggroups;
            }
            return groupViewModels;
        }
    }
}