using System.Collections.Generic;

namespace Dau.Services.Domain.DormitoryDetailService
{
    public interface IGetCommentsService
    {
        List<CommentSectionViewModel> GetComments(long DormitoryId);
    }
}