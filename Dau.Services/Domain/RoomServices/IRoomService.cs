using System.Collections.Generic;

namespace Dau.Services.Domain.RoomServices
{
    public interface IRoomService
    {
        int GetNumberOfRoomsWithLowQuota();
        List<RoomsListTable> GetRoomsListTable();
        long AddRoom(RoomViewCrud vm);
        RoomViewCrud GetRoomById(long id);
         bool   updateRoom(RoomViewCrud vm);
        bool Delete(RoomViewCrud vm);
        List<PicturesTable> GetRoomImagesTables(long id);
    }
}