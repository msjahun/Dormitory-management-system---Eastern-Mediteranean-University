using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using searchDormWeb.Models;


namespace searchDormWeb.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Login");
        }
    }
}