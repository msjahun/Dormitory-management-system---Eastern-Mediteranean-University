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
    public class DebugController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult TagHelpers()
        {
            return View();
        }
    }
}