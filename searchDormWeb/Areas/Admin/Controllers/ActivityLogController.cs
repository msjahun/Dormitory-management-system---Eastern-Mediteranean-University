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
    public class ActivityLogController : Controller
    {// GET: ActivityLog

        [HttpGet("[action]")]
        public IActionResult Index()
        {
            return View("_ActivityLog_Log");
        }


        [HttpGet("[action]")]
        public IActionResult Log()
        {
            return View("_ActivityLog_Log");
        }

        [HttpGet("[action]")]
        public IActionResult Type()
        {
            return View("_ActivityLog_logtype");
        }
    }
}