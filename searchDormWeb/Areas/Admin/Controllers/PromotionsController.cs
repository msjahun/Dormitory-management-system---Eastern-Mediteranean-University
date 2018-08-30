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
    public class PromotionsController : Controller
    {
        // GET: Promotions
        [HttpGet("[action]")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("[action]")]
        public IActionResult Discounts()
        {
            return View("_Discounts");
        }


        [HttpGet("[action]")]
        public IActionResult Affiliates()
        {
            return View("_Affiliates");
        }


        [HttpGet("[action]")]
        public IActionResult NewsLetterSubscribers()
        {
            return View("_NewsLetterSubscribers");
        }

        [HttpGet("[action]")]
        public IActionResult Campaigns()
        {
            return View("_Campaigns");
        }

    }
}