using Dau.Core.Domain.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Dau.Services.Security
{
    public interface IUserRolesService
    {
        List<SelectListItem> GetUserRolesItems();
        List<UserRole> GetUserRoleModels();
        List<UserRole> GetUserRoles(User user);
    }
}