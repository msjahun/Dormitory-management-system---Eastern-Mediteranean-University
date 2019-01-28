using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.SearchEngineOptimization;
using Dau.Data.Repository;
using Dau.Services.Event;
using Dau.Services.Languages;
using Dau.Services.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Dau.Services.Domain.DormitoryServices
{
    public class DormitoryService : IDormitoryService
    {
        private readonly IEventService _eventService;
        private readonly IUserRolesService _userRolesService;
        private readonly ILanguageService _languageService;
        private readonly IRepository<RoomTranslation> _roomTransRepo;
        private readonly IRepository<Room> _roomRepo;
        private readonly IRepository<Dormitory> _dormitoryRepo;
        private readonly IRepository<DormitoryTranslation> _dormitoryTransRepo;
        private readonly IRepository<DormitoryCatalogImage> _dormImageRepo;
        private readonly IRepository<CatalogImage> _imageRepo;
        private readonly IRepository<DormitoryType> _dormitoryTypeRepo;
        private readonly IRepository<DormitoryTypeTranslation> _dormitoryTypeTransRepo;
        private readonly IRepository<Seo> _SeoRepo;

        public DormitoryService(

              ILanguageService languageService,
            IRepository<Room> roomRepository,
            IRepository<RoomTranslation> roomTransRepository,
            IRepository<Dormitory> dormitoryRepository,
            IRepository<DormitoryTranslation> dormitoryTransRepository,
            IRepository<DormitoryCatalogImage> dormImageRepository,
            IRepository<CatalogImage> imageRepository,
            IRepository<DormitoryType> dormitoryTypeRepository,
            IRepository<DormitoryTypeTranslation> dormitoryTypeTransRepository,
            IRepository<Seo> SeoRepository,
          IUserRolesService userRolesService,
          IEventService eventService
            )
        {
            _eventService = eventService;
            _userRolesService = userRolesService;

            _languageService = languageService;
            _roomTransRepo = roomTransRepository;
            _roomRepo = roomRepository;
            _dormitoryRepo = dormitoryRepository;
            _dormitoryTransRepo = dormitoryTransRepository;
            _dormImageRepo = dormImageRepository;
            _imageRepo = imageRepository;
            _dormitoryTypeRepo      = dormitoryTypeRepository;
            _dormitoryTypeTransRepo= dormitoryTypeTransRepository;
            _SeoRepo=SeoRepository;

        }


        public List<DormitoriesDataTable> GetDormitoryListTable()
        {

            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            //var dormImages = from dormImage in _dormImageRepo.List().ToList()
            //                 join Image in _imageRepo.List().ToList() on dormImage.CatalogImageId equals Image.Id
            //                 select new { dormImage.DormitoryId, Image.ImageUrl, Image.Published };

            var dormitoryType = from dormType in _dormitoryTypeRepo.List().ToList()
                                join dormTypeTrans in _dormitoryTypeTransRepo.List().ToList() on dormType.Id equals dormTypeTrans.DormitoryTypeNonTransId
                                where dormTypeTrans.LanguageId == CurrentLanguageId
                                select new { dormType.Id, dormTypeTrans.Title };

            var dormitory = from dorm in _dormitoryRepo.List().Where(c => _userRolesService.RoleAccessResolver().Contains(c.Id)).ToList().ToList()
                            join dormTrans in _dormitoryTransRepo.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                            where dormTrans.LanguageId == CurrentLanguageId
                            select new DormitoriesDataTable {
                                 DormitoryId=dorm.Id,
                                 Picture = (dorm.DormitoryLogoUrl!=null)?((dorm.DormitoryLogoUrl.Length>0) ? dorm.DormitoryLogoUrl : "/Content/dist/img/default-image_100.png") : "/Content/dist/img/default-image_100.png",
                                 DormitoryName = dormTrans.DormitoryName,
                                 SKU =dorm.SKU,
                                 DormitoryType =dormitoryType.ToList().Where(c=> c.Id == dorm.DormitoryTypeId).FirstOrDefault().Title,
                                 Published =dorm.Published
                            };


            var model = dormitory.ToList();

            return model;
        }

        public long AddDormitory(DormitoryCrud vm)
        {

            //sorts seo issue
            if (vm.seoTab.SearchEngineFriendlyPageName == null || vm.seoTab.SearchEngineFriendlyPageName.Length <= 0)
                vm.seoTab.SearchEngineFriendlyPageName = vm.localizedContent[0].DormitoryName;



            DateTime weekdaysOpeningTime;
            DateTime.TryParseExact(vm.OpeningTimeWeekdays, "HH:mm", CultureInfo.InvariantCulture,
                     DateTimeStyles.None, out weekdaysOpeningTime);

          


            DateTime WeekendsOpeingTime;
            DateTime.TryParseExact(vm.OpeningTimeWeekends, "HH:mm", CultureInfo.InvariantCulture,
                     DateTimeStyles.None, out WeekendsOpeingTime);
           


            DateTime ClosingTimeWeekdays;
            DateTime.TryParseExact(vm.ClosingTimeWeekdays, "HH:mm", CultureInfo.InvariantCulture,
                     DateTimeStyles.None, out ClosingTimeWeekdays);

         


            DateTime ClosingTimeWeekends;
            DateTime.TryParseExact(vm.ClosingTimeWeekends, "HH:mm", CultureInfo.InvariantCulture,
                     DateTimeStyles.None, out ClosingTimeWeekends);
          
            int _englishLanguageId = 1;
            int _turkishLanguageId = 2;
            var dormitory = new Dormitory
            {
                DormitoryTypeId = vm.DormitoryType,
                NoOfStudents = vm.NumberOfStudents,
                NoOfNewFacilities = vm.NumberOfNewFacilities,
                NoOfStaff = vm.NumberOfStaffs,
                NoOfAwards = vm.NumberOfAwards,
                DormitoryStreetAddress = vm.DormitoryAddress,
                Published = vm.Published,
                SKU= vm.SKU,
                RatingNo = 9.0,
                ReviewNo = 0,
               CurrencyId= vm.Currency,
              BookingLimit = vm.BookingLimit,
              LocationOnCampus = vm.LocationOnCampus,
                MapSectionId=vm.BuildingsOnMap,
           WeekdaysOpeningTime = weekdaysOpeningTime,
           WeekendsOpeningTime = WeekendsOpeingTime,
           WeekdaysClosingTime = ClosingTimeWeekdays,
           WeekendsClosingTime = ClosingTimeWeekends,
                CancelWaitDays= vm.CancelWaitDays,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                OpenedOnSundays = vm.OpenedOnSundays,



            Seo = new Seo
                {
                    MetaKeywords = vm.seoTab.MetaKeywords,
                    MetaDescription = vm.seoTab.MetaDescription,
                    MetaTitle = vm.seoTab.MetaTitle,
                    SearchEngineFriendlyPageName = RemoveSpecialCharacters(vm.seoTab.SearchEngineFriendlyPageName)
                },
                DormitoryTranslation = new List<DormitoryTranslation>
                {
                    new DormitoryTranslation
                    {
                        
                        DormitoryName = vm.localizedContent[0].DormitoryName,
                        LanguageId=_englishLanguageId,
                        DormitoryDescription = vm.localizedContent[0].FullDescription,
                        ShortDescription =vm.localizedContent[0].ShortDescription,
                        RatingText = "Very Good"

                    },

                    new DormitoryTranslation
                    {
                      
                        DormitoryName = vm.localizedContent[1].DormitoryName,
                        LanguageId=_turkishLanguageId,
                        DormitoryDescription = vm.localizedContent[1].FullDescription,
                        ShortDescription =vm.localizedContent[1].ShortDescription,
                        RatingText = "Very goodTR",

                    }

                }


            };


            return _dormitoryRepo.Insert(dormitory);
        }

        public DormitoryCrud GetDormitoryById(long DormitoryId)
        {
            if (!_userRolesService.IsAuthorized(DormitoryId)) return null;
            var dorm = _dormitoryRepo.GetById(DormitoryId);
            if (dorm == null)
                return null;

       
            var dormT = from dormTrans in _dormitoryTransRepo.List().ToList()
                        where dormTrans.DormitoryNonTransId == dorm.Id
                        select dormTrans;

            var englishdorm= dormT.Where(c => c.LanguageId == 1).FirstOrDefault();
            var turkishdorm = dormT.Where(c => c.LanguageId == 2).FirstOrDefault();
            var Seo = _SeoRepo.GetById(dorm.SeoId);
           
            var model = new DormitoryCrud
            {

                Id = dorm.Id,
                DormitoryType = dorm.DormitoryTypeId,
                DormitoryLogo = (dorm.DormitoryLogoUrl!=null)?((dorm.DormitoryLogoUrl.Length > 0) ? dorm.DormitoryLogoUrl : "/Content/dist/img/default-image_100.png"): "/Content/dist/img/default-image_100.png",
                DormitoryAddress = dorm.DormitoryStreetAddress,
                Published = dorm.Published,
                NumberOfStudents = dorm.NoOfStudents,
                SKU = dorm.SKU,
                NumberOfStaffs = dorm.NoOfStaff,
                NumberOfAwards = dorm.NoOfAwards,
                NumberOfNewFacilities = dorm.NoOfNewFacilities,
                OpeningTimeWeekdays = dorm.WeekdaysOpeningTime.ToString("HH:mm"),
                OpeningTimeWeekends = dorm.WeekendsOpeningTime.ToString("HH:mm"),
                ClosingTimeWeekdays = dorm.WeekdaysClosingTime.ToString("HH:mm"),
                ClosingTimeWeekends = dorm.WeekendsClosingTime.ToString("HH:mm"),
                MarkAsNew = dorm.MarkAsNew,
                CancelWaitDays = dorm.CancelWaitDays,
                AdminComment = dorm.AdminComment,
               Currency= dorm.CurrencyId,
                CreatedOn = dorm.CreatedOn.ToString(),
                UpdatedOn = dorm.UpdatedOn.ToString(),
                AllowReviewsWithBookingOnly = dorm.AllowReviewsWithBookingOnly,
                OpenedOnSundays = dorm.OpenedOnSundays,
                localizedContent = new List<LocalizedContent>
                                        { new LocalizedContent
                                            {
                                                DormitoryName =englishdorm.DormitoryName,
                                                FullDescription=englishdorm.DormitoryDescription,
                                                ShortDescription=englishdorm.ShortDescription
                                                //english
                                            },
                                            new LocalizedContent
                                            {
                                                DormitoryName =turkishdorm.DormitoryName,
                                                FullDescription=turkishdorm.DormitoryDescription,
                                                ShortDescription=turkishdorm.ShortDescription
                                                //turkish
                                            }
                                        },
                seoTab = new SeoTab
                {
                    MetaDescription = Seo.MetaDescription,
                    MetaKeywords = Seo.MetaKeywords,
                    MetaTitle = Seo.MetaTitle,
                    SearchEngineFriendlyPageName = Seo.SearchEngineFriendlyPageName,

                },

             
                       CloseLocation = 1,//no need requires seperate handling when we come to area information
                BookingLimit = dorm.BookingLimit,//1year, 1 semester
                // resolve this tables and relationships
                LocationOnCampus = dorm.LocationOnCampus,//need to create tables for this
                BuildingsOnMap = int.Parse (dorm.MapSectionId.ToString()),//need to create a relationshipwith this
         

            };
            return model;
        }

        public bool UpdateDormitoryById(DormitoryCrud vm)
        {
            try {
                if (!_userRolesService.IsAuthorized(vm.Id)) return false;

            int _englishLanguageId = 1;
            int _turkishLanguageId = 2;
            var dormitoryToUpdate = _dormitoryRepo.GetById(vm.Id);

                dormitoryToUpdate.DormitoryTypeId = vm.DormitoryType;
                dormitoryToUpdate.NoOfStudents = vm.NumberOfStudents;
                dormitoryToUpdate.NoOfNewFacilities = vm.NumberOfNewFacilities;
                dormitoryToUpdate.NoOfStaff = vm.NumberOfStaffs;
                dormitoryToUpdate.NoOfAwards = vm.NumberOfAwards;
                dormitoryToUpdate.DormitoryStreetAddress = vm.DormitoryAddress;
                dormitoryToUpdate.Published = vm.Published;
                dormitoryToUpdate.SKU = vm.SKU;
                dormitoryToUpdate.RatingNo = 9.0;
                dormitoryToUpdate.ReviewNo = 0;
                dormitoryToUpdate.BookingLimit = vm.BookingLimit;
                dormitoryToUpdate.LocationOnCampus = vm.LocationOnCampus;
                dormitoryToUpdate.CurrencyId= vm.Currency;
               
                dormitoryToUpdate.BookingLimit =vm.BookingLimit;//1year, 1 semester
                                                                // resolve this tables and relationships
                dormitoryToUpdate.LocationOnCampus = vm.LocationOnCampus;//need to create tables for this
                dormitoryToUpdate.MapSectionId =vm.BuildingsOnMap;

                dormitoryToUpdate.CancelWaitDays = vm.CancelWaitDays;
                dormitoryToUpdate.UpdatedOn = DateTime.Now;
                dormitoryToUpdate.OpenedOnSundays = vm.OpenedOnSundays;

                var dormTransEnglish = _dormitoryTransRepo.List().Where(c => c.LanguageId == 1 && c.DormitoryNonTransId == dormitoryToUpdate.Id).FirstOrDefault();
                    var dormTransTurkish = _dormitoryTransRepo.List().Where(c => c.LanguageId == 2 && c.DormitoryNonTransId == dormitoryToUpdate.Id).FirstOrDefault();
            
                    dormTransEnglish.DormitoryName = vm.localizedContent[0].DormitoryName;
                    dormTransEnglish.LanguageId=_englishLanguageId;
                    dormTransEnglish.DormitoryDescription = vm.localizedContent[0].FullDescription;
                    dormTransEnglish.ShortDescription =vm.localizedContent[0].ShortDescription;
                    dormTransEnglish.RatingText = "Very Good";

                

                DateTime weekdaysOpeningTime;
                DateTime.TryParseExact(vm.OpeningTimeWeekdays, "HH:mm", CultureInfo.InvariantCulture,
                         DateTimeStyles.None, out weekdaysOpeningTime);

                dormitoryToUpdate.WeekdaysOpeningTime= weekdaysOpeningTime;


                DateTime WeekendsOpeingTime;
                DateTime.TryParseExact(vm.OpeningTimeWeekends, "HH:mm", CultureInfo.InvariantCulture,
                         DateTimeStyles.None, out WeekendsOpeingTime);

                dormitoryToUpdate.WeekendsOpeningTime = WeekendsOpeingTime;


                DateTime ClosingTimeWeekdays;
                DateTime.TryParseExact(vm.ClosingTimeWeekdays, "HH:mm", CultureInfo.InvariantCulture,
                         DateTimeStyles.None, out ClosingTimeWeekdays);


                dormitoryToUpdate.WeekdaysClosingTime = ClosingTimeWeekdays;


                DateTime ClosingTimeWeekends;
                DateTime.TryParseExact(vm.ClosingTimeWeekends, "HH:mm", CultureInfo.InvariantCulture,
                         DateTimeStyles.None, out ClosingTimeWeekends);

                dormitoryToUpdate.WeekendsClosingTime= ClosingTimeWeekends;


                    dormTransTurkish.DormitoryName = vm.localizedContent[1].DormitoryName;
                    dormTransTurkish.LanguageId=_turkishLanguageId;
                    dormTransTurkish.DormitoryDescription = vm.localizedContent[1].FullDescription;
                    dormTransTurkish.ShortDescription =vm.localizedContent[1].ShortDescription;
                    dormTransTurkish.RatingText = "Very goodTR";


            _dormitoryRepo.Update(dormitoryToUpdate);
            _dormitoryTransRepo.Update(dormTransEnglish);
            _dormitoryTransRepo.Update(dormTransTurkish);

                _eventService.Trigger_DormitoryInformationChange_DormitoryManagerNotification_Event(dormitoryToUpdate.Id);

            return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateDormSeo(DormitoryCrud vm)
        {
            try {
                if (!_userRolesService.IsAuthorized(vm.Id)) return false;
                var dormitoryToUpdate = _dormitoryRepo.GetById(vm.Id);
                if (vm.seoTab.SearchEngineFriendlyPageName == null || vm.seoTab.SearchEngineFriendlyPageName.Length <= 0)
                    vm.seoTab.SearchEngineFriendlyPageName = vm.localizedContent[0].DormitoryName;

                dormitoryToUpdate.UpdatedOn = DateTime.Now;
               
                var SeoToUpdate = _SeoRepo.GetById(dormitoryToUpdate.SeoId);
                _dormitoryRepo.Update(dormitoryToUpdate);
                //seo seperately

                SeoToUpdate.MetaKeywords = vm.seoTab.MetaKeywords;
            SeoToUpdate.MetaDescription = vm.seoTab.MetaDescription;
            SeoToUpdate.MetaTitle = vm.seoTab.MetaTitle;
            SeoToUpdate.SearchEngineFriendlyPageName = RemoveSpecialCharacters(vm.seoTab.SearchEngineFriendlyPageName);
            _SeoRepo.Update(SeoToUpdate);

            return true;
            }
            catch { return false; }
        }

        public string RemoveSpecialCharacters(string str)
        {//removes special characters and checks duplicates
            string acceptString = Regex.Replace(str, "[^a-zA-Z0-9_.]+", "-", RegexOptions.Compiled);
            var seolist = from seo in _SeoRepo.List().ToList()
                          where seo.SearchEngineFriendlyPageName == acceptString
                          select seo;
            if (seolist.ToList().Count >1)
                return acceptString + "-" + (seolist.ToList().Count+1);
            else
                return acceptString;
        }

        public List<DormitoryPicturesTable> GetDormitoryImagesTables(long id)
        {
            if (!_userRolesService.IsAuthorized(id)) return null;
            var DormImages = from dormImage in _dormImageRepo.List().ToList()
                             join Image in _imageRepo.List().ToList() on dormImage.CatalogImageId equals Image.Id
                             where dormImage.DormitoryId== id
                             orderby Image.CreatedDate descending
                             select new DormitoryPicturesTable
                             {
                                 Id = Image.Id,
                                 Picture = Image.ImageUrl,
                                 DisplayOrder = 4,
                                 Alt = "image",
                                 UploadDate = Image.CreatedDate.ToString(),
                             };
            var model = DormImages.ToList();
            return model;
        }

        public List<SEOFriendlyPageNamesTable> GetSEOFriendlyPageNamesTable()
        {

            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            //var dormImages = from dormImage in _dormImageRepo.List().ToList()
            //                 join Image in _imageRepo.List().ToList() on dormImage.CatalogImageId equals Image.Id
            //                 select new { dormImage.DormitoryId, Image.ImageUrl, Image.Published };

            var dormitoryType = from dormType in _dormitoryTypeRepo.List().ToList()
                                join dormTypeTrans in _dormitoryTypeTransRepo.List().ToList() on dormType.Id equals dormTypeTrans.DormitoryTypeNonTransId
                                where dormTypeTrans.LanguageId == CurrentLanguageId
                                select new { dormType.Id, dormTypeTrans.Title };

            var dormitory = from dorm in _dormitoryRepo.List().Where(c => _userRolesService.RoleAccessResolver().Contains(c.Id)).ToList().ToList()
                            join dormTrans in _dormitoryTransRepo.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                            where dormTrans.LanguageId == CurrentLanguageId
                            select new 
                            {dorm.SeoId,
                                DormitoryId = dorm.Id,
                                Picture = (dorm.DormitoryLogoUrl != null) ? ((dorm.DormitoryLogoUrl.Length > 0) ? dorm.DormitoryLogoUrl : "/Content/dist/img/default-image_100.png") : "/Content/dist/img/default-image_100.png",
                                DormitoryName = dormTrans.DormitoryName,
                                SKU = dorm.SKU,
                                DormitoryType = dormitoryType.ToList().Where(c => c.Id == dorm.DormitoryTypeId).FirstOrDefault().Title,
                                Published = dorm.Published
                            };


            var SeoList = from seo in _SeoRepo.List().ToList()
                          join dorm in dormitory.ToList() on seo.Id equals dorm.SeoId
                          select new SEOFriendlyPageNamesTable
                          {
                              Id = seo.Id,
                              SeoFriendlyName = seo.SearchEngineFriendlyPageName,
                              DormitoryId = dorm.DormitoryId,
                              DormitoryName = dorm.DormitoryName,
                              DormitoryType = dorm.DormitoryType,
                              IsActive = dorm.Published,
                          };

            return SeoList.ToList();

        }


        public string GetDormitoryNameById(long id)
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            
            var dormTrans= _dormitoryTransRepo.List().Where(c => c.DormitoryNonTransId== id && c.LanguageId == CurrentLanguageId).FirstOrDefault();
            if (dormTrans == null) return null;

            return dormTrans.DormitoryName;

        }
    }


    public class SEOFriendlyPageNamesTable
    {
        public long Id { get; set; }
        public string SeoFriendlyName { get; set; }
        public long DormitoryId { get; set; }
        public string DormitoryName { get; set; }
        public bool IsActive { get; set; }

        public string EditPage { get; set; }
        public string DormitoryType { get; internal set; }
    }

    public class DormitoriesDataTable
    {
        public long DormitoryId { get; set; }
        public string Picture { get; set; }
        public string DormitoryName { get; set; }
        public string SKU { get; set; }
        public string DormitoryType { get; set; }
        public bool Published { get; set; }
        //public string Edit { get; set; }
    }



    public class DormitoryCrud
    {



        public bool SavedSuccessful { get; set; }

        [Display(Name = "Dormitory Type",
                Description = "Dormitory type can be School own dormitory and private dormitory.")]
        public long DormitoryType { get; set; }

        public List<LocalizedContent> localizedContent { get; set; }

        [Display(Name = "Dormitory Logo",
      Description = "The Logo of the dormitory "), DataType(DataType.Text), MaxLength(256)]
        public string DormitoryLogo { get; set; }


        [Display(Name = "Currency",
      Description = "The Currency of dormitory ")]
        public long Currency { get; set; }
        

        [Display(Name = "Dormitory Address",
        Description = "Enter your Dormitory Address."), DataType(DataType.Text), MaxLength(256)]
        public string DormitoryAddress { get; set; }

        [Display(Name = "SKU",
     Description = "Room stock keeping unit(SKU). Your internal unique identifier that can be used to track this room."), DataType(DataType.Text), MaxLength(256)]
        public string SKU { get; set; }


        [Display(Name = "Published",
        Description = "Check to publish this dormitory (visible in customer area). Uncheck to unpublish (dormitory not available in customer area).")]
        public bool Published { get; set; }
        

        [Display(Name = "Mark As New",
        Description = "Check to mark the dormitory as new. Use this option for promoting new dormitories.")]
        public bool MarkAsNew { get; set; }

        [Display(Name = "Admin Comment",
        Description = "This comment is for internal use only, not visible for customers."), DataType(DataType.Text), MaxLength(256)]
        public string AdminComment { get; set; }




        public SeoTab seoTab { get; set; }

        [Display(Name = "ID",
              Description = "The Dormitory Id")]
        public long Id { get; set; }


        [Display(Name = "Created On",
        Description = "Date/Time this dormitory was created."), DataType(DataType.Text), MaxLength(256)]
        public string CreatedOn { get; set; }

        [Display(Name = "Updated On",
        Description = "Date/Time this dormitory was last updated."), DataType(DataType.Text), MaxLength(256)]
        public string UpdatedOn { get; set; }

      
        //number of students
        //number of staffs
        //number of awards

        public PicturesTab picturesTab { get; set; }

        public FacilitiesTabDormitory facilitiesTab { get; set; }


        //Booking settings
      //  public bool AllowSummerBooking { get; set; }//for rooms
        public int BookingLimit { get; set; }//1year, 1 semester

        [Range(3, 30)]
        [Display(Name = "Cancel Wait Days",
        Description = "Days Booking Will Be Cancelled If Not Confirmed")]
        public int CancelWaitDays { get; set; }


        //
        [Display(Name = "Allow Reviews With Booking Only",
    Description = "Allow only students that have booked a room in the dormitory to write reviews")]
        public bool AllowReviewsWithBookingOnly { get; set; }

        [Display(Name = "Building for map",
     Description = "The building that you select here will be used to show building location on the map")]
        public int BuildingsOnMap { get; set; }


        [Display(Name = "Add Close location Manually",
     Description = "The building that you select here will be shown on the Area information close locations list")]
        public int CloseLocation { get; set; }


        [Required]
        [Display(Name = "Opening Time Weekdays",
    Description = "Time the dormitory office opens on weekdays")]
        public string OpeningTimeWeekdays { get; set; }
        [Required]
        [Display(Name = "Opening Time Weekends",
    Description = "Time the dormitory office opens on weekends")]
        public string OpeningTimeWeekends { get; set; }
        [Required]
        [Display(Name = "Closing Time Weekdays",
    Description = "The time the dormitory office closes on the weekdays")]
        public string ClosingTimeWeekdays { get; set; }
        [Required]
        [Display(Name = "Closing Time Weekends",
    Description = "The time the dormitory office closes on the weekends")]
        public string ClosingTimeWeekends { get; set; }
        [Required]
        [Display(Name = "Opened on sundays",
    Description = "Is the dormitory office opened on sundays?")]
        public bool OpenedOnSundays { get; set; }


        public int LocationOnCampus { get; set; }


        //Additional information
        public int NumberOfStudents { get; set; }
        public int NumberOfStaffs { get; set; }
        public int NumberOfAwards { get; set; }
        public int NumberOfNewFacilities { get; set; }

     
    }


    public class SeoTab
    {

        [Display(Name = "Meta Keywords",
        Description = "Meta keywords to be added to dormitory page header."), DataType(DataType.Text), MaxLength(256)]
        public string MetaKeywords { get; set; }


        [Display(Name = "Meta Description",
        Description = "Meta description to be added to dormitory page header."), DataType(DataType.Text), MaxLength(256)]
        public string MetaDescription { get; set; }


        [Display(Name = "Meta Title",
        Description = "Override the page title. The default is the name of the dormitory."), DataType(DataType.Text), MaxLength(256)]
        public string MetaTitle { get; set; }


        [Display(Name = "Search Engine Friendly Page Name",
        Description = "Set a search engine friendly page name e.g. 'the-best-dormitory' to make your page URL 'http://www.domain.com/the-best-dormitory'. Leave empty to generate it automatically based on the name of the Dormitory"), DataType(DataType.Text), MaxLength(256)]
        public string SearchEngineFriendlyPageName { get; set; }

    }

    public class LocalizedContent
    {
        [Required]
        [Display(Name = "Dormitory Name",
       Description = "Name of the dormotory"), DataType(DataType.Text), MaxLength(60)]
        public string DormitoryName { get; set; }


        [Required]
        [Display(Name = "Full Description",
        Description = "Full description is the text that is displayed in dormitory page.")]
        public string FullDescription { get; set; }

       
        [Display(Name = "Short Description",
        Description = "Short description is the text that is displayed in Search page."), DataType(DataType.Text),MaxLength(256)]
        public string ShortDescription { get; set; }


   


    }

    public class PicturesTable
    {
        public string Picture { get; set; }
        public int DisplayOrder { get; set; }
        public string Alt { get; set; }
        public string Title { get; set; }

    }


    public class DormitoryPicturesTable
    {
        public string Picture { get; set; }
        public int DisplayOrder { get; set; }
        public string Alt { get; set; }
        public string UploadDate { get; set; }
        public long Id { get; set; }
    }
    public class PicturesTab
    {
        public long PictureId { get; set; }
        [Display(Name = "Alt",
       Description = ""), DataType(DataType.Text), MaxLength(256)]
        public string Alt { get; set; }


        [Display(Name = "title",
       Description = ""), DataType(DataType.Text), MaxLength(256)]
        public string title { get; set; }


        [Display(Name = "DisplayOrder",
       Description = "The order in which the image is displayed")]
        public int DisplayOrder { get; set; }

        [Display(Name = "DisplayOrder",
      Description = "The order in which the image is displayed")]
        public int SliderImageDisplayOrder { get; set; }

        [Display(Name = "Is Visible",
      Description = "Shows image in background homepage slider")]
        public bool IsVisible { get; set; }


    }


    public class FacilitiesTable
    {
        public string AttributeType { get; set; }
        public string Attribute { get; set; }
        public string Value { get; set; }
        public bool AllowFiltering { get; set; }
        public bool ShowOnRoomPage { get; set; }
        public int DisplayOrder { get; set; }

    }

    public class FacilitiesTabDormitory
    {

        public long DormitoryId { get; set; }
        [Display(Name = "Feature Category", Description = "The category of the feature, it may be under room feature category, bed type and so on")]
        public long FeatureCategory { get; set; }

        [Display(Name = "Feature", Description = "Feature name")]
        public long Feature { get; set; }


    }
}
