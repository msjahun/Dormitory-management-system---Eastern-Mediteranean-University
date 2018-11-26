using System.Globalization;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Dau.Data;
using Dau.Services.SearchService;
using Dau.Services.Dormitory;
using Dau.Core.Domain.User;
using Microsoft.AspNetCore.Identity;
using searchDormWeb.Configuration;
using Dau.Services.Security;
using Dau.Services.Users;
using Dau.Services.AccessControlList;
using searchDormWeb.Configuration.SecurityFilter;
using Dau.Services.Facility;
using Dau.Services.Room;
using Microsoft.Extensions.Logging;
using Dau.Services.Logging;
using Dau.Services.Middleware;
using Dau.Services.Domain.Users;

namespace searchDormWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;                   
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //For ACList getting all controller
            services.AddSingleton<IMvcControllerDiscovery, MvcControllerDiscovery>();
            //forchecking the roleBased authentication
           services.AddMvc(options => options.Filters.Add(typeof(DynamicAuthorizationFilter)));

            //Add identity
            services.AddIdentity<User, UserRole>()
                .AddEntityFrameworkStores<Fees_and_facilitiesContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login";
                options.AccessDeniedPath = "/Error/AccessDenied";
               
            });
            //http accessor for getting ipaddress of user.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            //adding our services to the ioc container
          //  services.AddTransient<OnlineUsersMiddleware>();
            services.AddTransient<AffiliateMiddleware>();

            services.AddScoped<IOnlineUsersService, OnlineUsersService>();

            services.AddScoped<ILoggingService, LoggingService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IFacilityService, FacilityService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IUserRolesService, UserRolesService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IDormitoryService, DormitoryService>();
            services.AddDbContext<Fees_and_facilitiesContext>();

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddMvc()
              .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
              .AddDataAnnotationsLocalization();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddProvider(new DBLoggerProvider());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler("/Error/PageNotFound");
                //app.UseStatusCodePagesWithReExecute("/Error/Status/{0}");

            //loggingFactory code
                //loggerFactory.AddContext(LogLevel.Information);
            }
            else
            {
                app.UseExceptionHandler("/Error/PageNotFound");
                app.UseStatusCodePagesWithReExecute("/Error/Status/{0}");

                app.UseHsts();
            }

            //we're passing RoleManager as a parameter, we declared it above so the service has been instanciated already we just need to call it
            // new UserRoleSeed(app.ApplicationServices.GetService<RoleManager<IdentityRole>>()).Seed();

            //exception handler 

          
            // identity middleware
            app.UseAuthentication();
            //app.UseIdentity();

          //  app.UseOnlineUsersMiddleware();
            app.UseAffiliatesMiddleware();


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

     




            var supportedCultures = new[]
{


    new CultureInfo("en"),
    new CultureInfo("tr"),

};

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });



            app.UseMvc(routes =>
            {

                routes.MapRoute("areaRoute", "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=redirect}/{id?}");
            });


           
        }
    }
}
