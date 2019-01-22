using System;

namespace Dau.Services.TimeServices
{
    public interface ITimeService
    {
        string TimeAgo(DateTime inputDate);
    }
}