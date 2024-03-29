﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QtasHelpDesk.Services.Contracts.Content;
using QtasHelpDesk.ViewModels.Content;

namespace QtasHelpDesk.ViewComponents
{
    public class FaqViewComponent:ViewComponent
    {
        private readonly IGroupService _groupService;

        public FaqViewComponent(IGroupService groupService)
        {
            _groupService = groupService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var groupViewModels = _groupService.GetGroups().Where(x => x.ParentId == null).Select(x =>
                new GroupViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,

                }).ToList();
            return View(viewName: "~/Views/Shared/Components/Faq/Default.cshtml",
                model: groupViewModels);
        }
    }
}
