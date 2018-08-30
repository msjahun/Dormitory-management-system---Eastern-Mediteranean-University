using Dau.Core.Configuration.AccessControlList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Configuration
{
    public class AclMvcControllerInfo
    {
        public string UserRole { get; set; }
        public List<MvcControllerInfo> mvcControllers { get; set; }
    }

    public class AclMvcControllerInfo2: AclMvcControllerInfo
    {
        public new IEnumerable<MvcControllerInfo> mvcControllers { get; set; }
      
    }
}
