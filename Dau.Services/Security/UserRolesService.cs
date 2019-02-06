using Dau.Core.Configuration.AccessControlList;
using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Users;
using Dau.Data;
using Dau.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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


        public List<AclMvcControllerInfo> ParseAccessControlJson(string bodyStr)
        {
            var data = JsonConvert.DeserializeObject<List<AclPostData>>(bodyStr);

            var roles = data.Select(s => s.UserRole).Distinct().ToList();

            List<AclReady> aclReadyList = new List<AclReady>();
            AclReady aclReady = new AclReady();

            List<mini> miniList = new List<mini>();


            foreach (var role in roles)
            {
                foreach (var item in data)
                {
                    if (item.UserRole == role)
                    {
                        miniList.Add(new mini { Area = item.Area, Controller = item.Controller, Action = item.Action });
                    }

                }

                aclReadyList.Add(new AclReady { UserRole = role, data = miniList });
                miniList = new List<mini>();
            }


            List<AclMvcControllerInfo> mvcControllers = new List<AclMvcControllerInfo>();
            List<MvcControllerInfo> miniController = new List<MvcControllerInfo>();
            List<MvcActionInfo> mvcActionInfos = new List<MvcActionInfo>();
            var controllers = data.Select(s => s.Controller).Distinct().ToList();

            foreach (var role in aclReadyList)
            {  //mvcController array initiate

                //for each controller type traverse data[Area: public, controller: users, Action: GetList]

                foreach (var controller in controllers)
                {
                    var controllerName = ""; var areaName = "";
                    foreach (var i in role.data)
                    {
                        if (controller == i.Controller)
                        {
                            mvcActionInfos.Add(new MvcActionInfo { Name = i.Action, ControllerId = i.Area + ":" + i.Controller });
                            controllerName = i.Controller;
                            areaName = i.Area;
                        }
                    }

                    miniController.Add(new MvcControllerInfo { Name = controllerName, AreaName = areaName, Actions = mvcActionInfos });
                    mvcActionInfos = new List<MvcActionInfo>();
                    //add action array to miniController


                }


                mvcControllers.Add(new AclMvcControllerInfo { UserRole = role.UserRole, mvcControllers = miniController });
                miniController = new List<MvcControllerInfo>();
                //add all corresponding array to mvcController list

            }


            return mvcControllers;
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

        public async Task<bool> UpdateUserRolesAccessControlAsync()
        {
            try
            {
                var req = _httpContextAccessor.HttpContext.Request;
                var bodyStr = "";
                using (StreamReader reader = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
                {
                    bodyStr = reader.ReadToEnd();
                }

                var mvcControllers = ParseAccessControlJson(bodyStr);

                foreach (var role in mvcControllers)
                {
                    var accessJson = JsonConvert.SerializeObject(role.mvcControllers);
                    var userRole = await _roleManager.FindByNameAsync(role.UserRole);
                    userRole.Access = accessJson;
                    await _roleManager.UpdateAsync(userRole);
                }

                return true;

            }
            catch
            {
                return false;
            }

        }
    }


    public class AclReady
    {

        public string UserRole { get; set; }

        public List<mini> data { get; set; }
    }

    public class mini
    {
        public string Area { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
    }

    public class AclPostData
    {
        public string UserRole { get; set; }

        public string Area { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }

    }


    public class AclMvcControllerInfo
    {
        public string UserRole { get; set; }
        public List<MvcControllerInfo> mvcControllers { get; set; }
    }

    public class AclMvcControllerInfo2 : AclMvcControllerInfo
    {
        public new IEnumerable<MvcControllerInfo> mvcControllers { get; set; }

    }
}
