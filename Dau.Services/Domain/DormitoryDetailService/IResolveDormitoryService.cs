namespace Dau.Services.Domain.DormitoryDetailService
{
    public interface IResolveDormitoryService
    {
        long GetDormitoryIdBySEOFriendlyName(string SearchEngineFriendlyName);
        string GetDormitorySEOFriendlyNameById(long id);
    }
}