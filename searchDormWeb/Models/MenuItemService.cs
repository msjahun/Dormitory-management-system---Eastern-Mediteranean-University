using Dau.Core.Configuration.AccessControlList;
using Dau.Core.Domain.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Models
{
    public class MenuItemService {
        public List<string> controllerIdsUsed { get; set; }

        public string subItemList { get; set; }

        public void PrepareMenu(List<UserRole> roles, MenuItemViewModel MenuItem)
        {
            foreach (var item in MenuItem.Actions)
            {
                var actionId = $"{MenuItem.AreaName}:{MenuItem.ControllerName}:{item.ActionName}";
                foreach (var role in roles)
                {
                    var accessList =
                         JsonConvert.DeserializeObject<IEnumerable<MvcControllerInfo>>(role.Access);
                    if (accessList.SelectMany(c => c.Actions).Any(a => a.Id == actionId))
                    {
                        if (!controllerIdsUsed.Contains(actionId))
                        {
                            subItemList += $"<li><a href=\"/{MenuItem.AreaName}/{MenuItem.ControllerName}/{item.ActionName}\")\"><i class=\"fa fa-circle-o\"></i> {item.ActionDisplayName}</a></li>";
                            controllerIdsUsed.Add(actionId);
                        }
                    }
                }



            }


        }






    }




}

