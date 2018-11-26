using System.Collections.Generic;
using Dau.Core.Domain.Logging;

namespace Dau.Services.Logging
{
    public interface ILoggingService
    {
        bool DeleteAllLogs();
        bool DeleteLogById(int Id);
        Log GetLogById(int Id);
        List<Log> GetLogs();
    }
}