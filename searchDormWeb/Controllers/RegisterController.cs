using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dau.Core.Domain.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using searchDormWeb.Models;

namespace searchDormWeb.Controllers
{
    //[Authorize]
    public class RegisterController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public RegisterController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = vm.Email, Email = vm.Email };
                var result = await userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }

            }
            return View(vm);
        }

    }
}