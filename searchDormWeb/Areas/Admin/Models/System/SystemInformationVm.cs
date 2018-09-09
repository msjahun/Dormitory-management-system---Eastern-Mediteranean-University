using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.System
{
    public class SystemInformationVm
    {

        public string Version { get; set; }
        public string OperatingSystem { get; set; }
        public string AspDotNetInfo { get; set; }
        public string IsFullTrustLevel { get; set; }
        public DateTime ServerTimeZone { get; set; }
        public DateTime ServerLocalTime { get; set; }
        public DateTime CordinateUniversalTime { get; set; }
        public DateTime CurrentUserTime { get; set; }
        public string HttpHost { get; set; }
    }
}
