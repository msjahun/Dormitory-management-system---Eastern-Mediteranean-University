using System.Collections.Generic;
using Dau.Services.Domain.DormitoryServices;
using Dau.Services.Domain.RoomServices;

namespace Dau.Services.Domain.FeaturesServices
{
    public interface IFeaturesService
    {
        bool AddDormitoryFeature(FacilitiesTabDormitory vm);
        bool AddRoomFeature(FacilitiesTab vm);
        List<DormitoryFeaturesTable> GetDormitoryFeatures(long DormitoryId);
        List<FeaturesCategoryTable> GetFeaturesCategoryTablesList();
        List<PopularFiltersTable> GetFeaturesHitCount();
        List<FeaturesTable> GetFeaturesTableList();
        List<RoomFeaturesTable> GetRoomFeatures(long RoomId);
        bool RemoveDormitoryFeature(FacilitiesTabDormitory vm);
        bool RemoveRoomFeature(FacilitiesTab vm);
        bool UpdateFeaturesHitCount(List<long> FeaturesIds);
        long AddNewFeature(FeaturesCrud vm);
        FeaturesCrud GetFeatureById(long id);
        bool UpdateFeature(FeaturesCrud vm);
        bool DeleteFeature(FeaturesCrud vm);
        bool RemoveFeatureIcon(long id);
    }
}