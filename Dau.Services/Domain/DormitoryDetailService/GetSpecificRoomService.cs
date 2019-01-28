using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Feature;
using Dau.Data.Repository;
using Dau.Services.Domain.CurrencyServices;
using Dau.Services.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.DormitoryDetailService
{
   public class GetSpecificRoomService : IGetSpecificRoomService
    {
        private readonly IRepository<DormitoryBlockTranslation> _dormitoryBlockTransRepo;
        private readonly IRepository<CatalogImage> _imagesRepo;
        private readonly IRepository<Room> _roomRepository;
        private readonly IRepository<RoomTranslation> _roomTranslationRepository;
        private readonly IRepository<RoomCatalogImage> _roomImageRepository;
        private readonly ILanguageService _languageService;
        private readonly IRepository<RoomFeatures> _roomFeaturesRepo;
        private readonly IRepository<Features> _featuresRepo;
        private readonly IRepository<FeaturesTranslation> _featuresTranslation;
        private readonly ICurrencyService _currencyService;

        public GetSpecificRoomService(
            IRepository<CatalogImage> imagesRepository,
                    IRepository<Room> RoomRepository,
                    IRepository<RoomTranslation> RoomTranslationRepository,
                    IRepository<RoomCatalogImage> RoomImageRepository,
    ILanguageService languageService,
                   IRepository<RoomFeatures> RoomFeaturesRepo,
            IRepository<Features> featuresRepo,
         
            IRepository<FeaturesTranslation> featuresTranslation,
            IRepository<DormitoryBlockTranslation> dormitoryBlockTransRepo,
              ICurrencyService currencyService


            )
        {

            _dormitoryBlockTransRepo = dormitoryBlockTransRepo;
            _imagesRepo = imagesRepository;
            _roomRepository = RoomRepository;
            _roomTranslationRepository=RoomTranslationRepository;
            _roomImageRepository=RoomImageRepository;

            _languageService = languageService;
            _roomFeaturesRepo = RoomFeaturesRepo;
            _featuresRepo = featuresRepo;
            _featuresTranslation = featuresTranslation;
            _currencyService = currencyService;
        }

        public SpecificRoomViewModel GetSpecificRoom(long RoomId)
        {

            //get room sliders seperately 
            //get room facilities seperately
            //get room informaiton //room table and translation then put everything together



            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

        


            /************ For getting Room Features *************************/
            var features = from feature in _featuresRepo.List().ToList()
                           join featureTrans in _featuresTranslation.List().ToList() on feature.Id equals featureTrans.FeaturesNonTransId
                           where featureTrans.LanguageId == CurrentLanguageId
                           select new { feature.Id, featureTrans.FeatureName, feature.IconUrl };


            var roomFeatures = from roomFeature in _roomFeaturesRepo.List().ToList()
                               join feature in features.ToList() on roomFeature.FeaturesId equals feature.Id
                               where roomFeature.RoomId == RoomId
                               select new FacilitiesSectionViewModel
                               {
                                   FacilityName = feature.FeatureName,
                                   IconUrl = feature.IconUrl
                               };
          
            List<FacilitiesSectionViewModel> modelList = roomFeatures.ToList();



            /************ For getting Room slider images *************************/
            var Images = from imageList in _imagesRepo.List().ToList()
                         join roomImage in _roomImageRepository.List().ToList() on imageList.Id equals roomImage.CatalogImageId
                         where roomImage.RoomId == RoomId
                         select new { imageList.ImageUrl };
            
            var flatList = Images.Select(x => x.ImageUrl).ToList();


            /************ For getting Room Infomation *************************/
            var rooms = from room in _roomRepository.List().ToList()
                        join roomTrans in _roomTranslationRepository.List().ToList() on room.Id equals roomTrans.RoomNonTransId
                        where roomTrans.LanguageId == CurrentLanguageId && room.Id == RoomId
                        select new SpecificRoomViewModel
                        {
                            Sliders = new SlidersSectionViewModel
                            {
                                ImageUrls = flatList

                            },

                            RoomId = room.Id,
                            Facilities = roomFeatures.ToList(),
                            RoomName = roomTrans.RoomName,
                            DormitoryBlock = _dormitoryBlockTransRepo.List().Where(_ => _.LanguageId == CurrentLanguageId && _.DormitoryBlockNonTransId == room.DormitoryBlockId).FirstOrDefault().Name,
                            GenderAllocation = roomTrans.GenderAllocation,
                            NoOfStudents = room.NoOfStudents,
                            BedType = roomTrans.BedType,
                            PriceCash = _currencyService.CurrencyFormatterByRoomId(room.Id,room.PriceCash),
                            MinBookingAmount = _currencyService.CurrencyFormatterByRoomId(room.Id,  room.MinBookingFee),
                            PaymentPerSemesterNotYear = room.PaymentPerSemesterNotYear,
                            PriceInstallment = _currencyService.CurrencyFormatterByRoomId(room.Id, room.PriceInstallment),
                            OldPriceCash = (room.PriceOldCash > 0 && room.PriceOldCash > room.PriceCash) ? _currencyService.CurrencyFormatterByRoomId(room.Id, room.PriceOldCash) : null,
                            NoRoomQuota = room.NoRoomQuota,
                            HasDeposit = room.HasDeposit,
                            ShowPrice = room.ShowPrice,
                        };


            SpecificRoomViewModel model = rooms.FirstOrDefault();

            return model;
        }
    }

    public class SpecificRoomViewModel
    {public long RoomId { get; set; }
        public SlidersSectionViewModel Sliders { get; set; }
        public List<FacilitiesSectionViewModel> Facilities { get; set; }
        public string RoomName { get; set; }
        public string DormitoryBlock { get; set; }
        public string GenderAllocation { get; set; }
        public string DormitoryName { get; set; }
        public string BedType { get; set; }
        public int NoOfStudents { get; set; }
        public string PriceCash { get; set; }
        public string PriceInstallment { get; set; }

        public bool PaymentPerSemesterNotYear { get; set; }
        public string OldPriceCash { get; set; }
        public string MinBookingAmount { get; set; }
        public bool HasDeposit { get; set; }
        public int NoRoomQuota { get; set; }
        public bool ShowPrice { get; set; }
    }
}
