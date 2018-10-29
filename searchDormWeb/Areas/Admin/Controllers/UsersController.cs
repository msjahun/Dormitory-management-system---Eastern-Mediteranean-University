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


        #region users
        [HttpGet("[action]")]
        [HttpGet("")]
        public IActionResult List()
        {

            return View("_Users_list");
        }



        [HttpPost("[action]")]
        public async Task<ActionResult> List(int temp)
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault(); // Skip number of Rows count
                var passedParam = Request.Form["myKey"].FirstOrDefault();//passed parameter
                var length = Request.Form["length"].FirstOrDefault();  // Paging Length 10,20  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault(); // Sort Column Name  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();// Sort Column Direction (asc, desc)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();// Search Value from (Search box) 
                int pageSize = length != null ? Convert.ToInt32(length) : 0; //Paging Size (10, 20, 50,100)  
                int skip = start != null ? Convert.ToInt32(start) : 0;
             


                 List<UserListViewModel> model = new List<UserListViewModel>();
                 var users = _userManager.Users.OrderByDescending(c => c.CreatedOnUtc).ToList();
                 foreach (var item in users)
                     {
                           model.Add(new UserListViewModel
                           {
                               User = item,
                               userRoles = (List<string>)await _userManager.GetRolesAsync(item)
                               //  userRoles = _userRolesService.GetUserRoles(item)
                                         });
                     }

              
                // getting all Discount data  
                var Data = model.Select(c => new {
                    c.User.FirstName,
                    c.User.LastActivityDateUtc,
                    c.User.CreatedOnUtc,
                    c.User.Email,
                    c.User.LastName,
                    c.User.PhoneNumber,
                    c.User.Active,
                    c.User.Id,
                    c.userRoles
                }).ToList();

                ////Sorting  
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    DiscountData = DiscountData.OrderBy(c => c.sortColumn sortColumnDirection);
                //}
                ////Search  
                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    DiscountData = DiscountData.Where(m => m.Name == searchValue);
                //}


                //total number of rows counts   
                int recordsTotal = 0;
                recordsTotal = Data.Count();
                //Paging   
                var data = Data.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }
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

              

                if (result.Succeeded)
                {
                    if (vm.CustomerRole != null)
                        foreach (var item in vm.CustomerRole)
                        {
                            var result_AddRole = await _userManager.AddToRoleAsync(user, item);
                        }

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

        #endregion



        #region UserRoles
        [HttpGet("[action]")]
        public ActionResult Roles()
        {

         
            return View("UserRoles/_User_roles_list");
        }

         [HttpPost("[action]")]
        public ActionResult Roles(int dummy)
        {

            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault(); // Skip number of Rows count
                var passedParam = Request.Form["myKey"].FirstOrDefault();//passed parameter
                var length = Request.Form["length"].FirstOrDefault();  // Paging Length 10,20  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault(); // Sort Column Name  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();// Sort Column Direction (asc, desc)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();// Search Value from (Search box) 
                int pageSize = length != null ? Convert.ToInt32(length) : 0; //Paging Size (10, 20, 50,100)  
                int skip = start != null ? Convert.ToInt32(start) : 0;



                var roleModels = _userRolesService.GetUserRoleModels();
                List<UserRolesTable> List = new List<UserRolesTable>();
                foreach (var item in roleModels)
                {
                    List.Add(new UserRolesTable
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Active = item.IsActive,
                        IsSystemRole = item.IsSystemRole
                    });

                }

                // getting all Discount data  
                var Data = List;

                ////Sorting  
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    DiscountData = DiscountData.OrderBy(c => c.sortColumn sortColumnDirection);
                //}
                ////Search  
                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    DiscountData = DiscountData.Where(m => m.Name == searchValue);
                //}


                //total number of rows counts   
                int recordsTotal = 0;
                recordsTotal = Data.Count();
                //Paging   
                var data = Data.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }
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
        #endregion

        #region Online Users

        [HttpGet("[action]")]
        public ActionResult OnlineUsers()
        {
            return View("_Users_online_users_list");
        }

        
        [HttpPost("[action]")]
        public ActionResult OnlineUsers(int dummy)
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault(); // Skip number of Rows count
                var passedParam = Request.Form["myKey"].FirstOrDefault();//passed parameter
                var length = Request.Form["length"].FirstOrDefault();  // Paging Length 10,20  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault(); // Sort Column Name  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();// Sort Column Direction (asc, desc)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();// Search Value from (Search box) 
                int pageSize = length != null ? Convert.ToInt32(length) : 0; //Paging Size (10, 20, 50,100)  
                int skip = start != null ? Convert.ToInt32(start) : 0;






                // getting all Discount data  
                var Data = new List<int>();

                ////Sorting  
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    DiscountData = DiscountData.OrderBy(c => c.sortColumn sortColumnDirection);
                //}
                ////Search  
                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    DiscountData = DiscountData.Where(m => m.Name == searchValue);
                //}


                //total number of rows counts   
                int recordsTotal = 0;
                recordsTotal = Data.Count();
                //Paging   
                var data = Data.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }
        }




        #endregion

        #region UsersReport
        [HttpGet("[action]")]
        public ActionResult UsersReport()
        {
            return View("_Users_report");
        }

        [HttpPost("[action]")]
        public ActionResult UsersReportByRegistration(int dummy)
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault(); // Skip number of Rows count
                var passedParam = Request.Form["myKey"].FirstOrDefault();//passed parameter
                var length = Request.Form["length"].FirstOrDefault();  // Paging Length 10,20  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault(); // Sort Column Name  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();// Sort Column Direction (asc, desc)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();// Search Value from (Search box) 
                int pageSize = length != null ? Convert.ToInt32(length) : 0; //Paging Size (10, 20, 50,100)  
                int skip = start != null ? Convert.ToInt32(start) : 0;






                // getting all Discount data  
                var Data = new List<int>();

                ////Sorting  
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    DiscountData = DiscountData.OrderBy(c => c.sortColumn sortColumnDirection);
                //}
                ////Search  
                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    DiscountData = DiscountData.Where(m => m.Name == searchValue);
                //}


                //total number of rows counts   
                int recordsTotal = 0;
                recordsTotal = Data.Count();
                //Paging   
                var data = Data.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("[action]")]
        public ActionResult UsersReportByBookingTotal(int dummy)
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault(); // Skip number of Rows count
                var passedParam = Request.Form["myKey"].FirstOrDefault();//passed parameter
                var length = Request.Form["length"].FirstOrDefault();  // Paging Length 10,20  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault(); // Sort Column Name  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();// Sort Column Direction (asc, desc)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();// Search Value from (Search box) 
                int pageSize = length != null ? Convert.ToInt32(length) : 0; //Paging Size (10, 20, 50,100)  
                int skip = start != null ? Convert.ToInt32(start) : 0;






                // getting all Discount data  
                var Data = new List<int>();

                ////Sorting  
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    DiscountData = DiscountData.OrderBy(c => c.sortColumn sortColumnDirection);
                //}
                ////Search  
                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    DiscountData = DiscountData.Where(m => m.Name == searchValue);
                //}


                //total number of rows counts   
                int recordsTotal = 0;
                recordsTotal = Data.Count();
                //Paging   
                var data = Data.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }
        }

           [HttpPost("[action]")]
        public ActionResult UsersReportRegistered()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault(); // Skip number of Rows count
                var passedParam = Request.Form["myKey"].FirstOrDefault();//passed parameter
                var length = Request.Form["length"].FirstOrDefault();  // Paging Length 10,20  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault(); // Sort Column Name  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();// Sort Column Direction (asc, desc)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();// Search Value from (Search box) 
                int pageSize = length != null ? Convert.ToInt32(length) : 0; //Paging Size (10, 20, 50,100)  
                int skip = start != null ? Convert.ToInt32(start) : 0;






                // getting all Discount data  
                var Data = new List<int>();

                ////Sorting  
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    DiscountData = DiscountData.OrderBy(c => c.sortColumn sortColumnDirection);
                //}
                ////Search  
                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    DiscountData = DiscountData.Where(m => m.Name == searchValue);
                //}


                //total number of rows counts   
                int recordsTotal = 0;
                recordsTotal = Data.Count();
                //Paging   
                var data = Data.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion




    }



    public class UsersListTable {
        public string Email { get; set; }
        public string Name { get; set; }
        public string UserRole { get; set; }
        public string Phone { get; set; }
        public string Active { get; set; }
        public string CreatedOn { get; set; }
        public string LastActivity { get; set; }
        //public button Edit { get; set; }
    }

    public class UserRolesTable {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool IsSystemRole { get; set; }
        //public button Edit { get; set; }
    }

    public class OnlineUsersTable {
        public string UserInfo { get; set; }
        public string IpAddress { get; set; }
        public string Location { get; set; }
        public string LastActivity { get; set; }
        public string LastVisitedPage { get; set; }
    }


    public class UserReportTable {
        public string User { get; set; }
        public string BookingTotal { get; set; }
        public string NumberOfBookings { get; set; }
        public string View { get; set; }
    }

    public class UserReportRegisteredTable {
        public string Period { get; set; }
        public string Count { get; set; }
    }


}