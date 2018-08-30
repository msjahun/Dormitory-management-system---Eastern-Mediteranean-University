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
    public class ReviewsController : Controller
    {
        // GET: Reviews
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
        public IActionResult Reported()
        {
            return View("_Reported");
        }

        [HttpGet("[action]")]
        public IActionResult Flagged()
        {
            return View("_Flagged");
        }

        [HttpGet("[action]")]
        public IActionResult Deleted()
        {
            return View("_Deleted");
        }
    }
}