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
    public class MobileAppManagerController : Controller
    {
        // GET: MobileAppManager
        [HttpGet("[action]")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("[action]")]
        public IActionResult SendPushNotifications()
        {
            return View("_SendPushNotifications");
        }

        [HttpGet("[action]")]
        public IActionResult UsageReport()
        {
            return View("_UsageReport");
        }
    }
}