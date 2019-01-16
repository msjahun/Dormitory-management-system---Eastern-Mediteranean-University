using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.System
{
    public class SystemInformationVm
    {
        [Display(Name = "Version",
        Description = "Dau Booking system version."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string Version { get; set; }

        [Display(Name = "Operating system",
        Description = "Operating system."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string OperatingSystem { get; set; }

        [Display(Name = "Asp.Net info",
        Description = "Asp.net info."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string AspDotNetInfo { get; set; }

        [Display(Name = "Is full trust level",
        Description = "Is Full trust level."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string IsFullTrustLevel { get; set; }


        [Display(Name = "Server time zone",
        Description = "Server time zone."),
        DataType(DataType.Date),
        MaxLength(256)]
        public string ServerTimeZone { get; set; }

        [Display(Name = "Server local time",
        Description = "Server local time."),
        DataType(DataType.Date),
        MaxLength(256)]
        public string ServerLocalTime { get; set; }

        [Display(Name = "Coordinate Universal time",
        Description = "Coordinate universal time ."),
        DataType(DataType.Date),
        MaxLength(256)]
        public string CoordinateUniversalTime { get; set; }

        [Display(Name = "Current user time",
        Description = "Current user time (based on the specified datetime and time zone settings)."),
        DataType(DataType.Date),
        MaxLength(256)]
        public string  CurrentUserTime { get; set; }

        [Display(Name = "Http Host",
        Description = "HTTP_HOST is used when you run a multidormtory solution to determine the current dormitory."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string HttpHost { get; set; }
    }
}
