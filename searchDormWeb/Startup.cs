

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Dau.Data;

using Dau.Core.Domain.Users;
using Microsoft.AspNetCore.Identity;
using searchDormWeb.Configuration;
using Dau.Services.Security;
using Dau.Services.Users;
using Dau.Services.AccessControlList;
using searchDormWeb.Configuration.SecurityFilter;
using Dau.Services.Facility;

using Microsoft.Extensions.Logging;
using Dau.Services.Logging;
using Dau.Services.Middleware;
using Dau.Services.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Dau.Data.Repository;
//using Dau.Core.Domain.Dormitory;
using NetCoreStack.Mvc;
using NetCoreStack.Localization;
using Dau.Data.Extensions;
using Dau.Services.Domain.DormitoryDetailService;
using Dau.Services.Domain.OnScrollAlertService;
using Dau.Services.Domain.SearchResultService;
using Dau.Services.Domain.HomeService;
using Dau.Services.Domain.ExploreEmuService;
using Dau.Services.Seeding;
using Dau.Services.Languages;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Dau.Services.Utilities;
using Dau.Services.Domain.BookingService;
using Dau.Services.Domain.RoomServices;
using Dau.Services.Domain.FeaturesServices;
using Dau.Services.Domain.DormitoryServices;
using Dau.Services.Domain.DormitoryBlockServices;
using Dau.Services.Domain.ReviewsServices;
using Dau.Services.Domain.DropdownServices;
using Dau.Services.Domain.ImageServices;

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
         // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //adding our services to the ioc container
            //  services.AddTransient<OnlineUsersMiddleware>();
            services.AddTransient<AffiliateMiddleware>();
            services.AddTransient<CultureMiddleware>();

            services.AddScoped<IOnlineUsersService, OnlineUsersService>();

            services.AddScoped<ILoggingService, LoggingService>();
          
            services.AddScoped<ILogger, DBLogger>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IFacilityService, FacilityService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IUserRolesService, UserRolesService>();
           
            services.AddScoped<IDormitoryService, DormitoryService>();


            //new Services
            services.AddScoped<IGetAreaInfoService, GetAreaInfoService>();
            services.AddScoped<IGetCommentsService, GetCommentsService>();
            services.AddScoped<IGetDormitoryDescriptionService, GetDormitoryDescriptionService>();
            services.AddScoped<IGetFacilitiesService, GetFacilitiesService>();
            services.AddScoped<IGetGoodToKnowService, GetGoodToKnowService>();


            services.AddScoped< IOnScrollAlertService, OnScrollAlertService > ();


            services.AddScoped<IGetReviewService, GetReviewService>();
            services.AddScoped<IGetRoomsService, GetRoomsService>();
            services.AddScoped<IGetSlidersService, GetSlidersService>();
            services.AddScoped<IGetSpecificRoomService, GetSpecificRoomService>();
            services.AddScoped<IGetTopNavService, GetTopNavService>();

            services.AddScoped<IRoomResultService, RoomResultService>();
            services.AddScoped<IFilterBottomService, FilterBottomService>();
            services.AddScoped<IDormitoryResultService, DormitoryResultService>();


            services.AddScoped<IGetHomeDormitoriesService, GetHomeDormitoriesService>();
            services.AddScoped<IGetHomeBackgroundImagesService, GetHomeBackgroundImagesService>();
            services.AddScoped< IExploreEmuPicsService, ExploreEmuPicsService > ();
            services.AddScoped<  IResolveDormitoryService,ResolveDormitoryService > ();
            services.AddScoped < IApiLogService, ApiLogService> ();
            services.AddScoped < IBookingService, BookingService > ();
            services.AddScoped < IFeaturesService, FeaturesService > ();
            services.AddScoped <ISearchService ,SearchService> ();


            services.AddScoped<   ISeedingService, SeedingService> ();
            services.AddScoped <  IHomeService,HomeService > ();
            services.AddScoped <IDormitoryBlockService, DormitoryBlockService > ();
            services.AddScoped <  IReviewService, ReviewService > ();
            services.AddScoped <  IDropdownService,DropdownService > ();
            services.AddScoped <IImageService, ImageService > ();


            services.AddScoped<ILanguageService, LanguageService>();

            var connectionString = Configuration.GetValue<string>("DbSettings:SqlConnectionString");
            services.AddDbContext<Fees_and_facilitiesContext>(options => options.UseSqlServer(connectionString));

           


           services.AddMvc();
          
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //localization
            services.AddNetCoreStackMvc(options =>
            {
                options.AppName = "NetCoreStack Localization";
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddNetCoreStackLocalization(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //inject this as parameter , UserManager<User> userManager
            //  ApplicationDbInitializer.SeedUsers(userManager);
            //loggerFactory.AddProvider(new DBLoggerProvider()); authomatic logger uncomment this
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
             //   app.UseExceptionHandler("/Error/PageNotFound");
             // app.UseStatusCodePagesWithReExecute("/Error/Status/{0}");

            //loggingFactory code
                //loggerFactory.AddContext(LogLevel.Information);
            }
            else
            {
                app.UseExceptionHandler("/Error/PageNotFound");
                app.UseStatusCodePagesWithReExecute("/Error/Status/{0}");
              
                app.UseHsts();
            }


            app.UseNetCoreStackMvc();

            ////Required
            app.UseNetCoreStackLocalization();

            //we're passing RoleManager as a parameter, we declared it above so the service has been instanciated already we just need to call it
            // new UserRoleSeed(app.ApplicationServices.GetService<RoleManager<IdentityRole>>()).Seed();

            //exception handler 


            // identity middleware
            app.UseAuthentication();
            //app.UseIdentity();
            app.UseCookieCultureMiddleware();
          //  app.UseOnlineUsersMiddleware();
            app.UseAffiliatesMiddleware();


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

     







            app.UseMvc(routes =>
            {

                routes.MapRoute(
                     name: "areaRoute",
                    template:"{area:exists}/{controller=Admin}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=redirect}/{id?}");
            });


           
        }
    }
}
