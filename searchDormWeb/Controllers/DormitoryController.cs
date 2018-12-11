using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace searchDormWeb.Controllers
{
    public class DormitoryController : Controller
    {
        public IActionResult Detail()
        {

            return View("DormitoryDetail");
        }


        public IActionResult GetAreaInfoSection()
        {return PartialView("_AreaInfoSection");
        }


        public IActionResult GetCommentsSection()
        {
            return PartialView("_CommentsSection");
        }

        public IActionResult GetDormitoryDescriptionSection()
        {
            return PartialView("_DormitoryDescriptionSection");
        }


        public IActionResult GetFacilitiesSection()
        {
            return PartialView("_FacilitiesSection");
        }
           public IActionResult GetFilterSection()
        {
            return PartialView("_FilterSection");
        }


        public IActionResult GetGoodToKnowSection()
        {
            return PartialView("_GoodToKnowSection");
        }


        public IActionResult GetReviewBottomSection()
        {
            return PartialView("_ReviewBottomSection");
        }


        public IActionResult GetRoomSection()
        {
            return PartialView("_RoomSection");
        }


        public IActionResult GetSlidersSection()
        {
            return PartialView("_SlidersSection");
        }

        public IActionResult GetTopnavDormitorySection()
        {
            return PartialView("_TopnavDormitorySection");
        }

    }
}
