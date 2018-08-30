using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace searchDormWeb.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize]
    public class SystemController : Controller
    {
        // GET: System
        [HttpGet("[action]")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("[action]")]
        public IActionResult Information()
        {
            return View("_Information");
        }


        [HttpGet("[action]")]
        public IActionResult Log()
        {

            return View("_Log");
        }


        [HttpGet("[action]")]
        public IActionResult Warnings()
        {
            return View("_Warnings");
        }


        [HttpGet("[action]")]
        public IActionResult Maintenance()
        {
            return View("_Maintenance");
        }


        [HttpGet("[action]")]
        public IActionResult MessageQueues()
        {
            return View("_MessageQueues");
        }

        [HttpGet("[action]")]
        public IActionResult ScheduleTasks()
        {
            return View("_ScheduleTasks");
        }

        [HttpGet("[action]")]
        public IActionResult SEOFriendlyPageNames()
        {
            return View("_SEOFriendlyPageNames");
        }
    }
}