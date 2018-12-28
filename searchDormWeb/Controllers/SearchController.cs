using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dau.Services.Domain.SearchResultService;
using Dau.Services.Domain.OnScrollAlertService;
using Dau.Services.Domain.FeaturesServices;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace searchDormWeb.Controllers
{
    public class SearchController : Controller
    {
        private readonly IOnScrollAlertService _getOnScrollAlertService;
        private readonly IFeaturesService _featuresService;
        private readonly IRoomResultService _roomResultService;
        private readonly IFilterBottomService _filterBottomService;
        private readonly IDormitoryResultService _dormitoryResultService;
        private readonly ISearchService _searchService;

        public SearchController(IOnScrollAlertService getOnScrollAlertService,
            IRoomResultService roomResultService,
            IFilterBottomService filterBottomService,
            IDormitoryResultService dormitoryResultService,
            IFeaturesService featuresService,
            ISearchService searchService)
        {
            _getOnScrollAlertService = getOnScrollAlertService;
            _featuresService = featuresService;
            _roomResultService=  roomResultService;
            _filterBottomService= filterBottomService;
            _dormitoryResultService= dormitoryResultService;
            _searchService=searchService;
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
            var modelList = _filterBottomService.GetFilterBottom();
         
            return PartialView("_FilterbottomFacilities", modelList);
        }


        public IActionResult GetRoomResultView(GetRoomResultViewModel InputModel)
        {
            //if filters are received well, remove the class and send it to the GetRoomResult service and use it for filtering
           var modelList = _roomResultService.GetRoomResult(InputModel);
            var featuresLogSuccess = _featuresService.UpdateFeaturesHitCount(InputModel.FeaturesIds);

            return PartialView("_RoomResultView", modelList);
        }


        public IActionResult GetDormitoryTypesFilter()
        {
            var model = _searchService.GetDormitoryTypesFilter();
            return PartialView("_options", model);
        }

        public IActionResult GetDormitoriesFilter(int Id)
        {
            var model = _searchService.GetDormitoriesFilter(Id);
            return PartialView("_options", model);
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
