using System.Collections.Generic;

namespace Dau.Services.Domain.DormitoryServices
{
    public interface IDormitoryService
    {
        List<DormitoriesDataTable> GetDormitoryListTable();
        long AddDormitory(DormitoryCrud vm);
        DormitoryCrud GetDormitoryById(long DormitoryId);
        bool UpdateDormitoryById(DormitoryCrud vm);
        bool UpdateDormSeo(DormitoryCrud vm);
        List<DormitoryPicturesTable> GetDormitoryImagesTables(long id);
        string GetDormitoryNameById(long id);
        List<SEOFriendlyPageNamesTable> GetSEOFriendlyPageNamesTable();
    }
}