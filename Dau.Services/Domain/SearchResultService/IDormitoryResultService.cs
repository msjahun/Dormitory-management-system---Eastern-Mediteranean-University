using System.Collections.Generic;

namespace Dau.Services.Domain.SearchResultService
{
    public interface IDormitoryResultService
    {
        List<DormitoryResultViewModel> GetDormitoryResult();
    }
}