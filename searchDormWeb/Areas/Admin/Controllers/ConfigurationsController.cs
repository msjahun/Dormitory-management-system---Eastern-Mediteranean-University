using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dau.Core.Configuration.AccessControlList;
using Dau.Core.Domain.User;
using Dau.Services.AccessControlList;
using Dau.Services.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using searchDormWeb.Areas.Admin.Models.Configuration;

namespace searchDormWeb.Areas.Admin.Controllers
{
   
  
    [Authorize]
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class ConfigurationsController : Controller
    {
        private readonly RoleManager<UserRole> _roleManager;
        private readonly IUserRolesService _userRolesService;
        private readonly IMvcControllerDiscovery _mvcControllerDiscovery;
        
        public ConfigurationsController(IMvcControllerDiscovery mvcControllerDiscovery, IUserRolesService userRolesService, RoleManager<UserRole> roleManager)
        {
            _roleManager = roleManager;
            _userRolesService = userRolesService;
            _mvcControllerDiscovery = mvcControllerDiscovery;
        }


        [HttpGet("[action]")]
        [HttpGet("")]// GET: Configurations
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet("[action]")]
       
        public ActionResult EmailAccounts()
        {
            return View("EmailAccounts");
        }


        [HttpGet("[action]")]
        public ActionResult Dormitories()
        {
            return View("Dormitories");
        }


        [HttpGet("[action]")]
        public ActionResult Countries()
        {
            return View("Countries");
        }


        [HttpGet("[action]")]
        public ActionResult Languages()
        {
            return View("Languages");
        }


        [HttpGet("[action]")]
        public ActionResult AccessControlList()
        { ViewData["CustomerRoles"]= _userRolesService.GetUserRolesItems();
          var mvcControllers = _mvcControllerDiscovery.GetControllers();
            ViewData["Controllers"] = mvcControllers;
            var roles = _roleManager.Roles;
            List<AclMvcControllerInfo2> controllerList = new List<AclMvcControllerInfo2>();
            foreach (var role in roles)
            {if(role.Access != null) { 
                var accessList =
                    JsonConvert.DeserializeObject<IEnumerable<MvcControllerInfo>>(role.Access);
                //if (accessList.SelectMany(c => c.Actions).Any(a => a.Id == actionId))
                //    return;
                controllerList.Add(new AclMvcControllerInfo2 { UserRole = role.NormalizedName.ToString(), mvcControllers = accessList });

                }
            }
            var list = controllerList;
            List<MvcActionInfoUserRole> actionList = new List<MvcActionInfoUserRole>();

            foreach (var controllerRoles in controllerList)
            {
                //controllerRoles.UserRole;
                var tempMVCControllersStorage = controllerRoles.mvcControllers;
                controllerRoles.mvcControllers = mvcControllers;
                foreach (var mvcC in controllerRoles.mvcControllers)
                {
                    foreach (var mvcControllerForUserRole in tempMVCControllersStorage)
                    {
                        if(mvcC.Name == mvcControllerForUserRole.Name && mvcC.AreaName == mvcControllerForUserRole.AreaName)
                        {//another forloop to check individual action
                            foreach (var mvcActions1 in mvcControllerForUserRole.Actions)
                            {
                                foreach (var mvcCActions in  mvcC.Actions )
                                {

                                    if(mvcActions1.Name == mvcCActions.Name)
                                    {
                                        mvcCActions.isSelected = true;
                                        actionList.Add(new MvcActionInfoUserRole { UserRole = controllerRoles.UserRole.ToString(), ControllerName = mvcC.Name, Name = mvcCActions.Name, isSelected = mvcCActions.isSelected , AreaName = mvcC.AreaName});
                                    }
                                    //push to userRoleAction
                                    

                            }
                           
                            }
                        }
                        // store
                     
                    }


                }
               

            }



            ViewData["ActionsList"] = actionList;
            return View("AccessControlList");
        }

         [HttpPost("[action]")]
        public async Task<ActionResult> AccessControlList( List<AclPostData> data)
        {
           
        var  roles =  data.Select(s => s.UserRole).Distinct().ToList();

            List<AclReady> aclReadyList = new List<AclReady>();
            AclReady aclReady = new AclReady();
            
            List<mini> miniList = new List<mini>();



            foreach (var role in roles)
            {
                foreach (var item in data)
                {
                   
                    if (item.UserRole == role)
                    {
                        miniList.Add( new mini { Area = item.Area , Controller = item.Controller , Action = item.Action });
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
                     

                        
                                if (controller == i.Controller )
                                { 
                                    mvcActionInfos.Add(new MvcActionInfo { Name = i.Action ,ControllerId = i.Area+":"+i.Controller });

                            controllerName = i.Controller;
                            areaName = i.Area;
                                }

                        
                    }
                            
                            miniController.Add(new MvcControllerInfo { Name = controllerName, AreaName = areaName, Actions=mvcActionInfos});
                    mvcActionInfos = new List<MvcActionInfo>();
                    //add action array to miniController


                }
                    

                
                mvcControllers.Add(new AclMvcControllerInfo { UserRole = role.UserRole, mvcControllers = miniController });
                miniController = new List<MvcControllerInfo>();
                //add all corresponding array to mvcController list
            }

            var list = aclReadyList;

           


            foreach (var role in mvcControllers)
            {
                var accessJson = JsonConvert.SerializeObject(role.mvcControllers);
               var userRole = await _roleManager.FindByNameAsync(role.UserRole);
                userRole.Access = accessJson;
               await _roleManager.UpdateAsync(userRole);
            }
            
            var result = data;
            ViewData["Controllers"] = _mvcControllerDiscovery.GetControllers();


         //   var role = new ApplicationRole { Name = viewModel.Name };

            //get role i.e Administrator and set access field of the role

          //  if (viewModel.SelectedControllers != null && viewModel.SelectedControllers.Any())
            //if (data != null && data.Any())
            //{
            //    foreach (var item in data)
            //        foreach (var Role in item.UserRole)
            //        {
            //            //if userrole ==  administrator jsonfy access and save to database//do that for every role
            //        }
            //            action.ControllerId = controller.Id;

            //    var accessJson = JsonConvert.SerializeObject(viewModel.SelectedControllers);
            //    role.Access = accessJson;
            //}

       

            //foreach (var error in result.Errors)
            //    ModelState.AddModelError("", error.Description);

            ViewData["Controllers"] = _mvcControllerDiscovery.GetControllers();

            //  return View(viewModel);

            return Content("{success:true}");
        }


     


        [HttpGet("[action]")]
        public ActionResult Currencies()
        {
            return View("Currencies");
        }



    }
}