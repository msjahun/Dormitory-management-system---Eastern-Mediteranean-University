using Dau.Core.Domain.Users;
using Dau.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Security
{
    public class UserRolesService : IUserRolesService
    {
        private RoleManager<UserRole> _roleManager;
    

        public UserRolesService( RoleManager<UserRole> roleManager)
        {
            _roleManager = roleManager;
         
        }

        public List<SelectListItem> GetUserRolesItems()

        {

            var roles = _roleManager.Roles.ToList();
            List<SelectListItem> userRoles = new List<SelectListItem>();

            foreach (var role in roles)
            {
                userRoles.Add(new SelectListItem { Value = role.NormalizedName, Text = role.Name });
            }
            return userRoles;

        }


        public List<UserRole> GetUserRoleModels()
        {
          return  _roleManager.Roles.ToList();
        }

        public List<UserRole> GetUserRoles(User user)
        {
            return _roleManager.Roles.ToList();

        }

        public IEnumerable<string> GetUserRolesEnum(User user)
        {
            return (IEnumerable<string> )_roleManager.Roles.ToList();

        }


    }
}
