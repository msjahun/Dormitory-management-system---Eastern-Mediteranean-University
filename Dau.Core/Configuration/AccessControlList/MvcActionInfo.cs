using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Configuration.AccessControlList
{
  public  class MvcActionInfo
    {

        public string Id => $"{ControllerId}:{Name}";

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string ControllerId { get; set; }

        public bool isSelected { get; set; }
    }


    public class MvcActionInfoUserRole : MvcActionInfo
    {
        public string UserRole { get; set; }
        public string ControllerName { get; set; }
        public string AreaName { get; set; }
    }
}
