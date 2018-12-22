namespace Dau.Services.Domain.DormitoryDetailService
{
    public interface IGetSpecificRoomService
    {
        SpecificRoomViewModel GetSpecificRoom(long RoomId);
    }
}