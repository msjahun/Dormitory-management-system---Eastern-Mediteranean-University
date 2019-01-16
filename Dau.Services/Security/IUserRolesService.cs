using Dau.Core.Domain.Users;
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
        bool IsDormitoryManager();
        List<long> RoleAccessResolver();
        bool IsAuthorized(long id);
    }
}