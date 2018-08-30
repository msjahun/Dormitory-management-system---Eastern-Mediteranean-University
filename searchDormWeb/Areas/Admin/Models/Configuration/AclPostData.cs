using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Configuration
{
    public class AclPostData
    {
        public string UserRole {get; set;}

        public string Area { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }

    }


}
