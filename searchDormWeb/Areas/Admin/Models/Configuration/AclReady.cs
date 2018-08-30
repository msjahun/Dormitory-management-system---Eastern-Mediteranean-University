using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Configuration
{
    public class AclReady
    {

        public string UserRole { get; set; }

    public List<mini> data { get; set; }
    }

    public class mini
    {
        public string Area { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
    }
}
