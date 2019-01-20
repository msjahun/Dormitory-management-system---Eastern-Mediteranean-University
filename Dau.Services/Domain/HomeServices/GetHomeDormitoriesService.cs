using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using Dau.Core.Domain.Bookings;
using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.LocationInformations;
using Dau.Core.Domain.SearchEngineOptimization;
using Dau.Data.Repository;
using Dau.Services.Domain.DropdownServices;
using Dau.Services.Domain.ImageServices;
using Dau.Services.Domain.LocationServices;
using Dau.Services.Domain.MapServices;
using Dau.Services.Languages;
using System.Linq;
using System;
using Dau.Services.Domain.ReviewsServices;

namespace Dau.Services.Domain.HomeService
{
    public class GetHomeDormitoriesService : IGetHomeDormitoriesService
    {
        private readonly IStringLocalizer Localizer;
        private readonly IRepository<Room> _roomRepository;
        private readonly IRepository<RoomTranslation> _roomTransRepository;
        private readonly IRepository<Dormitory> _dormitoryRepository;
        private readonly IRepository<DormitoryTranslation> _dormitoryTranslationRepository;
        private readonly IRepository<SemesterPeriod> _SemesterPeriodRepo;
        private readonly IRepository<SemesterPeriodTranslation> _semesterPeriodTransRepo;
        private IRepository<DormitoryType> _dormitoryTypeRepo;
        private readonly ILocationService _locationService;
        private readonly IDropdownService _dropdownService;
        private readonly IMapService _mapService;
        private readonly IRepository<Seo> _seoRepo;
        private readonly IImageService _imageService;
        private readonly ILanguageService _languageService;
        private readonly IRepository<DormitoryBlock> _dormitoryBlockRepo;
        private readonly IRepository<DormitoryBlockTranslation> _dormitoryBlockTransRepo;
        private readonly IRepository<DormitoryTypeTranslation> _dormitoryTypeTranslationRepo;
        private readonly IRepository<CatalogImage> _imagesRepo;
        private readonly IRepository<DormitoryCatalogImage> _dormitoryImageRepo;
        private readonly IRepository<Review> _reviewRepo;
        private readonly IRepository<Locationinformation> _locationRepo;
        private readonly IReviewService _reviewService;

        public GetHomeDormitoriesService(IStringLocalizer _Localizer, IRepository<Room> RoomRepository,
            IRepository<RoomTranslation> RoomTransRepository,
            IRepository<Dormitory> DormitoryRepository,
            IRepository<DormitoryTranslation> DormitoryTranslationRepository,
            IRepository<DormitoryBlock> DormitoryBlockRepository,
            IRepository<DormitoryBlockTranslation> DormitoryBlockTranslationRepository,
            IRepository<SemesterPeriod> SemesterPeriodRepository,
            IRepository<SemesterPeriodTranslation> semesterPeriodTransRepository,
             ILanguageService languageService,
            IRepository<DormitoryType> dormitoryTypeRepository,
            IRepository<DormitoryTypeTranslation> dormitoryTypeTranslationRepository,
        IRepository<CatalogImage> imagesRepository,
                    IRepository<DormitoryCatalogImage> DormitoryImageRepository,
                    IRepository<Seo> seoRepository,
                    IRepository<Review> reviewRepository,
                    IRepository<Locationinformation> locationRepository,
                      IImageService imageService,
                        IMapService mapService,
                        IDropdownService dropdownService,
                        ILocationService locationService,
                        IReviewService reviewService)
        {
            Localizer = _Localizer;
            _locationService = locationService;
            _dropdownService = dropdownService;
            _mapService = mapService;
            _seoRepo = seoRepository;
            _imageService = imageService;
            _languageService = languageService;
            _dormitoryBlockRepo = DormitoryBlockRepository;
            _dormitoryBlockTransRepo = DormitoryBlockTranslationRepository;

            _roomRepository = RoomRepository;
            _roomTransRepository = RoomTransRepository;
            _dormitoryRepository = DormitoryRepository;
            _dormitoryTranslationRepository = DormitoryTranslationRepository;
            _SemesterPeriodRepo = SemesterPeriodRepository;
            _semesterPeriodTransRepo = semesterPeriodTransRepository;
            _dormitoryTypeRepo = dormitoryTypeRepository;
            _dormitoryTypeTranslationRepo = dormitoryTypeTranslationRepository;
            _imagesRepo = imagesRepository;
            _dormitoryImageRepo = DormitoryImageRepository;
            _reviewRepo = reviewRepository;
            _locationRepo = locationRepository;
            _reviewService = reviewService;
        }

    

        public HomePageModel GetPopularDormitories(DormitoryPartialModel Model)
        {

            var Images = from imageList in _imagesRepo.List().Distinct().ToList()
                         join dormImage in _dormitoryImageRepo.List().ToList() on imageList.Id equals dormImage.CatalogImageId
                         select new { imageList.ImageUrl, dormImage.DormitoryId };

            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            var dormitories = from dorm in _dormitoryRepository.List().ToList()
                              join dormTrans in _dormitoryTranslationRepository.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                              where dormTrans.LanguageId == CurrentLanguageId && dorm.Published == true
                              select new
                              {
                                  dorm.Id,
                                  DormitorySeoId = dorm.SeoId,
                                  dormTrans.DormitoryName,
                                  dorm.DormitoryLogoUrl,
                                  dorm.DormitoryTypeId,
                                  dorm.RatingNo,
                                  Location = _dropdownService.ResolveDropdown(dorm.LocationOnCampus, _dropdownService.LocationOnCampus()),
                                  DormitoryDescription = dormTrans.ShortDescription,
                                  dorm.MapSectionId,
                                  dorm.DormitoryStreetAddress,
                                 
                              };

            var dormitoryType = from dormType in _dormitoryTypeRepo.List().ToList()
                                join dormTypeTrans in _dormitoryTypeTranslationRepo.List().ToList() on dormType.Id equals dormTypeTrans.DormitoryTypeNonTransId
                                where dormTypeTrans.LanguageId == CurrentLanguageId
                                select new { dormType.Id, dormTypeTrans.Title };

            var dormitoryAndtype = from dorm in dormitories.ToList()
                                   join dormType in dormitoryType.ToList() on dorm.DormitoryTypeId equals dormType.Id
                                   orderby dorm.Id ascending
                                   select new DormitoryCard
                                   {
                                       // ImageUrls = _imageService.ImageSplitterList(Images.Where(d => d.DormitoryId == dorm.Id).Select(x => x.ImageUrl).ToList(), "_p6"),
                                       DormitoryName = dorm.DormitoryName,
                                       // DormitoryIconUrl = dorm.DormitoryLogoUrl,
                                       DormitorySeoFriendlyUrl = _seoRepo.List().ToList().Where(c => c.Id == dorm.DormitorySeoId).FirstOrDefault().SearchEngineFriendlyPageName, //use seo table
                                                                                                                                                                                 //  RatingNo = dorm.RatingNo.ToString("N1"),
                                       RatingText = _reviewService.ResolveRatingText(dorm.RatingNo), //create a service that resolves this
                                                                    // ReviewNo = _reviewRepo.List().Where(c => c.DormitoryId == dorm.Id).ToList().Count,
                                                                    // Location = dorm.Location,
                                                                    // ShortDescription = dorm.DormitoryDescription,
                                                                    // ReservationPosibleWithoutCreditCard = false, //
                                                                    // DormitoryStreetAddress = dorm.DormitoryStreetAddress,
                                                                    // MapSection = _mapService.GetMapSectionById(dorm.MapSectionId),
                                                                    //
                                                                    //
                                                                    // ClosestLandMark = _locationService.GetClosestLandmark(dorm.Id),
                                                                    // ClosestLandMarkMapSection = _locationService.GetClosestLandmarkMapSection(dorm.Id),
                                                                    // DormitoryName = "Alfam dormitory",
                                                                    // DormitorySeoFriendlyUrl = "Alfam-dormitory",
                                       DormitoryId = dorm.Id,
                                       ImageUrl = _imageService.ImageSplitter(Images.Where(d => d.DormitoryId == dorm.Id).Select(x => x.ImageUrl).FirstOrDefault(), "_p6"),
                                       // RatingText = Localizer["Excellent"],
                                       RatingNo = dorm.RatingNo,
                                       ReviewsNo = _reviewRepo.List().Where(c => c.DormitoryId == dorm.Id).ToList().Count,
                                   };
            HomePageModel model= new HomePageModel();

            model.DormitoryPartialModel = Model;
            model.DormitoryCardsList = dormitoryAndtype.ToList();

           
            return model;
           
        }

        public HomePageModel GetHighlyRatedDormitories(DormitoryPartialModel Model)
        {
            var Images = from imageList in _imagesRepo.List().Distinct().ToList()
                         join dormImage in _dormitoryImageRepo.List().ToList() on imageList.Id equals dormImage.CatalogImageId
                         select new { imageList.ImageUrl, dormImage.DormitoryId };

            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            var dormitories = from dorm in _dormitoryRepository.List().ToList()
                              join dormTrans in _dormitoryTranslationRepository.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                              where dormTrans.LanguageId == CurrentLanguageId && dorm.Published == true
                              select new
                              {
                                  dorm.Id,
                                  DormitorySeoId = dorm.SeoId,
                                  dormTrans.DormitoryName,
                                  dorm.DormitoryLogoUrl,
                                  dorm.DormitoryTypeId,
                                  dorm.RatingNo,
                              
                                  Location = _dropdownService.ResolveDropdown(dorm.LocationOnCampus, _dropdownService.LocationOnCampus()),
                                  DormitoryDescription = dormTrans.ShortDescription,
                                  dorm.MapSectionId,
                                  dorm.DormitoryStreetAddress
                              };

            var dormitoryType = from dormType in _dormitoryTypeRepo.List().ToList()
                                join dormTypeTrans in _dormitoryTypeTranslationRepo.List().ToList() on dormType.Id equals dormTypeTrans.DormitoryTypeNonTransId
                                where dormTypeTrans.LanguageId == CurrentLanguageId
                                select new { dormType.Id, dormTypeTrans.Title };

            var dormitoryAndtype = from dorm in dormitories.ToList()
                                   join dormType in dormitoryType.ToList() on dorm.DormitoryTypeId equals dormType.Id
                                   select new DormitoryCard
                                   {
                                       // ImageUrls = _imageService.ImageSplitterList(Images.Where(d => d.DormitoryId == dorm.Id).Select(x => x.ImageUrl).ToList(), "_p6"),
                                       DormitoryName = dorm.DormitoryName,
                                       // DormitoryIconUrl = dorm.DormitoryLogoUrl,
                                       DormitorySeoFriendlyUrl = _seoRepo.List().ToList().Where(c => c.Id == dorm.DormitorySeoId).FirstOrDefault().SearchEngineFriendlyPageName, //use seo table
                                                                                                                                                                                 //  RatingNo = dorm.RatingNo.ToString("N1"),
                                       RatingText = _reviewService.ResolveRatingText(dorm.RatingNo), //create a service that resolves this
                                                                 // ReviewNo = _reviewRepo.List().Where(c => c.DormitoryId == dorm.Id).ToList().Count,
                                                                 // Location = dorm.Location,
                                                                 // ShortDescription = dorm.DormitoryDescription,
                                                                 // ReservationPosibleWithoutCreditCard = false, //
                                                                 // DormitoryStreetAddress = dorm.DormitoryStreetAddress,
                                                                 // MapSection = _mapService.GetMapSectionById(dorm.MapSectionId),
                                                                 //
                                                                 //
                                                                 // ClosestLandMark = _locationService.GetClosestLandmark(dorm.Id),
                                                                 // ClosestLandMarkMapSection = _locationService.GetClosestLandmarkMapSection(dorm.Id),
                                                                 // DormitoryName = "Alfam dormitory",
                                                                 // DormitorySeoFriendlyUrl = "Alfam-dormitory",
                                       DormitoryId = dorm.Id,
                                       ImageUrl = _imageService.ImageSplitter(Images.Where(d => d.DormitoryId == dorm.Id).Select(x => x.ImageUrl).FirstOrDefault(), "_p6"),
                                       // RatingText = Localizer["Excellent"],
                                       RatingNo = dorm.RatingNo,
                                       ReviewsNo = _reviewRepo.List().Where(c => c.DormitoryId == dorm.Id).ToList().Count
                                   };
            HomePageModel model = new HomePageModel();

            model.DormitoryPartialModel = Model;
            model.DormitoryCardsList = dormitoryAndtype.Where(c=>c.ReviewsNo>0).ToList();


            return model;

        }


        public HomePageModel GetCoolOffersDeals(DormitoryPartialModel Model)
        {
            var Images = from imageList in _imagesRepo.List().Distinct().ToList()
                         join dormImage in _dormitoryImageRepo.List().ToList() on imageList.Id equals dormImage.CatalogImageId
                         select new { imageList.ImageUrl, dormImage.DormitoryId };

            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            var dormitories = from dorm in _dormitoryRepository.List().ToList()
                              join dormTrans in _dormitoryTranslationRepository.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                              where dormTrans.LanguageId == CurrentLanguageId && dorm.Published == true
                              select new
                              {
                                  dorm.Id,
                                  DormitorySeoId = dorm.SeoId,
                                  dormTrans.DormitoryName,
                                  dorm.DormitoryLogoUrl,
                                  dorm.DormitoryTypeId,
                                  dorm.RatingNo,
                                  Location = _dropdownService.ResolveDropdown(dorm.LocationOnCampus, _dropdownService.LocationOnCampus()),
                                  DormitoryDescription = dormTrans.ShortDescription,
                                  dorm.MapSectionId,
                                  dorm.DormitoryStreetAddress,
                                  HasDeals = _roomRepository.List().Where(c => c.DormitoryId == dorm.Id && c.DisplayDeal == true && c.DealEndTime > DateTime.Now).ToList().Count
                              };

            var dormitoryType = from dormType in _dormitoryTypeRepo.List().ToList()
                                join dormTypeTrans in _dormitoryTypeTranslationRepo.List().ToList() on dormType.Id equals dormTypeTrans.DormitoryTypeNonTransId
                                where dormTypeTrans.LanguageId == CurrentLanguageId
                                select new { dormType.Id, dormTypeTrans.Title };

            var dormitoryAndtype = from dorm in dormitories.ToList()
                                   join dormType in dormitoryType.ToList() on dorm.DormitoryTypeId equals dormType.Id
                                   where _reviewRepo.List().Where(c => c.DormitoryId == dorm.Id).ToList().Count>0
                                   select new DormitoryCard
                                   {
                                       // ImageUrls = _imageService.ImageSplitterList(Images.Where(d => d.DormitoryId == dorm.Id).Select(x => x.ImageUrl).ToList(), "_p6"),
                                       DormitoryName = dorm.DormitoryName,
                                       // DormitoryIconUrl = dorm.DormitoryLogoUrl,
                                       DormitorySeoFriendlyUrl = _seoRepo.List().ToList().Where(c => c.Id == dorm.DormitorySeoId).FirstOrDefault().SearchEngineFriendlyPageName, //use seo table
                                                                                                                                                                                 //  RatingNo = dorm.RatingNo.ToString("N1"),
                                       RatingText = _reviewService.ResolveRatingText(dorm.RatingNo), //create a service that resolves this
                                                                 // ReviewNo = _reviewRepo.List().Where(c => c.DormitoryId == dorm.Id).ToList().Count,
                                                                 // Location = dorm.Location,
                                                                 // ShortDescription = dorm.DormitoryDescription,
                                                                 // ReservationPosibleWithoutCreditCard = false, //
                                                                 // DormitoryStreetAddress = dorm.DormitoryStreetAddress,
                                                                 // MapSection = _mapService.GetMapSectionById(dorm.MapSectionId),
                                                                 //
                                                                 //
                                                                 // ClosestLandMark = _locationService.GetClosestLandmark(dorm.Id),
                                                                 // ClosestLandMarkMapSection = _locationService.GetClosestLandmarkMapSection(dorm.Id),
                                                                 // DormitoryName = "Alfam dormitory",
                                                                 // DormitorySeoFriendlyUrl = "Alfam-dormitory",
                                       DormitoryId = dorm.Id,
                                       ImageUrl = _imageService.ImageSplitter(Images.Where(d => d.DormitoryId == dorm.Id).Select(x => x.ImageUrl).FirstOrDefault(), "_p6"),
                                       // RatingText = Localizer["Excellent"],
                                       RatingNo = dorm.RatingNo,
                                       ReviewsNo = _reviewRepo.List().Where(c => c.DormitoryId == dorm.Id).ToList().Count,
                                       DealsNo= dorm.HasDeals
                                   };
            HomePageModel model = new HomePageModel();

            model.DormitoryPartialModel = Model;
            model.DormitoryCardsList = dormitoryAndtype.Where(c=>c.DealsNo>0).ToList();


            return model;

        }


    }

    public class DormitoryPartialModel
    {
        public string SectionId { get; set; }
        public string SwiperId { get; set; }
    }

    public class DormitoryCard
    {
        public long DormitoryId { get; set; }
        public string DormitorySeoFriendlyUrl { get; set; }
        public string ImageUrl { get; set; }
        public string DormitoryName { get; set; }
        public string RatingText { get; set; }
        public double RatingNo { get; set; }
        public int ReviewsNo { get; set; }
        public int  DealsNo { get; set; }
    }

    public class HomePageModel
    {

        public DormitoryPartialModel DormitoryPartialModel { get; set; }
        public List<DormitoryCard> DormitoryCardsList { get; set; }
    }
}
