using System.Collections.Generic;

namespace Dau.Services.Domain.RoomServices
{
    public interface IRoomService
    {
        int GetNumberOfRoomsWithLowQuota();
        List<RoomsListTable> GetRoomsListTable();
        long AddRoom(RoomAdd vm);
    }
}