using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace QtasHelpDesk.IocConfig
{
  public static  class AddKenodServiceExtention
    {

        public static void AddKendoService(this IServiceCollection services)
        {
            services.AddKendo();
        }
    }
}
