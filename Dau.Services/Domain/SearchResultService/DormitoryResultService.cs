using Dau.Core.Domain.Bookings;
using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Feature;
using Dau.Core.Domain.LocationInformations;
using Dau.Core.Domain.SearchEngineOptimization;
using Dau.Data.Repository;
using Dau.Services.Domain.DropdownServices;
using Dau.Services.Domain.ImageServices;
using Dau.Services.Domain.LocationServices;
using Dau.Services.Domain.MapServices;
using Dau.Services.Domain.ReviewsServices;
using Dau.Services.Languages;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.SearchResultService
{
    public class DormitoryResultService : IDormitoryResultService
    {
        private readonly IRepository<Room> _roomRepository;
        private readonly IRepository<RoomTranslation> _roomTransRepository;
        private readonly IRepository<Dormitory> _dormitoryRepository;
        private readonly IRepository<DormitoryTranslation> _dormitoryTranslationRepository;
        private readonly IRepository<SemesterPeriod> _SemesterPeriodRepo;
        private readonly IRepository<SemesterPeriodTranslation> _semesterPeriodTransRepo;
        private IRepository<DormitoryType> _dormitoryTypeRepo;
        private readonly IStringLocalizer _localizer;
        private readonly IReviewService _reviewService;
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

        public DormitoryResultService(
   IRepository<Room> RoomRepository,
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
                        IReviewService reviewService,
                        IStringLocalizer stringLocalizer

          )
        {
            _localizer = stringLocalizer;
            _reviewService = reviewService;
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
            _dormitoryTypeRepo= dormitoryTypeRepository;
            _dormitoryTypeTranslationRepo = dormitoryTypeTranslationRepository;
            _imagesRepo = imagesRepository;
            _dormitoryImageRepo = DormitoryImageRepository;
            _reviewRepo = reviewRepository;
            _locationRepo = locationRepository;


        }

        public List<DormitoryResultViewModel> GetDormitoryResult()
        {

            var Images = from imageList in _imagesRepo.List().Distinct().ToList()
                         join dormImage in _dormitoryImageRepo.List().ToList() on imageList.Id equals dormImage.CatalogImageId
                         select new { imageList.ImageUrl, dormImage.DormitoryId };

            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            var dormitories = from dorm in _dormitoryRepository.List().ToList()
                              join dormTrans in _dormitoryTranslationRepository.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                              where dormTrans.LanguageId == CurrentLanguageId && dorm.Published== true
                              select new { dorm.Id, DormitorySeoId = dorm.SeoId,
                                  dormTrans.DormitoryName, dorm.DormitoryLogoUrl,
                                  dorm.DormitoryTypeId, dorm.RatingNo, dorm.ReviewNo,
                                  Location = _dropdownService.ResolveDropdown(dorm.LocationOnCampus, _dropdownService.LocationOnCampus()),
                                DormitoryDescription=  dormTrans.ShortDescription,
                                  dorm.MapSectionId,
                                  dorm.DormitoryStreetAddress
                              };

            var dormitoryType = from dormType in _dormitoryTypeRepo.List().ToList()
                                join dormTypeTrans in _dormitoryTypeTranslationRepo.List().ToList() on dormType.Id equals dormTypeTrans.DormitoryTypeNonTransId
                                where dormTypeTrans.LanguageId == CurrentLanguageId
                                select new { dormType.Id, dormTypeTrans.Title };

            var dormitoryAndtype = from dorm in dormitories.ToList()
                                   join dormType in dormitoryType.ToList() on dorm.DormitoryTypeId equals dormType.Id
                                   select new DormitoryResultViewModel
                                   {
                                       ImageUrls = _imageService.ImageSplitterList(Images.Where(d => d.DormitoryId == dorm.Id).Select(x => x.ImageUrl).ToList(), "_p6"),
                                       DormitoryType = dormType.Title, //dormitory type table
                                       DormitoryName = dorm.DormitoryName,
                                       DormitoryIconUrl = dorm.DormitoryLogoUrl,
                                       RatingNo = (_reviewRepo.List().Where(c => c.DormitoryId == dorm.Id).ToList().Count <= 0) ? _localizer["N.A"] : dorm.RatingNo.ToString("N1"),
                                       RatingNoRaw = dorm.RatingNo,
                                       RatingText = (_reviewRepo.List().Where(c => c.DormitoryId == dorm.Id).ToList().Count <= 0) ? _localizer["Unrated"] : _reviewService.ResolveRatingText(dorm.RatingNo),
                                       DormitorySeoFriendlyUrl = _seoRepo.List().ToList().Where(c => c.Id == dorm.DormitorySeoId).FirstOrDefault().SearchEngineFriendlyPageName, //use seo table
                                    
                                      
                                       ReviewNo = _reviewRepo.List().Where(c => c.DormitoryId == dorm.Id).ToList().Count,
                                       Location = dorm.Location,
                                       ShortDescription = dorm.DormitoryDescription ,
                                      ReservationPosibleWithoutCreditCard = false, //
                                DormitoryStreetAddress = dorm.DormitoryStreetAddress,
                             MapSection = _mapService.GetMapSectionById(dorm.MapSectionId),


                               ClosestLandMark =_locationService.GetClosestLandmark(dorm.Id),
                                      ClosestLandMarkMapSection =_locationService.GetClosestLandmarkMapSection(dorm.Id)
                        //  IsbookedInlast24hours = false //has to do with booking
                                                              
                              

                                  };




            List<DormitoryResultViewModel> modelList = dormitoryAndtype.ToList();
            
            return modelList;
        }
    }


    public class DormitoryResultViewModel
    {
        public List<string> ImageUrls { get; set; }
        public string DormitoryType { get; set; }
        public string DormitoryName { get; set; }
        public string DormitoryIconUrl { get; set; }
        public string DormitorySeoFriendlyUrl { get; set; }
        public string RatingNo { get; set; }
        public string RatingText { get; set; }
        public int ReviewNo { get; set; }
        public string Location { get; set; }
        public String ShortDescription { get; set; }
        public bool ReservationPosibleWithoutCreditCard { get; set; }

        public string DormitoryStreetAddress { get; set; }
        //Booked 3 times in the last 4 hours
        public int NoTimesBooked { get; set; }
        public int NoHours { get; set; }
        public bool IsbookedInlast24hours { get; set; }

        //mapSection in ergec campus map
        public string MapSection { get; set; }

        //(1.8 km from Central lecture hall
        public string ClosestLandMark { get; set; }
        public string ClosestLandMarkMapSection { get; set; }
        //-Bus stop access
        public string UniqueAttribute { get; set; }
        public Locationinformation location { get; set; }
        public double RatingNoRaw { get; internal set; }
    }


}
