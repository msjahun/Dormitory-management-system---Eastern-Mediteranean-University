using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using searchDormWeb.Models;


namespace searchDormWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class UsersController : Controller
    {
        // GET: Users


        [HttpGet("[action]")]
        [HttpGet("")]
        public ActionResult List()
        {
            return View("_Users_list");
        }

        [HttpGet("[action]")]

        public ActionResult Roles()
        {
            return View("_User_roles_list");
        }

        [HttpGet("[action]")]

        public ActionResult OnlineUsers()
        {
            return View("_Users_online_users_list");
        }

        [HttpGet("[action]")]

        public ActionResult UsersReport()
        {
            return View("_Users_report");
        }
    }
}