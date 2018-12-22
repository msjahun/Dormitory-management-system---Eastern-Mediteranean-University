using Dau.Core.Domain;
using System.Collections.Generic;

namespace Dau.Services.Utilities
{
    public interface IApiLogService
    {
        void LogApiRequest(ApiDebugLog apiDebugLog);
        List<ApiDebugLog> getApiDebugLogs();
        string GetRequestBody();
        void DeleteEntries();
    }
}