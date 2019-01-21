using System.Collections.Generic;
using static Dau.Services.Languages.LanguageService;

namespace Dau.Services.Languages
{
    public interface ILanguageService
    {
        long GetCurrentLanguageId();
        string GetCurrentCode();
        List<LanguagesTable> GetAllLanguagesTable();
        List<ResourcesVm> GetResoucesByLanguageId(long Id);
        LanguageEdit GetLanguageById(long Id);
        ResourcesVm GetResourceById(long id);
        bool UpdateResource(ResourcesVm vm);
        bool AddNewResource(ResourcesVm vm);
        bool DeleteResource(long id);
    }
}