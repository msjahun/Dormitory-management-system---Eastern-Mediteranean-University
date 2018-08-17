using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



namespace searchDormWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class CatalogController : Controller
    {
        // GET: Catalog
        [HttpGet("[action]")]
        [HttpGet("")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("[action]")]
        public ActionResult Rooms()
        {
            return View("Rooms");
        }

        [HttpGet("[action]")]
        public ActionResult DormitoryBlocks()
        {
            return View("DormitoryBlocks");
        }

        [HttpGet("[action]")]
        public ActionResult BulkRoomEdit()
        {
            return View("BulkRoomEdit");
        }

        [HttpGet("[action]")]
        public ActionResult LowQuotaReport()
        {
            return View("LowQuotaReport");
        }

        [HttpGet("[action]")]
        public ActionResult RoomReviews()
        {
            return View("RoomReviews");
        }

        [HttpGet("[action]")]
        public ActionResult FacilitiesSpecificationAttrs()
        {
            return View("FacilitiesSpecificationAttrs");
        }
    }
}