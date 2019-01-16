using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Users;
using Dau.Data;
using Dau.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Dau.Services.Security
{
    public class UserRolesService : IUserRolesService
    {
        private UserManager<User> _userManager;
        private RoleManager<UserRole> _roleManager;
        private IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<Dormitory> _dormRepo;
        private readonly Fees_and_facilitiesContext _dbContext;

        public UserRolesService( RoleManager<UserRole> roleManager, UserManager<User> userManager,
            IHttpContextAccessor httpContextAccessor,IRepository<Dormitory> dormRepo,
            Fees_and_facilitiesContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager; _httpContextAccessor = httpContextAccessor;
            _dormRepo = dormRepo;
            _dbContext = dbContext;

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

        public bool IsDormitoryManager()
        {
            // Resolve the user via their email
            //var user = await _userManager
              //  HttpContext.Current.User.Identity.GetUserId();
            return _httpContextAccessor.HttpContext.User.IsInRole("DormitoryManager");
            // Get the roles for the user
  
        }

        public List<long> RoleAccessResolver()
        {
            List<long> dormIdsList;

            if (_httpContextAccessor.HttpContext.User.IsInRole("DormitoryManager"))
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;


                dormIdsList = _dbContext.UsersDormitory.Where(c => c.UserId == userId).Select(c => c.DormitoryId).ToList();
                
                //get dormitoryId and put it in the list
            }else
            {
                dormIdsList = _dormRepo.List().Select(c => c.Id).ToList();
                
                //get all dormitories and put it in the list
            }

            return dormIdsList;
        }


        public bool IsAuthorized(long id)
        {
            if (RoleAccessResolver().Contains(id))
                return true;
            else
                return false;
        }

    }
}
