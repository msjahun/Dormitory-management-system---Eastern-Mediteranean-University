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
    
        #region Settings

        [HttpGet("[action]")]
        public IActionResult Settings()
        {
            return View("Settings");
        }

        #endregion

        #region Client

        [HttpGet("[action]")]
        public IActionResult Clients()
        {
            return View("Clients");
        }

        [HttpGet("[action]")]
        public IActionResult ClientAdd()
        {
            return View("_ClientAdd");
        }


        [HttpGet("[action]")]
        public IActionResult ClientEdit()
        {
            return View("_ClientEdit");
        }


        #endregion

        #region Documentation
        [HttpGet("[action]")]
        public IActionResult Documentation()
        {
            return View("Documentation");
        }

        #endregion
    }
}