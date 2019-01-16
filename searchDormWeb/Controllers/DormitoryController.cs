using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dau.Services.Domain.DormitoryDetailService;
using Dau.Services.Domain.OnScrollAlertService;
using Dau.Services.Domain.LocationServices;
using Dau.Services.Domain.ReviewsServices;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace searchDormWeb.Controllers
{
    public class DormitoryController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IGetAreaInfoService _areaInfoService;
        private readonly ILocationService _locationService;
        private readonly IGetCommentsService _getCommentsService;
        private readonly IGetDormitoryDescriptionService _getDormitoryDescriptionService;
        private readonly IGetFacilitiesService _getFacilitiesService;
        private readonly IGetGoodToKnowService _getGoodToKnowService;
        private readonly IOnScrollAlertService _getOnScrollAlertService;
        private readonly IGetReviewService _getReviewService;
        private readonly IGetRoomsService _getRoomsService;
        private readonly IGetSlidersService _getSlidersService;
        private readonly IGetSpecificRoomService _getSpecificRoomService;
        private readonly IGetTopNavService _getTopNavService;
        private readonly IResolveDormitoryService _resolveDormitoryService;

        public DormitoryController(
            IGetAreaInfoService AreaInfoService,
            IGetCommentsService getCommentsService,
            IGetDormitoryDescriptionService getDormitoryDescriptionService,
            IGetFacilitiesService getFacilitiesService,
            IGetGoodToKnowService getGoodToKnowService,
            IOnScrollAlertService getOnScrollAlertService,
            IGetReviewService getReviewService,
            IGetRoomsService getRoomsService,
            IGetSlidersService getSlidersService,
            IGetSpecificRoomService getSpecificRoomService,
            IGetTopNavService getTopNavService,
            IResolveDormitoryService resolveDormitoryService,
            ILocationService locationService,
            IReviewService reviewService



            )
        {
            _reviewService = reviewService;
            _areaInfoService = AreaInfoService;
            _locationService = locationService;
         _getCommentsService  = getCommentsService;
            _getDormitoryDescriptionService = getDormitoryDescriptionService;
            _getFacilitiesService = getFacilitiesService;
            _getGoodToKnowService = getGoodToKnowService;
            _getOnScrollAlertService = getOnScrollAlertService;
            _getReviewService = getReviewService;
            _getRoomsService = getRoomsService;
            _getSlidersService = getSlidersService;
            _getSpecificRoomService = getSpecificRoomService;
            _getTopNavService = getTopNavService;
            _resolveDormitoryService = resolveDormitoryService;
        }
        [Route("Dormitories/{id}")]
        [Route("Dormitories")]
        public IActionResult Detail(string id)
        {
            string dorm_url = id;
            if (dorm_url == null) return RedirectToAction("Results", "Search");
            var dormitoryId = _resolveDormitoryService.GetDormitoryIdBySEOFriendlyName(dorm_url);

            if (dormitoryId != 0)
            {

                return View("DormitoryDetail", dormitoryId);

            }
            return RedirectToAction("Results", "Search");

        }



        public IActionResult GetAreaInfoSection(long id)
        {
            var DormitoryId = id;
            var model = _areaInfoService.GetAreaInfo(DormitoryId);

            return PartialView("_AreaInfoSection", model);
        }


        public IActionResult GetCommentsSection(long id)
        {

            var DormitoryId = id;
            var modelList = _getCommentsService.GetComments(DormitoryId);
            
            return PartialView("_CommentsSection", modelList);
        }

        public IActionResult GetDormitoryDescriptionSection(long id)
        {

            var DormitoryId = id;
            var model = _getDormitoryDescriptionService.GetDormitoryDescription(DormitoryId);
            return PartialView("_DormitoryDescriptionSection", model);
        }


        public IActionResult GetFacilitiesSection(long id)
        {

            var DormitoryId = id;
            var modelList = _getFacilitiesService.GetFacilities(DormitoryId);
        
            return PartialView("_FacilitiesSection", modelList);
        }


        public IActionResult GetFilterSection(long id)
        {
          

            return PartialView("_FilterSection");
        }


        public IActionResult GetGoodToKnowSection(long id)
        {

            var DormitoryId = id;
            var model = _getGoodToKnowService.GetGoodToKnowInfo(DormitoryId);
            return PartialView("_GoodToKnowSection", model);
        }


        public IActionResult GetReviewBottomSection(long id)
        {

            var DormitoryId = id;
            var model = _getReviewService.GetReview(DormitoryId);
            return PartialView("_ReviewBottomSection",model);
        }


        public IActionResult GetRoomSection(long id)
        {

            var DormitoryId = id;
            var modelList = _getRoomsService.GetRooms(DormitoryId);
            return PartialView("_RoomSection", modelList);
        }

        public IActionResult GetSpecificRoomView(long id)

        {
            var RoomId = id;
            var model = _getSpecificRoomService.GetSpecificRoom(RoomId);

            return PartialView("_SpecificRoomView", model);
        }


        public IActionResult GetSlidersSection(long id)

        {
            var DormitoryId = id;
            var model = _getSlidersService.GetSliders(DormitoryId);
            return PartialView("_SlidersSection", model);
        }

        public IActionResult GetTopnavDormitorySection(long id)
        {

            var DormitoryId = id;
            var model = _getTopNavService.GetTopNav(DormitoryId);

            return PartialView("_TopnavDormitorySection", model);
        }
        
        public IActionResult CalculateDistanceToEMULocation(CalculateDistanceToEMULocationVm vm)
        {
            var Inputmodel = vm;
            var model = _locationService.GetCalculatedDistanceToEmulocationAsync(vm).Result;
                
            

           // model = null;
          //  var model = _getTopNavService.GetTopNav(DormitoryId);

           return PartialView("_DistanceToEMULocation", model);
         //   return PartialView();
        }

        public IActionResult AddReview(ReviewInputVm vm)
        {
            var Inputmodel = vm;
            // var model = _locationService.GetCalculatedDistanceToEmulocationAsync(vm).Result;

            var model = _reviewService.AddReviewService(vm);

            // model = null;
            //  var model = _getTopNavService.GetTopNav(DormitoryId);

            return Json(model);
         //   return PartialView();
        }



        public IActionResult GetOnScrollAlert(long id)
        {
            
            var modelList = _getOnScrollAlertService.GetOnScrollAlert();

            Random rnd = new Random();
            int randomNumber = rnd.Next(modelList.Count);

            return PartialView("_onScrollAlert", modelList[randomNumber]);
        }
    }

  
}
