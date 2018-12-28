using System.Collections.Generic;

namespace Dau.Services.Domain.SearchResultService
{
    public interface ISearchService
    {
       
        List<DormitoryNamesTypesViewModel> GetDormitoryTypesFilter();
        List<DormitoryNamesTypesViewModel> GetDormitoriesFilter(long DormitoryTypeId = 0);
    }
}