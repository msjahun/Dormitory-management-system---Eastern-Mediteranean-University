using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.ActivityLog
{
    public class ActivityLogVm
    {

public DateTime CreatedFrom { get; set; }
public DateTime CreatedTo { get; set; }
        public string IpAddress { get; set; }
        public int ActivityLogType { get; set; }


    }
}
