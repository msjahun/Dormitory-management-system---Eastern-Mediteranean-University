using System.Collections.Generic;

namespace Dau.Services.Domain.DormitoryBlockServices
{
    public interface IDormitoryBlockService
    {
        List<DormitoryBlocksTable> GetDormitoryBlockListTable();
        List<DormitoryBlocksTableList> GetDormitoryBlockByDormitoryIdListTable(long DormitoryId);
    }
}