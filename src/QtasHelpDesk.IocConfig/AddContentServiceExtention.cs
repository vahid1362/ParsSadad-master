using Microsoft.Extensions.DependencyInjection;
using QtasHelpDesk.Services.Content;
using QtasHelpDesk.Services.Contracts.Content;

namespace QtasHelpDesk.IocConfig
{
  public static  class AddContentServiceExtention
    {

        public static void AddContentService(this IServiceCollection services)
        {
            services.AddTransient<IGroupService, GroupService>();
        }
    }
}
