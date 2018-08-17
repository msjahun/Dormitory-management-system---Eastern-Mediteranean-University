using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



namespace searchDormWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        [HttpGet("[action]")]
        [HttpGet("")]
        public ActionResult Index()
        {
            return View("DashboardEMUAdmin");
        }
        [HttpGet("[action]")]
        public ActionResult DashboardEMUAdmin()
        {
            return View("DashboardEMUAdmin");
        }

        [HttpGet("[action]")]
        public ActionResult DashboardDormManager()
        {
            return View("DashboardDormManager");
        }
    }
}