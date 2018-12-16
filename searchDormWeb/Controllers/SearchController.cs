using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dau.Services.Domain.SearchResultService;
using Dau.Services.Domain.OnScrollAlertService;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace searchDormWeb.Controllers
{
    public class SearchController : Controller
    {
        private readonly IOnScrollAlertService _getOnScrollAlertService;
        private readonly IRoomResultService _roomResultService;
        private readonly IFilterBottomService _filterBottomService;
        private readonly IDormitoryResultService _dormitoryResultService;

        public SearchController(IOnScrollAlertService getOnScrollAlertService,
            IRoomResultService roomResultService,
            IFilterBottomService filterBottomService,
            IDormitoryResultService dormitoryResultService )
        {
            _getOnScrollAlertService = getOnScrollAlertService;

            _roomResultService=  roomResultService;
            _filterBottomService= filterBottomService;
            _dormitoryResultService= dormitoryResultService;
        }

        public IActionResult Results()
        {
            return View("SearchResultPage");
        }
        

        public IActionResult GetDormitoryResultView()
        {
            var modelList = _dormitoryResultService.GetDormitoryResult();
           
            return PartialView("_DormitoryResultView", modelList);
        }


        public IActionResult GetFilterbottomFacilities()
        {
            List<FiltersFacilityViewModel> modelList = _filterBottomService.GetFilterBottom();
         
            return PartialView("_FilterbottomFacilities", modelList);
        }


        public IActionResult GetRoomResultView()
        {
           var modelList = _roomResultService.GetRoomResult();
        

            return PartialView("_RoomResultView", modelList);
        }


        public IActionResult GetSortingButtonSection()
        {
            return PartialView("_SortingButtonsSection");
        }
        public IActionResult GetOnScrollAlert()
        {
            var modelList = _getOnScrollAlertService.GetOnScrollAlert();

            Random rnd = new Random();
            int randomNumber = rnd.Next(modelList.Count);

            return PartialView("_onScrollAlert", modelList[randomNumber]);
        }
    }




}
