using Dau.Services.Domain.DormitoryDetailService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dau.Services.Domain.LocationServices
{
    public interface ILocationService
    {
        string GetClosestLandmark(long DormitoryId);
        string GetClosestLandmarkMapSection(long DormitoryId);
        List<CloseLocationsTable> GetDormitoryCloseLocationsListTable(long DormitoryId);
         Task<bool> AddDormitoryCloseLocationAsync(CloseLocationVm vm);
       bool RemoveDormitoryCloseLocation(CloseLocationVm vm);
        Task<LocationinformationViewModel> GetCalculatedDistanceToEmulocationAsync(CalculateDistanceToEMULocationVm vm);
    }
}