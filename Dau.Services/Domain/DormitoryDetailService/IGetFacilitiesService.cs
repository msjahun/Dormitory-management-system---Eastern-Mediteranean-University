using System.Collections.Generic;

namespace Dau.Services.Domain.DormitoryDetailService
{
    public interface IGetFacilitiesService
    {
        List<FacilitiesSectionViewModel> GetFacilities();
    }
}