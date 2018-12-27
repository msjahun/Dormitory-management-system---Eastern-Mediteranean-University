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
    public class DormitoryResultService : IDormitoryResultService
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
                    IRepository<Locationinformation> locationRepository

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
                              where dormTrans.LanguageId == CurrentLanguageId
                              select new { dorm.Id, DormitorySeoId = dorm.SeoId,
                                  dormTrans.DormitoryName, dorm.DormitoryLogoUrl,
                                  dorm.DormitoryTypeId, dorm.RatingNo, dorm.ReviewNo,
                                  dorm.Location, dormTrans.DormitoryDescription,
                              dorm.DormitoryStreetAddress, dorm.MapSection, dormTrans.StandAloneOption};

            var dormitoryType = from dormType in _dormitoryTypeRepo.List().ToList()
                                join dormTypeTrans in _dormitoryTypeTranslationRepo.List().ToList() on dormType.Id equals dormTypeTrans.DormitoryTypeNonTransId
                                where dormTypeTrans.LanguageId == CurrentLanguageId
                                select new { dormType.Id, dormTypeTrans.Title };

           var dormitoryAndtype = from dorm in dormitories.ToList()
                                  join dormType in dormitoryType.ToList() on dorm.DormitoryTypeId equals dormType.Id
                                  select new DormitoryResultViewModel
                            {
                                ImageUrls = Images.Where(d => d.DormitoryId == dorm.Id).Select(x => x.ImageUrl).ToList(),
                                DormitoryType = dormType.Title, //dormitory type table
                                DormitoryName = dorm.DormitoryName,
                                DormitoryIconUrl = dorm.DormitoryLogoUrl,
                                DormitorySeoFriendlyUrl = _seoRepo.List().ToList().Where(c=> c.Id== dorm.DormitorySeoId).FirstOrDefault().SearchEngineFriendlyPageName, //use seo table
                                      RatingNo = dorm.RatingNo.ToString("N1"),
                                RatingText = "Fantastic", //create a service that resolves this
                                ReviewNo = _reviewRepo.List().Where(c=> c.DormitoryId ==dorm.Id).ToList().Count,
                                Location = dorm.Location,
                                ShortDescription = dorm.DormitoryDescription.Substring(0, 90)+"...",
                                ReservationPosibleWithoutCreditCard = false, //
                                DormitoryStreetAddress = dorm.DormitoryStreetAddress,
                                MapSection = "https://www.emu.edu.tr/campusmap?design=empty#" + dorm.MapSection,
                                ClosestLandMark = String.Format("({0} to {1})", _locationRepo.List().ToList().Where(d=> d.DormitoryId == dorm.Id).FirstOrDefault().Duration, _locationRepo.List().ToList().Where(d => d.DormitoryId == dorm.Id).FirstOrDefault().NameOfLocation), // I can put locations here
                                      ClosestLandMarkMapSection = "https://www.emu.edu.tr/campusmap?design=empty#" + _locationRepo.List().ToList().Where(d => d.DormitoryId == dorm.Id).FirstOrDefault().MapSection,
                     UniqueAttribute=dorm.StandAloneOption, //use bus stop coordinate to determine time to get to bus stop and distance
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


    }


}
