using System.Collections.Generic;

namespace Dau.Services.Dormitory
{
    public interface IDormitoryService
    {
        List<string> GetListAllDormitoriesByLangAndType(int _dormitory_type_id, int _lang_id);
    }
}