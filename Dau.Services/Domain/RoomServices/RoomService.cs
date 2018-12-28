using Dau.Core.Domain.Catalog;
using Dau.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.RoomServices
{
   public class RoomService : IRoomService
    {
        private readonly IRepository<Room> _roomRepo;

        public RoomService(
            IRepository<Room> roomRepository)
        {
            _roomRepo = roomRepository;


        }

        public int GetNumberOfRoomsWithLowQuota()
        {
            var roomswithLowQuota = from room in _roomRepo.List().ToList()
                                    where room.NoRoomQuota < 5
                                    select room;

            return roomswithLowQuota.ToList().Count;

        }
    }
}
