using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace searchDormWeb.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class ReservationsController : Controller
    {


        #region Reservations
        [HttpGet("[action]")]
        [HttpGet("")]
        public ActionResult List()
        {
            return View("List");
        }

        [HttpGet("[action]")]
        public ActionResult ReservationEdit()
        {
            return View("_ReservationEdit");

        }


        #endregion

        #region CancelRequests
        [HttpGet("[action]")]
        public ActionResult CancelRequest()
        {
            return View("CancelRequest");

        }

        #endregion

        #region CurrentWishList
        [HttpGet("[action]")]
        public ActionResult CurrentWishList()
        {
            return View("CurrentWishList");
        }
        #endregion

        #region BestSellerRooms
        [HttpGet("[action]")]
        public ActionResult BestSellerRooms()
        {
            return View("BestSellerRooms");
        }
        #endregion


        #region RoomsNeverReserved
        [HttpGet("[action]")]
        public ActionResult RoomsNeverReserved()
        {
            return View("RoomsNeverReserved");
        }
        #endregion


        #region CountryReport

        [HttpGet("[action]")]
        public ActionResult CountryReport()
        {
            return View("CountryReport");
        }

        #endregion
    }
}