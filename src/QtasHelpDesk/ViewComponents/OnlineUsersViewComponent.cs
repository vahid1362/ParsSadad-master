﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QtasHelpDesk.Services.Contracts.Identity;
using QtasHelpDesk.ViewModels.Identity;

namespace QtasHelpDesk.Areas.Admin.ViewComponents
{
    public class OnlineUsersViewComponent : ViewComponent
    {
        private readonly ISiteStatService _siteStatService;

        public OnlineUsersViewComponent(ISiteStatService siteStatService)
        {
            _siteStatService = siteStatService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int numbersToTake, int minutesToTake, bool showMoreItemsLink)
        {
            var usersList = await _siteStatService.GetOnlineUsersListAsync(numbersToTake, minutesToTake);
            return View(viewName: "~/Views/Shared/Components/OnlineUsers/Default.cshtml",
                        model: new OnlineUsersViewModel
                        {
                            MinutesToTake = minutesToTake,
                            NumbersToTake = numbersToTake,
                            Users = usersList
                        });
        }
    }
}