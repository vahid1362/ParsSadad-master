using System.Collections.Generic;
using System.Threading.Tasks;
using QtasHelpDesk.Entities.Identity;
using System.Security.Claims;
using QtasHelpDesk.Domain.Identity;
using QtasHelpDesk.ViewModels.Identity;

namespace QtasHelpDesk.Services.Contracts.Identity
{
    public interface ISiteStatService
    {
        Task<List<User>> GetOnlineUsersListAsync(int numbersToTake, int minutesToTake);

        Task<List<User>> GetTodayBirthdayListAsync();

        Task UpdateUserLastVisitDateTimeAsync(ClaimsPrincipal claimsPrincipal);

        Task<AgeStatViewModel> GetUsersAverageAge();
    }
}