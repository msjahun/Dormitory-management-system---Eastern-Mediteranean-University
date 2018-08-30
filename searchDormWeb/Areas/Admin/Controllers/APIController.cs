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
    public class APIController : Controller
    {
        // GET: API
        [HttpGet("[action]")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("[action]")]
        public IActionResult Settings()
        {
            return View("Settings");
        }

        [HttpGet("[action]")]
        public IActionResult Client()
        {
            return View("Client");
        }

        [HttpGet("[action]")]
        public IActionResult Documentation()
        {
            return View("Documentation");
        }
    }
}