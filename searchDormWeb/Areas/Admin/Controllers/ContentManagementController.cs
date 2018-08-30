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
    public class ContentManagementController : Controller
    {

        // GET: ContentManagement
        [HttpGet("[action]")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("[action]")]
        public IActionResult Topics()
        {
            return View("_Topics");
        }

        [HttpGet("[action]")]
        public IActionResult MessageTemplates()
        {
            return View("_MessageTemplates");
        }

        [HttpGet("[action]")]
        public IActionResult Polls()
        {
            return View("_Polls");
        }

        [HttpGet("[action]")]
        public IActionResult Survey()
        {
            return View("_Survey");
        }
    }
}