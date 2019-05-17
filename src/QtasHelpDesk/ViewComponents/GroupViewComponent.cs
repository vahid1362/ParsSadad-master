using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QtasHelpDesk.Services.Contracts.Content;
using QtasHelpDesk.ViewModels.Content;

namespace QtasHelpDesk.ViewComponents
{
    public class GroupViewComponent:ViewComponent
    {
        private readonly IGroupService _groupService;

        public GroupViewComponent(IGroupService groupService)
        {
            _groupService = groupService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var groupViewModels = _groupService.GetGroups();
            return View(viewName: "~/Views/Shared/Components/Groups/Default.cshtml",
                model: groupViewModels);
        }


        private List<GroupViewModel> GetSubGroup(int groupId)
        {
          return  _groupService.GetSubGroup(groupId).Select(x =>
                              new GroupViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    //  SubGroups = 

                }).ToList();
        }
    }
}
