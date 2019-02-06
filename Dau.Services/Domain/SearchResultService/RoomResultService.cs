using Dau.Core.Domain.Bookings;
using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.CurrencyInformation;
using Dau.Core.Domain.Feature;
using Dau.Core.Domain.LocationInformations;
using Dau.Core.Domain.SearchEngineOptimization;
using Dau.Data.Repository;
using Dau.Services.Domain.CurrencyServices;
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
  public  class RoomResultService : IRoomResultService
    {

        private readonly IRepository<Room> _roomRepository;
        private readonly IRepository<RoomTranslation> _roomTransRepository;
        private readonly IRepository<Dormitory> _dormitoryRepository;
        private readonly IRepository<DormitoryTranslation> _dormitoryTranslationRepository;
        private readonly IRepository<SemesterPeriod> _SemesterPeriodRepo;
        private readonly IRepository<SemesterPeriodTranslation> _semesterPeriodTransRepo;
        private IRepository<DormitoryType> _dormitoryTypeRepo;
        private readonly IRepository<Currency> _currencyRepo;
        private readonly IStringLocalizer _Localizer;
        private readonly IReviewService _reviewService;
        private readonly ILocationService _locationService;
        private readonly IRepository<Seo> _seoRepo;
        private readonly IMapService _mapService;
        private readonly ILanguageService _languageService;
        private readonly IRepository<DormitoryBlock> _dormitoryBlockRepo;
        private readonly IRepository<DormitoryBlockTranslation> _dormitoryBlockTransRepo;
        private readonly IImageService _imageService;
        private readonly IRepository<DormitoryTypeTranslation> _dormitoryTypeTranslationRepo;
        private readonly IRepository<CatalogImage> _imagesRepo;

        public IRepository<RoomCatalogImage> _roomImageRepo { get; }

       
        private readonly IRepository<Review> _reviewRepo;
        private readonly IRepository<Locationinformation> _locationRepo;
        private readonly IRepository<RoomFeatures> _roomFeaturesRepo;
        private readonly IRepository<Features> _featuresRepo;
        private readonly IRepository<FeaturesTranslation> _featuresTranslation;
        private readonly IDropdownService _dropdownService;
        private readonly ICurrencyService _currencyService;

        public RoomResultService(
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
                    IRepository<RoomCatalogImage> RoomImageRepository,
                    IRepository<Seo> seoRepository,
                    IRepository<Review> reviewRepository,
                    IRepository<Locationinformation> locationRepository,
                      IRepository<RoomFeatures> RoomFeaturesRepo,
            IRepository<Features> featuresRepo,
            IImageService imageService,
            IMapService mapService,
            IDropdownService dropdownService,
            ILocationService locationService,
              IReviewService reviewService,
            IRepository<FeaturesTranslation> featuresTranslation,
            IStringLocalizer stringLocalizer,
              ICurrencyService currencyService,
              IRepository<Currency> currencyRepo

            )
        {

            _currencyRepo = currencyRepo;
            _Localizer = stringLocalizer;
            _reviewService = reviewService;
            _locationService = locationService;
            _seoRepo = seoRepository;
            _mapService = mapService;
            _languageService = languageService;
            _dormitoryBlockRepo = DormitoryBlockRepository;
            _dormitoryBlockTransRepo = DormitoryBlockTranslationRepository;
            _imageService = imageService;
           _roomRepository = RoomRepository;
            _roomTransRepository = RoomTransRepository;
            _dormitoryRepository = DormitoryRepository;
            _dormitoryTranslationRepository = DormitoryTranslationRepository;
            _SemesterPeriodRepo = SemesterPeriodRepository;
            _semesterPeriodTransRepo = semesterPeriodTransRepository;
            _dormitoryTypeRepo = dormitoryTypeRepository;
            _dormitoryTypeTranslationRepo = dormitoryTypeTranslationRepository;
            _imagesRepo = imagesRepository;
            _roomImageRepo = RoomImageRepository;
            _reviewRepo = reviewRepository;
            _locationRepo = locationRepository;
            _roomFeaturesRepo = RoomFeaturesRepo;
            _featuresRepo = featuresRepo;
            _featuresTranslation = featuresTranslation;
            _dropdownService = dropdownService;
            _currencyService = currencyService;
        }

        public List<RoomResultViewModel> GetRoomResult(GetRoomResultViewModel filters)
        {
            //get all room images + dormitory images
            //get the top 4 room features and images images

            //room information with translation
            //dormitory information with translation

            var CurrentLanguageId = _languageService.GetCurrentLanguageId();


            var dormitoryBlock = from dormBlock in _dormitoryBlockRepo.List().ToList()
                                 join dormBlockTrans in _dormitoryBlockTransRepo.List().ToList() on dormBlock.Id equals dormBlockTrans.DormitoryBlockNonTransId
                                 where dormBlockTrans.LanguageId == CurrentLanguageId
                                 select new { dormBlock.Published, dormBlockTrans.Name, dormBlock.Id };

            var roomList = new List<Room>();


            if (filters.ShowAvailable)
                roomList= _roomRepository.List().Where(c => c.NoRoomQuota > 0).ToList();
            else
                roomList= _roomRepository.List().ToList();


            if (filters.ShowDiscountsOnly)
                roomList = roomList.Where(c => c.DisplayDeal == true && c.DealEndTime>DateTime.Now).ToList();
            


                var rooms = from room in roomList
                            join roomTrans in _roomTransRepository.List().ToList() on room.Id equals roomTrans.RoomNonTransId
                        where roomTrans.LanguageId == CurrentLanguageId && room.Published==true
                        select new { room.Id, room.DormitoryId, room.DormitoryBlockId, roomTrans.RoomName,
                            room.PriceCash,
                            room.PriceOldCash,
                            room.PriceInstallment,
                            room.PriceOldInstallment,
                            room.ShowPrice, room.NoRoomQuota, room.RoomSize,
                            roomTrans.GenderAllocation, room.PaymentPerSemesterNotYear,
                            room.PercentageOff,
                            room.DealEndTime,
                            room.DisplayNoRoomsLeft,
                            room.DisplayDeal
                        };

            var FeaturesToBeFiltered = _featuresRepo.List().ToList();
       

            var features = from feature in FeaturesToBeFiltered.ToList()
                           join featureTrans in _featuresTranslation.List().ToList() on feature.Id equals featureTrans.FeaturesNonTransId
                           where featureTrans.LanguageId == CurrentLanguageId
                           select new { feature.Id, featureTrans.FeatureName, feature.IconUrl };

            

            var roomsDormitoryBlock =( from room in rooms.ToList()
                                      join dormBlock in dormitoryBlock.ToList() on room.DormitoryBlockId equals dormBlock.Id
                                      select new
                                      {
                                         
                                          DormitoryBlockPublished = dormBlock.Published,
                                          DormitoryBlockName = dormBlock.Name,
                                          room.Id,
                                          room.DormitoryId,
                                          room.DormitoryBlockId,
                                          room.RoomName,
                                          room.PriceCash,
                                          room.PriceOldCash,
                                          room.PriceInstallment,
                                          room.PriceOldInstallment,
                                          room.ShowPrice,
                                          room.NoRoomQuota,
                                          room.RoomSize,
                                          room.GenderAllocation,
                                          room.PaymentPerSemesterNotYear,
                                          room.PercentageOff,
                                          room.DealEndTime,
                                          room.DisplayNoRoomsLeft,
                                          room.DisplayDeal
                                      }).ToList();



            var Images = from imageList in _imagesRepo.List().Distinct().ToList()
                         join roomImage in _roomImageRepo.List().ToList() on imageList.Id equals roomImage.CatalogImageId
                        select new { imageList.ImageUrl, roomImage.RoomId};


            var LocationsOnCampus = _dropdownService.LocationOnCampus();
            //dormitories filter applied here
            var dormIdsList = new List<long>();
            var dormfilteredList = new List<Dormitory>();

            if (filters.DormitoryNameIds!=null){
                dormIdsList = filters.DormitoryNameIds;

                dormfilteredList = _dormitoryRepository.List().Where(c => dormIdsList.Contains(c.Id)).ToList();
            }else{
                dormfilteredList = _dormitoryRepository.List().ToList();
            }
  
            var dormitories = from dorm in dormfilteredList
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
                                  RatingNoFloor =(_reviewRepo.List().Where(c => c.DormitoryId == dorm.Id).Count()==0)?0: Math.Floor(dorm.RatingNo),
                                  dorm.ReviewNo,
                                  UsersReviewNo = _reviewRepo.List().Where(c=>c.DormitoryId==dorm.Id).Count(),
                                  Location = _dropdownService.ResolveDropdown(dorm.LocationOnCampus, LocationsOnCampus),
                                  dormTrans.DormitoryDescription,
                                  dorm.DormitoryStreetAddress,
                                 dorm.MapSectionId,
                                 dorm.CurrencyId
                                
                              };

            var CurrencyTRY = _currencyRepo.List().Where(c => c.CurrencyCode == "TRY").FirstOrDefault();
            var CurrencyUSD = _currencyRepo.List().Where(c => c.CurrencyCode == "USD").FirstOrDefault();

            long CurrencyTLId = 0;
            if (CurrencyTRY != null)
                CurrencyTLId = CurrencyTRY.Id;


                    long CurrencyUSDId = 0;
            if (CurrencyUSD != null)
                CurrencyUSDId= CurrencyUSD.Id;

            var CurrencyList = new List<double>();
            if (filters.CurrencyTl)
            {
                CurrencyList.Add(CurrencyTLId);
            }

            if (filters.CurrencyUsd)
            {
                CurrencyList.Add(CurrencyUSDId);
            }


            dormitories = dormitories.Where(c => CurrencyList.Contains(c.CurrencyId)).ToList();

            //starrating filtering && review!=0;
            var RatingsList = new List<double>();

           
            if (filters.RatingStar1) {
            
                RatingsList.Add(1);
                RatingsList.Add(2);
            }

            if (filters.RatingStar2) { 
                RatingsList.Add(3);
                RatingsList.Add(4);
            }

            if (filters.RatingStar3) { 
                RatingsList.Add(5);
                RatingsList.Add(6);
            }

            if (filters.RatingStar4) {
                RatingsList.Add(7);
                RatingsList.Add(8);
            }

            if (filters.RatingStar5) {
                RatingsList.Add(9);
                RatingsList.Add(10);
            }


           
            if (filters.RatingUnrated)
            {
                RatingsList.Add(0);
            }

            dormitories = dormitories.Where(c => RatingsList.Contains(c.RatingNoFloor)).ToList();
            
     

            var dormitoryType = from dormType in _dormitoryTypeRepo.List().ToList()
                                join dormTypeTrans in _dormitoryTypeTranslationRepo.List().ToList() on dormType.Id equals dormTypeTrans.DormitoryTypeNonTransId
                                where dormTypeTrans.LanguageId == CurrentLanguageId
                                select new { dormType.Id, dormTypeTrans.Title };

            bool same = (filters.PrivateDormitories == filters.SchoolDormitories); //false true =false and false false= false, true true= true
            var dormTypeIdsList = new List<long>();
            if (filters.PrivateDormitories) dormTypeIdsList.Add(2);
            if (filters.SchoolDormitories) dormTypeIdsList.Add(1); //adding the ids

            //dormitoriestype filter applied here
            var dormitoryAndtype = from dorm in dormitories.Where(c => dormTypeIdsList.Contains(c.DormitoryTypeId)).ToList()
                                   join dormType in dormitoryType.ToList() on dorm.DormitoryTypeId equals dormType.Id
                                   
                                   select new 
                                   { dorm.Id,
                                      
                                       DormitoryType = dormType.Title, //dormitory type table
                                       DormitoryName = dorm.DormitoryName,
                                       DormitoryIconUrl = dorm.DormitoryLogoUrl,
                                       DormitorySeoFriendlyUrl = _seoRepo.List().ToList().Where(c => c.Id == dorm.DormitorySeoId).FirstOrDefault().SearchEngineFriendlyPageName, //use seo table
                                       RatingNo = dorm.RatingNo.ToString("N1"),
                                       SortingRatingNo=dorm.RatingNo,

                                       RatingText = _reviewService.ResolveRatingText(dorm.RatingNo), //create a service that resolves this
                                       ReviewNo = _reviewRepo.List().Where(c => c.DormitoryId == dorm.Id).ToList().Count,
                                       Location = dorm.Location,
                                       ShortDescription =(dorm.DormitoryDescription.Length>=91) ? dorm.DormitoryDescription.Substring(0, 90) + "...": dorm.DormitoryDescription,
                                       ReservationPosibleWithoutCreditCard = false, //
                                       DormitoryStreetAddress = dorm.DormitoryStreetAddress,
                                      MapSection = _mapService.GetMapSectionById(dorm.MapSectionId),

                                       ClosestLandMark = _locationService.GetClosestLandmark(dorm.Id),
                                       ClosestLandMarkMapSection = _locationService.GetClosestLandmarkMapSection(dorm.Id)
                                       //  IsbookedInlast24hours = false //has to do with booking



                                   };
       


            var dormtypeListToList = dormitoryAndtype.ToList();
            var roomDormitory = from room in roomsDormitoryBlock.ToList()
                                join dorm in dormitoryAndtype.ToList() on room.DormitoryId equals dorm.Id

                             where room.PriceCash >= filters.PriceMin && room.PriceCash <= filters.PriceMax //room price and area filter applied here
                                   && room.RoomSize <= filters.RoomArea

                                select new RoomResultViewModel
                                {
                                    Features = (from roomFeature in _roomFeaturesRepo.List().ToList()
                                                join feature in features.ToList() on roomFeature.FeaturesId equals feature.Id
                                                where roomFeature.RoomId == room.Id && !string.IsNullOrEmpty(feature.IconUrl) 
                                                select new FeaturesViewModel
                                                {
                                                    FeatureName = feature.FeatureName,
                                                    IconUrl = feature.IconUrl
                                                }).Take(5).ToList(),
                                   FilteredFeatures=(from roomFeature in _roomFeaturesRepo.List().ToList()
                                                      join feature in features.ToList() on roomFeature.FeaturesId equals feature.Id
                                                      where roomFeature.RoomId == room.Id 
                                                      select new FeaturesViewModel
                                                      {FeatureId=feature.Id,
                                                          FeatureName = feature.FeatureName,
                                                          IconUrl = feature.IconUrl
                                                      }).ToList(),
                                    ImageUrls = _imageService.ImageSplitterList(Images.Where(d => d.RoomId == room.Id).Select(x => x.ImageUrl).ToList(), "_p6"),
                                    RoomId =room.Id,
                                    GenderAllocation = room.GenderAllocation,
                                    DormitoryName = dorm.DormitoryName,
                                    DormitoryRoomBlock = room.DormitoryBlockName,
                                    RatingNo = (dorm.ReviewNo<=0) ? _Localizer["N.A"]:dorm.RatingNo,
                                    RatingNoRaw = dorm.RatingNo,
                                    RatingText = (dorm.ReviewNo <= 0) ? _Localizer["Unrated"] : dorm.RatingText,
                                    DormitorySeoFriendlyUrl = dorm.DormitorySeoFriendlyUrl,
                                  
                                    RoomName = room.RoomName,
                                    ReviewNo = dorm.ReviewNo,
                                    SortingPrice=room.PriceCash,
                                    SortingRatingNO=dorm.SortingRatingNo,
                                    ShortDescription =dorm.ShortDescription,
                                    DormitoryStreetAddress = dorm.DormitoryStreetAddress,
                                    NumberOfRoomsLeft = room.NoRoomQuota,
                                    MapSection =  dorm.MapSection,
                                  ClosestLandMark = dorm.ClosestLandMark,
                                    Price =  _currencyService.CurrencyFormatterByRoomId(room.Id, room.PriceCash),
                                    OldPrice = (room.PriceOldCash>0 && room.PriceOldCash> room.PriceCash)
                                    ? _currencyService.CurrencyFormatterByRoomId(room.Id, room.PriceOldCash):null,


                                    PaymentPerSemesterNotYear = room.PaymentPerSemesterNotYear,
                                    ShowPrice= room.ShowPrice,
                                    //should come from promotions table
                                    PercentageOff = room.PercentageOff, //from database
                                    DealEndTime = room.DealEndTime, //change this to come from db
                                    DisplayNoRoomsLeft = room.DisplayNoRoomsLeft,
                                    DisplayDeal = (room.DealEndTime>DateTime.Now.AddDays(-2)),
                                };


            List<RoomResultViewModel> modelList;

            if (filters.sortId == 2)
            {//price
                modelList = roomDormitory.OrderBy(c => c.SortingPrice).ToList();
            }
            else if(filters.sortId == 3)
            {//rating
                modelList = roomDormitory.OrderBy(c => c.SortingRatingNO).ToList();
            }
            else
            {
                modelList = roomDormitory.OrderBy(c => c.DormitoryName).ToList();

                //a-z or anything else
            }


            var dummyModelList = new List<RoomResultViewModel>();


            if (filters.FeaturesIds != null)
            {


                foreach (var item in modelList)
                {
                    var filT = item.FilteredFeatures.Where(c => filters.FeaturesIds.Contains(c.FeatureId)).ToList();

                    if (filT != null && filT.Count > 0 && filters.FeaturesIds.Count == filT.Count)
                    {
                        dummyModelList.Add(item);
                    }

                }

            }
            else dummyModelList = modelList;
            return dummyModelList;
        }
    }


    public class RoomResultViewModel
    {public double SortingRatingNO { get; set; }
public double SortingPrice { get; set; }
        public long RoomId { get; set; }
        public List<string> ImageUrls { get; set; }
        public string GenderAllocation { get; set; }
        public string RoomName { get; set; }
        public string DormitoryName { get; set; }
        public string RatingNo { get; set; }
        public string DormitorySeoFriendlyUrl { get; set; }
        public string RatingText { get; set; }
        public int ReviewNo { get; set; }
        public bool ShowPrice { get; set; }
        public DateTime DealEndTime { get; set; }
        public bool DisplayDeal { get; set; }
        public int PercentageOff { get; set; }
        public bool DisplayNoRoomsLeft { get; set; }
        public List<FeaturesViewModel> Features { get; set; }
        public List<FeaturesViewModel> FilteredFeatures { get; set; }

        

        public string DormitoryRoomBlock { get; set; }
        public string ShortDescription { get; set; }

        public string DormitoryStreetAddress { get; set; }
        //Booked 3 times in the last 4 hours
        public int NumberOfRoomsLeft { get; set; }
      
        //mapSection in ergec campus map
        public string MapSection { get; set; }

        //(1.8 km from Central lecture hall
        public string ClosestLandMark { get; set; }

        //-Bus stop access
        public string UniqueAttribute { get; set; }
        public string Price { get; set; }
        public string OldPrice { get; set; }
        public bool PaymentPerSemesterNotYear { get; set; }
        public string RatingNoRaw { get; internal set; }
    }
    public class FeaturesViewModel
    {
        public long FeatureId { get; set; }
        public string IconUrl { get; set; }
        public string FeatureName { get; set; }
    }

    public class GetRoomResultViewModel
    {
        public string SectionId { get; set; }
        public List<long> FeaturesIds { get; set; }
        public int DormitoryTypeIds { get; set; }
        public List<long> DormitoryNameIds { get; set; }
        public double PriceMin { get; set; }
        public double PriceMax { get; set; }
        public double RoomArea { get; set; }
        public bool ShowAvailable { get; set; }
        public bool ShowDiscountsOnly { get; set; }
        public bool PrivateDormitories { get; set; }
        public bool SchoolDormitories { get; set; }
        public int sortId { get; set; }


           public bool RatingStar1 {get;set;}
           public bool RatingStar2 {get;set;}
           public bool RatingStar3 {get;set;}
           public bool RatingStar4 {get;set;}
           public bool RatingStar5 { get; set; }
           public bool RatingUnrated { get; set; }

        public bool CurrencyTl { get; set; }
        public bool CurrencyUsd { get; set; }
    }

}
