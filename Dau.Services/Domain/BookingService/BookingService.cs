using Dau.Core.Domain.Bookings;
using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Users;
using Dau.Data.Repository;
using Dau.Services.Languages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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
          IHttpContextAccessor httpContextAccessor
            )
        {
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
                        select new { room.Id, room.DormitoryId, room.DormitoryBlockId, roomTrans.RoomName, room.Price, room.PriceOld, room.ShowPrice, room.RoomsQuota, room.RoomSize };

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
                                          room.RoomsQuota,
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
                                    room.RoomsQuota,
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
                               RoomPricePerSemester = String.Format("${0} USD",room.Price.ToString("N2")),
                               AmountTotal = String.Format("${0} USD", room.Price.ToString("N2")),
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
            //    RoomPricePerSemester = "$900 USD",
            //    AmountTotal = "$1,800 USD",
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
                        select new { room.Id, room.DormitoryId, room.DormitoryBlockId, roomTrans.RoomName, room.Price, room.PriceOld, room.ShowPrice, room.RoomsQuota, room.RoomSize, room.TaxAmount, room.BookingFee};

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
                                    room.RoomsQuota,
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
                               RoomPricePerSemester = String.Format("${0} ", room.Price.ToString("N2")),
                               AmountTotal = String.Format("${0} ",( room.Price+room.BookingFee+room.TaxAmount).ToString("N2")),
                               DormitoryLogoUrl = room.DormitoryLogoUrl,
                               TaxAmount = String.Format("${0} ", room.TaxAmount.ToString("N2")),
                               BookingFee = String.Format("${0} ", room.BookingFee.ToString("N2")),
                               StayDuration = semesterPeriods.Where(c=> c.Id == cart.SemesterPeriodId).FirstOrDefault().SemesterPeriodName,
                               SubtotalAmount = String.Format("${0} ", room.Price.ToString("N2"))
                          
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
                        select new { room.Id, room.DormitoryId, room.DormitoryBlockId, roomTrans.RoomName, room.Price, room.PriceOld, room.ShowPrice, room.RoomsQuota, room.RoomSize, room.TaxAmount, room.BookingFee };

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
                                    room.RoomsQuota,
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
                               RoomPricePerSemester = String.Format("${0} ", room.Price.ToString("N2")),
                               AmountTotal = String.Format("${0} ", (room.Price + room.BookingFee + room.TaxAmount).ToString("N2")),
                               DormitoryLogoUrl = room.DormitoryLogoUrl,
                               TaxAmount = String.Format("${0} ", room.TaxAmount.ToString("N2")),
                               BookingFee = String.Format("${0} ", room.BookingFee.ToString("N2")),
                               StayDuration = semesterPeriods.Where(c => c.Id == cart.SemesterPeriodId).FirstOrDefault().SemesterPeriodName,
                               SubtotalAmount = String.Format("${0} ", room.Price.ToString("N2"))

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
            var Cart = new Cart
            {
                RoomId = RoomId,
                UserId = CurrentUserId,
                SemesterPeriodId = CurrentSemesterId  // fix this 
            };
            _cartRepository.Insert(Cart);
            return true;
        }


        public int  GetTotalNumberOfBookings()
        {
            return _bookingRepository.List().ToList().Count;
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



            var Bookings = from booking in _bookingRepository.List().ToList()
                           select new ReservationListTable
                           {
                               BookingNo = booking.Id.ToString(),
                               BookingStatus = bookingStatus.Where(c => c.Id == booking.BookingStatusId).FirstOrDefault().BookingStatus,
                               PaymentStatus = paymentStatus.Where(p => p.Id == booking.PaymentStatusId).FirstOrDefault().PaymentStatus,
                               User = _userManager.Users.Where(c => c.Id == booking.UserId).FirstOrDefault().UserName,
                               CreatedOn = booking.CreatedOn.ToString("d"),
                               BookingTotal = booking.BookingTotal.ToString("N2"),


                           };

            return Bookings.ToList();
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
                           select new LatestBookingsTable
                           {
                               OrderNo = booking.Id.ToString(),
                               OrderStatus = bookingStatus.Where(c => c.Id == booking.BookingStatusId).FirstOrDefault().BookingStatus,
                               Customer = _userManager.Users.Where(c => c.Id == booking.UserId).FirstOrDefault().UserName,
                               CreatedOn = booking.CreatedOn.ToString("d"),
                              


                           };

            return Bookings.ToList();
        }

    }


    public class LatestBookingsTable
    {
        public string OrderNo { get; set; }
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
        public string BookingNo { get; set; }
        public string BookingStatus { get; set; }
        public string PaymentStatus { get; set; }
        public string User { get; set; }
        public string CreatedOn { get; set; }
        public string BookingTotal { get; set; }
        public string View { get; set; }
    }
}
