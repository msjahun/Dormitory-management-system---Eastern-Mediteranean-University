using System.Collections.Generic;

namespace Dau.Services.Domain.DormitoryServices
{
    public interface IDormitoryService
    {
        List<DormitoriesDataTable> GetDormitoryListTable();
    }
}