using Dau.Data;
using Microsoft.AspNetCore.Razor.TagHelpers;
using searchDormWeb.Models;
using System.Collections.Generic;
using System.Linq;
using Dau.Core.Configuration.AccessControlList;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Threading.Tasks;

namespace searchDormWeb.TagHelpers
{
    [HtmlTargetElement("Menu-item")]
    public class MenuItemTagHelper : TagHelper
    {
        private readonly Fees_and_facilitiesContext _dbContext;
        public MenuItemViewModel MenuItem { get; set; }
        [ViewContext, HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }


        public MenuItemTagHelper(Fees_and_facilitiesContext dbContext)
        {
            _dbContext = dbContext;
        }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            var user = ViewContext.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                output.SuppressOutput();
                return;
            }


            var roles = await(
               from usr in _dbContext.Users
               join userRole in _dbContext.UserRoles on usr.Id equals userRole.UserId
               join role in _dbContext.Roles on userRole.RoleId equals role.Id
               where usr.UserName == user.Identity.Name
               select role
           ).ToListAsync();

           
            List<string> controllerIdsUsed = new List<string>();
            output.TagName = "li";
            var subItemList = "";

       
            foreach (var item in MenuItem.Actions)
            {
                var actionId = $"{MenuItem.AreaName}:{MenuItem.ControllerName}:{item.ActionName}";
                foreach (var role in roles)
                {
                    var accessList =
                         JsonConvert.DeserializeObject<IEnumerable<MvcControllerInfo>>(role.Access);
                    if (accessList.SelectMany(c => c.Actions).Any(a => a.Id == actionId))
                    {
                        if (!controllerIdsUsed.Contains(actionId)) {
                        subItemList += $"<li><a href=\"/{MenuItem.AreaName}/{MenuItem.ControllerName}/{item.ActionName}\")\"><i class=\"fa fa-circle-o\"></i> {item.ActionDisplayName}</a></li>";
                        controllerIdsUsed.Add(actionId);
                        }
                    }
                }

               

            }
            List<string> leveltwoControllerIdsUsed = new List<string>();
            var leveltwoSubItemList = "";
            var level2String = "";
            var LeveltwoIsActive = "";
            if (MenuItem.subMenu != null) { 
            


            foreach (var item in MenuItem.subMenu.Actions)
            {
                var actionId = $"{MenuItem.subMenu.AreaName}:{MenuItem.subMenu.ControllerName}:{item.ActionName}";
                foreach (var role in roles)
                {
                    var accessList =
                         JsonConvert.DeserializeObject<IEnumerable<MvcControllerInfo>>(role.Access);
                    if (accessList.SelectMany(c => c.Actions).Any(a => a.Id == actionId))
                    {
                        if (!leveltwoControllerIdsUsed.Contains(actionId))
                        {
                            leveltwoSubItemList += $"<li><a href=\"/{MenuItem.subMenu.AreaName}/{MenuItem.subMenu.ControllerName}/{item.ActionName}\")\"><i class=\"fa fa-circle-o\"></i> {item.ActionDisplayName}</a></li>";
                            leveltwoControllerIdsUsed.Add(actionId);
                        }
                    }
                }



            }

           
                LeveltwoIsActive = (MenuItem.subMenu.ControllerName == MenuItem.subMenu.CurrentController) ? "active" : "";
           
            if ((leveltwoControllerIdsUsed.Count > 0)) {
                level2String = $" <li class=\"treeview {LeveltwoIsActive}\">"+
                        "<a href=\"#\">" +
                          $" <i class=\"fa fa-circle-o\"></i> { MenuItem.subMenu.ControllerDisplayName } "+
                           " <span class=\"pull-right-container\">"+
                             "   <i class=\"fa fa-angle-left pull-right\"></i>"+
                          "  </span>"+
                       " </a>"+
                       " <ul class=\"treeview-menu\">"+
                           $" {leveltwoSubItemList }"+
                       " </ul>"+
                  "  </li>";
            }

            }

            //send current controller and current action
            var isActive = (MenuItem.ControllerName == MenuItem.CurrentController) ? "active" : "";

            var isActiveAny = (isActive.Length > 0) ? "active" : (LeveltwoIsActive.Length > 0) ? "active" : "";
            output.Attributes.Add(new TagHelperAttribute("class", "treeview " + isActiveAny));

            output.Content.SetHtmlContent($"<a href=\"#\">" +
                 $"   <i class=\"{MenuItem.icon}\"></i> <span> {MenuItem.ControllerDisplayName} </span>" +
                  "  <span class=\"pull-right-container\">" +
                   "     <i class=\"fa fa-angle-left pull-right\"></i>" +
                    "</span>" +
                "</a>" +
                "<ul class=\"treeview-menu\">" +
                subItemList + level2String+
                "</ul>");

            if (controllerIdsUsed.Count + leveltwoControllerIdsUsed.Count > 0)
             return;
            else
                output.SuppressOutput();




        }
    }
}
