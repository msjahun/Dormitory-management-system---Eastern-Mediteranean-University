using Dau.Core.Domain.Bookings;
using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Users;
using Dau.Data.Repository;
using Dau.Services.Domain.DormitoryServices;
using Dau.Services.Domain.ImageServices;
using Dau.Services.Event;
using Dau.Services.Languages;
using Dau.Services.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Dau.Services.Domain.BookingService
{
   public class BookingService : IBookingService
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<Room> _roomRepository;
        private readonly IRepository<RoomTranslation> _roomTransRepository;
        private readonly IRepository<Dormitory> _dormitoryRepository;
        private readonly IRepository<DormitoryTranslation> _dormitoryTranslationRepository;
        private readonly IRepository<SemesterPeriod> _SemesterPeriodRepo;
        private readonly IRepository<SemesterPeriodTranslation> _semesterPeriodTransRepo;
        private readonly IRepository<Booking> _bookingRepository;
        private readonly IRepository<CancelBookingRequests> _cancelBookingRequests;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<BookingStatus> _bookingStatusRepo;
        private readonly IRepository<BookingStatusTranslation> _bookingStatusTransRepo;
        private readonly IRepository<PaymentStatus> _paymentStatusRepo;
        private readonly IRepository<PaymentStatusTranslation> _paymentStatusTransRepo;
        private readonly IEventService _eventService;
        private readonly IDormitoryService _dormitoryService;
        private readonly IUserRolesService _userRolesService;
        private readonly IImageService _imageService;
        private readonly ILanguageService _languageService;
        private readonly IRepository<DormitoryBlock> _dormitoryBlockRepo;
        private readonly IRepository<DormitoryBlockTranslation> _dormitoryBlockTransRepo;

        public BookingService(
            IRepository<Cart> CartRepository,
            IRepository<Room> RoomRepository,
            IRepository<RoomTranslation> RoomTransRepository,
            IRepository<Dormitory> DormitoryRepository,
            IRepository<DormitoryTranslation> DormitoryTranslationRepository,
            IRepository<DormitoryBlock> DormitoryBlockRepository,
            IRepository<DormitoryBlockTranslation> DormitoryBlockTranslationRepository,
            IRepository<SemesterPeriod> SemesterPeriodRepository,
            IRepository<SemesterPeriodTranslation> semesterPeriodTransRepository,
            IRepository<Booking> bookingRepository,
            IRepository<BookingStatus> bookingStatusRepository,
            IRepository<BookingStatusTranslation> bookingStatusTransRepository,
            IRepository<PaymentStatus> paymentStatusRepository,
            IRepository<PaymentStatusTranslation> paymentStatusTransRepository,
            IRepository<CancelBookingRequests> cancelBookingRequests,
             ILanguageService languageService,
             UserManager<User> userManager,
          IHttpContextAccessor httpContextAccessor,
          IImageService imageService,
           IUserRolesService userRolesService,
           IDormitoryService dormitoryService,
           IEventService eventService
            )
        {
            _eventService = eventService;
            _dormitoryService = dormitoryService;
            _userRolesService = userRolesService;
            _imageService = imageService;
            _languageService = languageService;
            _dormitoryBlockRepo = DormitoryBlockRepository;
           _dormitoryBlockTransRepo= DormitoryBlockTranslationRepository;
            _cartRepository = CartRepository;
            _roomRepository= RoomRepository;
            _roomTransRepository= RoomTransRepository;
            _dormitoryRepository= DormitoryRepository;
            _dormitoryTranslationRepository= DormitoryTranslationRepository;
            _SemesterPeriodRepo= SemesterPeriodRepository;
            _semesterPeriodTransRepo= semesterPeriodTransRepository;
            _bookingRepository=bookingRepository;
            _cancelBookingRequests = cancelBookingRequests;
            _userManager = userManager;
            _httpContextAccessor= httpContextAccessor;


        _bookingStatusRepo  = bookingStatusRepository;
         _bookingStatusTransRepo  = bookingStatusTransRepository;
           _paymentStatusRepo = paymentStatusRepository;
          _paymentStatusTransRepo=paymentStatusTransRepository;

        }

        public BookingCartViewModel GetCheckoutCartService()
        {
            //get full room information with translation
            //get full dormitory information with translation
            //join them together room and dormitory

            //join everything with cart table
            var CurrentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            var dormitories = from dorm in _dormitoryRepository.List().ToList()
                              join dormTrans in _dormitoryTranslationRepository.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                              where dormTrans.LanguageId == CurrentLanguageId
                              select new { dorm.Id, DormitorySeoId = dorm.SeoId, dormTrans.DormitoryName, dorm.DormitoryLogoUrl };

            var dormitoryBlock = from dormBlock in _dormitoryBlockRepo.List().ToList()
                                 join dormBlockTrans in _dormitoryBlockTransRepo.List().ToList() on dormBlock.Id equals dormBlockTrans.DormitoryBlockNonTransId
                                 where dormBlockTrans.LanguageId == CurrentLanguageId
                                 select new { dormBlock.Published, dormBlockTrans.Name, dormBlock.Id };

            var rooms = from room in _roomRepository.List().ToList()
                        join roomTrans in _roomTransRepository.List().ToList() on room.Id equals roomTrans.RoomNonTransId
                        where roomTrans.LanguageId == CurrentLanguageId
                        select new { room.Id, room.DormitoryId, room.DormitoryBlockId, roomTrans.RoomName, room.Price, room.PriceOld, room.ShowPrice, room.NoRoomQuota, room.RoomSize };

            var roomsDormitoryBlock = from room in rooms.ToList()
                                      join dormBlock in dormitoryBlock.ToList() on room.DormitoryBlockId equals dormBlock.Id
                                      select new
                                      {
                                          DormitoryBlockPublished =dormBlock.Published,
                                         DormitoryBlockName = dormBlock.Name,
                                          room.Id,
                                          room.DormitoryId,
                                          room.DormitoryBlockId,
                                          room.RoomName,
                                          room.Price,
                                          room.PriceOld,
                                          room.ShowPrice,
                                          room.NoRoomQuota,
                                          room.RoomSize
                                      };

            var roomDormitory = from room in roomsDormitoryBlock.ToList()
                                join dorm in dormitories.ToList() on room.DormitoryId equals dorm.Id
                                select new
                                {
                                    room.DormitoryBlockPublished,
                                    room.DormitoryBlockName,
                                    room.Id,
                                    room.DormitoryId,
                                    room.DormitoryBlockId,
                                    room.RoomName,
                                    room.Price,
                                    room.PriceOld,
                                    room.ShowPrice,
                                    room.NoRoomQuota,
                                    room.RoomSize,
                                    dorm.DormitorySeoId ,
                                    dorm.DormitoryName,
                                    dorm.DormitoryLogoUrl
                                };

            var semesterPeriods = from semPeriod in _SemesterPeriodRepo.List().ToList()
                                  join semPeriodTrans in _semesterPeriodTransRepo.List().ToList() on semPeriod.Id equals semPeriodTrans.SemesterPeriodNonTransId
                                  where semPeriodTrans.LanguageId == CurrentLanguageId
                                  select new { semPeriod.Id, semPeriodTrans.SemesterPeriodName };


            var Carts = from cart in _cartRepository.List().ToList()
                        where cart.UserId == CurrentUserId
                        select new { cart.RoomId, cart.UserId, cart.TotalAmount, cart.SemesterPeriodId };

            var CartRoom = from cart in Carts.ToList()
                           join room in roomDormitory.ToList() on cart.RoomId equals room.Id
                           select new BookingCartViewModel
                           {
                               DormitoryName = room.DormitoryName,
                               RoomName = room.RoomName,
                               RoomBlock = room.DormitoryBlockName,
                               RoomSize = room.RoomSize.ToString("N1")+" m2",
                               RoomPricePerSemester = String.Format("{1} {0} ",room.Price.ToString("N2"), "TL"),
                               AmountTotal = String.Format("{1}{0} ", room.Price.ToString("N2"),"TL"),
                               DormitoryLogoUrl = room.DormitoryLogoUrl
                           };


            //var CartsSemesterPeriods = from cart in Carts.ToList()
            //                           join SemPeriod in semesterPeriods.ToList() on cart.SemesterPeriodId equals SemPeriod.Id
            //                           select 

            var User = from user in _userManager.Users.ToList()
                       where user.Id == CurrentUserId
                       select user;

            //join rooms with dormitories and dormitoryBlock, leave roomId only and other components
            //get semesterPeriods

            //join Cart with semester periods

            //get the current user, use his id to get specific cart, 

            //join cart with room, dormitoryblock, dormitories join table

            //select the first cart or default and display it to the model


            BookingCartViewModel model = CartRoom.FirstOrDefault();


            //    new BookingCartViewModel
            //{
            //    DormitoryName = "Alfam Dormitories",
            //    RoomName = "Single room",
            //    RoomBlock = "A. block",
            //    RoomSize = "42.5 m2",
            //    RoomPricePerSemester = "{1}900 ",
            //    AmountTotal = "{1}1,800 ",
            //    DormitoryLogoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuzxmbcw2jxGlHQ_ZuICaAowpUUjFoOYTJH9oGmsQmz3WG4IpkSw"
            //};
           // return null;
           return model;

        }

        public BookingCheckoutCustomerInfoViewModel GetCheckoutCustomerService()
        {
            var CurrentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            var dormitories = from dorm in _dormitoryRepository.List().ToList()
                              join dormTrans in _dormitoryTranslationRepository.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                              where dormTrans.LanguageId == CurrentLanguageId
                              select new { dorm.Id, DormitorySeoId = dorm.SeoId, dormTrans.DormitoryName, dorm.DormitoryLogoUrl };

            var dormitoryBlock = from dormBlock in _dormitoryBlockRepo.List().ToList()
                                 join dormBlockTrans in _dormitoryBlockTransRepo.List().ToList() on dormBlock.Id equals dormBlockTrans.DormitoryBlockNonTransId
                                 where dormBlockTrans.LanguageId == CurrentLanguageId
                                 select new { dormBlock.Published, dormBlockTrans.Name, dormBlock.Id };

            var rooms = from room in _roomRepository.List().ToList()
                        join roomTrans in _roomTransRepository.List().ToList() on room.Id equals roomTrans.RoomNonTransId
                        where roomTrans.LanguageId == CurrentLanguageId
                        select new { room.Id, room.DormitoryId, room.DormitoryBlockId, roomTrans.RoomName, room.Price, room.PriceOld, room.ShowPrice, room.NoRoomQuota, room.RoomSize, room.TaxAmount, room.BookingFee};

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
                                          room.TaxAmount,
                                          room.BookingFee
                                      };

            var roomDormitory = from room in roomsDormitoryBlock.ToList()
                                join dorm in dormitories.ToList() on room.DormitoryId equals dorm.Id
                                select new
                                {
                                    room.DormitoryBlockPublished,
                                    room.DormitoryBlockName,
                                    room.Id,
                                    room.DormitoryId,
                                    room.DormitoryBlockId,
                                    room.RoomName,
                                    room.Price,
                                    room.PriceOld,
                                    room.ShowPrice,
                                    room.NoRoomQuota,
                                    room.RoomSize,
                                    room.TaxAmount,
                                    room.BookingFee,
                                    dorm.DormitorySeoId,
                                    dorm.DormitoryName,
                                    dorm.DormitoryLogoUrl
                                };

            var semesterPeriods = from semPeriod in _SemesterPeriodRepo.List().ToList()
                                  join semPeriodTrans in _semesterPeriodTransRepo.List().ToList() on semPeriod.Id equals semPeriodTrans.SemesterPeriodNonTransId
                                  where semPeriodTrans.LanguageId == CurrentLanguageId
                                  select new { semPeriod.Id, semPeriodTrans.SemesterPeriodName };


            var Carts = from cart in _cartRepository.List().ToList()
                        where cart.UserId == CurrentUserId
                        select new { cart.RoomId, cart.UserId, cart.TotalAmount, cart.SemesterPeriodId };

            var CartRoom = from cart in Carts.ToList()
                           join room in roomDormitory.ToList() on cart.RoomId equals room.Id
                           select new BookingCartViewModel
                           {
                               DormitoryName = room.DormitoryName,
                               RoomName = room.RoomName,
                               RoomBlock = room.DormitoryBlockName,
                               RoomSize = room.RoomSize.ToString("N1") + " m2",
                               RoomPricePerSemester = String.Format("{1} {0} ", room.Price.ToString("N2"),"TL"),
                               AmountTotal = String.Format("{1} {0} ", ( room.Price+room.BookingFee+room.TaxAmount).ToString("N2"), "TL"),
                               DormitoryLogoUrl = room.DormitoryLogoUrl,
                               TaxAmount = String.Format("{1} {0} ", room.TaxAmount.ToString("N2"), "TL"),
                               BookingFee = String.Format("{1} {0} ", room.BookingFee.ToString("N2"), "TL"),
                               StayDuration = semesterPeriods.Where(c=> c.Id == cart.SemesterPeriodId).FirstOrDefault().SemesterPeriodName,
                               SubtotalAmount = String.Format("{1} {0} ", room.Price.ToString("N2"), "TL")
                          
                           };


            //var CartsSemesterPeriods = from cart in Carts.ToList()
            //                           join SemPeriod in semesterPeriods.ToList() on cart.SemesterPeriodId equals SemPeriod.Id
            //                           select 

            var Users = from _user in _userManager.Users.ToList()
                       where _user.Id == CurrentUserId
                       select _user;
            var user = Users.FirstOrDefault();


            BookingCheckoutCustomerInfoViewModel model = new BookingCheckoutCustomerInfoViewModel
            {
                BookingDetails = CartRoom.FirstOrDefault(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                StudentNumber = user.StudentNumber,
                ParmanentAddress = user.ParmanentAddress,
                Country = user.Country,
                City = user.City,
                EmailAddress = user.Email,
                PhoneNumber = user.PhoneNumber
            };


            return model;
        }

        public BookingCheckoutCustomerInfoViewModel GetCheckoutPaymentService()
        {
            var CurrentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            var dormitories = from dorm in _dormitoryRepository.List().ToList()
                              join dormTrans in _dormitoryTranslationRepository.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                              where dormTrans.LanguageId == CurrentLanguageId
                              select new { dorm.Id, DormitorySeoId = dorm.SeoId, dormTrans.DormitoryName, dorm.DormitoryLogoUrl };

            var dormitoryBlock = from dormBlock in _dormitoryBlockRepo.List().ToList()
                                 join dormBlockTrans in _dormitoryBlockTransRepo.List().ToList() on dormBlock.Id equals dormBlockTrans.DormitoryBlockNonTransId
                                 where dormBlockTrans.LanguageId == CurrentLanguageId
                                 select new { dormBlock.Published, dormBlockTrans.Name, dormBlock.Id };

            var rooms = from room in _roomRepository.List().ToList()
                        join roomTrans in _roomTransRepository.List().ToList() on room.Id equals roomTrans.RoomNonTransId
                        where roomTrans.LanguageId == CurrentLanguageId
                        select new { room.Id, room.DormitoryId, room.DormitoryBlockId, roomTrans.RoomName, room.Price, room.PriceOld, room.ShowPrice, room.NoRoomQuota, room.RoomSize, room.TaxAmount, room.BookingFee };

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
                                          room.TaxAmount,
                                          room.BookingFee
                                      };

            var roomDormitory = from room in roomsDormitoryBlock.ToList()
                                join dorm in dormitories.ToList() on room.DormitoryId equals dorm.Id
                                select new
                                {
                                    room.DormitoryBlockPublished,
                                    room.DormitoryBlockName,
                                    room.Id,
                                    room.DormitoryId,
                                    room.DormitoryBlockId,
                                    room.RoomName,
                                    room.Price,
                                    room.PriceOld,
                                    room.ShowPrice,
                                    room.NoRoomQuota,
                                    room.RoomSize,
                                    room.TaxAmount,
                                    room.BookingFee,
                                    dorm.DormitorySeoId,
                                    dorm.DormitoryName,
                                    dorm.DormitoryLogoUrl
                                };

            var semesterPeriods = from semPeriod in _SemesterPeriodRepo.List().ToList()
                                  join semPeriodTrans in _semesterPeriodTransRepo.List().ToList() on semPeriod.Id equals semPeriodTrans.SemesterPeriodNonTransId
                                  where semPeriodTrans.LanguageId == CurrentLanguageId
                                  select new { semPeriod.Id, semPeriodTrans.SemesterPeriodName };


            var Carts = from cart in _cartRepository.List().ToList()
                        where cart.UserId == CurrentUserId
                        select new { cart.RoomId, cart.UserId, cart.TotalAmount, cart.SemesterPeriodId };

            var CartRoom = from cart in Carts.ToList()
                           join room in roomDormitory.ToList() on cart.RoomId equals room.Id
                           select new BookingCartViewModel
                           {
                               DormitoryName = room.DormitoryName,
                               RoomName = room.RoomName,
                               RoomBlock = room.DormitoryBlockName,
                               RoomSize = room.RoomSize.ToString("N1") + " m2",
                               RoomPricePerSemester = String.Format("{1}{0} ", room.Price.ToString("N2"),"TL"),
                               AmountTotal = String.Format("{1}{0} ", (room.Price + room.BookingFee + room.TaxAmount).ToString("N2"),"TL"),
                               DormitoryLogoUrl = room.DormitoryLogoUrl,
                               TaxAmount = String.Format("{1}{0} ", room.TaxAmount.ToString("N2"),"TL"),
                               BookingFee = String.Format("{1}{0} ", room.BookingFee.ToString("N2"),"TL"),
                               StayDuration = semesterPeriods.Where(c => c.Id == cart.SemesterPeriodId).FirstOrDefault().SemesterPeriodName,
                               SubtotalAmount = String.Format("{1}{0} ", room.Price.ToString("N2"),"TL")

                           };


            //var CartsSemesterPeriods = from cart in Carts.ToList()
            //                           join SemPeriod in semesterPeriods.ToList() on cart.SemesterPeriodId equals SemPeriod.Id
            //                           select 

            var Users = from _user in _userManager.Users.ToList()
                        where _user.Id == CurrentUserId
                        select _user;
            var user = Users.FirstOrDefault();


            BookingCheckoutCustomerInfoViewModel model = new BookingCheckoutCustomerInfoViewModel
            {
                BookingDetails = CartRoom.FirstOrDefault(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                StudentNumber = user.StudentNumber,
                ParmanentAddress = user.ParmanentAddress,
                Country = user.Country,
                City = user.City,
                EmailAddress = user.Email,
                PhoneNumber = user.PhoneNumber,
                DateBookingExpiresWithoutConfirmation = DateTime.Now.AddDays(14).ToString("d"),
                NumberOfWorkingDaysBeforeBookingExpires = 14,
              

            };

            

            return model;
        }

        public bool DeleteItemFromCart()
        {
            var CurrentUserId =  _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var cartToDelete =  (from cart in _cartRepository.List().ToList()
                                where cart.UserId == CurrentUserId
                                select cart);
            foreach( var cart in cartToDelete.ToList()) {
         _cartRepository.Delete(cart);
            }
            return true;
        }

        public bool AddToCart(long RoomId)
        {
            var CurrentSemesterId = (from sem in _SemesterPeriodRepo.List().ToList()
                                     where sem.IsCurrentSemester == true
                                     select sem).FirstOrDefault().Id;
            var CurrentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var oldCartItems= _cartRepository.List().Where(c => c.UserId == CurrentUserId).ToList();
            foreach(var cartItem in oldCartItems)
            {
                _cartRepository.Delete(cartItem);
            }
            var Cart = new Cart
            {
                RoomId = RoomId,
                UserId = CurrentUserId,
                SemesterPeriodId = CurrentSemesterId  // fix this 
            };
            _cartRepository.Insert(Cart);
            return true;
        }

        public ReservationEdit GetBookingById(long BookingId)
        {
            var booking =_bookingRepository.GetById(BookingId);
            if (booking == null) return null;
            var CurrentLanguage = _languageService.GetCurrentLanguageId();
            var room = _roomRepository.GetById(booking.RoomId);

            if (!_userRolesService.IsAuthorized(room.DormitoryId)) return null;

            var dormitoryName = _dormitoryTranslationRepository.List().Where(c => c.DormitoryNonTransId == room.DormitoryId && c.LanguageId==CurrentLanguage).FirstOrDefault().DormitoryName;
            var user = _userManager.Users.Where(c => c.Id == booking.UserId).FirstOrDefault();

        var bookingStatus=    _bookingStatusTransRepo.List().Where(c => c.BookingStatusNonTransId == booking.BookingStatusId && c.LanguageId == CurrentLanguage).FirstOrDefault().BookingStatus;
        var PaymentStatus=    _paymentStatusTransRepo.List().Where(c => c.PaymentStatusNonTransId== booking.PaymentStatusId&& c.LanguageId == CurrentLanguage).FirstOrDefault().PaymentStatus;

            var model = new ReservationEdit
            {
                BookingOrderNumber = booking.Id.ToString(),
                Dormitory = dormitoryName,
                Student = user.Email,
                StudentIpAddress = user.LastIpAddress,
                BookingOrderSubtotal = booking.BookingOrderSubtotal.ToString("N2"),
                BookingFee = booking.BookingFee.ToString("N2"),
                BookingTotal = booking.BookingTotal.ToString("N2"),
                Profit = (booking.BookingTotal - room.RoomCost).ToString("N2"),
                ReceiptUrl = booking.ReceiptUrl,
                CreatedOn = booking.CreatedOn.ToString(),
                StudentName = user.FirstName + " " +user.LastName,
                StudentEmail = user.Email,
                StudentPhoneNumber = user.PhoneNumber,
                StudentAddress1 = booking.StudentAddress1,
                StudentAddress2 = booking.StudentAddress2,
                City = booking.City,
                RoomId = booking.RoomId,
                StateProvince = booking.StateProvince,
                ZipCode = booking.ZipCode,
                Country = booking.Country,
                PaymentStatus= PaymentStatus,
                BookingStatus= bookingStatus




            };
            return model;
        }
        public int  GetTotalNumberOfBookings()
        {
            //room Id and dormitoryId
            return _bookingRepository.List().Where(c => _userRolesService.RoleAccessResolver().Contains(_roomRepository.GetById(c.RoomId).DormitoryId)).ToList().Count; 
        }

        public int GetTotalNumberOfCancelRequests()
        {
            return _cancelBookingRequests.List().ToList().Count;
        }


        public List<ReservationListTable> GetBookingTableList()
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var bookingStatus = from bookingStats in _bookingStatusRepo.List().ToList()
                                join bookingStatsTrans in _bookingStatusTransRepo.List().ToList() on bookingStats.Id equals bookingStatsTrans.BookingStatusNonTransId
                                where bookingStatsTrans.LanguageId == CurrentLanguageId
                                select new { bookingStats.Id, bookingStatsTrans.BookingStatus };

            var paymentStatus = from payStats in _paymentStatusRepo.List().ToList()
                                join payStatsTrans in _paymentStatusTransRepo.List().ToList() on payStats.Id equals payStatsTrans.PaymentStatusNonTransId
                                where payStatsTrans.LanguageId == CurrentLanguageId
                                select new { payStats.Id, payStatsTrans.PaymentStatus };

            var dormitoryId = _roomRepository.GetById(1).DormitoryId;
            //   var numberOfDaysBeforeCancellation = _dormitoryRepository.GetById(_roomRepository.GetById(1).DormitoryId).CancelWaitDays;
            var Bookings = from booking in _bookingRepository.List().ToList()
                           orderby booking.Id descending
                           select new ReservationListTable
                           { DormitoryId = _roomRepository.GetById(booking.RoomId).DormitoryId,
                               BookingNo = booking.Id.ToString(),
                               BookingStatus = bookingStatus.Where(c => c.Id == booking.BookingStatusId).FirstOrDefault().BookingStatus,
                               PaymentStatus = paymentStatus.Where(p => p.Id == booking.PaymentStatusId).FirstOrDefault().PaymentStatus,
                               PaymentStatusId = booking.PaymentStatusId,
                               BookingStatusId = booking.BookingStatusId,
                               User = _userManager.Users.Where(c => c.Id == booking.UserId).FirstOrDefault().UserName,
                               CreatedOn = booking.CreatedOn.ToString("d"),
                               cancellationDate= DaysRemaining((booking.CreatedOn.AddDays(_dormitoryRepository.GetById(_roomRepository.GetById(booking.RoomId).DormitoryId).CancelWaitDays) - DateTime.Now).TotalDays),
                               cancellationDays= (booking.CreatedOn.AddDays(_dormitoryRepository.GetById(_roomRepository.GetById(booking.RoomId).DormitoryId).CancelWaitDays) - DateTime.Now).TotalDays,
                               BookingTotal = booking.BookingTotal.ToString("N2"),


                           };

            return Bookings.Where(c => _userRolesService.RoleAccessResolver().Contains(c.DormitoryId)).ToList();
        }

        private string DaysRemaining(double TotalDays)
        {
            int totaldays = (int)(TotalDays);
            var date =DateTime.FromOADate(TotalDays);
            return String.Format("{0} days {1} hours {2} min {3} sec left", totaldays, date.ToString("HH"),date.ToString("mm"), date.ToString("ss"));
            
        }

        public List<LatestBookingsTable> GetLatestBookingsDashboardList()
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var bookingStatus = from bookingStats in _bookingStatusRepo.List().ToList()
                                join bookingStatsTrans in _bookingStatusTransRepo.List().ToList() on bookingStats.Id equals bookingStatsTrans.BookingStatusNonTransId
                                where bookingStatsTrans.LanguageId == CurrentLanguageId
                                select new { bookingStats.Id, bookingStatsTrans.BookingStatus };

            var paymentStatus = from payStats in _paymentStatusRepo.List().ToList()
                                join payStatsTrans in _paymentStatusTransRepo.List().ToList() on payStats.Id equals payStatsTrans.PaymentStatusNonTransId
                                where payStatsTrans.LanguageId == CurrentLanguageId
                                select new { payStats.Id, payStatsTrans.PaymentStatus };



            var Bookings = from booking in _bookingRepository.List().ToList()
                           orderby booking.Id descending
                           select new LatestBookingsTable
                           {DormitoryId=_roomRepository.GetById(booking.RoomId).DormitoryId,
                               OrderNo = booking.Id.ToString(),
                              
                               OrderStatus = bookingStatus.Where(c => c.Id == booking.BookingStatusId).FirstOrDefault().BookingStatus,
                               BookingStatusId = booking.BookingStatusId,
                               Customer = _userManager.Users.Where(c => c.Id == booking.UserId).FirstOrDefault().UserName,
                               CreatedOn = booking.CreatedOn.ToString("d"),
                              


                           };

            return Bookings.Where(c => _userRolesService.RoleAccessResolver().Contains(c.DormitoryId)).ToList();
        }


        public bool AddBooking()
        {
            var CurrentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
           
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            var dormitories = from dorm in _dormitoryRepository.List().ToList()
                              join dormTrans in _dormitoryTranslationRepository.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                              where dormTrans.LanguageId == CurrentLanguageId
                              select new { dorm.Id, DormitorySeoId = dorm.SeoId, dormTrans.DormitoryName, dorm.DormitoryLogoUrl };

            var dormitoryBlock = from dormBlock in _dormitoryBlockRepo.List().ToList()
                                 join dormBlockTrans in _dormitoryBlockTransRepo.List().ToList() on dormBlock.Id equals dormBlockTrans.DormitoryBlockNonTransId
                                 where dormBlockTrans.LanguageId == CurrentLanguageId
                                 select new { dormBlock.Published, dormBlockTrans.Name, dormBlock.Id };

            var rooms = from room in _roomRepository.List().ToList()
                        join roomTrans in _roomTransRepository.List().ToList() on room.Id equals roomTrans.RoomNonTransId
                        where roomTrans.LanguageId == CurrentLanguageId
                        select new { room.Id, room.DormitoryId, room.DormitoryBlockId, roomTrans.RoomName, room.Price, room.PriceOld, room.ShowPrice, room.NoRoomQuota, room.RoomSize, room.TaxAmount, room.BookingFee };

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
                                          room.TaxAmount,
                                          room.BookingFee
                                      };

            var roomDormitory = from room in roomsDormitoryBlock.ToList()
                                join dorm in dormitories.ToList() on room.DormitoryId equals dorm.Id
                                select new
                                {
                                    room.DormitoryBlockPublished,
                                    room.DormitoryBlockName,
                                    room.Id,
                                    room.DormitoryId,
                                    room.DormitoryBlockId,
                                    room.RoomName,
                                    room.Price,
                                    room.PriceOld,
                                    room.ShowPrice,
                                    room.NoRoomQuota,
                                    room.RoomSize,
                                    room.TaxAmount,
                                    room.BookingFee,
                                    dorm.DormitorySeoId,
                                    dorm.DormitoryName,
                                    dorm.DormitoryLogoUrl
                                };

            var semesterPeriods = from semPeriod in _SemesterPeriodRepo.List().ToList()
                                  join semPeriodTrans in _semesterPeriodTransRepo.List().ToList() on semPeriod.Id equals semPeriodTrans.SemesterPeriodNonTransId
                                  where semPeriodTrans.LanguageId == CurrentLanguageId
                                  select new { semPeriod.Id, semPeriodTrans.SemesterPeriodName };


            var Carts = from cart in _cartRepository.List().ToList()
                        where cart.UserId == CurrentUserId
                        select new { cart.RoomId, cart.UserId, cart.TotalAmount, cart.SemesterPeriodId };

            var CartToBooking = (from cart in Carts.ToList()
                           join room in roomDormitory.ToList() on cart.RoomId equals room.Id
                           select new Booking
                           {
                               BookingStatusId = 2,
                               PaymentStatusId = 2,
                               UserId = CurrentUserId,
                               CustomerIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(),
                               BookingOrderSubtotal = room.Price,
                               BookingFee = room.BookingFee,
                               BookingTotal = room.Price + room.BookingFee + room.TaxAmount,
                               CreatedOn = DateTime.Now,
                               RoomId =room.Id

                           }).FirstOrDefault();

            try
            {//reduce room quota and check if room quota
             var room=   _roomRepository.GetById(CartToBooking.RoomId);
                if (room.NoRoomQuota > 0)
                {
                    room.NoRoomQuota--;
                    _roomRepository.Update(room);
                   var bookingId= _bookingRepository.Insert(CartToBooking);
                    _imageService.uploadBookingReceiptImage(bookingId);
                    _eventService.Trigger_BookingPlaced_DormitoryManagerNotification_Event();
                    _eventService.Trigger_BookingPlaced_DormitoryNotification_Event();
                    _eventService.Trigger_BookingPlaced_StudentNotification_Event();

                    if (room.NoRoomQuota <= 5)
                        _eventService.Trigger_RoomQuotaBelow_DormitoryManagerNotification_Event();

                    return true;
                }else
                {
                    return false; //room quota is not enough
                }

                }
            catch
            {
                return false;
            }

           
        }


        /// <summary>
        /// Calculates number of business days, taking into account:
        ///  - weekends (Saturdays and Sundays)
        ///  - bank holidays in the middle of the week
        /// </summary>
        /// <param name="firstDay">First day in the time interval</param>
        /// <param name="lastDay">Last day in the time interval</param>
        /// <param name="bankHolidays">List of bank holidays excluding weekends</param>
        /// <returns>Number of business days during the 'span'</returns>
        public int BusinessDaysUntil(DateTime firstDay, DateTime lastDay, params DateTime[] Holidays)
        {
            firstDay = firstDay.Date;
            lastDay = lastDay.Date;
            if (firstDay > lastDay)
                throw new ArgumentException("Incorrect last day " + lastDay);

            TimeSpan span = lastDay - firstDay;
            int businessDays = span.Days + 1;
            int fullWeekCount = businessDays / 7;
            // find out if there are weekends during the time exceedng the full weeks
            if (businessDays > fullWeekCount * 7)
            {
                // we are here to find out if there is a 1-day or 2-days weekend
                // in the time interval remaining after subtracting the complete weeks
                int firstDayOfWeek = firstDay.DayOfWeek == DayOfWeek.Sunday
                    ? 7 : (int)firstDay.DayOfWeek;
                int lastDayOfWeek = lastDay.DayOfWeek == DayOfWeek.Sunday
                    ? 7 : (int)lastDay.DayOfWeek;


                if (lastDayOfWeek < firstDayOfWeek)
                    lastDayOfWeek += 7;
                if (firstDayOfWeek <= 6)
                {
                    if (lastDayOfWeek >= 7)// Both Saturday and Sunday are in the remaining time interval
                        businessDays -= 2;
                    else if (lastDayOfWeek >= 6)// Only Saturday is in the remaining time interval
                        businessDays -= 1;
                }
                else if (firstDayOfWeek <= 7 && lastDayOfWeek >= 7)// Only Sunday is in the remaining time interval
                    businessDays -= 1;
            }

            // subtract the weekends during the full weeks in the interval
            businessDays -= fullWeekCount + fullWeekCount;

            //// subtract the number of bank holidays during the time interval
            //foreach (DateTime Holiday in Holidays)
            //{
            //    DateTime b = Holiday.Date;
            //    if (firstDay <= b && b <= lastDay)
            //        --businessDays;
            //}

            return businessDays;
        }

        public bool ChangeBookingStatus(long bookingId, long newBookingStatusId)
        {
            try
            {
                var booking = _bookingRepository.GetById(bookingId);
                if (booking == null) return false;
                booking.BookingStatusId = newBookingStatusId;
                _bookingRepository.Update(booking);

                if (newBookingStatusId == 1)
                    _eventService.Trigger_BookingCompleted_StudentNotification_Event();
                else if (newBookingStatusId == 3)
                    _eventService.Trigger_BookingCancelled_StudentNotification_Event();
                 
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool ChangePaymentStatus(long bookingId, long newpaymentStatusId)
        {
            try
            {
                var booking = _bookingRepository.GetById(bookingId);
                if (booking == null) return false;
                booking.PaymentStatusId = newpaymentStatusId;
                _bookingRepository.Update(booking);


                if (newpaymentStatusId == 1)
                {
                    _eventService.Trigger_BookingPaid_DormitoryNotification_Event();
                    _eventService.Trigger_BookingPaid_StudentNotification_Event();
                }
                   
          
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Charts GetBookingsChartById(long id)
        {
            
            if (id == 1)
            {
                //per week
                var data = BookingsPerWeekAllCode(DateTime.Now.AddDays(1), DateTime.Now.AddDays(-7));
                return data;
            }
            else if(id==2)
            {
                //per month
                var data = BookingsPerMonthAllCode(DateTime.Now.AddDays(1), DateTime.Now.AddMonths(-1));
                return data;
            }
            else
            {
                //per year
                var data = BookingsPerYearAllCode(DateTime.Now.AddMonths(1), DateTime.Now.AddYears(-1));
                return data;
            }
            
        }


        private int BookingsPerWeekCounter(DateTime baselineDate)
        {
            var count = _bookingRepository.List().Where(c => _userRolesService.RoleAccessResolver().Contains(_roomRepository.GetById(c.RoomId).DormitoryId)).ToList().Where(x => x.CreatedOn.ToString("d dddd") == baselineDate.ToString("d dddd")).Count();
            return count;
        }

        private Charts BookingsPerWeekAllCode(DateTime EndDate, DateTime startDate)
        {
         
            var dates = new List<DateTime>();
            var Labels = new List<string>();
            var Data = new List<int>();

            for (var dt = startDate; dt <= EndDate; dt = dt.AddDays(1))
            {
                Labels.Add(dt.ToString("d dddd"));
                Data.Add(BookingsPerWeekCounter(dt));
            }

            var data = new Charts
            {
                Labels = Labels,
                Data = Data,

            };

            return data;
        }

        private int BookingsPerMonthCounter(DateTime baselineDate)
        {
            var count = _bookingRepository.List().Where(c => _userRolesService.RoleAccessResolver().Contains(_roomRepository.GetById(c.RoomId).DormitoryId)).ToList().Where(x => x.CreatedOn.ToString("MMMM d") == baselineDate.ToString("MMMM d")).Count();
            return count;
        }

        private Charts BookingsPerMonthAllCode(DateTime EndDate, DateTime startDate)
        {
         
            var dates = new List<DateTime>();
            var Labels = new List<string>();
            var Data = new List<int>();

            for (var dt = startDate; dt <= EndDate; dt = dt.AddDays(1))
            {
                Labels.Add(dt.ToString("MMMM d"));
                Data.Add(BookingsPerMonthCounter(dt));
            }

            var data = new Charts
            {
                Labels = Labels,
                Data = Data,

            };

            return data;
        }

        private int BookingsPerYearCounter(DateTime baselineDate)
        {
            var count = _bookingRepository.List().Where(c => _userRolesService.RoleAccessResolver().Contains(_roomRepository.GetById(c.RoomId).DormitoryId)).ToList().Where(x => x.CreatedOn.ToString("MMMM yyyy") == baselineDate.ToString("MMMM yyyy")).Count();
            return count;
        }

        private Charts BookingsPerYearAllCode(DateTime EndDate, DateTime startDate)
        {
         
            var dates = new List<DateTime>();
            var Labels = new List<string>();
            var Data = new List<int>();

            for (var dt = startDate; dt <= EndDate; dt = dt.AddMonths(1))
            {
                Labels.Add(dt.ToString("MMMM yyyy"));
                Data.Add(BookingsPerYearCounter(dt));
            }

            var data = new Charts
            {
                Labels = Labels,
                Data = Data,

            };

            return data;
        }

        public List<BookingAccountVM> GetUserBookings(string userId)
        {

            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var bookingStatus = from bookingStats in _bookingStatusRepo.List().ToList()
                                join bookingStatsTrans in _bookingStatusTransRepo.List().ToList() on bookingStats.Id equals bookingStatsTrans.BookingStatusNonTransId
                                where bookingStatsTrans.LanguageId == CurrentLanguageId
                                select new { bookingStats.Id, bookingStatsTrans.BookingStatus };

            var paymentStatus = from payStats in _paymentStatusRepo.List().ToList()
                                join payStatsTrans in _paymentStatusTransRepo.List().ToList() on payStats.Id equals payStatsTrans.PaymentStatusNonTransId
                                where payStatsTrans.LanguageId == CurrentLanguageId
                                select new { payStats.Id, payStatsTrans.PaymentStatus };



            var Bookings = from booking in _bookingRepository.List().ToList()
                           where booking.UserId==userId
                           orderby booking.Id descending
                           select new BookingAccountVM
                           {
                             
                       
                               BookingId = "#"+booking.Id.ToString(),
                               PaymentStatusId = booking.PaymentStatusId,
                               Paymentstatus = paymentStatus.Where(c => c.Id == booking.PaymentStatusId).FirstOrDefault().PaymentStatus,
                               BookingStatusId = booking.BookingStatusId,
                               BookingStatus = bookingStatus.Where(c => c.Id == booking.BookingStatusId).FirstOrDefault().BookingStatus,
                               BookingDate = booking.CreatedOn.ToString("d"),
                               DormitoryName = _dormitoryService.GetDormitoryNameById(_roomRepository.GetById(booking.RoomId).DormitoryId),
                               RoomName = _roomTransRepository.List().Where(c=>c.LanguageId==CurrentLanguageId && c.RoomNonTransId==booking.RoomId).FirstOrDefault().RoomName,
                               Price =booking.BookingTotal.ToString("N2"),
                               ReceiptImageUrl = booking.ReceiptUrl



                           };

            var model = Bookings.ToList();

            return model;
        }
    }


    public class BookingAccountVM
    {
        public string BookingId { get; set; }
        public long PaymentStatusId { get; set; }
        public string Paymentstatus { get; set; }
        public long BookingStatusId { get; set; }
        public string BookingStatus { get; set; }
        public string BookingDate { get; set; }
        public string DormitoryName { get; set; }
        public string RoomName { get; set; }
        public string Price { get; set; }
        public string ReceiptImageUrl { get; set; }
    }
    public class ReservationEdit
    {
        //student information
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentPhoneNumber { get; set; }
        public string StudentAddress1 { get; set; }
        public string StudentAddress2 { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string ZipCode { get; set; }


        public string ReceiptUrl { get; set; }
        [Display(Name = "Booking Status",
        Description = "The status of the booking"), DataType(DataType.Text), MaxLength(256)]
        public string BookingStatus { get; set; }

        [Display(Name = "Booking Order Number",
        Description = "The unique number of this booking order."), DataType(DataType.Text), MaxLength(256)]
        public string BookingOrderNumber { get; set; }

        [Display(Name = "Dormitory",
        Description = "A dormitory name in which this booking order was placed."), DataType(DataType.Text), MaxLength(256)]
        public string Dormitory { get; set; }

        public long RoomId { get; set; }

        [Display(Name = "Student",
        Description = "The customer who placed this booking order."), DataType(DataType.Text), MaxLength(256)]
        public string Student { get; set; }

        [Display(Name = "Student Ip Address",
        Description = "Student IP address"), DataType(DataType.Text), MaxLength(256)]
        public string StudentIpAddress { get; set; }

        [Display(Name = "Booking Order Subtotal",
        Description = "The subtotal of this booking order."), DataType(DataType.Text), MaxLength(256)]
        public string BookingOrderSubtotal { get; set; }

        [Display(Name = "Booking Fee",
        Description = "The total shipping cost for this booking order."), DataType(DataType.Text), MaxLength(256)]
        public string BookingFee { get; set; }

        [Display(Name = "Booking Total",
        Description = "The total cost of this booking order(includes discounts, booking fee & tax)."), DataType(DataType.Text), MaxLength(256)]
        public string BookingTotal { get; set; }

        [Display(Name = "Profit",
        Description = "Profit of this order."), DataType(DataType.Text), MaxLength(256)]
        public string Profit { get; set; }

        [Display(Name = "Payment receipt",
        Description = "The payment receipt used for this transaction."), DataType(DataType.Text), MaxLength(256)]
        public string PaymentMethod { get; set; }


        [Display(Name = "Payment Status",
        Description = "The status of the payment."), DataType(DataType.Text), MaxLength(256)]
        public string PaymentStatus { get; set; }

        [Display(Name = "Created On",
        Description = "The date/time the booking order was placed/created."), DataType(DataType.Text), MaxLength(256)]
        public string CreatedOn { get; set; }


        [Display(Name = "Student information",
    Description = "The Student information"), DataType(DataType.Text), MaxLength(256)]
        public string StudentInformation { get; set; }


    public OrderNotesTab orderNotesTab { get; set; }
    }

    public class BillingAddressTable
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string ZipPostalCode { get; set; }
        public string Country { get; set; }

    }

    public class RoomResevationTable
    {
        public string Picture { get; set; }
        public string RoomName { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string Discount { get; set; }
        public string Total { get; set; }
        public string Edit { get; set; }

    }

    public class OrderNotesTable
    {
        public string CreatedOn { get; set; }
        public string Note { get; set; }
        public string AttachedFile { get; set; }
        public string DisplayToStudent { get; set; }
        public string Delete { get; set; }

    }


    public class OrderNotesTab
    {
        [Display(Name = "Note",
        Description = "A note about booking."), DataType(DataType.Text), MaxLength(256)]
        public string Note { get; set; }

        [Display(Name = "Attached file",
      Description = "Attached file to this to the order note, e.g booking receipt an so on.")]
        public bool AttachedFile { get; set; }


        [Display(Name = "Display to customer",
      Description = "Check this option to display this booking note to customer")]
        public bool DisplayToStudent { get; set; }

    }

    public class LatestBookingsTable
    {
        public long DormitoryId { get; set; }
        public string OrderNo { get; set; }
        public long BookingStatusId { get; set; }
        public string OrderStatus { get; set; }
        public string Customer { get; set; }
        public string CreatedOn { get; set; }
        //public button View { get; set; }


    }

    public class BookingCartViewModel
    {
        public string DormitoryName { get; set; }
        public string DormitoryLogoUrl { get; set; }
        public string RoomName { get; set; }
        public string RoomBlock { get; set; }
        public string RoomSize { get; set; }
        public string AmountTotal { get; set; }
        public string StayDuration { get; set; }
        public string RoomPricePerSemester { get; set; }

        public string SubtotalAmount { get; set; }
        public string BookingFee { get; set; }
        public string TaxAmount { get; set; }
    }

    public class BookingCheckoutCustomerInfoViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentNumber { get; set; }
        public string ParmanentAddress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string DateBookingExpiresWithoutConfirmation { get; set; }
        public int NumberOfWorkingDaysBeforeBookingExpires { get; set; }
        public BookingCartViewModel BookingDetails { get; set; }
        //summary

    }



    public class ReservationListTable
    {
        public long DormitoryId { get; set; }
        public long PaymentStatusId{ get; set; }
        public long BookingStatusId
        { get; set; }
        public string BookingNo { get; set; }
        public string BookingStatus { get; set; }
        public string PaymentStatus { get; set; }
        public string cancellationDate { get; set; }
        public double cancellationDays { get; set; }
        public string User { get; set; }
        public string CreatedOn { get; set; }
        public string BookingTotal { get; set; }
        public string View { get; set; }
    }
}
