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
    public class NotificationsController : Controller
    {
        // GET: Notifications
        [HttpGet("[action]")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("[action]")]
        public IActionResult List()
        {
            return View("_List");
        }

        [HttpGet("[action]")]
        public IActionResult Announcements()
        {
            return View("_Announcements");
        }

        [HttpGet("[action]")]
        public IActionResult ManageAnnouncements()
        {
            return View("_ManageAnnouncements");
        }
    }
}