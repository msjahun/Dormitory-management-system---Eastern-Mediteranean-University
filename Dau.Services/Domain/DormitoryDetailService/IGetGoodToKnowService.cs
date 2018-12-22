namespace Dau.Services.Domain.DormitoryDetailService
{
    public interface IGetGoodToKnowService
    {
        GoodToKnowSectionViewModel GetGoodToKnowInfo(long DormitoryId);
    }
}