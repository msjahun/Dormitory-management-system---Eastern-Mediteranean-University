using Dau.Core.Domain.Bookings;
using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Feature;
using Dau.Core.Domain.SearchEngineOptimization;
using Dau.Data.Repository;
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
        private readonly ILanguageService _languageService;
        private readonly IRepository<DormitoryBlock> _dormitoryBlockRepo;
        private readonly IRepository<DormitoryBlockTranslation> _dormitoryBlockTransRepo;
        private readonly IRepository<DormitoryTypeTranslation> _dormitoryTypeTranslationRepo;
        private readonly IRepository<CatalogImage> _imagesRepo;

        public IRepository<RoomCatalogImage> _roomImageRepo { get; }

        private readonly IRepository<DormitoryCatalogImage> _dormitoryImageRepo;
        private readonly IRepository<Review> _reviewRepo;
        private readonly IRepository<Locationinformation> _locationRepo;
        private readonly IRepository<RoomFeatures> _roomFeaturesRepo;
        private readonly IRepository<Features> _featuresRepo;
        private readonly IRepository<FeaturesTranslation> _featuresTranslation;

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

            IRepository<FeaturesTranslation> featuresTranslation

            )
        {
            _seoRepo = seoRepository;

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
            _roomImageRepo = RoomImageRepository;
            _reviewRepo = reviewRepository;
            _locationRepo = locationRepository;
            _roomFeaturesRepo = RoomFeaturesRepo;
            _featuresRepo = featuresRepo;
            _featuresTranslation = featuresTranslation;
        }

        public List<RoomResultViewModel> GetRoomResult()
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
                            room.Price, room.PriceOld, room.ShowPrice, room.RoomsQuota, room.RoomSize,
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
                                          room.RoomsQuota,
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

    

            var dormitories = from dorm in _dormitoryRepository.List().ToList()
                              join dormTrans in _dormitoryTranslationRepository.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                              where dormTrans.LanguageId == CurrentLanguageId
                              select new
                              {
                                  dorm.Id,
                                  DormitorySeoId = dorm.SeoId,
                                  dormTrans.DormitoryName,
                                  dorm.DormitoryLogoUrl,
                                  dorm.DormitoryTypeId,
                                  dorm.RatingNo,
                                  dorm.ReviewNo,
                                  dorm.Location,
                                  dormTrans.DormitoryDescription,
                                  dorm.DormitoryStreetAddress,
                                  dorm.MapSection,
                                  dormTrans.StandAloneOption
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
                                       ShortDescription = dorm.DormitoryDescription.Substring(0, 90) + "...",
                                       ReservationPosibleWithoutCreditCard = false, //
                                       DormitoryStreetAddress = dorm.DormitoryStreetAddress,
                                       MapSection = "https://www.emu.edu.tr/campusmap?design=empty#" + dorm.MapSection,
                                       ClosestLandMark = String.Format("({0} to {1})", _locationRepo.List().ToList().Where(d => d.DormitoryId == dorm.Id).FirstOrDefault().Duration, _locationRepo.List().ToList().Where(d => d.DormitoryId == dorm.Id).FirstOrDefault().NameOfLocation), // I can put locations here
                                       ClosestLandMarkMapSection = "https://www.emu.edu.tr/campusmap?design=empty#" + _locationRepo.List().ToList().Where(d => d.DormitoryId == dorm.Id).FirstOrDefault().MapSection,
                                       UniqueAttribute = dorm.StandAloneOption, //use bus stop coordinate to determine time to get to bus stop and distance
                                                                                //  IsbookedInlast24hours = false //has to do with booking



                                   };


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
            ImageUrls = Images.Where(d => d.RoomId == room.Id).Select(x => x.ImageUrl).ToList(),
                                    RoomId =room.Id,
                                    GenderAllocation = room.GenderAllocation.Substring(0, 12)+"...",
                                    DormitoryName = dorm.DormitoryName,
                                    DormitoryRoomBlock = room.DormitoryBlockName,
                                    RatingNo = dorm.RatingNo,
                                    DormitorySeoFriendlyUrl = dorm.DormitorySeoFriendlyUrl,
                                    RatingText = "Fantastic",
                                    RoomName = room.RoomName,
                                    ReviewNo = dorm.ReviewNo,
                                    ShortDescription =dorm.ShortDescription,
                                    DormitoryStreetAddress = dorm.DormitoryStreetAddress,
                                    NumberOfRoomsLeft = room.RoomsQuota,
                                    MapSection = "https://www.emu.edu.tr/campusmap?design=empty" + dorm.MapSection,
                                    ClosestLandMark = dorm.ClosestLandMark,
                                    UniqueAttribute = dorm.UniqueAttribute,
                                    Price = room.Price.ToString("N2"),
                                    OldPrice = (room.PriceOld>0)?room.PriceOld.ToString("N2"):null,
                                    PaymentPerSemesterNotYear = room.PaymentPerSemesterNotYear,

                                    //should come from promotions table
                                    PercentageOff = room.PercentageOff, //from database
                                    DealEndTime = room.DealEndTime, //change this to come from db
                                    DisplayNoRoomsLeft = room.DisplayNoRoomsLeft,
                                    DisplayDeal = (room.DealEndTime>DateTime.Now.AddDays(1)),
                                };


            List<RoomResultViewModel> modelList = roomDormitory.ToList();
                
                
            //    new List<RoomResultViewModel>
            //{
            //    new RoomResultViewModel
            //{
            //    ImageUrls = new List<string>
            //    {
            //              "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/_DSC8319.jpg?RenditionID=6",

            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%205.jpg?RenditionID=6"

            //    },
            //    Features = new List<FeaturesViewModel>
            //    {
            //        new FeaturesViewModel{ 
            //           FeatureName="Desk lamp"
            //},
            //      new FeaturesViewModel
            //{
            //    IconUrl="/dusk/png/facilities/icons8-widescreen-64.png",
            //    FeatureName="TV"
            //},
            //       new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-shower-50.png",
            //    FeatureName="WC-shower"
            //},
            //        new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-fridge-64.png",
            //    FeatureName="Refrigerator"
            //},
            //        new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-office-phone-64.png",
            //    FeatureName="Room tel."
            //},
            //        new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-compressor-64.png",
            //    FeatureName="Generator"
            //}
            //    },
            //     RoomId=235,
            //    GenderAllocation = "Boys only",
            //    DormitoryName = "Akdeniz Dormitory",
            //    DormitoryRoomBlock = "A Block",
            //    RatingNo = 4.6,
            //      DormitorySeoFriendlyUrl = "Akdeniz-Dormitory",
            //    RatingText = "Fantastic",
            //            RoomName ="Double Room",
            //    ReviewNo = 19,
            //    DealEndTime = DateTime.Now.AddDays(3),
            //    ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
            //    DormitoryStreetAddress = "Albert-Einstein, Street",
            //    NumberOfRoomsLeft = 55,
            //    DisplayNoRoomsLeft=true,
            //    PercentageOff = 20,
            //    DisplayDeal=true,
            //    MapSection = "https://www.emu.edu.tr/campusmap?design=empty" + "#b64",
            //    ClosestLandMark = "(2 min to Health center and CMPE dept.)",
            //    UniqueAttribute = "Bus stop access",
            //   Price="1,839.00",
            //   PaymentPerSemesterNotYear = true


            //},
            //    new RoomResultViewModel
            //{
            //    ImageUrls = new List<string>
            //    {
            //           "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2016/ugursal/img_1198.jpg?RenditionID=6",

            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",

            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%2011.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%205.jpg?RenditionID=6"

            //    },

            //             Features = new List<FeaturesViewModel>
            //    {
            //        new FeaturesViewModel{
            //           FeatureName="Desk lamp"
            //},
            //      new FeaturesViewModel
            //{
            //    IconUrl="/dusk/png/facilities/icons8-widescreen-64.png",
            //    FeatureName="TV"
            //},
            //       new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-shower-50.png",
            //    FeatureName="WC-shower"
            //},
            //        new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-fridge-64.png",
            //    FeatureName="Refrigerator"
            //},
            //        new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-office-phone-64.png",
            //    FeatureName="Room tel."
            //},
            //        new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-compressor-64.png",
            //    FeatureName="Generator"
            //}
            //    },
            //     RoomId=2454,
            //    GenderAllocation = "Boys and girls",
            //    DormitoryName = "Novel Dormitory",
            //      DormitoryRoomBlock = "A Block",
            //    RatingNo = 4.6,
            //      DormitorySeoFriendlyUrl = "Novel-Dormitory",
            //            RoomName ="Quadruple Room",
            //    RatingText = "Fantastic",
            //    ReviewNo = 19,
            //    DealEndTime = DateTime.Now.AddDays(3),
            //    ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
            //    DormitoryStreetAddress = "Albert-Einstein, Street",
            //    NumberOfRoomsLeft = 55,
            //    DisplayNoRoomsLeft=false,
            //    PercentageOff = 20,
            //    DisplayDeal=false,
            //    MapSection = "https://www.emu.edu.tr/campusmap?design=empty" + "#b64",
            //    ClosestLandMark = "(2 min to Health center and CMPE dept.)",
            //    UniqueAttribute = "Bus stop access",
            //       Price="1,839.00",
            //        PaymentPerSemesterNotYear = false


            //},
            //    new RoomResultViewModel
            //{
            //    ImageUrls = new List<string>
            //    {   "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",

            //        "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%2011.jpg?RenditionID=6", "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",

            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",
            //        "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%2011.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%205.jpg?RenditionID=6"

            //    },
            //             Features = new List<FeaturesViewModel>
            //    {
            //        new FeaturesViewModel{
            //           FeatureName="Desk lamp"
            //},
            //      new FeaturesViewModel
            //{
            //    IconUrl="/dusk/png/facilities/icons8-widescreen-64.png",
            //    FeatureName="TV"
            //},
            //       new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-shower-50.png",
            //    FeatureName="WC-shower"
            //},
            //        new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-fridge-64.png",
            //    FeatureName="Refrigerator"
            //},
            //        new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-office-phone-64.png",
            //    FeatureName="Room tel."
            //},
            //        new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-compressor-64.png",
            //    FeatureName="Generator"
            //}
            //    },
            //     RoomId=454,
            //    GenderAllocation = "Boys & Girls only",
            //    DormitoryName = "Alfam Dormitory",
            //    RoomName ="Single Room",
            //      DormitoryRoomBlock = "Studio block",
            //    RatingNo = 9.2,
            //    RatingText = "Excellent",
            //      DormitorySeoFriendlyUrl = "Alfam-dormitory",
            //    ReviewNo = 19,
            //    DealEndTime = DateTime.Now.AddDays(3),
            //    ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
            //    DormitoryStreetAddress = "Albert-Einstein, Street",
            //    NumberOfRoomsLeft = 55,
            //    DisplayNoRoomsLeft=false,
            //    PercentageOff = 20,
            //    DisplayDeal=false,
            //    MapSection = "https://www.emu.edu.tr/campusmap?design=empty" + "#b64",
            //    ClosestLandMark = "(2 min to Health center and CMPE dept.)",
            //    UniqueAttribute = "Bus stop access",
            //    Price="1,839.00",
            //     PaymentPerSemesterNotYear = true


            //},
            //     new RoomResultViewModel
            //{
            //    ImageUrls = new List<string>
            //    {
            //              "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/_DSC8319.jpg?RenditionID=6",

            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%205.jpg?RenditionID=6"

            //    },
                      
            //     RoomId=344,
            //    GenderAllocation = "Boys only",
            //    DormitoryName = "Akdeniz Dormitory",
            //    DormitoryRoomBlock = "A Block",
            //    RatingNo = 4.6,
            //    RatingText = "Fantastic",
            //            RoomName ="Double Room",
            //    ReviewNo = 19,
            //    DealEndTime = DateTime.Now.AddDays(3),
            //    ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
            //    DormitoryStreetAddress = "Albert-Einstein, Street",
            //    NumberOfRoomsLeft = 3,
            //      DormitorySeoFriendlyUrl = "Akdeniz-Dormitory",
            //    DisplayNoRoomsLeft=true,
            //    PercentageOff = 20,
            //    DisplayDeal=true,
            //    MapSection = "https://www.emu.edu.tr/campusmap?design=empty" + "#b64",
            //    ClosestLandMark = "(2 min to Health center and CMPE dept.)",
            //    UniqueAttribute = "Bus stop access",
            //   Price="1,839.00",
            //    OldPrice="2,000.99"

            //},
            //    new RoomResultViewModel
            //{
            //    ImageUrls = new List<string>
            //    {
            //           "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2016/ugursal/img_1198.jpg?RenditionID=6",

            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",

            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%2011.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%205.jpg?RenditionID=6"

            //    },

            //             Features = new List<FeaturesViewModel>
            //    {
            //        new FeaturesViewModel{
            //           FeatureName="Desk lamp"
            //},
            //      new FeaturesViewModel
            //{
            //    IconUrl="/dusk/png/facilities/icons8-widescreen-64.png",
            //    FeatureName="TV"
            //},
            //       new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-shower-50.png",
            //    FeatureName="WC-shower"
            //},
            //        new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-fridge-64.png",
            //    FeatureName="Refrigerator"
            //},
            //        new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-office-phone-64.png",
            //    FeatureName="Room tel."
            //},
            //        new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-compressor-64.png",
            //    FeatureName="Generator"
            //}
            //    },
            //     RoomId=264,
            //    GenderAllocation = "Boys and girls",
            //    DormitoryName = "Novel Dormitory",
            //      DormitoryRoomBlock = "A Block",
            //    RatingNo = 4.6,
            //            RoomName ="Quadruple Room",
            //    RatingText = "Fantastic",
            //    ReviewNo = 19,
            //    DealEndTime = DateTime.Now.AddDays(3),
            //    ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
            //    DormitoryStreetAddress = "Albert-Einstein, Street",
            //    NumberOfRoomsLeft = 55,
            //    DisplayNoRoomsLeft=true,
            //      DormitorySeoFriendlyUrl = "Novel-Dormitory",
            //    PercentageOff = 20,
            //    DisplayDeal=false,
            //    MapSection = "https://www.emu.edu.tr/campusmap?design=empty" + "#b64",
            //    ClosestLandMark = "(2 min to Health center and CMPE dept.)",
            //    UniqueAttribute = "Bus stop access",
            //       Price="1,839.00",
            //    OldPrice="2,000.99",
            //     PaymentPerSemesterNotYear = true

            //},
            //    new RoomResultViewModel
            //{
            //    ImageUrls = new List<string>
            //    {   "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",

            //        "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%2011.jpg?RenditionID=6", "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",

            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",
            //        "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%2011.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%205.jpg?RenditionID=6"

            //    },
            //             Features = new List<FeaturesViewModel>
            //    {
            //        new FeaturesViewModel{
            //           FeatureName="Desk lamp"
            //},
            //      new FeaturesViewModel
            //{
            //    IconUrl="/dusk/png/facilities/icons8-widescreen-64.png",
            //    FeatureName="TV"
            //},
            //       new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-shower-50.png",
            //    FeatureName="WC-shower"
            //},
            //        new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-fridge-64.png",
            //    FeatureName="Refrigerator"
            //},
            //        new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-office-phone-64.png",
            //    FeatureName="Room tel."
            //},
            //        new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-compressor-64.png",
            //    FeatureName="Generator"
            //}
            //    },
            //     RoomId=253,
            //    GenderAllocation = "Boys & Girls only",
            //    DormitoryName = "Alfam Dormitory",
            //    RoomName ="Single Room",
            //      DormitoryRoomBlock = "Studio block",
            //    RatingNo = 9.2,
            //    RatingText = "Excellent",
            //    ReviewNo = 19,
            //      DormitorySeoFriendlyUrl = "Alfam-dormitory",
            //    DealEndTime = DateTime.Now.AddDays(-3),
            //    ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
            //    DormitoryStreetAddress = "Albert-Einstein, Street",
            //    NumberOfRoomsLeft = 5,
            //    DisplayNoRoomsLeft=true,
            //    PercentageOff = 20,
            //    DisplayDeal=true,
            //    MapSection = "https://www.emu.edu.tr/campusmap?design=empty" + "#b64",
            //    ClosestLandMark = "(2 min to Health center and CMPE dept.)",
            //    UniqueAttribute = "Bus stop access",
            //    Price="1,839.00",
            //    OldPrice="2,000.99"
            //    , PaymentPerSemesterNotYear = false

            //},
            //     new RoomResultViewModel
            //{
            //    ImageUrls = new List<string>
            //    {
            //              "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/_DSC8319.jpg?RenditionID=6",

            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%205.jpg?RenditionID=6"

            //    },
            //             Features = new List<FeaturesViewModel>
            //    {
            //        new FeaturesViewModel{
            //           FeatureName="Desk lamp"
            //},
            //      new FeaturesViewModel
            //{
            //    IconUrl="/dusk/png/facilities/icons8-widescreen-64.png",
            //    FeatureName="TV"
            //},
            //       new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-shower-50.png",
            //    FeatureName="WC-shower"
            //},
            //        new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-fridge-64.png",
            //    FeatureName="Refrigerator"
            //},
            //        new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-office-phone-64.png",
            //    FeatureName="Room tel."
            //},
            //        new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-compressor-64.png",
            //    FeatureName="Generator"
            //}
            //    },
            //     RoomId=34,
            //    GenderAllocation = "Boys only",
            //    DormitoryName = "Akdeniz Dormitory",
            //    DormitoryRoomBlock = "A Block",
            //    RatingNo = 4.6,
            //    RatingText = "Fantastic",
            //            RoomName ="Double Room",
            //    ReviewNo = 19,
            //      DormitorySeoFriendlyUrl = "Akdeniz-Dormitory",
            //    DealEndTime = DateTime.Now.AddDays(3),
            //    ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
            //    DormitoryStreetAddress = "Albert-Einstein, Street",
            //    NumberOfRoomsLeft = 55,
            //    DisplayNoRoomsLeft=true,
            //    PercentageOff = 20,
            //    DisplayDeal=true,
            //    MapSection = "https://www.emu.edu.tr/campusmap?design=empty" + "#b64",
            //    ClosestLandMark = "(2 min to Health center and CMPE dept.)",
            //    UniqueAttribute = "Bus stop access",
            //   Price="1,839.00",
            //    OldPrice="2,000.99",
            //     PaymentPerSemesterNotYear = true

            //},
            //    new RoomResultViewModel
            //{
            //    ImageUrls = new List<string>
            //    {
            //           "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2016/ugursal/img_1198.jpg?RenditionID=6",

            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",

            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%2011.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%205.jpg?RenditionID=6"

            //    },
            //             Features = new List<FeaturesViewModel>
            //    {
            //        new FeaturesViewModel{
            //           FeatureName="Desk lamp"
            //},
            //      new FeaturesViewModel
            //{
            //    IconUrl="/dusk/png/facilities/icons8-widescreen-64.png",
            //    FeatureName="TV"
            //},
            //       new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-shower-50.png",
            //    FeatureName="WC-shower"
            //},
            //        new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-fridge-64.png",
            //    FeatureName="Refrigerator"
            //},
            //        new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-office-phone-64.png",
            //    FeatureName="Room tel."
            //},
            //        new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-compressor-64.png",
            //    FeatureName="Generator"
            //}
            //    },
            //     RoomId=264,
            //    GenderAllocation = "Boys and girls",
            //    DormitoryName = "Novel Dormitory",
            //      DormitoryRoomBlock = "A Block",
            //    RatingNo = 4.6,
            //            RoomName ="Quadruple Room",
            //    RatingText = "Fantastic",
            //    ReviewNo = 19,
            //      DormitorySeoFriendlyUrl = "Novel-Dormitory",
            //    DealEndTime = DateTime.Now.AddDays(3),
            //    ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
            //    DormitoryStreetAddress = "Albert-Einstein, Street",
            //    NumberOfRoomsLeft = 55,
            //    DisplayNoRoomsLeft=true,
            //    PercentageOff = 20,
            //    DisplayDeal=false,
            //    MapSection = "https://www.emu.edu.tr/campusmap?design=empty" + "#b64",
            //    ClosestLandMark = "(2 min to Health center and CMPE dept.)",
            //    UniqueAttribute = "Bus stop access",
            //       Price="1,839.00",
            //    OldPrice="2,000.99",
            //     PaymentPerSemesterNotYear = false

            //},
            //    new RoomResultViewModel
            //{
            //    ImageUrls = new List<string>
            //    {   "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",

            //        "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%2011.jpg?RenditionID=6", "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",

            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=6",
            //        "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%2011.jpg?RenditionID=6",
            //        "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/novel/Double%20suit%205.jpg?RenditionID=6"

            //    },
            //             Features = new List<FeaturesViewModel>
            //    {
            //        new FeaturesViewModel{
            //           FeatureName="Desk lamp"
            //},
            //      new FeaturesViewModel
            //{
            //    IconUrl="/dusk/png/facilities/icons8-widescreen-64.png",
            //    FeatureName="TV"
            //},
            //       new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-shower-50.png",
            //    FeatureName="WC-shower"
            //},
            //        new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-fridge-64.png",
            //    FeatureName="Refrigerator"
            //},
            //        new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-office-phone-64.png",
            //    FeatureName="Room tel."
            //},
            //        new FeaturesViewModel
            //{
            //     IconUrl="/dusk/png/facilities/icons8-compressor-64.png",
            //    FeatureName="Generator"
            //}
            //    },
            //     RoomId=234,
            //    GenderAllocation = "Boys & Girls only",
            //    DormitoryName = "Alfam Dormitory",
            //    RoomName ="Single Room",
            //      DormitoryRoomBlock = "Studio block",
            //    RatingNo = 9.2,
            //    RatingText = "Excellent",
            //    ReviewNo = 19,
            //      DormitorySeoFriendlyUrl = "Alfam-dormitory",
            //    DealEndTime = DateTime.Now.AddDays(3),
            //    ShortDescription = "Has multi-cultural students, Akdeniz studio is located inside school, not far from Ekor Market...",
            //    DormitoryStreetAddress = "Albert-Einstein, Street",
            //    NumberOfRoomsLeft = 2,
            //    DisplayNoRoomsLeft=true,
            //    PercentageOff = 20,
            //    DisplayDeal=false,
            //    MapSection = "https://www.emu.edu.tr/campusmap?design=empty" + "#b64",
            //    ClosestLandMark = "(2 min to Health center and CMPE dept.)",
            //    UniqueAttribute = "Bus stop access",
            //    Price="1,839.00",
            //     PaymentPerSemesterNotYear = true


            //}
            //};
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

}
