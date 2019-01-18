using System.Collections.Generic;

namespace Dau.Services.Domain.DormitoryBlockServices
{
    public interface IDormitoryBlockService
    {
        bool AddNewDormitoryBlock(DormitoryBlockService.DormitoryBlockCrud vm);
        bool DeleteDormitoryBlockById(long Id);
        List<DormitoryBlockService.DormitoryBlocksTableList> GetDormitoryBlockByDormitoryIdListTable(long DormitoryId);
        DormitoryBlockService.DormitoryBlockCrud GetDormitoryBlockById(long id);
        List<DormitoryBlockService.DormitoryBlocksTable> GetDormitoryBlockListTable();
        bool UpdateDormitoryBlock(DormitoryBlockService.DormitoryBlockCrud vm);
    }
}