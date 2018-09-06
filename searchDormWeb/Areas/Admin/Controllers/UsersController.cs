using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dau.Core.Domain.User;
using Dau.Data;
using Dau.Services.Dormitory;
using Dau.Services.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using searchDormWeb.Areas.Admin.Models.User;

namespace searchDormWeb.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserRolesService _userRolesService;
        private readonly RoleManager<UserRole> _roleManager;
        private IDormitoryService _dormitoryService;
        private IHttpContextAccessor _accessor;



        public UsersController(IDormitoryService dormitoryService, RoleManager<UserRole> roleManager,
            UserManager<User> userManager,
            IUserRolesService userRolesService,
            IHttpContextAccessor accessor
            )
        {
          _dormitoryService = dormitoryService;
            _userManager = userManager;
            _accessor = accessor;
            _userRolesService = userRolesService;
            _roleManager = roleManager;
        
          
        }

        [HttpGet("[action]")]
        [HttpGet("")]
        public async Task<ActionResult> List()
        {
            List<UserListViewModel> model = new List<UserListViewModel>();

            List<User> users = _userManager.Users.OrderByDescending (c => c.CreatedOnUtc).ToList();
           

            foreach (var item in users)
            {
                model.Add(new UserListViewModel
                {
                    User = item,
                    userRoles = (List<string>)await _userManager.GetRolesAsync(item)
                    //  userRoles = _userRolesService.GetUserRoles(item)
                });
                           }


            return View("_Users_list", model);
        }




        [HttpGet("[action]")]

        public ActionResult Add()
        {
            UserAddViewModel model = new UserAddViewModel();
         //send languageId through here
           model.Dormitories = _dormitoryService.GetSelectListDormitories(1);
           model.CustomerRoles = _userRolesService.GetUserRolesItems();
            return View("_User_Add", model);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(UserAddViewModel vm)
        {
            vm.CustomerRoles = _userRolesService.GetUserRolesItems();
            vm.Dormitories = _dormitoryService.GetSelectListDormitories(1);


            if (!ModelState.IsValid)
                return View("_User_Add", vm);
            else
            {
                var user = new User { UserName = vm.Email, Email = vm.Email,
                    FirstName = vm.FirstName, LastName = vm.LastName, Active = vm.Active, AdminComment = vm.AdminComment,
                    NewsletterSubscription = vm.NewsletterSubscription, Country = vm.Country, City = vm.City,
                    DateOfBirth = vm.DateOfBirth, Gender = vm.Gender, DormitoryId = vm.ManagerOfDormitory,
                    CreatedOnUtc = DateTime.UtcNow, LastIpAddress = _accessor.HttpContext.Connection.RemoteIpAddress.ToString(),
                    PhoneNumber = vm.PhoneNumber
                };
                var result = await _userManager.CreateAsync(user, vm.Password);

                foreach (var item in vm.CustomerRole)
                {
                    var result_AddRole = await _userManager.AddToRoleAsync(user, item);
                }
              

                if (result.Succeeded)
                {

                    return RedirectToAction("List", "Users");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View("_User_Add", vm);
                }

               
            }
              
        }





        [HttpGet("[action]")]

        public async Task<ActionResult> Delete(string UserId)
        {
            User editUser = new User();
            editUser = _userManager.Users.Where(user => user.Id == UserId).FirstOrDefault();
         var result =   await _userManager.DeleteAsync(editUser);

            return RedirectToAction("List", "Users");

        }




        [HttpGet("[action]")]

        public async Task<ActionResult> Edit(string UserId)
        {
            User editUser = new User();
            editUser = _userManager.Users.Where(user => user.Id == UserId).FirstOrDefault();
            if(editUser == null)
                return RedirectToAction("List", "Users");

            UserEditViewModel model = new UserEditViewModel {
                Id = editUser.Id,
                Email = editUser.Email,
                ManagerOfDormitory = editUser.DormitoryId,
                Gender = editUser.Gender,
                FirstName = editUser.FirstName,
                LastName = editUser.LastName,
                PhoneNumber = editUser.PhoneNumber,
                DateOfBirth = editUser.DateOfBirth,
                City = editUser.City,
                Country = editUser.Country,
                AdminComment = editUser.AdminComment,
                NewsletterSubscription = editUser.NewsletterSubscription,
                Active = editUser.Active,
                CustomerRole =  (List<string>)await _userManager.GetRolesAsync(editUser)

            };
            //send languageId through here
            model.Dormitories = _dormitoryService.GetSelectListDormitories(1);
            model.CustomerRoles = _userRolesService.GetUserRolesItems();


          
         


            
            string id = UserId;
            return View("_User_Edit", model);
        }



        [HttpPost("[action]")]
        public async Task<ActionResult> Edit(UserEditViewModel vm)
        {
            vm.CustomerRoles = _userRolesService.GetUserRolesItems();
            vm.Dormitories = _dormitoryService.GetSelectListDormitories(1);


            if (!ModelState.IsValid)
                return View("_User_Edit", vm);
            else
            {


                var editUser =(User)  await _userManager.FindByIdAsync(vm.Id);

                if (!vm.isChangePassword)
                {


                    editUser.UserName = vm.Email;
                    editUser.Email = vm.Email;
                    editUser.FirstName = vm.FirstName;
                    editUser.LastName = vm.LastName;
                    editUser.Active = vm.Active;
                    editUser.AdminComment = vm.AdminComment;
                    editUser.NewsletterSubscription = vm.NewsletterSubscription;
                    editUser.Country = vm.Country;
                    editUser.City = vm.City;
                    editUser.DateOfBirth = vm.DateOfBirth;
                    editUser.Gender = vm.Gender;
                    editUser.DormitoryId = vm.ManagerOfDormitory;
                    editUser.PhoneNumber = vm.PhoneNumber;

                }
                else { 

                    editUser.PasswordHash =  _userManager.PasswordHasher.HashPassword(editUser,vm.Password);
                }
                var result = await  _userManager.UpdateAsync(editUser);
                 await _userManager.RemoveFromRolesAsync(editUser, await _userManager.GetRolesAsync(editUser));

                if(vm.CustomerRole != null)
                foreach (var role in vm.CustomerRole)
                {
                    await _userManager.AddToRoleAsync(editUser, role);
                }

               
                //foreach (var item in vm.CustomerRole)
                //{
                //    var result_AddRole = await _userManager.AddToRoleAsync(user, item);
                //}


                if (result.Succeeded)
                {
                    if (vm.isChangePassword)
                    {
                        return RedirectToAction("List", "Users");
                       
                    }
                    return View("_User_Edit", vm);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View("_User_Edit", vm);
                }


            }

        }






        [HttpGet("[action]")]

        public ActionResult Roles()
        {

            var model = _userRolesService.GetUserRoleModels();
            return View("UserRoles/_User_roles_list", model);
        }





        [HttpGet("[action]")]

        public ActionResult UserRoleAdd()
        {

         
            return View("UserRoles/_User_role_add");
        }


        [HttpPost("[action]")]

        public async Task<ActionResult> UserRoleAdd(UserRoleAddViewModel vm)
        {

            if (!ModelState.IsValid)
                return View("UserRoles/_User_role_add", vm);
            else
            {
                //create user role and redirect to edit_userRole page
                var role = new UserRole();
                role.Name = vm.Name;
                role.Access ="[{\"Id\":\":\",\"Name\":\"\",\"DisplayName\":null,\"AreaName\":\"\",\"Actions\":[]}]";
                role.IsActive = vm.ISActive;
                await _roleManager.CreateAsync(role);

                return RedirectToAction("Roles");
            }
        }



        [HttpGet("[action]")]

        public ActionResult UserRoleEdit(string user_role_id)
        {
            //getUser role and send the model to the view
            if (user_role_id == null)
                return RedirectToAction("Roles");
            var role = _roleManager.Roles.Where(r => r.Id == user_role_id).FirstOrDefault();
            if (role == null)
                return RedirectToAction("Roles");
            var vm = new UserRoleEditViewModel
            {
                Name = role.Name,
                SystemName = role.NormalizedName,
                ISActive = role.IsActive,
                IsSystemRole = role.IsSystemRole,
                ID = role.Id
            };

            return View("UserRoles/_User_role_Edit", vm);
        }




        [HttpPost("[action]")]

        public async Task<ActionResult> UserRoleEdit(UserRoleEditViewModel vm)
        {
            //getUser role and send the model to the view

            if (!ModelState.IsValid)
                return View("UserRoles/_User_role_Edit", vm);
            else
            {

                var getRole = _roleManager.Roles.Where(r => r.Id == vm.ID).FirstOrDefault();

                getRole.Name = vm.Name;

                    getRole.IsActive = vm.ISActive;






                await _roleManager.UpdateAsync(getRole);
             
               
            }
            return RedirectToAction("Roles");
        }








        [HttpPost("[action]")]

        public async Task<ActionResult> UserRoleDelete(string user_role_id)
        {
            //getUser role and send the model to the view
            if (user_role_id == null)
                return Content("{Reponse:Error}");
            var role = _roleManager.Roles.Where(r => r.Id == user_role_id).FirstOrDefault();
            if (role == null)
                return Content("{Reponse:Error}");
            await _roleManager.DeleteAsync(role);

          return  Content("{Reponse:Success}");
        }




        [HttpGet("[action]")]

        public ActionResult OnlineUsers()
        {
            return View("_Users_online_users_list");
        }

        [HttpGet("[action]")]

        public ActionResult UsersReport()
        {
            return View("_Users_report");
        }







    }
}