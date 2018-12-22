namespace Dau.Services.Domain.DormitoryDetailService
{
    public interface IGetReviewService
    {
        ReviewButtomSectionViewModel GetReview(long DormitoryId);
    }
}