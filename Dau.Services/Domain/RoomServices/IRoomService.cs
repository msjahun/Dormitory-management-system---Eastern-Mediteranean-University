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
        List<DormitoryRoomsTable> GetRoomsByDormitoryIdListTable(long DormitoryId);
        string GetRoomWithLowestDealByDormitoryId(long DormitoryId, long languageId);
        List<RoomsListTable> GetRoomsListTableByRoomId(long Id);
    }
}