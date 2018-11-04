﻿using Dau.Core.Configuration.AccessControlList;
using Dau.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.TagHelpers
{
    [HtmlTargetElement("secure-controller")]
    public class SecureControllerTagHelper : TagHelper
    {
        private readonly Fees_and_facilitiesContext _dbContext;
        public SecureControllerTagHelper(Fees_and_facilitiesContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HtmlAttributeName("asp-area")]
        public string Area { get; set; }

        [HtmlAttributeName("asp-controller")]
        public string Controller { get; set; }

        

        [ViewContext, HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            var user = ViewContext.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                output.SuppressOutput();
                return;
            }

            var roles = await (
                from usr in _dbContext.Users
                join userRole in _dbContext.UserRoles on usr.Id equals userRole.UserId
                join role in _dbContext.Roles on userRole.RoleId equals role.Id
                where usr.UserName == user.Identity.Name
                select role
            ).ToListAsync();

            var controllerId = $"{Area}:{Controller}";

            foreach (var role in roles)
            {
                var accessList =
                     JsonConvert.DeserializeObject<IEnumerable<MvcControllerInfo>>(role.Access);
                if (accessList.Any(a => a.Id == controllerId)) {
                   
                    return;
                }
            }

            output.SuppressOutput();
        }
    }
}
