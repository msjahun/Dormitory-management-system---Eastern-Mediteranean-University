﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dau.Core.Domain.Feature;
using Dau.Data;
using Dau.Data.Repository;
using Dau.Services.Seeding;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Dau.Services.Domain.SearchResultService;
using Dau.Core.Domain.Localization;
using Dau.Services.Domain.DormitoryDetailService;
using Dau.Core.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Dau.Core.Domain.Users;
using Dau.Services.Languages;
using Dau.Core.Domain.SearchEngineOptimization;
using Dau.Services.Domain.ExploreEmuService;
using System.Security.Claims;
using Dau.Core.Domain;
using Dau.Services.Utilities;
using Dau.Services.Email;
using Dau.Services.Export;
using System.IO;
using Dau.Services.Event;
using Microsoft.AspNetCore.Authorization;

namespace searchDormWeb.Controllers
{
    //[Authorize]
    //public class DebugController : Controller
    //{
    //    private readonly IExportService _exportService;
    //    private readonly IEmailService _emailService;
    //    private readonly IGetReviewService _getReviewService;
    //    private readonly IApiLogService _apiLogService;
    //    private readonly IGetRoomsService _getRoomsService;
    //    private readonly ISeedingService _seedingService;
    //    private readonly IRepository<FeaturesCategory> _FeatureCategoryrepository;
    //    private readonly IRepository<Language> _Language;
    //    private readonly IGetSlidersService _getSlidersService;
    //    private readonly IRepository<CatalogImage> _imagesRepo;
    //    private readonly IRepository<Room> _roomRepository;
    //    private readonly IRepository<RoomTranslation> _roomTranslationRepository;
    //    private readonly UserManager<User> _userManager;
    //    private readonly RoleManager<UserRole> _roleManager;
    //    private readonly SignInManager<User> _signInManager;
    //    private readonly IRepository<Features> _Featuresrepository;
    //    private readonly IRepository<FeaturesTranslation> _FeaturesTranslationRepo;
    //    private readonly Fees_and_facilitiesContext _dbContext;
    //    private readonly IRepository<FeaturesCategoryTranslation> _FeaturesCategoryTranslationRepo;
    //    private readonly IHttpContextAccessor _httpContextAccessor;
    //    private readonly IRepository<Room> _roomRepo;
    //    private readonly IRepository<RoomTranslation> _roomTransRepo;
    //    private readonly IRepository<Dormitory> _dormitoryRepo;
    //    private readonly IRepository<RoomCatalogImage> _roomImageRepository;
    //    private readonly ILanguageService _languageService;
    //    private readonly IRepository<RoomFeatures> _roomFeaturesRepo;
    //    private readonly IRepository<Features> _featuresRepo;
    //    private readonly IRepository<FeaturesTranslation> _featuresTranslation;
    //    private readonly IRepository<Review> _reviewRepo;
    //    private readonly IEventService _eventService;
    //    private readonly IResolveDormitoryService _resolveDormitoryService;
    //    private readonly IRepository<Dormitory> _dormitoryRepository;
    //    private readonly IRepository<DormitoryTranslation> _dormitoryTransRepository;
    //    private readonly IRepository<DormitoryCatalogImage> _dormitoryImageRepository;
    //    private readonly IRepository<CatalogImage> _imagesRepository;
    //    private readonly IRepository<Seo> _seoRepository;


    //    public DebugController(
    //        ISeedingService seedingService,
    //        IRepository<FeaturesCategory> FeatureCategoryrepository,
    //        IRepository<FeaturesCategoryTranslation> FeaturesCategoryTranslationRepo,
    //        IRepository<Features> Featuresrepository,
    //        IRepository<FeaturesTranslation> FeaturesTranslationRepo,
    //        IRepository<Language> Language,
    //        IGetSlidersService getSlidersService,
    //        IRepository<CatalogImage> imagesRepository,
    //        Fees_and_facilitiesContext dbContext,
    //        UserManager<User> userManager,
    //        RoleManager<UserRole> roleManager,
    //        SignInManager<User> signInManager,
    //        IGetRoomsService getRoomsService,
    //        IRepository<Review> reviewRepo,

    //         IRepository<Room> roomRepo,
    //        IRepository<RoomTranslation> roomTransRepo,
    //        IRepository<Dormitory> dormitoryRepo,
    //        ILanguageService languageService,
    //        IApiLogService apiLogService,

    //          IResolveDormitoryService resolveDormitoryService,
    //          IRepository<Dormitory> DormitoryRepository,
    //          IRepository<DormitoryTranslation> DormitoryTransRepository,
    //          IRepository<DormitoryCatalogImage> DormitoryImageRepository,
    //          IRepository<CatalogImage> ImagesRepository,
    //          IRepository<Seo> SeoRepository,
           
    //                IRepository<Room> RoomRepository,
    //                IRepository<RoomTranslation> RoomTranslationRepository,
    //                IRepository<RoomCatalogImage> RoomImageRepository,

    //               IRepository<RoomFeatures> RoomFeaturesRepo,
    //        IRepository<Features> featuresRepo,
        
    //        IRepository<FeaturesTranslation> featuresTranslation,
    //        IGetReviewService getReviewService,
    //        IEmailService emailService,
    //        IExportService exportService,
    //        IEventService eventService


    //        )
    //    {
    //        _exportService = exportService;
    //        _emailService = emailService;
    //        _getReviewService = getReviewService;
    //        _apiLogService = apiLogService;
    //            _getRoomsService = getRoomsService;
    //        _seedingService = seedingService;
    //        _Featuresrepository = Featuresrepository;
    //        _FeaturesTranslationRepo= FeaturesTranslationRepo;
    //        _FeaturesCategoryTranslationRepo=FeaturesCategoryTranslationRepo;
    //        _FeatureCategoryrepository = FeatureCategoryrepository;
    //        _Language = Language;
    //        _getSlidersService = getSlidersService;
    //        _imagesRepo = imagesRepository;
    //        _userManager = userManager;
    //        _roleManager = roleManager;
    //        _signInManager = signInManager;

    //        _languageService = languageService;
    //        _roomRepo = roomRepo;
    //        _dbContext = dbContext;
    //        _roomTransRepo = roomTransRepo;
    //        _dormitoryRepo = dormitoryRepo;

    //        _languageService = languageService;
    //        _resolveDormitoryService = resolveDormitoryService;
    //        _dormitoryRepository = DormitoryRepository;
    //        _dormitoryTransRepository = DormitoryTransRepository;
    //        _dormitoryImageRepository = DormitoryImageRepository;
    //        _imagesRepository = ImagesRepository;
    //        _seoRepository = SeoRepository;

    //        _imagesRepo = imagesRepository;
    //        _roomRepository = RoomRepository;
    //        _roomTranslationRepository = RoomTranslationRepository;
    //        _roomImageRepository = RoomImageRepository;

    //        _languageService = languageService;
    //        _roomFeaturesRepo = RoomFeaturesRepo;
    //        _featuresRepo = featuresRepo;
    //        _featuresTranslation = featuresTranslation;
    //        _reviewRepo=reviewRepo;
    //        _eventService = eventService;


    //    }

    //    public IActionResult Seeding()
    //    {
    //        return View();
    //    }

    //    public IActionResult ApiLog()
    //    {

    //       var debugLogs = _apiLogService.getApiDebugLogs();
    //        return View(debugLogs);
    //    }


    //    public IActionResult EventsLog()
    //    {

    //        var eventLogs = _eventService.GetAllEvents();
    //        return View(eventLogs);
    //    }


    //    public IActionResult DeleteLogEntries()
    //    {

    //        _apiLogService.DeleteEntries();
    //        return Json(true);
    //    }


    //    public IActionResult DeleteEventLogEntries()
    //    {

    //        _eventService.DeleteAllEvents();
    //        return Json(true);
    //    }



    //    public IActionResult SeedFacilities()
    //    {



    //        //  bool status = true;
    //        // throw new System.ArgumentException("Parameter cannot be null", "original");

    //        //var Languageid = 1;//english
    //        //var query =
    //        //   from FC in _FeatureCategoryrepository.List().ToList()
    //        //   join FCTrans in _FeaturesCategoryTranslationRepo.List().ToList() on FC.Id equals FCTrans.FeaturesCategoryNonTransId
    //        //   where FCTrans.LanguageId == Languageid
    //        //   select new { FeatureCategoryName = FCTrans.CategoryName};

    //        //  _FeatureCategoryrepository.List().ToList();
    //        //  _FeaturesCategoryTranslationRepo.List().ToList();





    //        //    join dist in distributors on cust.City equals dist.City

    //        //     var FeaturesCategoryJoined = from FC in _FeatureCategoryrepository.List().ToList()
    //        //                                  join FCTrans in _FeaturesCategoryTranslationRepo.List().ToList() on FC.Id equals FCTrans.FeaturesCategoryNonTransId
    //        //                                  where FCTrans.LanguageId ==2
    //        //                                  select new { FeatureCategoryName = FCTrans.CategoryName, FeatureCategoryId = FC.Id};



    //        //     var FeaturesJoined = from F in _Featuresrepository.List().ToList()
    //        //                          join FTrans in _FeaturesTranslationRepo.List().ToList() on F.Id equals FTrans.FeaturesNonTransId
    //        //                          where FTrans.LanguageId == 2
    //        //                          select new { FTrans.FeatureName, FeatureId = F.Id ,FeaturesCategoryId = F.FeaturesCategory.Id};


    //        //     var CombinedQuery = from FC in FeaturesCategoryJoined.ToList()
    //        //                         join F in FeaturesJoined.ToList() on FC.FeatureCategoryId equals F.FeaturesCategoryId
    //        //                         select new {  FC.FeatureCategoryName, FC.FeatureCategoryId, F.FeatureName,  F.FeatureId};

    //        //     var results = from p in CombinedQuery
    //        //                   group new FacilityOptions {OptionId= p.FeatureId,OptionName= p.FeatureName, OptionCount=32 } by new { p.FeatureCategoryId, p.FeatureCategoryName} into g
    //        //                   select new FiltersFacilityViewModel { FacilityName =g.Key.FeatureCategoryName,FacilityOptions = g.ToList() };


    //        //     var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
    //        //     var culture = rqf.RequestCulture.Culture;

    //        //var Language=     _Language.List().Where(l => l.CultureName == culture.ToString()).FirstOrDefault();
    //        //     // Culture contains the information of the requested culture



    //        //var Images = from imageList in _imagesRepo.List().ToList()

    //        //             select new { imageList.ImageUrl };




    //        //   _Featuresrepository.List().ToList();
    //        //_FeaturesCategoryTranslationRepo.List();
    //       _seedingService.SeedFeatures();
    //        return Json(true);
    //    }

    //    //[HttpPost]
    //    public IActionResult CheckJsonResult()
    //    {

    //        var CurrentLanguageId = _languageService.GetCurrentLanguageId();

    //        var DormitoryId = 2;

           

    //        return Json(User.Identity.IsAuthenticated);
    //    }

    //    public IActionResult seedDormitories()
    //    {
    //        _seedingService.SeedDormitoryData();
    //        var success = true;
    //      return Json(success);
    //    }

    //        public IActionResult testEmail()
    //    {
    //       _seedingService.SeedSampleEmail();
    //        var success = true;
    //      return Json(success);
    //    }


    //    public IActionResult SeedBackgroundSliderImages()
    //    {
    //       _seedingService.SeedBackgroundSliderImages();
    //        var success = true;
    //      return Json(success);
    //    }

    //    public IActionResult exportExcel()
    //    {
    //       string filename= _exportService.ExportToExcel();
    //        RedirectToAction("download", "debug", new { filename });

    //        var success = true;
    //      return Json(success);
    //    }

       

    //    public IActionResult SeedBookings()
    //    {
    //        _seedingService.SeedBookings();
    //        var success = true;
    //        return Json(success);
    //    }

    //    public IActionResult SeedMessageTempletes()
    //    {
    //        _seedingService.SeedMessageTempletes();
    //        var success = true;
    //        return Json(success);
    //    }


    //    public IActionResult SeedRoomData()
    //    {
    //        _seedingService.SeedRoomData();
    //        var success = true;
    //        return Json(success);
    //    }


    //    public IActionResult seedDormitoryBlocks()
    //    {
    //        _seedingService.seedDormitoryBlocks();
    //        var success = true;
    //        return Json(success);
    //    }


    //    public IActionResult SeedDormitoryType()
    //    {
    //        _seedingService.SeedDormitoryType();
    //        var success = true;
    //        return Json(success);
    //    }


    //    public IActionResult SeedCartItems()
    //    {
    //        _seedingService.SeedCartItems();
    //        var success = true;
    //        return Json(success);
    //    }

       
    //        public IActionResult SeedEMUMapLocations()
    //    {
    //        _seedingService.SeedEMUMapLocations();
    //        var success = true;
    //        return Json(success);
    //    }


    //    public IActionResult seedReviews()
    //    {
    //        _seedingService.SeedReviews();
    //        var success = true;
    //        return Json(success);
    //    }


    //    public async Task<IActionResult> SeedUsersAndRolesAsync()
    //    {
    //        var user1 = new User
    //        {
    //            UserName = "DUYGU.CELIK@EMU.EDU.TR",
    //            Email = "DUYGU.CELIK@EMU.EDU.TR",
    //            FirstName = "Prof. Duygu",
    //            LastName = "Çelik Ertuğrul"
    //        };
    //        var result = await _userManager.CreateAsync(user1, "Project1@emu");

    //        var user2 = new User
    //        {
    //            UserName = "Chivy1221@gmail.com",
    //            Email = "Chivy1221@gmail.com",
    //            FirstName = "Ivy",
    //            LastName = "Thopson",
    //            UserImageUrl = "https://avatars0.githubusercontent.com/u/14825113?s=400&v=4"
    //        };
    //       result = await _userManager.CreateAsync(user2, "Grad@Proj2");


    //        var user3 = new User
    //        {
    //            UserName = "Abdullahiismailabubakar@gmail.com",
    //            Email = "Abdullahiismailabubakar@gmail.com",
    //            FirstName = "Abdullahi",
    //            LastName = "Ismail",
    //            UserImageUrl = "https://avatars3.githubusercontent.com/u/35945225?s=460&v=4"
    //        };
    //        result = await _userManager.CreateAsync(user3, "Grad@Proj2");


    //        var user4 = new User
    //        {
    //            UserName = "kamaluddeen02@gmail.com",
    //            Email = "kamaluddeen02@gmail.com",
    //            FirstName = "Kamaludden",
    //            LastName = "Umar",
    //            UserImageUrl = "https://www.facebook.com/search/async/profile_picture/?fbid=100001237759702&width=72&height=72"
    //        };
    //       result = await _userManager.CreateAsync(user4, "Grad@Proj2");


    //        var user5 = new User
    //        {
    //            UserName = "msjahun@live.com",
    //            Email = "msjahun@live.com",
    //            FirstName = "Musa",
    //            LastName = "Jahun",
    //            UserImageUrl = "https://www.facebook.com/search/async/profile_picture/?fbid=100000839361217&width=72&height=72"
    //        };
    //        result = await _userManager.CreateAsync(user5, "Mami1961#");


    //        //create user role and redirect to edit_userRole page
    //        var role = new UserRole();
    //        role.Name = "Administrator";
    //        role.Access = @"[{""Id"":"":"",""Name"":"""",""DisplayName"":null,""AreaName"":"""",""Actions"":[]},{""Id"":"":Login"",""Name"":""Login"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":Login: Index"",""Name"":""Index"",""DisplayName"":null,""ControllerId"":"":Login"",""isSelected"":false},{""Id"":"":Login: Logout"",""Name"":""Logout"",""DisplayName"":null,""ControllerId"":"":Login"",""isSelected"":false}]},{""Id"":"":Register"",""Name"":""Register"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":Register: Index"",""Name"":""Index"",""DisplayName"":null,""ControllerId"":"":Register"",""isSelected"":false}]},{""Id"":"":Admin"",""Name"":""Admin"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":Admin: Index"",""Name"":""Index"",""DisplayName"":null,""ControllerId"":"":Admin"",""isSelected"":false}]},{""Id"":""Admin: Catalog"",""Name"":""Catalog"",""DisplayName"":null,""AreaName"":""Admin"",""Actions"":[{""Id"":""Admin: Catalog: Rooms"",""Name"":""Rooms"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: RoomAdd"",""Name"":""RoomAdd"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: RoomEdit"",""Name"":""RoomEdit"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: AddRoomFeature"",""Name"":""AddRoomFeature"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: RemoveRoomFeature"",""Name"":""RemoveRoomFeature"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: RemoveRoomImage"",""Name"":""RemoveRoomImage"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: GetFeaturesDropdown"",""Name"":""GetFeaturesDropdown"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: GetDormitoryBlockByDormitoryIdDropdown"",""Name"":""GetDormitoryBlockByDormitoryIdDropdown"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: RoomFeaturesMapping"",""Name"":""RoomFeaturesMapping"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: DeleteRoom"",""Name"":""DeleteRoom"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: GetRoomImages"",""Name"":""GetRoomImages"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: UploadRoomImage"",""Name"":""UploadRoomImage"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: DormitoryBlocks"",""Name"":""DormitoryBlocks"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: DormitoryBlockAdd"",""Name"":""DormitoryBlockAdd"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: DormitoryBlockEdit"",""Name"":""DormitoryBlockEdit"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: BulkRoomEdit"",""Name"":""BulkRoomEdit"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: LowQuotaReport"",""Name"":""LowQuotaReport"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: RoomReviews"",""Name"":""RoomReviews"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: RoomReviewEdit"",""Name"":""RoomReviewEdit"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: Features"",""Name"":""Features"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: FeaturesAdd"",""Name"":""FeaturesAdd"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: FeaturesEdit"",""Name"":""FeaturesEdit"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: FeaturesCategory"",""Name"":""FeaturesCategory"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: FeaturesCategoryAdd"",""Name"":""FeaturesCategoryAdd"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: FeaturesCategoryEdit"",""Name"":""FeaturesCategoryEdit"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false}]},{""Id"":""Admin: Dashboard"",""Name"":""Dashboard"",""DisplayName"":null,""AreaName"":""Admin"",""Actions"":[{""Id"":""Admin: Dashboard: Index"",""Name"":""Index"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false},{""Id"":""Admin: Dashboard: BookingTotals"",""Name"":""BookingTotals"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false},{""Id"":""Admin: Dashboard: IncompleteBookings"",""Name"":""IncompleteBookings"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false},{""Id"":""Admin: Dashboard: LatestBookings"",""Name"":""LatestBookings"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false},{""Id"":""Admin: Dashboard: PopularFilters"",""Name"":""PopularFilters"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false},{""Id"":""Admin: Dashboard: BestSellersQuantity"",""Name"":""BestSellersQuantity"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false},{""Id"":""Admin: Dashboard: BestSellersAmount"",""Name"":""BestSellersAmount"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false},{""Id"":""Admin: Dashboard: NoOfBookings"",""Name"":""NoOfBookings"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false},{""Id"":""Admin: Dashboard: NoOfUsers"",""Name"":""NoOfUsers"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false},{""Id"":""Admin: Dashboard: NoOfPendingCancelledRequests"",""Name"":""NoOfPendingCancelledRequests"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false},{""Id"":""Admin: Dashboard: NoOfLowQuotaRooms"",""Name"":""NoOfLowQuotaRooms"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false},{""Id"":""Admin: Dashboard: GetBookingsChart"",""Name"":""GetBookingsChart"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false},{""Id"":""Admin: Dashboard: GetnewCustomersChart"",""Name"":""GetnewCustomersChart"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false}]},{""Id"":""Admin: Notifications"",""Name"":""Notifications"",""DisplayName"":null,""AreaName"":""Admin"",""Actions"":[{""Id"":""Admin: Notifications: List"",""Name"":""List"",""DisplayName"":null,""ControllerId"":""Admin: Notifications"",""isSelected"":false},{""Id"":""Admin: Notifications: Announcements"",""Name"":""Announcements"",""DisplayName"":null,""ControllerId"":""Admin: Notifications"",""isSelected"":false},{""Id"":""Admin: Notifications: AnnouncementAdd"",""Name"":""AnnouncementAdd"",""DisplayName"":null,""ControllerId"":""Admin: Notifications"",""isSelected"":false},{""Id"":""Admin: Notifications: AnnouncementEdit"",""Name"":""AnnouncementEdit"",""DisplayName"":null,""ControllerId"":""Admin: Notifications"",""isSelected"":false}]},{""Id"":""Admin: Reservations"",""Name"":""Reservations"",""DisplayName"":null,""AreaName"":""Admin"",""Actions"":[{""Id"":""Admin: Reservations: List"",""Name"":""List"",""DisplayName"":null,""ControllerId"":""Admin: Reservations"",""isSelected"":false},{""Id"":""Admin: Reservations: ReservationEdit"",""Name"":""ReservationEdit"",""DisplayName"":null,""ControllerId"":""Admin: Reservations"",""isSelected"":false},{""Id"":""Admin: Reservations: CancelRequest"",""Name"":""CancelRequest"",""DisplayName"":null,""ControllerId"":""Admin: Reservations"",""isSelected"":false},{""Id"":""Admin: Reservations: CancelRequestEdit"",""Name"":""CancelRequestEdit"",""DisplayName"":null,""ControllerId"":""Admin: Reservations"",""isSelected"":false},{""Id"":""Admin: Reservations: CurrentWishList"",""Name"":""CurrentWishList"",""DisplayName"":null,""ControllerId"":""Admin: Reservations"",""isSelected"":false},{""Id"":""Admin: Reservations: BestSellerRooms"",""Name"":""BestSellerRooms"",""DisplayName"":null,""ControllerId"":""Admin: Reservations"",""isSelected"":false},{""Id"":""Admin: Reservations: RoomsNeverReserved"",""Name"":""RoomsNeverReserved"",""DisplayName"":null,""ControllerId"":""Admin: Reservations"",""isSelected"":false},{""Id"":""Admin: Reservations: CountryReport"",""Name"":""CountryReport"",""DisplayName"":null,""ControllerId"":""Admin: Reservations"",""isSelected"":false}]},{""Id"":""Admin: Users"",""Name"":""Users"",""DisplayName"":null,""AreaName"":""Admin"",""Actions"":[{""Id"":""Admin: Users: List"",""Name"":""List"",""DisplayName"":null,""ControllerId"":""Admin: Users"",""isSelected"":false},{""Id"":""Admin: Users: Add"",""Name"":""Add"",""DisplayName"":null,""ControllerId"":""Admin: Users"",""isSelected"":false},{""Id"":""Admin: Users: Delete"",""Name"":""Delete"",""DisplayName"":null,""ControllerId"":""Admin: Users"",""isSelected"":false},{""Id"":""Admin: Users: Edit"",""Name"":""Edit"",""DisplayName"":null,""ControllerId"":""Admin: Users"",""isSelected"":false},{""Id"":""Admin: Users: Roles"",""Name"":""Roles"",""DisplayName"":null,""ControllerId"":""Admin: Users"",""isSelected"":false},{""Id"":""Admin: Users: UserRoleAdd"",""Name"":""UserRoleAdd"",""DisplayName"":null,""ControllerId"":""Admin: Users"",""isSelected"":false},{""Id"":""Admin: Users: UserRoleEdit"",""Name"":""UserRoleEdit"",""DisplayName"":null,""ControllerId"":""Admin: Users"",""isSelected"":false},{""Id"":""Admin: Users: UserRoleDelete"",""Name"":""UserRoleDelete"",""DisplayName"":null,""ControllerId"":""Admin: Users"",""isSelected"":false},{""Id"":""Admin: Users: OnlineUsers"",""Name"":""OnlineUsers"",""DisplayName"":null,""ControllerId"":""Admin: Users"",""isSelected"":false},{""Id"":""Admin: Users: TrackOnlineUsers"",""Name"":""TrackOnlineUsers"",""DisplayName"":null,""ControllerId"":""Admin: Users"",""isSelected"":false},{""Id"":""Admin: Users: UsersReport"",""Name"":""UsersReport"",""DisplayName"":null,""ControllerId"":""Admin: Users"",""isSelected"":false},{""Id"":""Admin: Users: UsersReportByRegistration"",""Name"":""UsersReportByRegistration"",""DisplayName"":null,""ControllerId"":""Admin: Users"",""isSelected"":false},{""Id"":""Admin: Users: UsersReportByBookingTotal"",""Name"":""UsersReportByBookingTotal"",""DisplayName"":null,""ControllerId"":""Admin: Users"",""isSelected"":false},{""Id"":""Admin: Users: UsersReportRegistered"",""Name"":""UsersReportRegistered"",""DisplayName"":null,""ControllerId"":""Admin: Users"",""isSelected"":false}]},{""Id"":"":BookingByBookingId"",""Name"":""BookingByBookingId"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":BookingByBookingId: Get"",""Name"":""Get"",""DisplayName"":null,""ControllerId"":"":BookingByBookingId"",""isSelected"":false}]},{""Id"":"":CancelBooking"",""Name"":""CancelBooking"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":CancelBooking: Post"",""Name"":""Post"",""DisplayName"":null,""ControllerId"":"":CancelBooking"",""isSelected"":false}]},{""Id"":"":CreateBooking"",""Name"":""CreateBooking"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":CreateBooking: Post"",""Name"":""Post"",""DisplayName"":null,""ControllerId"":"":CreateBooking"",""isSelected"":false}]},{""Id"":"":EditBooking"",""Name"":""EditBooking"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":EditBooking: Post"",""Name"":""Post"",""DisplayName"":null,""ControllerId"":"":EditBooking"",""isSelected"":false}]},{""Id"":"":FacilitiesFilter"",""Name"":""FacilitiesFilter"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":FacilitiesFilter: Get"",""Name"":""Get"",""DisplayName"":null,""ControllerId"":"":FacilitiesFilter"",""isSelected"":false}]},{""Id"":"":GetBooking"",""Name"":""GetBooking"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":GetBooking: Get"",""Name"":""Get"",""DisplayName"":null,""ControllerId"":"":GetBooking"",""isSelected"":false}]},{""Id"":"":GetBookingsByCustomerId"",""Name"":""GetBookingsByCustomerId"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":GetBookingsByCustomerId: Get"",""Name"":""Get"",""DisplayName"":null,""ControllerId"":"":GetBookingsByCustomerId"",""isSelected"":false}]},{""Id"":"":GetCurrency"",""Name"":""GetCurrency"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":GetCurrency: Get"",""Name"":""Get"",""DisplayName"":null,""ControllerId"":"":GetCurrency"",""isSelected"":false}]},{""Id"":"":GetDormitories"",""Name"":""GetDormitories"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":GetDormitories: Get"",""Name"":""Get"",""DisplayName"":null,""ControllerId"":"":GetDormitories"",""isSelected"":false}]},{""Id"":"":GetDormitoryDetailById"",""Name"":""GetDormitoryDetailById"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":GetDormitoryDetailById: Get"",""Name"":""Get"",""DisplayName"":null,""ControllerId"":"":GetDormitoryDetailById"",""isSelected"":false}]},{""Id"":"":GetHighlyRatedDormitories"",""Name"":""GetHighlyRatedDormitories"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":GetHighlyRatedDormitories: Get"",""Name"":""Get"",""DisplayName"":null,""ControllerId"":"":GetHighlyRatedDormitories"",""isSelected"":false}]},{""Id"":"":GetMostPopularDormitories"",""Name"":""GetMostPopularDormitories"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":GetMostPopularDormitories: Get"",""Name"":""Get"",""DisplayName"":null,""ControllerId"":"":GetMostPopularDormitories"",""isSelected"":false}]},{""Id"":"":GetRoomByDormitoryId"",""Name"":""GetRoomByDormitoryId"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":GetRoomByDormitoryId: Get"",""Name"":""Get"",""DisplayName"":null,""ControllerId"":"":GetRoomByDormitoryId"",""isSelected"":false}]},{""Id"":"":GetRoomById"",""Name"":""GetRoomById"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":GetRoomById: Get"",""Name"":""Get"",""DisplayName"":null,""ControllerId"":"":GetRoomById"",""isSelected"":false}]},{""Id"":"":GetSearchDormitoriesByFilter"",""Name"":""GetSearchDormitoriesByFilter"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":GetSearchDormitoriesByFilter: Post"",""Name"":""Post"",""DisplayName"":null,""ControllerId"":"":GetSearchDormitoriesByFilter"",""isSelected"":false}]},{""Id"":"":GiveAppFeedBack"",""Name"":""GiveAppFeedBack"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":GiveAppFeedBack: Post"",""Name"":""Post"",""DisplayName"":null,""ControllerId"":"":GiveAppFeedBack"",""isSelected"":false}]},{""Id"":"":PaymentConfirmation"",""Name"":""PaymentConfirmation"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":PaymentConfirmation: Post"",""Name"":""Post"",""DisplayName"":null,""ControllerId"":"":PaymentConfirmation"",""isSelected"":false}]},{""Id"":"":RateYourStay"",""Name"":""RateYourStay"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":RateYourStay: Post"",""Name"":""Post"",""DisplayName"":null,""ControllerId"":"":RateYourStay"",""isSelected"":false}]},{""Id"":""Admin: ActivityLog"",""Name"":""ActivityLog"",""DisplayName"":null,""AreaName"":""Admin"",""Actions"":[{""Id"":""Admin: ActivityLog: Log"",""Name"":""Log"",""DisplayName"":null,""ControllerId"":""Admin: ActivityLog"",""isSelected"":false},{""Id"":""Admin: ActivityLog: Type"",""Name"":""Type"",""DisplayName"":null,""ControllerId"":""Admin: ActivityLog"",""isSelected"":false}]},{""Id"":""Admin: API"",""Name"":""API"",""DisplayName"":null,""AreaName"":""Admin"",""Actions"":[{""Id"":""Admin: API: Settings"",""Name"":""Settings"",""DisplayName"":null,""ControllerId"":""Admin: API"",""isSelected"":false}]},{""Id"":""Admin: Configurations"",""Name"":""Configurations"",""DisplayName"":null,""AreaName"":""Admin"",""Actions"":[{""Id"":""Admin: Configurations: EmailAccounts"",""Name"":""EmailAccounts"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false},{""Id"":""Admin: Configurations: EmailAccountAdd"",""Name"":""EmailAccountAdd"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false},{""Id"":""Admin: Configurations: EmailAccountEdit"",""Name"":""EmailAccountEdit"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false},{""Id"":""Admin: Configurations: Dormitories"",""Name"":""Dormitories"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false},{""Id"":""Admin: Configurations: DormitoryAdd"",""Name"":""DormitoryAdd"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false},{""Id"":""Admin: Configurations: DormitoryEdit"",""Name"":""DormitoryEdit"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false},{""Id"":""Admin: Configurations: DormitorySeoEdit"",""Name"":""DormitorySeoEdit"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false},{""Id"":""Admin: Configurations: AddDormitoryFeature"",""Name"":""AddDormitoryFeature"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false},{""Id"":""Admin: Configurations: RemoveDormitoryFeature"",""Name"":""RemoveDormitoryFeature"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false},{""Id"":""Admin: Configurations: AddCloseLocation"",""Name"":""AddCloseLocation"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false},{""Id"":""Admin: Configurations: RemoveCloseLocation"",""Name"":""RemoveCloseLocation"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false},{""Id"":""Admin: Configurations: UploadDormitoryImage"",""Name"":""UploadDormitoryImage"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false},{""Id"":""Admin: Configurations: RemoveDormitoryImage"",""Name"":""RemoveDormitoryImage"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false},{""Id"":""Admin: Configurations: CloseLocationsTable"",""Name"":""CloseLocationsTable"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false},{""Id"":""Admin: Configurations: DormitoryPicturesTable"",""Name"":""DormitoryPicturesTable"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false},{""Id"":""Admin: Configurations: DormitoryFeaturesTable"",""Name"":""DormitoryFeaturesTable"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false},{""Id"":""Admin: Configurations: DormitoryRoomsTable"",""Name"":""DormitoryRoomsTable"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false},{""Id"":""Admin: Configurations: DormitoryBlocksTable"",""Name"":""DormitoryBlocksTable"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false},{""Id"":""Admin: Configurations: Languages"",""Name"":""Languages"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false},{""Id"":""Admin: Configurations: LanguageAdd"",""Name"":""LanguageAdd"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false},{""Id"":""Admin: Configurations: LanguageEdit"",""Name"":""LanguageEdit"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false},{""Id"":""Admin: Configurations: AccessControlList"",""Name"":""AccessControlList"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false},{""Id"":""Admin: Configurations: Currencies"",""Name"":""Currencies"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false},{""Id"":""Admin: Configurations: CurrencyAdd"",""Name"":""CurrencyAdd"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false},{""Id"":""Admin: Configurations: CurrencyEdit"",""Name"":""CurrencyEdit"",""DisplayName"":null,""ControllerId"":""Admin: Configurations"",""isSelected"":false}]},{""Id"":""Admin: System"",""Name"":""System"",""DisplayName"":null,""AreaName"":""Admin"",""Actions"":[{""Id"":""Admin: System: Information"",""Name"":""Information"",""DisplayName"":null,""ControllerId"":""Admin: System"",""isSelected"":false},{""Id"":""Admin: System: Log"",""Name"":""Log"",""DisplayName"":null,""ControllerId"":""Admin: System"",""isSelected"":false},{""Id"":""Admin: System: LogView"",""Name"":""LogView"",""DisplayName"":null,""ControllerId"":""Admin: System"",""isSelected"":false},{""Id"":""Admin: System: ClearAllLogs"",""Name"":""ClearAllLogs"",""DisplayName"":null,""ControllerId"":""Admin: System"",""isSelected"":false},{""Id"":""Admin: System: Warnings"",""Name"":""Warnings"",""DisplayName"":null,""ControllerId"":""Admin: System"",""isSelected"":false},{""Id"":""Admin: System: Maintenance"",""Name"":""Maintenance"",""DisplayName"":null,""ControllerId"":""Admin: System"",""isSelected"":false},{""Id"":""Admin: System: MessageQueues"",""Name"":""MessageQueues"",""DisplayName"":null,""ControllerId"":""Admin: System"",""isSelected"":false},{""Id"":""Admin: System: MessageQueueEdit"",""Name"":""MessageQueueEdit"",""DisplayName"":null,""ControllerId"":""Admin: System"",""isSelected"":false},{""Id"":""Admin: System: ScheduleTasks"",""Name"":""ScheduleTasks"",""DisplayName"":null,""ControllerId"":""Admin: System"",""isSelected"":false},{""Id"":""Admin: System: SEOFriendlyPageNames"",""Name"":""SEOFriendlyPageNames"",""DisplayName"":null,""ControllerId"":""Admin: System"",""isSelected"":false}]},{""Id"":"":NetCoreStackLocalization"",""Name"":""NetCoreStackLocalization"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":NetCoreStackLocalization: SetLanguage"",""Name"":""SetLanguage"",""DisplayName"":null,""ControllerId"":"":NetCoreStackLocalization"",""isSelected"":false},{""Id"":"":NetCoreStackLocalization: ShowMeTheCulture"",""Name"":""ShowMeTheCulture"",""DisplayName"":null,""ControllerId"":"":NetCoreStackLocalization"",""isSelected"":false},{""Id"":"":NetCoreStackLocalization: GetAllLanguage"",""Name"":""GetAllLanguage"",""DisplayName"":null,""ControllerId"":"":NetCoreStackLocalization"",""isSelected"":false},{""Id"":"":NetCoreStackLocalization: GetResourceByLanguageId"",""Name"":""GetResourceByLanguageId"",""DisplayName"":null,""ControllerId"":"":NetCoreStackLocalization"",""isSelected"":false},{""Id"":"":NetCoreStackLocalization: GetAllResource"",""Name"":""GetAllResource"",""DisplayName"":null,""ControllerId"":"":NetCoreStackLocalization"",""isSelected"":false},{""Id"":"":NetCoreStackLocalization: CreateLanguage"",""Name"":""CreateLanguage"",""DisplayName"":null,""ControllerId"":"":NetCoreStackLocalization"",""isSelected"":false},{""Id"":"":NetCoreStackLocalization: CreateResource"",""Name"":""CreateResource"",""DisplayName"":null,""ControllerId"":"":NetCoreStackLocalization"",""isSelected"":false}]}]";
    //        role.IsActive = true;
    //        role.IsSystemRole = true;
    //        await _roleManager.CreateAsync(role);

    //        await _userManager.AddToRoleAsync(user1, role.Name);
    //        await _userManager.AddToRoleAsync(user2, role.Name);
    //        await _userManager.AddToRoleAsync(user3, role.Name);
    //        await _userManager.AddToRoleAsync(user4, role.Name);
    //        await _userManager.AddToRoleAsync(user5, role.Name);

    //        //create user role and redirect to edit_userRole page
    //        role = new UserRole();
    //        role.Name = "DormitoryManager";
    //        role.Access = @"[{""Id"":"":Error"",""Name"":""Error"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":Error: AccessDenied"",""Name"":""AccessDenied"",""DisplayName"":null,""ControllerId"":"":Error"",""isSelected"":false},{""Id"":"":Error: UnAuthorized"",""Name"":""UnAuthorized"",""DisplayName"":null,""ControllerId"":"":Error"",""isSelected"":false},{""Id"":"":Error: PageNotFound"",""Name"":""PageNotFound"",""DisplayName"":null,""ControllerId"":"":Error"",""isSelected"":false},{""Id"":"":Error: Status"",""Name"":""Status"",""DisplayName"":null,""ControllerId"":"":Error"",""isSelected"":false}]},{""Id"":"":Login"",""Name"":""Login"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":Login: Index"",""Name"":""Index"",""DisplayName"":null,""ControllerId"":"":Login"",""isSelected"":false},{""Id"":"":Login: Logout"",""Name"":""Logout"",""DisplayName"":null,""ControllerId"":"":Login"",""isSelected"":false}]},{""Id"":"":Register"",""Name"":""Register"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":Register: Index"",""Name"":""Index"",""DisplayName"":null,""ControllerId"":"":Register"",""isSelected"":false}]},{""Id"":"":Admin"",""Name"":""Admin"",""DisplayName"":null,""AreaName"":null,""Actions"":[{""Id"":"":Admin: Index"",""Name"":""Index"",""DisplayName"":null,""ControllerId"":"":Admin"",""isSelected"":false}]},{""Id"":""Admin: Catalog"",""Name"":""Catalog"",""DisplayName"":null,""AreaName"":""Admin"",""Actions"":[{""Id"":""Admin: Catalog: Rooms"",""Name"":""Rooms"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: RoomAdd"",""Name"":""RoomAdd"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: RoomEdit"",""Name"":""RoomEdit"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: DormitoryBlocks"",""Name"":""DormitoryBlocks"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: DormitoryBlockAdd"",""Name"":""DormitoryBlockAdd"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: DormitoryBlockEdit"",""Name"":""DormitoryBlockEdit"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: BulkRoomEdit"",""Name"":""BulkRoomEdit"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: LowQuotaReport"",""Name"":""LowQuotaReport"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: RoomReviews"",""Name"":""RoomReviews"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false},{""Id"":""Admin: Catalog: RoomReviewEdit"",""Name"":""RoomReviewEdit"",""DisplayName"":null,""ControllerId"":""Admin: Catalog"",""isSelected"":false}]},{""Id"":""Admin: Dashboard"",""Name"":""Dashboard"",""DisplayName"":null,""AreaName"":""Admin"",""Actions"":[{""Id"":""Admin: Dashboard: Index"",""Name"":""Index"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false},{""Id"":""Admin: Dashboard: BookingTotals"",""Name"":""BookingTotals"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false},{""Id"":""Admin: Dashboard: IncompleteBookings"",""Name"":""IncompleteBookings"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false},{""Id"":""Admin: Dashboard: LatestBookings"",""Name"":""LatestBookings"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false},{""Id"":""Admin: Dashboard: PopularFilters"",""Name"":""PopularFilters"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false},{""Id"":""Admin: Dashboard: BestSellersQuantity"",""Name"":""BestSellersQuantity"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false},{""Id"":""Admin: Dashboard: BestSellersAmount"",""Name"":""BestSellersAmount"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false},{""Id"":""Admin: Dashboard: NoOfBookings"",""Name"":""NoOfBookings"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false},{""Id"":""Admin: Dashboard: NoOfUsers"",""Name"":""NoOfUsers"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false},{""Id"":""Admin: Dashboard: NoOfPendingCancelledRequests"",""Name"":""NoOfPendingCancelledRequests"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false},{""Id"":""Admin: Dashboard: NoOfLowQuotaRooms"",""Name"":""NoOfLowQuotaRooms"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false},{""Id"":""Admin: Dashboard: GetBookingsChart"",""Name"":""GetBookingsChart"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false},{""Id"":""Admin: Dashboard: GetnewCustomersChart"",""Name"":""GetnewCustomersChart"",""DisplayName"":null,""ControllerId"":""Admin: Dashboard"",""isSelected"":false}]},{""Id"":""Admin: Notifications"",""Name"":""Notifications"",""DisplayName"":null,""AreaName"":""Admin"",""Actions"":[{""Id"":""Admin: Notifications: List"",""Name"":""List"",""DisplayName"":null,""ControllerId"":""Admin: Notifications"",""isSelected"":false}]},{""Id"":""Admin: Reservations"",""Name"":""Reservations"",""DisplayName"":null,""AreaName"":""Admin"",""Actions"":[{""Id"":""Admin: Reservations: List"",""Name"":""List"",""DisplayName"":null,""ControllerId"":""Admin: Reservations"",""isSelected"":false},{""Id"":""Admin: Reservations: ReservationEdit"",""Name"":""ReservationEdit"",""DisplayName"":null,""ControllerId"":""Admin: Reservations"",""isSelected"":false},{""Id"":""Admin: Reservations: CancelRequest"",""Name"":""CancelRequest"",""DisplayName"":null,""ControllerId"":""Admin: Reservations"",""isSelected"":false},{""Id"":""Admin: Reservations: CancelRequestEdit"",""Name"":""CancelRequestEdit"",""DisplayName"":null,""ControllerId"":""Admin: Reservations"",""isSelected"":false},{""Id"":""Admin: Reservations: CurrentWishList"",""Name"":""CurrentWishList"",""DisplayName"":null,""ControllerId"":""Admin: Reservations"",""isSelected"":false},{""Id"":""Admin: Reservations: BestSellerRooms"",""Name"":""BestSellerRooms"",""DisplayName"":null,""ControllerId"":""Admin: Reservations"",""isSelected"":false},{""Id"":""Admin: Reservations: RoomsNeverReserved"",""Name"":""RoomsNeverReserved"",""DisplayName"":null,""ControllerId"":""Admin: Reservations"",""isSelected"":false},{""Id"":""Admin: Reservations: CountryReport"",""Name"":""CountryReport"",""DisplayName"":null,""ControllerId"":""Admin: Reservations"",""isSelected"":false}]},{""Id"":""Admin: Users"",""Name"":""Users"",""DisplayName"":null,""AreaName"":""Admin"",""Actions"":[{""Id"":""Admin: Users: TrackOnlineUsers"",""Name"":""TrackOnlineUsers"",""DisplayName"":null,""ControllerId"":""Admin: Users"",""isSelected"":false}]},{""Id"":"":"",""Name"":"""",""DisplayName"":null,""AreaName"":"""",""Actions"":[]},{""Id"":"":"",""Name"":"""",""DisplayName"":null,""AreaName"":"""",""Actions"":[]},{""Id"":"":"",""Name"":"""",""DisplayName"":null,""AreaName"":"""",""Actions"":[]},{""Id"":"":"",""Name"":"""",""DisplayName"":null,""AreaName"":"""",""Actions"":[]},{""Id"":"":"",""Name"":"""",""DisplayName"":null,""AreaName"":"""",""Actions"":[]},{""Id"":"":"",""Name"":"""",""DisplayName"":null,""AreaName"":"""",""Actions"":[]},{""Id"":"":"",""Name"":"""",""DisplayName"":null,""AreaName"":"""",""Actions"":[]},{""Id"":"":"",""Name"":"""",""DisplayName"":null,""AreaName"":"""",""Actions"":[]},{""Id"":"":"",""Name"":"""",""DisplayName"":null,""AreaName"":"""",""Actions"":[]},{""Id"":"":"",""Name"":"""",""DisplayName"":null,""AreaName"":"""",""Actions"":[]},{""Id"":"":"",""Name"":"""",""DisplayName"":null,""AreaName"":"""",""Actions"":[]},{""Id"":"":"",""Name"":"""",""DisplayName"":null,""AreaName"":"""",""Actions"":[]},{""Id"":"":"",""Name"":"""",""DisplayName"":null,""AreaName"":"""",""Actions"":[]},{""Id"":"":"",""Name"":"""",""DisplayName"":null,""AreaName"":"""",""Actions"":[]},{""Id"":"":"",""Name"":"""",""DisplayName"":null,""AreaName"":"""",""Actions"":[]},{""Id"":"":"",""Name"":"""",""DisplayName"":null,""AreaName"":"""",""Actions"":[]},{""Id"":"":"",""Name"":"""",""DisplayName"":null,""AreaName"":"""",""Actions"":[]},{""Id"":"":"",""Name"":"""",""DisplayName"":null,""AreaName"":"""",""Actions"":[]},{""Id"":"":"",""Name"":"""",""DisplayName"":null,""AreaName"":"""",""Actions"":[]},{""Id"":"":"",""Name"":"""",""DisplayName"":null,""AreaName"":"""",""Actions"":[]},{""Id"":"":"",""Name"":"""",""DisplayName"":null,""AreaName"":"""",""Actions"":[]},{""Id"":"":"",""Name"":"""",""DisplayName"":null,""AreaName"":"""",""Actions"":[]},{""Id"":"":"",""Name"":"""",""DisplayName"":null,""AreaName"":"""",""Actions"":[]}]";
    //        role.IsActive = true;
    //        role.IsSystemRole = true;
    //        await _roleManager.CreateAsync(role);




                  
             

    //        if (result.Succeeded)
    //        {
    //            await _signInManager.SignInAsync(user5, false);
    //            return Json(true);
    //        }
    //        else
    //        {
          
    //            return Json(false);
    //        }

           
            
    //    }
    //    //public IActionResult Login()
    //    //{
    //    //    return View();
    //    //}



    //    //public IActionResult Register()
    //    //{
    //    //    return View();
    //    //}















    //}



}