using Dau.Services.Domain.RoomServices;
using System.Collections.Generic;
using static Dau.Services.Domain.FeaturesServices.FeaturesService;

namespace Dau.Services.Domain.FeaturesServices
{
    public interface IFeaturesService
    {
        List<PopularFiltersTable> GetFeaturesHitCount();
        bool UpdateFeaturesHitCount(List<int> FeaturesIds);
        List<RoomFeaturesTable> GetRoomFeatures(long RoomId);
        bool AddRoomFeature(FacilitiesTab vm);
        bool RemoveRoomFeature(FacilitiesTab vm);
    }
}