using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dau.Core.Domain.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace searchDormWeb.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly SignInManager<User> _signInManager;

        public AdminController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }
        // GET: Admin
        //[Authorize]
        [DisplayName("AdminAreaRedirect")]
        public ActionResult Index()
        {

            if(_signInManager.IsSignedIn(User))
                return RedirectToAction("", "Dashboard", new { Area = "Admin" });
           
                return RedirectToAction("", "Login");
            
          



        }
    }
}