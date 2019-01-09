using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dau.Core.Domain.API;
using Dau.Core.Domain.Bookings;
using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Feature;
using Dau.Core.Domain.LocationInformations;
using Dau.Core.Domain.SearchEngineOptimization;
using Dau.Core.Domain.Users;
using Dau.Data.Repository;
using Dau.Services.Domain.DropdownServices;
using Dau.Services.Domain.ImageServices;
using Dau.Services.Domain.LocationServices;
using Dau.Services.Domain.MapServices;
using Dau.Services.Domain.RoomServices;
using Dau.Services.Languages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Internal;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Dau.Services.Domain.MobileApiServices
{
   public class MobileApiService : IMobileApiService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<Features> _featuresRepo;
        private readonly IRepository<FeaturesTranslation> _featuresTransRepo;
        private readonly IRepository<FeaturesCategory> _featuresCategoryRepo;
        private readonly IRepository<FeaturesCategoryTranslation> _featuresCategoryTransRepo;
        private readonly IRepository<DormitoryFeatures> _dormFeaturesRepo;
        private readonly IRepository<Dormitory> _dormitoryRepo;
        private readonly IRepository<DormitoryTranslation> _dormitoryTransRepo;
        private readonly IRepository<RoomCatalogImage> _roomImageRepo;
        private readonly IImageService _imageService;
        private readonly IRoomService _roomService;
        private readonly IRepository<RoomFeatures> _roomFeaturesRepo;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IRepository<Booking> _bookingRepository;
        private readonly IRepository<BookingStatus> _bookingStatusRepo;
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
        private readonly ILanguageService _languageService;
        private readonly IRepository<DormitoryBlock> _dormitoryBlockRepo;
        private readonly IRepository<DormitoryBlockTranslation> _dormitoryBlockTransRepo;
        private readonly IRepository<DormitoryTypeTranslation> _dormitoryTypeTranslationRepo;
        private readonly IRepository<CatalogImage> _imagesRepo;
        private readonly IRepository<DormitoryCatalogImage> _dormitoryImageRepo;
        private readonly IRepository<Review> _reviewRepo;
        private readonly IRepository<Locationinformation> _locationRepo;
        private readonly IRepository<BookingStatusTranslation> _bookingStatusTransRepo;
        private readonly IRepository<PaymentStatus> _paymentStatusRepo;
        private readonly IRepository<PaymentStatusTranslation> _paymentStatusTransRepo;

        public MobileApiService(
             IRepository<Features> featuresRepository,
            IRepository<FeaturesTranslation> featuresTransRepository,
              IRepository<FeaturesCategory> featuresCategoryRepository,
            IRepository<FeaturesCategoryTranslation> featuresCategoryTransRepository,

              IRepository<Dormitory> dormitoryRepository,
            IRepository<DormitoryTranslation> dormitoryTransRepository,
             IHttpContextAccessor httpContextAccessor,
             IRoomService roomService,
            


              IRepository<Room> RoomRepository,
            IRepository<RoomTranslation> RoomTransRepository,
            IRepository<Dormitory> DormitoryRepository,
            IRepository<DormitoryTranslation> DormitoryTranslationRepository,
            IRepository<DormitoryBlock> DormitoryBlockRepository,
            IRepository<DormitoryBlockTranslation> DormitoryBlockTranslationRepository,
            IRepository<SemesterPeriod> SemesterPeriodRepository,
            IRepository<SemesterPeriodTranslation> semesterPeriodTransRepository,
            IImageService imageService,
            IRepository<DormitoryType> dormitoryTypeRepository,
            IRepository<DormitoryTypeTranslation> dormitoryTypeTranslationRepository,
        IRepository<CatalogImage> imagesRepository,
                    IRepository<DormitoryCatalogImage> DormitoryImageRepository,
                    IRepository<Seo> seoRepository,
                    IRepository<Review> reviewRepository,
                    IRepository<Locationinformation> locationRepository,
                     IRepository<DormitoryFeatures> dormFeaturesRepo,
                        IMapService mapService,
                        IDropdownService dropdownService,
                        ILocationService locationService,
                    IRepository<RoomCatalogImage> RoomImageRepository,
                    IRepository<RoomFeatures> roomFeaturesRepository,

                     IRepository<Booking> bookingRepository,
            IRepository<BookingStatus> bookingStatusRepository,
            IRepository<BookingStatusTranslation> bookingStatusTransRepository,
            IRepository<PaymentStatus> paymentStatusRepository,
            IRepository<PaymentStatusTranslation> paymentStatusTransRepository,
            SignInManager<User> signInManager,
            UserManager<User> userManager

            )
        {
            _httpContextAccessor = httpContextAccessor;
            _featuresRepo = featuresRepository;
            _featuresTransRepo = featuresTransRepository;
            _featuresCategoryRepo = featuresCategoryRepository;
            _featuresCategoryTransRepo = featuresCategoryTransRepository;
            _dormFeaturesRepo = dormFeaturesRepo;
            _dormitoryRepo = dormitoryRepository;
            _dormitoryTransRepo = dormitoryTransRepository;
            _roomImageRepo = RoomImageRepository;
            _imageService = imageService;
            _roomService = roomService;
            _roomFeaturesRepo = roomFeaturesRepository;
            _signInManager = signInManager;
            _userManager = userManager;



            _bookingRepository = bookingRepository;
      

            _bookingStatusRepo = bookingStatusRepository;
            _bookingStatusTransRepo = bookingStatusTransRepository;
            _paymentStatusRepo = paymentStatusRepository;
            _paymentStatusTransRepo = paymentStatusTransRepository;



            _locationService = locationService;
            _dropdownService = dropdownService;
            _mapService = mapService;
            _seoRepo = seoRepository;
           
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
        }


        private CreateUser CreateUserDeserializeJson(string Json)
        {
            JObject jUser = JObject.Parse(Json);
            if (Json.Length <= 0) return null;
            var desJson = new CreateUser
            {
                Password = (string)jUser["password"],
                Email = (string)jUser["email"],
                userFirstName = (string)jUser["userFirstName"],
                userLastName = (string)jUser["userLastName"],
                userImageString = (string)jUser["userImageString"],
                userGender = (string)jUser["userGender"],

            };

            return desJson;
        }

        private AuthenticationInput AuthDeserializeJson(string Json)
        {
            JObject jUser = JObject.Parse(Json);
            var desJson = new AuthenticationInput
            {
                Username = (string)jUser["Username"],
                password= (string)jUser["Password"],

        };
            return desJson;
           
        }

        public async Task<RootObjectAuthentication> CreateUserAsync()
        {
            //done

            //user manager check if user exist
            //return Userid//userPicture//
            //userFirstname// userlastname//
            // and so on

            var bodyStr = "";
            var req = _httpContextAccessor.HttpContext.Request;

            // Allows using several time the stream in ASP.Net Core
            req.EnableRewind();

            // Arguments: Stream, Encoding, detect encoding, buffer size 
            // AND, the most important: keep stream opened
            using (StreamReader reader
                      = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
            {
                bodyStr = reader.ReadToEnd();
            }
            //  AuthenticationInput
           var Input= CreateUserDeserializeJson(bodyStr);
            if (Input==null) return null;
            

            var emailKey = Input.Email;
            if (string.IsNullOrWhiteSpace(emailKey)) return null;
              
            
            var userFirstNameKey = Input.userFirstName;
            if (string.IsNullOrWhiteSpace(userFirstNameKey)) return null;
              
            
            var userLastNameKey = Input.userLastName;
            if (string.IsNullOrWhiteSpace(userLastNameKey)) return null;
                
            
            var userImageString = Input.userImageString;
         
            var PasswordKey = Input.Password;
            if (string.IsNullOrWhiteSpace(PasswordKey)) return null;


            //create user key here

            var user2 = new User
            {
                UserName = emailKey,
                Email = emailKey,
                FirstName = userFirstNameKey,
                LastName = userLastNameKey,
                CreatedOnUtc=DateTime.Now
               // UserImageUrl = "https://avatars0.githubusercontent.com/u/14825113?s=400&v=4"
               //create the image here then then return the imagePath
            };
            var createdSuccessful = await _userManager.CreateAsync(user2, PasswordKey);

            if (createdSuccessful == null) return null;

            var user = await _userManager.FindByEmailAsync(emailKey);
            if (user == null) return null;
           bool passworsIsCorrect =await _signInManager.UserManager.CheckPasswordAsync(user, PasswordKey);
            if (!passworsIsCorrect) return null;

            var Response = new RootObjectAuthentication
            {
                response = "Success",
                body = new BodyAuthentication
                {
                  UserId =user.Id,
                  UserName  =user.UserName,
                  UserFirstName=user.FirstName,
                  UserLastName=user.LastName,
                  UserImageUrl =user.UserImageUrl,
                  UserGender =user.Gender
                 }

            };

            return Response;

        }
           public async Task<RootObjectAuthentication> AuthenticationAsync()
        {
            //done

            //user manager check if user exist
            //return Userid//userPicture//
            //userFirstname// userlastname//
            // and so on

            var bodyStr = "";
            var req = _httpContextAccessor.HttpContext.Request;

            // Allows using several time the stream in ASP.Net Core
            req.EnableRewind();

            // Arguments: Stream, Encoding, detect encoding, buffer size 
            // AND, the most important: keep stream opened
            using (StreamReader reader
                      = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
            {
                bodyStr = reader.ReadToEnd();
            }
            //  AuthenticationInput
           var Input= AuthDeserializeJson(bodyStr);
            if (Input==null) return null;


            var UsernameKey = Input.Username;
            if (string.IsNullOrWhiteSpace(UsernameKey)) return null;
                var Username = UsernameKey;

            var PasswordKey = Input.password;
            if (string.IsNullOrWhiteSpace(PasswordKey)) return null;
                var Password = PasswordKey;

            var user = await _userManager.FindByEmailAsync(Username);
            if (user == null) return null;
           bool passworsIsCorrect =await _signInManager.UserManager.CheckPasswordAsync(user, Password);
            if (!passworsIsCorrect) return null;

            var Response = new RootObjectAuthentication
            {
                response = "Success",
                body = new BodyAuthentication
                {
                  UserId =user.Id,
                  UserName  =user.UserName,
                  UserFirstName=user.FirstName,
                  UserLastName=user.LastName,
                  UserImageUrl =user.UserImageUrl,
                  UserGender =user.Gender
                 }

            };

            return Response;

        }

        public RootObjectBookingByBookingId BookingByBookingIdService(long BookingId)
        {
            //done

            var Booking = _bookingRepository.GetById(BookingId);
            if (Booking == null) return null;
            var CurrentLanguageId = 1; //english for api
            var bookingStatus = from bookingStats in _bookingStatusRepo.List().ToList()
                                join bookingStatsTrans in _bookingStatusTransRepo.List().ToList() on bookingStats.Id equals bookingStatsTrans.BookingStatusNonTransId
                                where bookingStatsTrans.LanguageId == CurrentLanguageId
                                select new { bookingStats.Id, bookingStatsTrans.BookingStatus };
            var cancelWaitDays = _dormitoryRepo.GetById(_roomRepository.GetById(Booking.RoomId).DormitoryId).CancelWaitDays;
                var roomBooked = _roomRepository.GetById(Booking.RoomId);
            var roomTrans = _roomTransRepository.List().Where(c => c.RoomNonTransId == Booking.RoomId && c.LanguageId == CurrentLanguageId).FirstOrDefault();
            var dormTrans = _dormitoryTransRepo.List().Where(c => c.DormitoryNonTransId == roomBooked.DormitoryId && c.LanguageId == CurrentLanguageId).FirstOrDefault();

            if (Booking == null) return null;

            var Response = new RootObjectBookingByBookingId
            {
                response = "Success",
                body = new BodyBookingByBookingId
                {
                    dormitoryId = roomBooked.DormitoryId,
                    bookingDate = Booking.CreatedOn.ToString("d"),
                    bookingStatus = bookingStatus.Where(c => c.Id == Booking.BookingStatusId).FirstOrDefault().BookingStatus,
                    paymentConfirmationExpiryDate = Booking.CreatedOn.AddDays(cancelWaitDays).ToString("d"),
                    bookingNo = Booking.Id,
                    roomBooked = roomTrans.RoomName,
                    dormitoryName = dormTrans.DormitoryName
                }

            };

            return Response;

        }

        public RootObjectGetBooking GetBookingService(long BookingId)
        {
            var Booking = _bookingRepository.GetById(BookingId);

            if (Booking == null) return null;

            //done
            var Response = new RootObjectGetBooking
            {
                response = "Success",
                body = new BodyGetBooking
                {
                    bookingId = Booking.Id,
                    dateOfBooking = Booking.CreatedOn.ToString("d"),
                    timeOfBooking = Booking.CreatedOn.ToString("T"),
                    checkInDate = "Beginning of semester",
                    checkInSemester = "Spring semester"//will set this later



                }

            };

            return Response;

        }
        public RootObjectGetBookingsByCustomerId GetBookingsByCustomerIdService(string UserGuid)
        {
            //done
            //where booking custorid == booking.userId

            var CurrentLanguageId = 1; //english for api
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
                                  dormTrans.DormitoryDescription,
                                  dorm.DormitoryStreetAddress,
                                  dorm.MapSectionId,
                                  dormTrans.ShortDescription,
                                  dormTrans.RatingText

                              };
            if (dormitories == null) return null;
            if (dormitories.FirstOrDefault() == null) return null;

            var Images = from imageList in _imagesRepo.List().Distinct().ToList()
                         join roomImage in _roomImageRepo.List().ToList() on imageList.Id equals roomImage.CatalogImageId
                         select new { imageList.ImageUrl, roomImage.RoomId };


            var rooms = from room in _roomRepository.List().ToList()
                        join roomTrans in _roomTransRepository.List().ToList() on room.Id equals roomTrans.RoomNonTransId
                        where roomTrans.LanguageId == CurrentLanguageId 
                        select new RoomGetRoomByDormitoryId
                        {
                            pictureUrl = (Images.Where(c => c.RoomId == room.Id) != null) ? _imageService.PrepareImageForMobileApi(Images.Where(c => c.RoomId == room.Id).FirstOrDefault().ImageUrl) : _imageService.PrepareImageForMobileApi(""),
                            dormitoryName = dormitories.ToList().FirstOrDefault().DormitoryName,
                            bedType = roomTrans.BedType,
                            roomSize = room.RoomSize,
                            roomQuotaRemaining = room.NoRoomQuota,
                            roomPrice = room.Price,
                            roomId = room.Id,
                            dormitoryId = room.DormitoryId,

                        };

            var bookingStatus = from bookingStats in _bookingStatusRepo.List().ToList()
                                join bookingStatsTrans in _bookingStatusTransRepo.List().ToList() on bookingStats.Id equals bookingStatsTrans.BookingStatusNonTransId
                                where bookingStatsTrans.LanguageId == CurrentLanguageId
                                select new { bookingStats.Id, bookingStatsTrans.BookingStatus };

            var paymentStatus = from payStats in _paymentStatusRepo.List().ToList()
                                join payStatsTrans in _paymentStatusTransRepo.List().ToList() on payStats.Id equals payStatsTrans.PaymentStatusNonTransId
                                where payStatsTrans.LanguageId == CurrentLanguageId
                                select new { payStats.Id, payStatsTrans.PaymentStatus };


            var roomDormitory = from room in rooms.ToList()
                                join dorm in dormitories.ToList() on room.dormitoryId equals dorm.Id
                                select new {
                            room.pictureUrl,
                            room.dormitoryName ,
                            room.bedType ,
                            room.roomSize ,
                            room.roomQuotaRemaining ,
                            room.roomPrice ,
                            room.roomId ,
                            room.dormitoryId,
                                    dorm.DormitoryName,
                                    dorm.DormitoryLogoUrl,
                                    dorm.DormitoryTypeId,
                                    dorm.RatingNo,
                                    dorm.ReviewNo,
                                    dorm.DormitoryDescription,
                                    dorm.DormitoryStreetAddress,
                                    dorm.MapSectionId,
                                    dorm.ShortDescription,
                                    dorm.RatingText

                                };

            var Bookings = from booking in _bookingRepository.List().ToList()
                           join roomDorm in roomDormitory.ToList() on booking.RoomId equals roomDorm.roomId
                           where booking.UserId==UserGuid
                           orderby booking.Id descending
                           select new BookingGetBookingsByCustomerId
                           {
                               dormitoryDescription = roomDorm.ShortDescription,
                               dormitoryId = roomDorm.dormitoryId,
                               bookingNumber = booking.Id,
                               dormitoryname = roomDorm.dormitoryName,
                               pictureUrl = roomDorm.pictureUrl,
                               ratingNumber = roomDorm.RatingNo,
                               ratingText = roomDorm.RatingText,
                               bookingDate = booking.CreatedOn.ToString("d"),
                               checkInDate = "Semester beginning",
                               bookingStatus = bookingStatus.Where(c => c.Id == booking.BookingStatusId).FirstOrDefault().BookingStatus,
                               roomId = roomDorm.roomId


                           };

            if (Bookings == null) return null;
            var Response = new RootObjectGetBookingsByCustomerId
            {
                response = "Success",
                body = new BodyGetBookingsByCustomerId
                {
                    bookings = Bookings.ToList()



                }
            };


            return Response;
        }



        public RootObjectGetRoomById GetRoomByIdService(long RoomId)
        {
            //done
            var CurrentLanguageId = 1; //english for api
            var Images = from imageList in _imagesRepo.List().Distinct().ToList()
                         join roomImage in _roomImageRepo.List().ToList() on imageList.Id equals roomImage.CatalogImageId
                         where roomImage.RoomId== RoomId
                         select new { imageList.ImageUrl, roomImage.RoomId };

            var features = from feature in _featuresRepo.List().ToList()
                           join featureTrans in _featuresTransRepo.List().ToList() on feature.Id equals featureTrans.FeaturesNonTransId
                           where featureTrans.LanguageId == CurrentLanguageId
                           select new { feature.Id, featureTrans.FeatureName, feature.IconUrl };

            var Room = from room in _roomRepository.List().ToList()
                        join roomTrans in _roomTransRepository.List().ToList() on room.Id equals roomTrans.RoomNonTransId
                        where roomTrans.LanguageId == CurrentLanguageId && room.Id==RoomId
                        select new BodyGetRoomById
                        {
                            pictureUrl = _imageService.PrepareImageForMobileApi(Images.Select(x => x.ImageUrl).ToList()),
                          
                            roomId = room.Id,
                            roomQuota = room.NoRoomQuota,
                            roomPrice = room.Price,
                            facilitiesList = (from roomFeature in _roomFeaturesRepo.List().ToList()
                                                         join feature in features.ToList() on roomFeature.FeaturesId equals feature.Id
                                                         where roomFeature.RoomId == room.Id && feature.IconUrl != null
                                                         select new FacilitiesListGetRoomById
                                                         {
                                                             pictureUrl = (feature.IconUrl != null) ? _imageService.PrepareImageForMobileApi("/frontend_Content/assets/img/icons" + feature.IconUrl) : null,
                                                             facilityname = feature.FeatureName,
                                                             facilityId = feature.Id
                                                         }).ToList()

                        };

            if (Room == null) return null;
            if (Room.FirstOrDefault()==null) return null;
            var Response = new RootObjectGetRoomById
            {
                response = "Success",
                body = Room.FirstOrDefault()

            };

            return Response;

        }


        public RootObjectGetRoomByDormitoryId GetRoomByDormitoryIdService(long DormitoryId)
        {
            var CurrentLanguageId = 1; //english for api

            var dormitories = from dorm in _dormitoryRepository.List().ToList()
                              join dormTrans in _dormitoryTranslationRepository.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                              where dormTrans.LanguageId == CurrentLanguageId && dorm.Published == true && dorm.Id==DormitoryId
                              select new
                              {
                                  dorm.Id,
                                  DormitorySeoId = dorm.SeoId,
                                  dormTrans.DormitoryName,
                                  dorm.DormitoryLogoUrl,
                                  dorm.DormitoryTypeId,
                                  dorm.RatingNo,
                                  dorm.ReviewNo,
                                  dormTrans.DormitoryDescription,
                                  dorm.DormitoryStreetAddress,
                                  dorm.MapSectionId,

                              };
            if (dormitories == null) return null;
            if (dormitories.FirstOrDefault() == null) return null;

            var Images = from imageList in _imagesRepo.List().Distinct().ToList()
                         join roomImage in _roomImageRepo.List().ToList() on imageList.Id equals roomImage.CatalogImageId
                         select new { imageList.ImageUrl, roomImage.RoomId };


            var rooms = from room in _roomRepository.List().ToList()
                        join roomTrans in _roomTransRepository.List().ToList() on room.Id equals roomTrans.RoomNonTransId
                        where roomTrans.LanguageId == CurrentLanguageId && room.DormitoryId==DormitoryId
                        select new RoomGetRoomByDormitoryId
                        {
             pictureUrl=(Images.Where(c => c.RoomId == room.Id)!=null)?_imageService.PrepareImageForMobileApi(Images.Where(c=> c.RoomId==room.Id).FirstOrDefault().ImageUrl):_imageService.PrepareImageForMobileApi(""),
            dormitoryName=dormitories.ToList().FirstOrDefault().DormitoryName,
            bedType=roomTrans.BedType,
            roomSize=room.RoomSize,
            roomQuotaRemaining=room.NoRoomQuota,
            roomPrice=room.Price,
            roomId=room.Id,
           dormitoryId=DormitoryId
                        };

            if (rooms == null) return null;
            if (rooms.ToList().Count <= 0) return null;
            //done
            var Response = new RootObjectGetRoomByDormitoryId
            {
                response = "Success",
                body = new BodyGetRoomByDormitoryId
                {

                    rooms = rooms.ToList()
                }

            };

            return Response;

        }


        public RootObjectGetDormitoryDetailById GetDormitoryDetailByIdService(long DormitoryId)
        {
            var CurrentLanguageId = 1; //english for api
            var dormitories = from dorm in _dormitoryRepository.List().ToList()
                              join dormTrans in _dormitoryTranslationRepository.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                              where dormTrans.LanguageId == CurrentLanguageId && dorm.Published == true
                              select new
                              {
                                  dorm.Id,
                                  dormTrans.ShortDescription,
                                  DormitorySeoId = dorm.SeoId,
                                  dormTrans.DormitoryName,
                                  dorm.DormitoryLogoUrl,
                                  dorm.DormitoryTypeId,
                                  dorm.RatingNo,
                                  dorm.ReviewNo,
                                  Location = _dropdownService.ResolveDropdown(dorm.LocationOnCampus, _dropdownService.LocationOnCampus()),
                                  DormitoryDescription = dormTrans.ShortDescription,
                                  dorm.MapSectionId,
                                  dorm.DormitoryStreetAddress
                              };
            if (dormitories == null) return null;
            var Images = from imageList in _imagesRepo.List().Distinct().ToList()
                         join dormImage in _dormitoryImageRepo.List().ToList() on imageList.Id equals dormImage.CatalogImageId
                         select new { imageList.ImageUrl, dormImage.DormitoryId };

       

            var features = from feature in _featuresRepo.List().ToList()
                           join featureTrans in _featuresTransRepo.List().ToList() on feature.Id equals featureTrans.FeaturesNonTransId
                           where featureTrans.LanguageId == CurrentLanguageId
                           select new { feature.Id, featureTrans.FeatureName, feature.IconUrl };


            var dormitoryType = from dormType in _dormitoryTypeRepo.List().ToList()
                                join dormTypeTrans in _dormitoryTypeTranslationRepo.List().ToList() on dormType.Id equals dormTypeTrans.DormitoryTypeNonTransId
                                where dormTypeTrans.LanguageId == CurrentLanguageId
                                select new { dormType.Id, dormTypeTrans.Title };

            var dormitoryAndtype = from dorm in dormitories.ToList()
                                   join dormType in dormitoryType.ToList() on dorm.DormitoryTypeId equals dormType.Id
                                   where dorm.Id== DormitoryId
                                   select new BodyGetDormitoryDetailById
                                   {
                                       //  IsbookedInlast24hours = false //has to do with booking
                                       dormitoryname = dorm.DormitoryName,
                                       dormitoryShortDescription =dorm.ShortDescription,
                                       dormitotyFullDescription = dorm.DormitoryDescription,

                                       imageUrls = _imageService.PrepareImageForMobileApi(Images.Where(d => d.DormitoryId == dorm.Id).Select(x => x.ImageUrl).ToList()),
                                       dormitoryPolicies = "!Important -Dormitory policies - Please remove this field, dormtories can put their policies in the dormitory description.- Thanks Musa Jahun",
                                       facilitiesList = (from dormFeature in _dormFeaturesRepo.List().ToList()
                                                         join feature in features.ToList() on dormFeature.FeaturesId equals feature.Id
                                                         where dormFeature.DormitoryId== dorm.Id 
                                                         select new FacilitiesListGetDormitoryDetailById
                                                         {
                                                            
                                                             pictureUrl = (feature.IconUrl!=null)?_imageService.PrepareImageForMobileApi("/frontend_Content/assets/img/icons" + feature.IconUrl):null,
                                                             facilityname = feature.FeatureName,
                                                             facilityId = feature.Id
                                                         }).ToList(),
                                   
                                   


                                       };


            //return null if not found, controller already handle the null
            if (dormitoryAndtype == null) return null;
            if (dormitoryAndtype.ToList().FirstOrDefault() == null) return null;
            var Response = new RootObjectGetDormitoryDetailById
            {
                response = "Success",
                body = dormitoryAndtype.ToList().FirstOrDefault()
            };



            return Response;

        }



        public RootObjectFacilitiesFilter FacilitiesFilterService()
        {
            var CurrentLanguageId = 1;// english 
            var features = from feature in _featuresRepo.List().ToList()
                           join featureTrans in _featuresTransRepo.List().ToList() on feature.Id equals featureTrans.FeaturesNonTransId
                           where featureTrans.LanguageId == CurrentLanguageId
                           orderby feature.HitCount descending
                           select new FacilityFacilitiesFilter
                           {
                               facilityId = feature.Id,
                               facilityName = featureTrans.FeatureName
                           };
            //done
            var Response = new RootObjectFacilitiesFilter
            {
                response = "Success",
                body = new BodyFacilitiesFilter
                {
                    facilities = features.ToList()
                }

            };

            return Response;
        }
        public RootObjectGetDormitories GetDormitoriesService()
        {
            //done
           
            var CurrentLanguageId = 1;// english
            var dormitory = from dorm in _dormitoryRepo.List().ToList()
                            join dormTrans in _dormitoryTransRepo.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                            where dormTrans.LanguageId == CurrentLanguageId
                            select new DormitoryGetDormitories
                            {
                               
                                pictureUrl = _imageService.PrepareImageForMobileApi(dorm.DormitoryLogoUrl),
                                dormitoryName = dormTrans.DormitoryName,
                                dormitoryDescription =dormTrans.ShortDescription,
                                ratingNumber = dorm.RatingNo,
                                ratingText = dormTrans.RatingText,
                                dormitoryId = dorm.Id
                            };

            var Response = new RootObjectGetDormitories
            {
                response = "Success",
                body = new BodyGetDormitories
                {
                    dormitories = dormitory.ToList()
                    
                }

            };

            return Response;
        }


        public RootObjectGetHighlyRatedDormitories GetHighlyRatedDormitoriesService()
        {
            //done // output a list of all the dormitories for now, everything should be english first
            var CurrentLanguageId = 1;// english
            var dormitory = from dorm in _dormitoryRepo.List().ToList()
                            join dormTrans in _dormitoryTransRepo.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                            where dormTrans.LanguageId == CurrentLanguageId
                            orderby dorm.RatingNo descending
                            select new DormitoryGetHighlyRatedDormitories
                            {
                                pictureUrl = _imageService.PrepareImageForMobileApi(dorm.DormitoryLogoUrl),
                                dormitoryName = dormTrans.DormitoryName,
                                dealsText = String.Format("Deals start at TL {0}",_roomService.GetRoomWithLowestDealByDormitoryId(dorm.Id,CurrentLanguageId)),
                                dormitoryId = dorm.Id,
                            };


            var Response = new RootObjectGetHighlyRatedDormitories
            {

                response = "Success",
                body = new BodyGetHighlyRatedDormitories
                {

                    dormitories = dormitory.ToList()
                }

            };


            return Response;
        }


        public RootObjectGetMostPopularDormitories GetMostPopularDormitoriesService()
        {
           
            //done // output a list of all the dormitories for now, everything should be english first
            var CurrentLanguageId = 1;// english
            var dormitory = from dorm in _dormitoryRepo.List().ToList()
                            join dormTrans in _dormitoryTransRepo.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                            where dormTrans.LanguageId == CurrentLanguageId
                            orderby dorm.RatingNo descending
                            select new DormitoryGetMostPopularDormitories
                            {
                                pictureUrl = _imageService.PrepareImageForMobileApi(dorm.DormitoryLogoUrl),
                                dormitoryName = dormTrans.DormitoryName,
                                dealsText = String.Format("Deals start at TL {0}", _roomService.GetRoomWithLowestDealByDormitoryId(dorm.Id, CurrentLanguageId)),
                                dormitoryId = dorm.Id,
                            };

            //done 
            var Response = new RootObjectGetMostPopularDormitories
            {
                response = "Success",
                body = new BodyGetMostPopularDormitories
                {

                    dormitories = dormitory.ToList()
                }

            };

            return Response;

        }


        //these are posts, I haven't worked on them yet

        public void GetSearchDormitoriesByFilterService()
        {

        }

        public void GiveAppFeedBackService()
        {


        }

        public void PaymentConfirmationService()
        {

        }


        public void RateYourStayService()
        {

        }



        public void CreateBookingService()
        {


        }
        public void CancelBookingService()
        {

        }

        public void EditBookingService()
        {


        }

        public void GetCurrencyService()
        {

        }
    }

}
