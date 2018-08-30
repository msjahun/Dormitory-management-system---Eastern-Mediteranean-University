using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Models
{
    public class MenuItemViewModel
    {
        public string ControllerName { get; set; }
        public string ControllerDisplayName { get; set; }
        public string CurrentController { get; set; }
        public string CurrentAction { get; set; }
        public string AreaName { get; set; }
        public string icon { get; set; }
        public List<MenuSubItems> Actions { get; set; }
        public MenuItemViewModel subMenu { get; set; }
    }

    public class MenuSubItems
    {
        public string ActionName { get; set; }
        public string ActionDisplayName { get; set; }
    }

   
}
