using System.Collections.Generic;

namespace Dau.Services.Domain.FeaturesServices
{
    public interface IFeaturesService
    {
        List<PopularFiltersTable> GetFeaturesHitCount();
        bool UpdateFeaturesHitCount(List<int> FeaturesIds);
    }
}