using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dau.Core.Domain.Users;
using Dau.Services.Domain.BookingService;
using Dau.Services.Domain.ImageServices;
using Dau.Services.Users;
using Dau.Services.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace searchDormWeb.Controllers
{
 
    public class AccountController : Controller
    {
        private readonly IImageService _imageService;
        private readonly IBookingService _bookingservice;
        private readonly IApiLogService _apiLogService;
        private readonly IUsersService _UserService;
        private readonly IStringLocalizer _Localizer;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AccountController(IApiLogService apiLogService,
            IBookingService bookingService,
            IUsersService userService,
            IStringLocalizer localizer,
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IImageService imageService)
        {
            _imageService = imageService;
            _bookingservice = bookingService;
            _apiLogService = apiLogService;
            _UserService = userService;
            _Localizer = localizer;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Profile()
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (!isAuthenticated)
            {
                return RedirectToAction("", "Login", new { ReturnUrl = "/Account/Profile" });
                //redirect to login page
            }
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
       
            var vm = _UserService.GetUserDetailsAsync(userId).Result;

            if (vm ==null)
                return RedirectToAction("", "Login", new { ReturnUrl = "/Account/Profile" });

            return View("AccountProfile",vm);
        }





        //public IActionResult Settings()
        //{
        //    bool isAuthenticated = (User.Identity.IsAuthenticated);
        //    if (!isAuthenticated)
        //    {
        //        //redirect to login page
        //        return RedirectToAction("", "Login",new { ReturnUrl = "/Account/Settings" });
        //    }
        //    return View("AccountSettings");
        //}

        public IActionResult Billing()
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (!isAuthenticated)
            {
                //redirect to login page
                return RedirectToAction("", "Login", new { ReturnUrl = "/Account/Billing" });
            }
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
         
            List <BookingAccountVM> model = _bookingservice.GetUserBookings(userId);





            return View("AccountBilling",model);
        }

        public IActionResult Notifications()
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (!isAuthenticated)
            {
                return RedirectToAction("", "Login", new { ReturnUrl = "/Account/Notifications" });
                //redirect to login page
            }
            return View("AccountNotifications");
        }



        [HttpPost]
        public async Task<ActionResult> GeneralInformation(AccountProfileVm vm)
        {
            if (!ModelState.IsValid)
                return View("AccountProfile", vm);
            //save and return model
         
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var success = _UserService.UpdateUserInfoAsync(userId, vm);
          
            var model = _UserService.GetUserDetailsAsync(userId).Result;

            model.SavedSuccessfully = success.Result;
            model.SuccessMessage = _Localizer["User General information updated successfully"];

            return View("AccountProfile", model);
        }


        [HttpPost]
        public async Task<ActionResult> UpdateProfilePhoto()
        {
          
            //upload image and get back imagePath string then update User
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var user = await _userManager.FindByIdAsync(userId);
            //if old password is correct
            user.UserImageUrl = _imageService.UploadUserImage();

            var succedded = await _userManager.UpdateAsync(user);

            var model = _UserService.GetUserDetailsAsync(userId).Result;

            model.SavedSuccessfully = succedded.Succeeded;
            model.SuccessMessage = _Localizer["User photo updated successfully"];
            if (!succedded.Succeeded)
            {
                foreach (var error in succedded.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("AccountProfile", model);

            }


            return View("AccountProfile", model);
        }



        [HttpPost]
        public async Task<ActionResult> ChangePassword(AccountProfileVm vm)
        {
            //    if (!ModelState.IsValid)
            //  return View("AccountProfile", vm);
            bool modelError = false;
            if (string.IsNullOrEmpty(vm.OldPassword))
            {
                ModelState.AddModelError("", _Localizer["Old password cannot be empty"]);
                modelError = true;
            }

            if (string.IsNullOrEmpty( vm.Password))
            {
                ModelState.AddModelError("", _Localizer["New Password cannot be empty"]);
                modelError = true;
            }

            if (string.IsNullOrEmpty(vm.ConfirmPassword))
            {
                ModelState.AddModelError("", _Localizer["Confirm password field cannot be empty"]);
                modelError = true;
            }

            if (!string.IsNullOrEmpty(vm.Password)&& !string.IsNullOrEmpty(vm.ConfirmPassword)&& !(vm.Password.Equals(vm.ConfirmPassword)))
            {
                ModelState.AddModelError("", _Localizer["New Password and Confirm password do not match"]);
                modelError = true;
                
            }

            if(modelError) return View("AccountProfile", vm); 

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var User = await _userManager.FindByIdAsync(userId);
            //if old password is correct
        
          
           var succedded =await _userManager.ChangePasswordAsync(User, vm.OldPassword, vm.Password);
            if (!succedded.Succeeded)
            {
                foreach(var error in succedded.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
              
                return View("AccountProfile", vm);

            }


            var model = _UserService.GetUserDetailsAsync(userId).Result;
            model.SavedSuccessfully = succedded.Succeeded;
            model.SuccessMessage = _Localizer["User password updated successfully"];




                return View("AccountProfile",model);
        }
    }


}
