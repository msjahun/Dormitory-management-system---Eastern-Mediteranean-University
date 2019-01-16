using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dau.Core.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using searchDormWeb.Configuration;
using searchDormWeb.Models;

namespace searchDormWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<UserRole> _roleManager;

        public IStringLocalizer Localizer { get; }

        private readonly ILogger<LoginController> _logger;

        public LoginController(SignInManager<User> signInManager, RoleManager<UserRole> roleManager, ILogger<LoginController> logger , IStringLocalizer _Localizer, UserManager<User> userManager)
        {
            Localizer = _Localizer;
            _logger = logger;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;

         // new UserRoleSeed(_roleManager).Seed();
        }

        [Route("Login")]
        // GET: Login
        [HttpGet]
        public ActionResult Index(string ReturnUrl)
        {
            ViewData["ReturnUrl"] = ReturnUrl;
                return View("Index");
        }
        [Route("Login/")]
        [HttpPost]
        public async Task<ActionResult> Index(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Users.FirstOrDefault(s => s.Email == vm.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", Localizer["User doesn't exist"]);
                    return View(vm);
                }

                if (user.EmailConfirmed ==false)
                {
                    ModelState.AddModelError("", Localizer["Please verify your email before signing in"]);
                    return View(vm);
                }
                var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, vm.RememberMe, false);
             
                if (result.Succeeded)
                {
                    _logger.LogInformation("Successful login.");
                    var st = vm.ReturnUrl;
                    if (st!=null) 
                    return Redirect(vm.ReturnUrl);
                else
                      

              return RedirectToAction("", "Home");
                }

                ModelState.AddModelError("", Localizer["Invalid Login attempt"]);
                _logger.LogWarning("Invalid Login attempt.");
            }


            return View(vm);
        }

        [Route("Logout/")]
        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("", "Home");
        }



        public async Task<IActionResult> ConfirmEmail(string userid, string token)
        {
           var user = _userManager.FindByIdAsync(userid).Result;
            IdentityResult result = _userManager.
                        ConfirmEmailAsync(user, token).Result;
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                ViewBag.Message = "Email confirmed successfully!";
                return View();
            }
            else
            {
                ViewBag.Message = "Error while confirming your email!";
                return View();
            }
        }

        public IActionResult RecoverAccount()
        {
            return View();
        }
    }
}