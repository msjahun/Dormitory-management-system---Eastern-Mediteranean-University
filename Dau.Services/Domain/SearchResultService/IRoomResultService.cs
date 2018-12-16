using System.Collections.Generic;

namespace Dau.Services.Domain.SearchResultService
{
    public interface IRoomResultService
    {
        List<RoomResultViewModel> GetRoomResult();
    }
}