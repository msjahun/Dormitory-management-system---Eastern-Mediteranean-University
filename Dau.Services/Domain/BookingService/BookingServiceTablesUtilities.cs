using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.BookingService
{
    public partial class BookingService
    {

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
                           {
                               DormitoryId = _roomRepository.GetById(booking.RoomId).DormitoryId,
                               BookingNo = booking.Id.ToString(),
                               BookingStatus = bookingStatus.Where(c => c.Id == booking.BookingStatusId).FirstOrDefault().BookingStatus,
                               PaymentStatus = paymentStatus.Where(p => p.Id == booking.PaymentStatusId).FirstOrDefault().PaymentStatus,
                               PaymentStatusId = booking.PaymentStatusId,
                               BookingStatusId = booking.BookingStatusId,
                               User = _userManager.Users.Where(c => c.Id == booking.UserId).FirstOrDefault().UserName,
                               CreatedOn = booking.CreatedOn.ToString("d"),
                               cancellationDate = DaysRemaining((booking.CreatedOn.AddDays(_dormitoryRepository.GetById(_roomRepository.GetById(booking.RoomId).DormitoryId).CancelWaitDays) - DateTime.Now).TotalDays),
                               cancellationDays = (booking.CreatedOn.AddDays(_dormitoryRepository.GetById(_roomRepository.GetById(booking.RoomId).DormitoryId).CancelWaitDays) - DateTime.Now).TotalDays,
                               BookingTotal = _currencyService.CurrencyFormatterByRoomId(booking.RoomId, booking.BookingTotal),


                           };

            return Bookings.Where(c => _userRolesService.RoleAccessResolver().Contains(c.DormitoryId)).ToList();
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
                           {
                               DormitoryId = _roomRepository.GetById(booking.RoomId).DormitoryId,
                               OrderNo = booking.Id.ToString(),

                               OrderStatus = bookingStatus.Where(c => c.Id == booking.BookingStatusId).FirstOrDefault().BookingStatus,
                               BookingStatusId = booking.BookingStatusId,
                               Customer = _userManager.Users.Where(c => c.Id == booking.UserId).FirstOrDefault().UserName,
                               CreatedOn = booking.CreatedOn.ToString("d"),



                           };

            return Bookings.Where(c => _userRolesService.RoleAccessResolver().Contains(c.DormitoryId)).ToList();
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
                           where booking.UserId == userId
                           orderby booking.Id descending
                           select new BookingAccountVM
                           {


                               BookingId = "#" + booking.Id.ToString(),
                               PaymentStatusId = booking.PaymentStatusId,
                               Paymentstatus = paymentStatus.Where(c => c.Id == booking.PaymentStatusId).FirstOrDefault().PaymentStatus,
                               BookingStatusId = booking.BookingStatusId,
                               BookingStatus = bookingStatus.Where(c => c.Id == booking.BookingStatusId).FirstOrDefault().BookingStatus,
                               BookingDate = booking.CreatedOn.ToString("d"),
                               DormitoryName = _dormitoryService.GetDormitoryNameById(_roomRepository.GetById(booking.RoomId).DormitoryId),
                               RoomName = _roomTransRepository.List().Where(c => c.LanguageId == CurrentLanguageId && c.RoomNonTransId == booking.RoomId).FirstOrDefault().RoomName,
                               Price = _currencyService.CurrencyFormatterByRoomId(booking.RoomId, booking.BookingTotal),
                               ReceiptImageUrl = booking.ReceiptUrl



                           };

            var model = Bookings.ToList();

            return model;
        }

        public List<CurrentBookingWishListTable> GetBookingCartsListTable()
        {

            //  var CurrentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
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
                            room.MinBookingFee
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

                                          room.MinBookingFee
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
                                    dorm.DormitoryLogoUrl
                                };

            var semesterPeriods = from semPeriod in _SemesterPeriodRepo.List().ToList()
                                  join semPeriodTrans in _semesterPeriodTransRepo.List().ToList() on semPeriod.Id equals semPeriodTrans.SemesterPeriodNonTransId
                                  where semPeriodTrans.LanguageId == CurrentLanguageId
                                  select new { semPeriod.Id, semPeriodTrans.SemesterPeriodName };



            var CartRoom = from cart in _cartRepository.List().ToList()
                           join room in roomDormitory.ToList() on cart.RoomId equals room.Id
                           select new CurrentBookingWishListTable
                           {
                               UserId = cart.UserId,
                               User = _userManager.Users.Where(c => c.Id == cart.UserId).FirstOrDefault().Email,
                               DormitoryId = room.DormitoryId,
                               RoomId = room.Id,
                               DormitoryBlock = room.DormitoryBlockName,
                               DormitoryName = room.DormitoryName,
                               RoomName = room.RoomName,
                               Semester = semesterPeriods.Where(c => c.Id == cart.SemesterPeriodId).FirstOrDefault().SemesterPeriodName,
                               CartTotalAmount = _currencyService.CurrencyFormatterByRoomId(room.Id, room.PriceCash),
                               CartSubTotal = _currencyService.CurrencyFormatterByRoomId(room.Id, room.PriceCash),
                               DateCreated = cart.CreatedOn.ToString()

                           };


            return CartRoom.ToList();
        }

        public List<RoomsNeverBookedTable> GetRoomsNeverBookedTable()
        {
            var RoomsBookedIds = _bookingRepository.List().ToList().Select(c => c.RoomId);

            var CurrentLanguageId = _languageService.GetCurrentLanguageId();


            var model = from room in _roomRepository.List().ToList()

                        select new RoomsNeverBookedTable
                        {
                            DormitoryName = _dormitoryService.GetDormitoryNameById(_roomRepository.GetById(room.Id).DormitoryId),
                            RoomId = room.Id,
                            DormitoryBlock = _dormitoryBlockTransRepo.List().Where(c => c.LanguageId == CurrentLanguageId &&
                                              c.DormitoryBlockNonTransId == _roomRepository.GetById(room.Id).DormitoryBlockId)
                                             .FirstOrDefault().Name,
                            RoomName = _roomTransRepository.List().Where(c => c.LanguageId == CurrentLanguageId && c.RoomNonTransId == room.Id).FirstOrDefault().RoomName,

                        };

            model = model.Where(c => !RoomsBookedIds.Contains(c.RoomId)).ToList();

            return model.ToList();
        }

        public List<BestSellerRoomsTable> GetBestSellerRoomsTable()
        {
            var model = GetBestSellerRooms();
            return model.OrderByDescending(_ => _.TotalAmount).ToList();
        }

        public List<BestSellerRoomsTable> GetBestSellerRoomsByPriceDashboardTable()
        {
            var model = GetBestSellerRooms();
            return model.OrderByDescending(_ => _.TotalAmount).Take(10).ToList();
        }

        public List<BestSellerRoomsTable> GetBestSellerRoomsByQuantityDashboardTable()
        {
            var model = GetBestSellerRooms();
            return model.OrderByDescending(_ => _.TotalQuantity).Take(10).ToList();
        }

        private List<BestSellerRoomsTable> GetBestSellerRooms()
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            //var results = from line in Lines
            //              group line by line.ProductCode into g
            //              select new ResultLine
            //              {
            //                  ProductName = g.First().Name,
            //                  Price = g.Sum(_ => _.Price).ToString(),
            //                  Quantity = g.Count().ToString(),
            //              };

            var model = from booking in _bookingRepository.List().ToList()
                        group booking by booking.RoomId into g
                        select new BestSellerRoomsTable
                        {
                            DormitoryName = _dormitoryService.GetDormitoryNameById(_roomRepository.GetById(g.First().RoomId).DormitoryId),
                            RoomId = g.First().RoomId,
                            DormitoryBlock = _dormitoryBlockTransRepo.List().Where(c => c.LanguageId == CurrentLanguageId &&
                                              c.DormitoryBlockNonTransId == _roomRepository.GetById(g.First().RoomId).DormitoryBlockId)
                                             .FirstOrDefault().Name,
                            RoomName = _roomTransRepository.List().Where(c => c.LanguageId == CurrentLanguageId && c.RoomNonTransId == g.First().RoomId).FirstOrDefault().RoomName,

                            TotalAmount = _currencyService.CurrencyFormatterByRoomId(g.First().RoomId, g.Sum(_ => _.BookingTotal)),
                            TotalQuantity = g.Count()

                        };

            return model.ToList();

        }

    }
}
