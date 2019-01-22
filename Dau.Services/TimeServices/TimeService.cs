using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.TimeServices
{
  public  class TimeService : ITimeService
    {
        private readonly IStringLocalizer _Localizer;

        public TimeService(IStringLocalizer stringLocalizer)
        {
            _Localizer = stringLocalizer;
        }

        public string TimeAgo(DateTime inputDate)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = new TimeSpan(DateTime.Now.Ticks - inputDate.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? _Localizer["one second ago"] : ts.Seconds + _Localizer[" seconds ago"];

            if (delta < 2 * MINUTE)
                return _Localizer["a minute ago"];

            if (delta < 45 * MINUTE)
                return ts.Minutes + _Localizer[" minutes ago"];

            if (delta < 90 * MINUTE)
                return _Localizer["an hour ago"];

            if (delta < 24 * HOUR)
                return ts.Hours + _Localizer[" hours ago"];

            if (delta < 48 * HOUR)
                return _Localizer["yesterday"];

            if (delta < 30 * DAY)
                return ts.Days + _Localizer[" days ago"];

            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? _Localizer["one month ago"] : months + _Localizer[" months ago"];
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? _Localizer["one year ago"] : years + _Localizer[" years ago"];
            }
        }
    }
}
