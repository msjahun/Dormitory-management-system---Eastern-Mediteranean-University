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
    public class ReservationsController : Controller
    {



        [HttpGet("[action]")]
        [HttpGet("")]
        public ActionResult List()
        {
            return View("List");
        }

        [HttpGet("[action]")]
        public ActionResult CancelRequest()
        {
            return View("CancelRequest");

        }

        [HttpGet("[action]")]
        public ActionResult CurrentWishList()
        {
            return View("CurrentWishList");
        }

        [HttpGet("[action]")]
        public ActionResult BestSellerRooms()
        {
            return View("BestSellerRooms");
        }

        [HttpGet("[action]")]
        public ActionResult RoomsNeverReserved()
        {
            return View("RoomsNeverReserved");
        }

        [HttpGet("[action]")]
        public ActionResult CountryReport()
        {
            return View("CountryReport");
        }
    }
}