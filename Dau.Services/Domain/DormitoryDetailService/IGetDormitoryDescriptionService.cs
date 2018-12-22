namespace Dau.Services.Domain.DormitoryDetailService
{
    public interface IGetDormitoryDescriptionService
    {
        DormitoryDescriptionSectionViewModel GetDormitoryDescription(long DormitoryId);
    }
}