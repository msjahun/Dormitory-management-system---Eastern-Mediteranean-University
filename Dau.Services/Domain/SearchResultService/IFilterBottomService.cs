using System.Collections.Generic;

namespace Dau.Services.Domain.SearchResultService
{
    public interface IFilterBottomService
    {
        List<FiltersFacilityViewModel> GetFilterBottom();
    }
}