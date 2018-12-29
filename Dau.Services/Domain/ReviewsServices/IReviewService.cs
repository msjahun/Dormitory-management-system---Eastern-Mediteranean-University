using System.Collections.Generic;

namespace Dau.Services.Domain.ReviewsServices
{
    public interface IReviewService
    {
        List<ReviewsTable> GetReviewsListTable();
    }
}