using Dau.Core.Domain.Bookings;
using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Users;
using Dau.Data.Repository;
using Dau.Services.Domain.CurrencyServices;
using Dau.Services.Domain.DormitoryServices;
using Dau.Services.Domain.ImageServices;
using Dau.Services.Domain.PriceCalculationService;
using Dau.Services.Event;
using Dau.Services.Languages;
using Dau.Services.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Dau.Services.Domain.BookingService
{
    public partial class BookingService : IBookingService
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
        private readonly IPriceCalculationService _priceCalcService;
        private readonly ICurrencyService _currencyService;
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
           IEventService eventService,
            ICurrencyService currencyService,
            IPriceCalculationService priceCalculationService
            )
        {
            _priceCalcService = priceCalculationService;
            _currencyService = currencyService;
            _eventService = eventService;
            _dormitoryService = dormitoryService;
            _userRolesService = userRolesService;
            _imageService = imageService;
            _languageService = languageService;
            _dormitoryBlockRepo = DormitoryBlockRepository;
            _dormitoryBlockTransRepo = DormitoryBlockTranslationRepository;
            _cartRepository = CartRepository;
            _roomRepository = RoomRepository;
            _roomTransRepository = RoomTransRepository;
            _dormitoryRepository = DormitoryRepository;
            _dormitoryTranslationRepository = DormitoryTranslationRepository;
            _SemesterPeriodRepo = SemesterPeriodRepository;
            _semesterPeriodTransRepo = semesterPeriodTransRepository;
            _bookingRepository = bookingRepository;
            _cancelBookingRequests = cancelBookingRequests;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;


            _bookingStatusRepo = bookingStatusRepository;
            _bookingStatusTransRepo = bookingStatusTransRepository;
            _paymentStatusRepo = paymentStatusRepository;
            _paymentStatusTransRepo = paymentStatusTransRepository;

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
                        select new
                        {
                            room.Id,
                            room.DormitoryId,
                            room.DormitoryBlockId,
                            roomTrans.RoomName,
                            room.PriceCash,
                            room.PriceOldCash,
                            room.PriceInstallment,
                            room.PriceOldInstallment,
                            room.ShowPrice,
                            room.NoRoomQuota,
                            room.RoomSize,
                            room.MinBookingFee,
                            room.PaymentPerSemesterNotYear
                        };

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
                                          room.PriceCash,
                                          room.PriceOldCash,
                                          room.PriceInstallment,
                                          room.PriceOldInstallment,
                                          room.ShowPrice,
                                          room.NoRoomQuota,
                                          room.RoomSize,

                                          room.MinBookingFee,
                                          room.PaymentPerSemesterNotYear
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
                                    room.PriceCash,
                                    room.PriceOldCash,
                                    room.PriceInstallment,
                                    room.PriceOldInstallment,
                                    room.ShowPrice,
                                    room.NoRoomQuota,
                                    room.RoomSize,

                                    room.MinBookingFee,
                                    dorm.DormitorySeoId,
                                    dorm.DormitoryName,
                                    dorm.DormitoryLogoUrl,
                                    room.PaymentPerSemesterNotYear
                                };

            var semesterPeriods = from semPeriod in _SemesterPeriodRepo.List().ToList()
                                  join semPeriodTrans in _semesterPeriodTransRepo.List().ToList() on semPeriod.Id equals semPeriodTrans.SemesterPeriodNonTransId
                                  where semPeriodTrans.LanguageId == CurrentLanguageId
                                  select new { semPeriod.Id, semPeriodTrans.SemesterPeriodName };


            var Carts = from cart in _cartRepository.List().ToList()
                        where cart.UserId == CurrentUserId
                        select new { cart.RoomId, cart.UserId, cart.TotalAmount, cart.SemesterPeriodId };


            var dummyFinalCart = (from cart in Carts.ToList()
                                  join room in roomDormitory.ToList() on cart.RoomId equals room.Id
                                  select new
                                  {
                                      BookingStatusId = 2,
                                      PaymentStatusId = 2,
                                      UserId = CurrentUserId,
                                      CustomerIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(),
                                      BookingOrderSubtotal = room.PriceCash,
                                      BookingFee = room.MinBookingFee,
                                      BookingTotal = room.PriceCash,
                                      CreatedOn = DateTime.Now,
                                      RoomId = room.Id,
                                      room.PriceCash,
                                      cart.SemesterPeriodId,
                                      IsPricePerYear = !room.PaymentPerSemesterNotYear,


                                  }).FirstOrDefault();


            var finalCart = (from cart in Carts.ToList()
                             join room in roomDormitory.ToList() on cart.RoomId equals room.Id
                             select new Booking
                             {
                                 BookingStatusId = 2,
                                 PaymentStatusId = 2,
                                 UserId = CurrentUserId,
                                 CustomerIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(),
                                 BookingOrderSubtotal = room.PriceCash,
                                 BookingFee = room.MinBookingFee,
                                 BookingTotal = room.PriceCash,
                                 CreatedOn = DateTime.Now,
                                 RoomId = room.Id

                             }).FirstOrDefault();



            var userCart = Carts.ToList().FirstOrDefault();
            finalCart.BookingTotal = _priceCalcService.CalculateBookingTotal(dummyFinalCart.IsPricePerYear, dummyFinalCart.SemesterPeriodId, dummyFinalCart.PriceCash);

            try
            {//reduce room quota and check if room quota
                var room = _roomRepository.GetById(finalCart.RoomId);
                if (room.NoRoomQuota > 0)
                {
                    room.NoRoomQuota--;
                    _roomRepository.Update(room);
                    var bookingId = _bookingRepository.Insert(finalCart);
                    _imageService.uploadBookingReceiptImage(bookingId);
                    //_eventService.Trigger_BookingPlaced_DormitoryManagerNotification_Event(); to notify administrator of booking
                    _eventService.Trigger_BookingPlaced_DormitoryNotification_Event(bookingId);
                    _eventService.Trigger_BookingPlaced_StudentNotification_Event(bookingId);

                    if (room.NoRoomQuota <= 5)
                        _eventService.Trigger_RoomQuotaBelow_DormitoryManagerNotification_Event(room.Id);

                    return true;
                }
                else
                {
                    return false; //room quota is not enough
                }

            }
            catch
            {
                return false;
            }


        }

        public ReservationEdit GetBookingById(long BookingId)
        {
            var booking = _bookingRepository.GetById(BookingId);
            if (booking == null) return null;
            var CurrentLanguage = _languageService.GetCurrentLanguageId();
            var room = _roomRepository.GetById(booking.RoomId);

            if (!_userRolesService.IsAuthorized(room.DormitoryId)) return null;

            var dormitoryName = _dormitoryTranslationRepository.List().Where(c => c.DormitoryNonTransId == room.DormitoryId && c.LanguageId == CurrentLanguage).FirstOrDefault().DormitoryName;
            var user = _userManager.Users.Where(c => c.Id == booking.UserId).FirstOrDefault();

            var bookingStatus = _bookingStatusTransRepo.List().Where(c => c.BookingStatusNonTransId == booking.BookingStatusId && c.LanguageId == CurrentLanguage).FirstOrDefault().BookingStatus;
            var PaymentStatus = _paymentStatusTransRepo.List().Where(c => c.PaymentStatusNonTransId == booking.PaymentStatusId && c.LanguageId == CurrentLanguage).FirstOrDefault().PaymentStatus;

            var model = new ReservationEdit
            {
                BookingOrderNumber = booking.Id.ToString(),
                Dormitory = dormitoryName,
                Student = user.Email,
                StudentIpAddress = user.LastIpAddress,
                BookingOrderSubtotal = _currencyService.CurrencyFormatterByRoomId(room.Id, booking.BookingOrderSubtotal),
                BookingFee = _currencyService.CurrencyFormatterByRoomId(room.Id, booking.BookingFee),
                BookingTotal = _currencyService.CurrencyFormatterByRoomId(room.Id, booking.BookingTotal),
                ReceiptUrl = booking.ReceiptUrl,
                CreatedOn = booking.CreatedOn.ToString(),
                StudentName = user.FirstName + " " + user.LastName,
                StudentEmail = user.Email,
                StudentPhoneNumber = user.PhoneNumber,
                StudentAddress1 = booking.StudentAddress1,
                StudentAddress2 = booking.StudentAddress2,
                City = booking.City,
                RoomId = booking.RoomId,
                StateProvince = booking.StateProvince,
                ZipCode = booking.ZipCode,
                Country = booking.Country,
                PaymentStatus = PaymentStatus,
                BookingStatus = bookingStatus




            };
            return model;
        }

        //no update and delete methods to complete crud


        public int GetTotalNumberOfBookings()
        {
            //room Id and dormitoryId
            return _bookingRepository.List().Where(c => _userRolesService.RoleAccessResolver().Contains(_roomRepository.GetById(c.RoomId).DormitoryId)).ToList().Count;
        }

        public int GetTotalNumberOfCancelRequests()
        {
            return _cancelBookingRequests.List().ToList().Count;
        }

        private string DaysRemaining(double TotalDays)
        {
            int totaldays = (int)(TotalDays);
            var date = DateTime.FromOADate(TotalDays);
            return String.Format("{0} days {1} hours {2} min {3} sec left", totaldays, date.ToString("HH"), date.ToString("mm"), date.ToString("ss"));

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
                    _eventService.Trigger_BookingCompleted_StudentNotification_Event(bookingId);
                else if (newBookingStatusId == 3)
                    _eventService.Trigger_BookingCancelled_StudentNotification_Event(bookingId);

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
                    _eventService.Trigger_BookingPaid_DormitoryNotification_Event(booking.Id);
                    _eventService.Trigger_BookingPaid_StudentNotification_Event(booking.Id);
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
            else if (id == 2)
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

    }



}
