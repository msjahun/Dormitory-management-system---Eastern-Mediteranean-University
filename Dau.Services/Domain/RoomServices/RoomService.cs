using Dau.Core.Domain.Catalog;
using Dau.Data.Repository;
using Dau.Services.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.RoomServices
{
   public class RoomService : IRoomService
    {
        private readonly ILanguageService _languageService;
        private readonly IRepository<RoomTranslation> _roomTransRepo;
        private readonly IRepository<Room> _roomRepo;
        private readonly IRepository<Dormitory> _dormitoryRepo;
        private readonly IRepository<DormitoryTranslation> _dormitoryTransRepo;
        private readonly IRepository<RoomCatalogImage> _roomImageRepo;
        private readonly IRepository<CatalogImage> _imageRepo;

        public RoomService(
            ILanguageService languageService,
            IRepository<Room> roomRepository,
            IRepository<RoomTranslation> roomTransRepository,
            IRepository<Dormitory> dormitoryRepository,
            IRepository<DormitoryTranslation> dormitoryTransRepository,
            IRepository<RoomCatalogImage> roomImageRepository,
            IRepository<CatalogImage> imageRepository)
        {
            _languageService = languageService;
            _roomTransRepo =roomTransRepository;
           _roomRepo = roomRepository;
            _dormitoryRepo=dormitoryRepository;
            _dormitoryTransRepo=dormitoryTransRepository;
            _roomImageRepo=roomImageRepository;
            _imageRepo=imageRepository;


        }

        public int GetNumberOfRoomsWithLowQuota()
        {
            var roomswithLowQuota = from room in _roomRepo.List().ToList()
                                    where room.NoRoomQuota < 5
                                    select room;

            return roomswithLowQuota.ToList().Count;

        }

        public List<RoomsListTable> GetRoomsListTable()
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var rooms = from room in _roomRepo.List().ToList()
                        join roomTrans in _roomTransRepo.List().ToList() on room.Id equals roomTrans.RoomNonTransId
                        where roomTrans.LanguageId == CurrentLanguageId
                        select new { room.Id, roomTrans.RoomName, room.NoRoomQuota, room.Price, room.Published, room.SKU, room.DormitoryId};

            var dormitory = from dorm in _dormitoryRepo.List().ToList()
                            join dormTrans in _dormitoryTransRepo.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                            where dormTrans.LanguageId == CurrentLanguageId
                            select new { dorm.Id, dormTrans.DormitoryName };

            var RoomImages = from roomImage in _roomImageRepo.List().ToList()
                             join Image in _imageRepo.List().ToList() on roomImage.CatalogImageId equals Image.Id
                             select new { roomImage.RoomId, Image.ImageUrl, Image.Published };

            var RoomDormitory = from room in rooms.ToList()
                                join dorm in dormitory.ToList() on room.DormitoryId equals dorm.Id
                                select new RoomsListTable
                                {
                                    dormitoryName = dorm.DormitoryName,
                                    dormitoryId = dorm.Id,
                                    roomId = room.Id,
                                    Picture = RoomImages.ToList().Where(c=> c.RoomId == room.Id).FirstOrDefault().ImageUrl,
                                    RoomName = room.RoomName,
                                    SKU = room.SKU,
                                    Price = room.Price,
                                    Quota = room.NoRoomQuota,
                                    Published = room.Published
                                };

            var model = RoomDormitory.ToList();
            return model;
        }
    }


    public class RoomsListTable
    {
        public string dormitoryName { get; set; }
        public long dormitoryId { get; set; }
        public long roomId { get; set; }
        public string Picture { get; set; }
        public string RoomName { get; set; }
        public string SKU { get; set; }
        public double Price { get; set; }
        public int Quota { get; set; }
        public bool Published { get; set; }
        //public string Edit { get; set; }
    }
}
