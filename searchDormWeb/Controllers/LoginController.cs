using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dau.Core.Domain.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using searchDormWeb.Configuration;
using searchDormWeb.Models;

namespace searchDormWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<UserRole> _roleManager;
        public LoginController(SignInManager<User> signInManager, RoleManager<UserRole> roleManager)
        {
            _roleManager = roleManager;
            _signInManager = signInManager;

         // new UserRoleSeed(_roleManager).Seed();
        }

        [Route("Login/")]
        // GET: Login
        [HttpGet]
        public ActionResult Index(string ReturnUrl)
        {
            ViewData["ReturnUrl"] = ReturnUrl;
                return View("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Index(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, vm.RememberMe, false);
             
                if (result.Succeeded)
                {
                  
                    var st = vm.ReturnUrl;
                    if (st!=null) 
                    return Redirect(vm.ReturnUrl);
                else
                      

              return RedirectToAction("Home", "debug");
                }

                ModelState.AddModelError("", "Invalid Login attempt");
            }


            return View(vm);
        }

        [Route("Logout/")]
        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Home", "debug");
        }
    }
}