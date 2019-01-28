using Dau.Core.Domain.Catalog;
using Dau.Data;
using Dau.Data.Repository;
using Dau.Services.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Dau.Services.Domain.CurrencyServices;

namespace Dau.Services.Domain.DormitoryDetailService
{
 public   class GetRoomsService : IGetRoomsService
    {
        private readonly IRepository<Room> _roomRepo;
        private readonly ICurrencyService _currencyService;
        private readonly IRepository<RoomTranslation> _roomTransRepo;
        private readonly IRepository<Dormitory> _dormitoryRepo;
        private readonly IRepository<DormitoryBlockTranslation> _dormitoryBlockTransRepo;
        private readonly ILanguageService _languageService;
      

        public GetRoomsService(
            IRepository<Room> roomRepo,
            IRepository<RoomTranslation> roomTransRepo,
            IRepository<Dormitory> dormitoryRepo,
            ILanguageService languageService,
            IRepository<DormitoryBlockTranslation> dormitoryBlockTransRepo,
            ICurrencyService currencyService
          



            )
        {

            _dormitoryBlockTransRepo = dormitoryBlockTransRepo;
            _languageService = languageService;
            _roomRepo = roomRepo;
            _currencyService = currencyService;
         
            _roomTransRepo = roomTransRepo;
            _dormitoryRepo= dormitoryRepo;
         
        }

        public List<RoomSectionViewModel> GetRooms(long DormitoryId)
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
           

           // var rooms = from DormRooms in _dbContext.Dormitory.Include(d=> d.Rooms).ToList().Where(c => c.Id == DormitoryId).FirstOrDefault().Rooms.ToList()
            var rooms = from room in _roomRepo.List().ToList()
                        join roomTrans in _roomTransRepo.List().ToList() on room.Id equals roomTrans.RoomNonTransId
                        where roomTrans.LanguageId == CurrentLanguageId && room.DormitoryId == DormitoryId && room.Published==true
                        select new RoomSectionViewModel
                              {
                                  RoomId = room.Id,
                                  RoomName = roomTrans.RoomName,
                                  DormitoryBlock = _dormitoryBlockTransRepo.List().Where(_=>_.LanguageId==CurrentLanguageId && _.DormitoryBlockNonTransId==room.DormitoryBlockId).FirstOrDefault().Name,
                                  GenderAllocation = roomTrans.GenderAllocation,
                                  NoOfStudents = room.NoOfStudents,
                                  BedType = roomTrans.BedType,
                                  PriceCash = _currencyService.CurrencyFormatterByRoomId(room.Id, room.PriceCash),
                                  PriceInstallment = _currencyService.CurrencyFormatterByRoomId(room.Id, room.PriceInstallment),

                                  PriceOldCash  = (room.PriceOldCash > 0 && room.PriceOldCash>room.PriceCash)
                                  ? _currencyService.CurrencyFormatterByRoomId(room.Id, room.PriceOldCash) : null,


                                  MinBookingAmount= _currencyService.CurrencyFormatterByRoomId(room.Id, room.MinBookingFee) ,
                                  RoomsQuota = room.NoRoomQuota,
                                  HasDeposit = room.HasDeposit,
                            PaymentPerSemesterNotYear = room.PaymentPerSemesterNotYear,
                            ShowPrice = room.ShowPrice,
                            PercentageOff = room.PercentageOff, //from database
                            DealEndTime = room.DealEndTime, //change this to come from db

                            DisplayDeal = (room.DealEndTime > DateTime.Now.AddDays(-2)),
                        };





            List<RoomSectionViewModel> modelList = rooms.ToList();

            return modelList;
        }
    }

    public class RoomSectionViewModel
    {
        public long RoomId { get; set; }
        public string RoomName { get; set; }
        public string GenderAllocation { get; set; }
        public int NoOfStudents { get; set; }
        public string DormitoryBlock { get; set; }
        public string BedType { get; set; }

        public bool PaymentPerSemesterNotYear { get; set; }
        public string PriceCash { get; set; }
        public string PriceInstallment { get; set; }
        public string PriceOldCash { get; set; }
        public string MinBookingAmount { get; set; }
        public int RoomsQuota { get; set; }
        public bool HasDeposit { get; set; }
        public bool ShowPrice { get; set; }
        public DateTime DealEndTime { get; set; }
        public bool DisplayDeal { get; set; }
        public int PercentageOff { get; set; }

    }
}
