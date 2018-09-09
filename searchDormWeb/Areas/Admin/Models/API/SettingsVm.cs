using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.API
{
    public class SettingsVm
    {

        public bool EnableAPI { get; set; }
        public bool AllowRequestsFromSwagger { get; set; }

    }
}
