using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Dau.Core.Domain.Bookings;
namespace Dau.Services.Domain.BookingService
{
    public partial class BookingService
    {

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
                                          room.PaymentPerSemesterNotYear,
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
                                    room.PriceCash,
                                    room.PriceOldCash,
                                    room.PriceInstallment,
                                    room.PriceOldInstallment,
                                    room.PaymentPerSemesterNotYear,
                                    room.ShowPrice,
                                    room.NoRoomQuota,
                                    room.RoomSize,
                                    dorm.DormitorySeoId,
                                    dorm.DormitoryName,
                                    dorm.DormitoryLogoUrl
                                };



            var Carts = from cart in _cartRepository.List().ToList()
                        where cart.UserId == CurrentUserId
                        select new { cart.RoomId, cart.UserId, cart.TotalAmount, cart.SemesterPeriodId, cart.Id };
            var semesterPeriods = from semPeriod in _SemesterPeriodRepo.List().ToList()
                                  join semPeriodTrans in _semesterPeriodTransRepo.List().ToList() on semPeriod.Id equals semPeriodTrans.SemesterPeriodNonTransId
                                  where semPeriod.Id != 2
                                  where semPeriodTrans.LanguageId == CurrentLanguageId
                                  select new SelectListItem
                                  {
                                      Value = semPeriod.Id.ToString(),
                                      Text = semPeriodTrans.SemesterPeriodName
                                  };


            var CartRoom = from cart in Carts.ToList()
                           join room in roomDormitory.ToList() on cart.RoomId equals room.Id
                           select new BookingCartViewModel
                           {
                               SemestersList = semesterPeriods.ToList(),
                               IsPricePerYear = !room.PaymentPerSemesterNotYear,
                               DormitoryName = room.DormitoryName,
                               RoomName = room.RoomName,
                               RoomBlock = room.DormitoryBlockName,
                               RoomSize = room.RoomSize.ToString("N1") + " m2",
                               RoomPricePerSemester = _currencyService.CurrencyFormatterByRoomId(room.Id, room.PriceCash),
                               AmountTotal = _currencyService.CurrencyFormatterByRoomId(room.Id, room.PriceCash),
                               DormitoryLogoUrl = room.DormitoryLogoUrl,
                               SemesterPeriodId = cart.SemesterPeriodId,
                               CartId = cart.Id,
                               PriceRaw = room.PriceCash,
                               RoomId = room.Id
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


            var finalCart = CartRoom.FirstOrDefault();
            if (finalCart == null) return null;


            var userCart = Carts.ToList().FirstOrDefault();
            double AmountTotal = _priceCalcService.CalculateBookingTotal(finalCart.IsPricePerYear, finalCart.SemesterPeriodId, finalCart.PriceRaw);
            finalCart.AmountTotal = _currencyService.CurrencyFormatterByRoomId(finalCart.RoomId, AmountTotal);

            
            BookingCartViewModel model = finalCart;
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
                               RoomPricePerSemester = _currencyService.CurrencyFormatterByRoomId(room.Id, room.PriceCash),
                               AmountTotal = _currencyService.CurrencyFormatterByRoomId(room.Id, room.PriceCash),
                               DormitoryLogoUrl = room.DormitoryLogoUrl,
                               SemesterPeriodId = cart.SemesterPeriodId,
                               BookingFee = _currencyService.CurrencyFormatterByRoomId(room.Id, room.MinBookingFee),
                               StayDuration = semesterPeriods.Where(c => c.Id == cart.SemesterPeriodId).FirstOrDefault().SemesterPeriodName,
                               SubtotalAmount = _currencyService.CurrencyFormatterByRoomId(room.Id, room.PriceCash),
                               PriceRaw = room.PriceCash,
                               RoomId = room.Id,
                               BookingFeeRaw = room.MinBookingFee


                           };


            var finalCart = CartRoom.FirstOrDefault();
            if (finalCart == null) return null;


            var userCart = Carts.ToList().FirstOrDefault();
            double SubtotalAmount = _priceCalcService.CalculateBookingTotal(finalCart.IsPricePerYear, finalCart.SemesterPeriodId, finalCart.PriceRaw);
                double AmountTotal = _priceCalcService.CalculateBookingTotal(finalCart.IsPricePerYear, finalCart.SemesterPeriodId, finalCart.PriceRaw);

            finalCart.SubtotalAmount = _currencyService.CurrencyFormatterByRoomId(finalCart.RoomId, SubtotalAmount);
            finalCart.AmountTotal = _currencyService.CurrencyFormatterByRoomId(finalCart.RoomId, AmountTotal);


            //var CartsSemesterPeriods = from cart in Carts.ToList()
            //                           join SemPeriod in semesterPeriods.ToList() on cart.SemesterPeriodId equals SemPeriod.Id
            //                           select 

            var Users = from _user in _userManager.Users.ToList()
                        where _user.Id == CurrentUserId
                        select _user;
            var user = Users.FirstOrDefault();


            BookingCheckoutCustomerInfoViewModel model = new BookingCheckoutCustomerInfoViewModel
            {
                BookingDetails = finalCart,
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
                              select new { dorm.Id, DormitorySeoId = dorm.SeoId, dormTrans.DormitoryName, dorm.DormitoryLogoUrl, dorm.CancelWaitDays };

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
                                    dorm.DormitoryLogoUrl,
                                    dorm.CancelWaitDays
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

                               RoomPricePerSemester = _currencyService.CurrencyFormatterByRoomId(room.Id, room.PriceCash),
                               AmountTotal = _currencyService.CurrencyFormatterByRoomId(room.Id, room.PriceCash),
                               DormitoryLogoUrl = room.DormitoryLogoUrl,
                               SemesterPeriodId = cart.SemesterPeriodId,
                               BookingFee = _currencyService.CurrencyFormatterByRoomId(room.Id, room.MinBookingFee),
                               StayDuration = semesterPeriods.Where(c => c.Id == cart.SemesterPeriodId).FirstOrDefault().SemesterPeriodName,
                               SubtotalAmount = _currencyService.CurrencyFormatterByRoomId(room.Id, room.PriceCash),
                               PriceRaw = room.PriceCash,
                               RoomId = room.Id,
                               BookingFeeRaw = room.MinBookingFee,

                               CancelWaitDays = room.CancelWaitDays

                           };


            //var CartsSemesterPeriods = from cart in Carts.ToList()
            //                           join SemPeriod in semesterPeriods.ToList() on cart.SemesterPeriodId equals SemPeriod.Id
            //                           select 

            var Users = from _user in _userManager.Users.ToList()
                        where _user.Id == CurrentUserId
                        select _user;
            var user = Users.FirstOrDefault();


            var finalCart = CartRoom.FirstOrDefault();
            if (finalCart == null) return null;
           
            var userCart = Carts.ToList().FirstOrDefault();

            double SubtotalAmount = _priceCalcService.CalculateBookingTotal(finalCart.IsPricePerYear, finalCart.SemesterPeriodId, finalCart.PriceRaw);
            double AmountTotal = _priceCalcService.CalculateBookingTotal(finalCart.IsPricePerYear, finalCart.SemesterPeriodId, finalCart.PriceRaw);

            finalCart.SubtotalAmount = _currencyService.CurrencyFormatterByRoomId(finalCart.RoomId, SubtotalAmount);
            finalCart.AmountTotal = _currencyService.CurrencyFormatterByRoomId(finalCart.RoomId, AmountTotal);



            BookingCheckoutCustomerInfoViewModel model = new BookingCheckoutCustomerInfoViewModel
            {
                BookingDetails = finalCart,
                FirstName = user.FirstName,
                LastName = user.LastName,
                StudentNumber = user.StudentNumber,
                ParmanentAddress = user.ParmanentAddress,
                Country = user.Country,
                City = user.City,
                EmailAddress = user.Email,
                PhoneNumber = user.PhoneNumber,
                DateBookingExpiresWithoutConfirmation = DateTime.Now.AddDays(finalCart.CancelWaitDays).ToString("d"),
                NumberOfWorkingDaysBeforeBookingExpires = finalCart.CancelWaitDays

            };



            return model;
        }

        public bool DeleteItemFromCart()
        {
            var CurrentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var cartToDelete = (from cart in _cartRepository.List().ToList()
                                where cart.UserId == CurrentUserId
                                select cart);
            foreach (var cart in cartToDelete.ToList())
            {
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

            var oldCartItems = _cartRepository.List().Where(c => c.UserId == CurrentUserId).ToList();
            foreach (var cartItem in oldCartItems)
            {
                _cartRepository.Delete(cartItem);
            }
            var Cart = new Cart
            {
                RoomId = RoomId,
                UserId = CurrentUserId,
                SemesterPeriodId = CurrentSemesterId,  // fix this
                CreatedOn = DateTime.Now
            };
            _cartRepository.Insert(Cart);
            return true;
        }

        public bool UpdateSemesterPeriod(long id)
        {
            try
            {
                var CurrentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var cart = _cartRepository.List().ToList().Where(c => c.UserId == CurrentUserId).FirstOrDefault();
                if (cart == null) return false;
                cart.SemesterPeriodId = id;
                _cartRepository.Update(cart);

                return true;
            }
            catch
            {
                return false;
            }

        }


    }
}
