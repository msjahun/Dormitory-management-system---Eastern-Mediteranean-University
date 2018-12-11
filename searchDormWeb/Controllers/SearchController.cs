using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace searchDormWeb.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Results()
        {
            return View("SearchResultPage");
        }


        public IActionResult GetDormitoryResultView()
        {
            return PartialView("_DormitoryResultView");
        }


        public IActionResult GetFilterbottomFacilities()
        {
            return PartialView("_FilterbottomFacilities");
        }


        public IActionResult GetRoomResultView()
        {
            return PartialView("_RoomResultView");
        }


        public IActionResult GetSortingButtonSection()
        {
            return PartialView("_SortingButtonsSection");
        }
    }
}
