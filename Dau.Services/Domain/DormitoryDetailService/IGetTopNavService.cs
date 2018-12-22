namespace Dau.Services.Domain.DormitoryDetailService
{
    public interface IGetTopNavService
    {
        TopNavDormitorySectionViewModel GetTopNav(long DormitoryId);
    }
}