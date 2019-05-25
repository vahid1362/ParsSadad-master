using System.Net.Http.Formatting;
using AutoMapper;
using QtasHelpDesk.Services.Identity.Logger;
using QtasHelpDesk.ViewModels.Identity.Settings;
using DNTCaptcha.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QtasHelpDesk.IocConfig;
using QtasHelpDesk.DataLayer.Context;
using DNTCommon.Web.Core;
using NToastNotify;


namespace QtasHelpDesk
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SiteSettings>(options => Configuration.Bind(options));
            
            // Adds all of the ASP.NET Core Identity related services and configurations at once.
            services.AddCustomIdentityServices();
            services.AddKendo();
            services.AddRandomNumberService();
            services.AddContentService();
        

            var siteSettings = services.GetSiteSettings();
            services.AddRequiredEfInternalServices(siteSettings); // It's added to access services from the dbcontext, remove it if you are using the normal `AddDbContext` and normal constructor dependency injection.
            services.AddDbContextPool<ApplicationDbContext>((serviceProvider, optionsBuilder) =>
            {
                optionsBuilder.SetDbContextOptions(siteSettings);
                optionsBuilder.UseInternalServiceProvider(serviceProvider); // It's added to access services from the dbcontext, remove it if you are using the normal `AddDbContext` and normal constructor dependency injection.
            });
            services.AddAutoMapper();
          
            services.AddMvc(options =>
            {
                options.UseYeKeModelBinder();
                options.AllowEmptyInputInBodyModelBinding = true;
                // options.Filters.Add(new NoBrowserCacheAttribute());
            }).AddJsonOptions(jsonOptions =>
            {
            jsonOptions.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                jsonOptions.SerializerSettings.ContractResolver =
                    new JsonContractResolver(new JsonMediaTypeFormatter());
            }).AddNToastNotifyToastr(new ToastrOptions()
                {
                    Rtl = true,
                    PositionClass = ToastPositions.TopCenter
                });
            // .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSession();
            services.AddMemoryCache();
            services.AddDNTCommonWeb();
            services.AddDNTCaptcha();
         


        }

        public void Configure(ILoggerFactory loggerFactory,IApplicationBuilder app,IHostingEnvironment env)
        {
            loggerFactory.AddDbLogger(serviceProvider: app.ApplicationServices, minLevel: LogLevel.Warning);

            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseExceptionHandler("/error/index/500");
            app.UseStatusCodePagesWithReExecute("/error/index/{0}");

            // Serve wwwroot as root
            app.UseFileServer(new FileServerOptions
            {
                // Don't expose file system
                EnableDirectoryBrowsing = false
            });

            // Adds all of the ASP.NET Core Identity related initializations at once.
            app.UseCustomIdentityServices();
            app.UseCookiePolicy();
            app.UseSession();


            app.UseStaticFiles();
            
   
            app.UseMvcWithDefaultRoute();

            // app.UseNoBrowserCache();
       
            app.UseNToastNotify();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}