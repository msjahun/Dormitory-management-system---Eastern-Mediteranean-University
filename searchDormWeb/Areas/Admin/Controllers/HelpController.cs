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
    public class HelpController : Controller
    {
     

        [HttpGet("[action]")]
        public IActionResult Topics()
        {
            return View("_Topics");
        }

        [HttpGet("[action]")]
        public IActionResult FAQ()
        {

            return View("_FAQ");
        }
    }
}