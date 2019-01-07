using Dau.Core.Domain.Bookings;
using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Feature;
using Dau.Core.Domain.SearchEngineOptimization;
using Dau.Data.Repository;
using Dau.Services.Domain.DropdownServices;
using Dau.Services.Domain.ImageServices;
using Dau.Services.Domain.MapServices;
using Dau.Services.Languages;
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

            IRepository<FeaturesTranslation> featuresTranslation

            )
        {
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



            var rooms = from room in _roomRepository.List().ToList()
                        join roomTrans in _roomTransRepository.List().ToList() on room.Id equals roomTrans.RoomNonTransId
                        where roomTrans.LanguageId == CurrentLanguageId
                        select new { room.Id, room.DormitoryId, room.DormitoryBlockId, roomTrans.RoomName,
                            room.Price, room.PriceOld, room.ShowPrice, room.NoRoomQuota, room.RoomSize,
                            roomTrans.GenderAllocation, room.PaymentPerSemesterNotYear,
                            room.PercentageOff,
                            room.DealEndTime,
                            room.DisplayNoRoomsLeft,
                            room.DisplayDeal
                        };

            var features = from feature in _featuresRepo.List().ToList()
                           join featureTrans in _featuresTranslation.List().ToList() on feature.Id equals featureTrans.FeaturesNonTransId
                           where featureTrans.LanguageId == CurrentLanguageId
                           select new { feature.Id, featureTrans.FeatureName, feature.IconUrl };


            //var roomFeatures = (from roomFeature in _roomFeaturesRepo.List().ToList()
            //                    join feature in features.ToList() on roomFeature.FeaturesId equals feature.Id
            //                    where roomFeature.RoomId == 1
            //                    select new FeaturesViewModel
            //                    {
            //                        FeatureName = feature.FeatureName,
            //                        IconUrl = feature.IconUrl
            //                    }).ToList();
            var roomsDormitoryBlock = from room in rooms.ToList()
                                      join dormBlock in dormitoryBlock.ToList() on room.DormitoryBlockId equals dormBlock.Id
                                      select new
                                      {
                                          DormitoryBlockPublished = dormBlock.Published,
                                          DormitoryBlockName = dormBlock.Name,
                                          room.Id,
                                          room.DormitoryId,
                                          room.DormitoryBlockId,
                                          room.RoomName,
                                          room.Price,
                                          room.PriceOld,
                                          room.ShowPrice,
                                          room.NoRoomQuota,
                                          room.RoomSize,
                                          room.GenderAllocation,
                                          room.PaymentPerSemesterNotYear,
                                          room.PercentageOff,
                                          room.DealEndTime,
                                          room.DisplayNoRoomsLeft,
                                          room.DisplayDeal
                                      };

  




           var Images = from imageList in _imagesRepo.List().Distinct().ToList()
                         join roomImage in _roomImageRepo.List().ToList() on imageList.Id equals roomImage.CatalogImageId
                        select new { imageList.ImageUrl, roomImage.RoomId};


            var LocationsOnCampus = _dropdownService.LocationOnCampus();
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
                                  dorm.ReviewNo,
                                  Location = _dropdownService.ResolveDropdown(dorm.LocationOnCampus, LocationsOnCampus),
                                  dormTrans.DormitoryDescription,
                                  dorm.DormitoryStreetAddress,
                                 dorm.MapSectionId,
                                
                              };

            var dormitoryType = from dormType in _dormitoryTypeRepo.List().ToList()
                                join dormTypeTrans in _dormitoryTypeTranslationRepo.List().ToList() on dormType.Id equals dormTypeTrans.DormitoryTypeNonTransId
                                where dormTypeTrans.LanguageId == CurrentLanguageId
                                select new { dormType.Id, dormTypeTrans.Title };

            var dormitoryAndtype = from dorm in dormitories.ToList()
                                   join dormType in dormitoryType.ToList() on dorm.DormitoryTypeId equals dormType.Id
                                   select new 
                                   { dorm.Id,
                                      
                                       DormitoryType = dormType.Title, //dormitory type table
                                       DormitoryName = dorm.DormitoryName,
                                       DormitoryIconUrl = dorm.DormitoryLogoUrl,
                                       DormitorySeoFriendlyUrl = _seoRepo.List().ToList().Where(c => c.Id == dorm.DormitorySeoId).FirstOrDefault().SearchEngineFriendlyPageName, //use seo table
                                       RatingNo = dorm.RatingNo.ToString("N1"),
                                       RatingText = "Fantastic", //create a service that resolves this
                                       ReviewNo = _reviewRepo.List().Where(c => c.DormitoryId == dorm.Id).ToList().Count,
                                       Location = dorm.Location,
                                       ShortDescription =(dorm.DormitoryDescription.Length>=91) ? dorm.DormitoryDescription.Substring(0, 90) + "...": dorm.DormitoryDescription,
                                       ReservationPosibleWithoutCreditCard = false, //
                                       DormitoryStreetAddress = dorm.DormitoryStreetAddress,
                                      MapSection = _mapService.GetMapSectionById(dorm.MapSectionId),
                                       ClosestLandMark =(_locationRepo.List().ToList().Where(d => d.DormitoryId == dorm.Id).FirstOrDefault() != null && _locationRepo.List().ToList().Where(d => d.DormitoryId == dorm.Id).FirstOrDefault().Duration!=null&& _locationRepo.List().ToList().Where(d => d.DormitoryId == dorm.Id).FirstOrDefault().NameOfLocation!=null)?
                                       String.Format("({0} to {1})", _locationRepo.List().ToList().Where(d => d.DormitoryId == dorm.Id).FirstOrDefault().Duration, _locationRepo.List().ToList().Where(d => d.DormitoryId == dorm.Id).FirstOrDefault().NameOfLocation):"", // I can put locations here
                                       ClosestLandMarkMapSection =(_locationRepo.List().ToList().Where(d => d.DormitoryId == dorm.Id).FirstOrDefault()!= null && _locationRepo.List().ToList().Where(d => d.DormitoryId == dorm.Id).FirstOrDefault().MapSection!=null) ?
                                       "https://www.emu.edu.tr/campusmap?design=empty#" + _locationRepo.List().ToList().Where(d => d.DormitoryId == dorm.Id).FirstOrDefault().MapSection:"",
                                                                            //  IsbookedInlast24hours = false //has to do with booking



                                   };

            var dormtypeListToList = dormitoryAndtype.ToList();
            var roomDormitory = from room in roomsDormitoryBlock.ToList()
                                join dorm in dormitoryAndtype.ToList() on room.DormitoryId equals dorm.Id
                                select  new RoomResultViewModel
                                {
                                    Features = (from roomFeature in _roomFeaturesRepo.List().ToList()
                                                join feature in features.ToList() on roomFeature.FeaturesId equals feature.Id
                                                where roomFeature.RoomId == room.Id && feature.IconUrl!=null
                                                select new FeaturesViewModel
                                                {
                                                    FeatureName = feature.FeatureName,
                                                    IconUrl = feature.IconUrl
                                                }).Take(5).ToList(),
            ImageUrls = _imageService.ImageSplitterList(Images.Where(d => d.RoomId == room.Id).Select(x => x.ImageUrl).ToList(), "_p6"),
                                    RoomId =room.Id,
                                    GenderAllocation = (room.GenderAllocation.Length>12) ?room.GenderAllocation.Substring(0, 12)+"...": room.GenderAllocation,
                                    DormitoryName = dorm.DormitoryName,
                                    DormitoryRoomBlock = room.DormitoryBlockName,
                                    RatingNo = dorm.RatingNo,
                                    DormitorySeoFriendlyUrl = dorm.DormitorySeoFriendlyUrl,
                                    RatingText = "Fantastic",
                                    RoomName = room.RoomName,
                                    ReviewNo = dorm.ReviewNo,
                                    ShortDescription =dorm.ShortDescription,
                                    DormitoryStreetAddress = dorm.DormitoryStreetAddress,
                                    NumberOfRoomsLeft = room.NoRoomQuota,
                                    MapSection =  dorm.MapSection,
                                    ClosestLandMark = dorm.ClosestLandMark,
                                    Price = room.Price.ToString("N2"),
                                    OldPrice = (room.PriceOld>0)?room.PriceOld.ToString("N2"):null,
                                    PaymentPerSemesterNotYear = room.PaymentPerSemesterNotYear,
                                    ShowPrice= room.ShowPrice,
                                    //should come from promotions table
                                    PercentageOff = room.PercentageOff, //from database
                                    DealEndTime = room.DealEndTime, //change this to come from db
                                    DisplayNoRoomsLeft = room.DisplayNoRoomsLeft,
                                    DisplayDeal = (room.DealEndTime>DateTime.Now.AddDays(-2)),
                                };


            List<RoomResultViewModel> modelList = roomDormitory.ToList();
                
                
        
            return modelList;
        }
    }


    public class RoomResultViewModel
    {
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



    }
    public class FeaturesViewModel
    {
        public string IconUrl { get; set; }
        public string FeatureName { get; set; }
    }

    public class GetRoomResultViewModel
    {
        public string SectionId { get; set; }
        public List<int> FeaturesIds { get; set; }
        public int DormitoryTypeIds { get; set; }
        public List<int> DormitoryNameIds { get; set; }
        public double PriceMin { get; set; }
        public double PriceMax { get; set; }
        public double RoomArea { get; set; }
        public bool ShowAvailable { get; set; }
        public bool ShowDiscountsOnly { get; set; }
    }

}
