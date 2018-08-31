using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace searchDormWeb.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize]
        [DisplayName("AdminAreaRedirect")]
        public ActionResult Index()
        {


           
                return RedirectToAction("", "Dashboard", new { Area = "Admin" });
           
          
        }
    }
}