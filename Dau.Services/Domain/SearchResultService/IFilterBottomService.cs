using System.Collections.Generic;

namespace Dau.Services.Domain.SearchResultService
{
    public interface IFilterBottomService
    {
        IEnumerable<FiltersFacilityViewModel> GetFilterBottom();
    }
}