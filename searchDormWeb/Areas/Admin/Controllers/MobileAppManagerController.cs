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
      
        #region PushNotifications
        [HttpGet("[action]")]
        public IActionResult PushNotifications()
        {
            return View("_PushNotifications");
        }

        [HttpGet("[action]")]
        public IActionResult PushNotificationAdd()
        {
            return View("_PushNotificationAdd");
        }

        [HttpGet("[action]")]
        public IActionResult PushNotificationEdit()
        {
            return View("_PushNotificationEdit");
        }

        #endregion

        #region UsageReport
        [HttpGet("[action]")]
        public IActionResult UsageReport()
        {
            return View("_UsageReport");
        }

        #endregion
    }
}