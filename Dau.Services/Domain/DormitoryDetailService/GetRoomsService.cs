using Dau.Core.Domain.Catalog;
using Dau.Data;
using Dau.Data.Repository;
using Dau.Services.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Dau.Services.Domain.DormitoryDetailService
{
 public   class GetRoomsService : IGetRoomsService
    {
        private readonly IRepository<Room> _roomRepo;
        private readonly IRepository<RoomTranslation> _roomTransRepo;
        private readonly IRepository<Dormitory> _dormitoryRepo;
        private readonly ILanguageService _languageService;
      

        public GetRoomsService(
            IRepository<Room> roomRepo,
            IRepository<RoomTranslation> roomTransRepo,
            IRepository<Dormitory> dormitoryRepo,
            ILanguageService languageService
          



            )
        {

            _languageService = languageService;
            _roomRepo = roomRepo;
         
            _roomTransRepo = roomTransRepo;
            _dormitoryRepo= dormitoryRepo;
         
        }

        public List<RoomSectionViewModel> GetRooms(long DormitoryId)
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
           

           // var rooms = from DormRooms in _dbContext.Dormitory.Include(d=> d.Rooms).ToList().Where(c => c.Id == DormitoryId).FirstOrDefault().Rooms.ToList()
            var rooms = from room in _roomRepo.List().ToList()
                        join roomTrans in _roomTransRepo.List().ToList() on room.Id equals roomTrans.RoomNonTransId
                        where roomTrans.LanguageId == CurrentLanguageId && room.DormitoryId == DormitoryId
                        select new RoomSectionViewModel
                              {
                                  RoomId = room.Id,
                                  RoomName = roomTrans.RoomName,
                                  DormitoryBlock = "A block",
                                  GenderAllocation = roomTrans.GenderAllocation,
                                  NoOfStudents = room.NoOfStudents,
                                  BedType = roomTrans.BedType,
                                  Price = room.Price.ToString("N2"),
                                  PriceOld  = (room.PriceOld > 0) ? room.PriceOld.ToString("N2") : null,
                                  RoomsQuota = room.NoRoomQuota,
                                  HasDeposit = room.HasDeposit,
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
        public string Price { get; set; }
        public string PriceOld { get; set; }
        public int RoomsQuota { get; set; }
        public bool HasDeposit { get; set; }
        public bool ShowPrice { get; set; }
        public DateTime DealEndTime { get; set; }
        public bool DisplayDeal { get; set; }
        public int PercentageOff { get; set; }

    }
}
