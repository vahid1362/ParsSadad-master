using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using QtasHelpDesk.Services.Contracts;
using QtasHelpDesk.Services.Security;

namespace QtasHelpDesk.IocConfig
{
    public static class AddSecurityServiceExtention
    {
        public static void AddRandomNumberService(this IServiceCollection services)
        {
            services.TryAddSingleton<IRandomNumberProvider, RandomNumberProvider>();
        }
    }
}

