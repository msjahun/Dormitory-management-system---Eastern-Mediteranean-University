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
    public class CatalogController : Controller
    {
        

        #region Rooms
        [HttpGet("[action]")]
        public ActionResult Rooms()
        {
          //  var Claims = User.Claims;
            return View("Rooms");
        }


        [HttpGet("[action]")]
        public ActionResult RoomAdd()
        {
            return View("_RoomAdd");
        }


        [HttpGet("[action]")]
        public ActionResult RoomEdit()
        {
           
            return View("_RoomEdit");
        }


        #endregion

        #region DormitoryBlocks
        [HttpGet("[action]")]
        public ActionResult DormitoryBlocks()
        {
            return View("DormitoryBlocks");
        }

        [HttpGet("[action]")]
        public ActionResult DormitoryBlockAdd()
        {
            return View("_DormitoryBlockAdd");
        }

        [HttpGet("[action]")]
        public ActionResult DormitoryBlockEdit()
        {
            return View("_DormitoryBlockEdit");
        }
        #endregion

        #region BulkRoomEdit
        [HttpGet("[action]")]
        public ActionResult BulkRoomEdit()
        {
            return View("BulkRoomEdit");
        }


        #endregion

        #region LowQuotaReport
        [HttpGet("[action]")]
        public ActionResult LowQuotaReport()
        {
            return View("LowQuotaReport");
        }
        #endregion

        #region RoomReviews
        [HttpGet("[action]")]
        public ActionResult RoomReviews()
        {
            return View("RoomReviews");
        }

        [HttpGet("[action]")]
        public ActionResult RoomReviewEdit()
        {
            return View("_RoomReviewEdit");
        }

        #endregion

        #region Facilities
        [HttpGet("[action]")]
        public ActionResult Facilities()
        {
            return View("Facilities");
        }

        [HttpGet("[action]")]
        public ActionResult FacilityAdd()
        {
            return View("_FacilityAdd");
        }

        [HttpGet("[action]")]
        public ActionResult FacilityEdit()
        {
            return View("_FacilityEdit");
        }

        #endregion
    }
}