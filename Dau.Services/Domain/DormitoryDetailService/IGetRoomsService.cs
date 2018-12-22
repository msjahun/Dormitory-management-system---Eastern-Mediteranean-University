using System.Collections.Generic;

namespace Dau.Services.Domain.DormitoryDetailService
{
    public interface IGetRoomsService
    {
        List<RoomSectionViewModel> GetRooms(long DormitoryId);
    }
}