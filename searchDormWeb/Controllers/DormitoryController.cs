using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dau.Services.Domain.DormitoryDetailService;
using Dau.Services.Domain.OnScrollAlertService;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace searchDormWeb.Controllers
{
    public class DormitoryController : Controller
    {
        private readonly IGetAreaInfoService _areaInfoService;
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
            IGetTopNavService getTopNavService



            )
        {
            _areaInfoService = AreaInfoService;

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
        }
        [Route("Dormitories/{id}")]
        [Route("Dormitories")]
        public IActionResult Detail(string id)
        {
            string dorm_url = id;
            if(dorm_url == null) return RedirectToAction("Results", "Search");
           
            return View("DormitoryDetail", dorm_url);
        }



        public IActionResult GetAreaInfoSection(string id)
        {
            string dorm_url = id;
            if (dorm_url == null) return NotFound();


            var model = _areaInfoService.GetAreaInfo();

            return PartialView("_AreaInfoSection", model);
        }


        public IActionResult GetCommentsSection(string id)
        {
            string dorm_url = id;
            if (dorm_url == null) return NotFound();


            var modelList = _getCommentsService.GetComments();
            
            return PartialView("_CommentsSection", modelList);
        }

        public IActionResult GetDormitoryDescriptionSection(string id)
        {
            string dorm_url = id;
            if (dorm_url == null) return NotFound();

            var model = _getDormitoryDescriptionService.GetDormitoryDescription();
            return PartialView("_DormitoryDescriptionSection", model);
        }


        public IActionResult GetFacilitiesSection(string id)
        {
            string dorm_url = id;
            if (dorm_url == null) return NotFound();


            var modelList = _getFacilitiesService.GetFacilities();
        
            return PartialView("_FacilitiesSection", modelList);
        }


        public IActionResult GetFilterSection(string id)
        {
            string dorm_url = id;
            if (dorm_url == null) return NotFound();


            return PartialView("_FilterSection");
        }


        public IActionResult GetGoodToKnowSection(string id)
        {
            string dorm_url = id;
            if (dorm_url == null) return NotFound();


            var model = _getGoodToKnowService.GetGoodToKnowInfo();
            return PartialView("_GoodToKnowSection", model);
        }


        public IActionResult GetReviewBottomSection(string id)
        {
            string dorm_url = id;
            if (dorm_url == null) return NotFound();


            var model = _getReviewService.GetReview();
            return PartialView("_ReviewBottomSection",model);
        }


        public IActionResult GetRoomSection(string id)
        {
            string dorm_url = id;
            if (dorm_url == null) return NotFound();


            var modelList = _getRoomsService.GetRooms();
            return PartialView("_RoomSection", modelList);
        }

        public IActionResult GetSpecificRoomView(string id)

        {
            string dorm_url = id;
            if (dorm_url == null) return NotFound();


            var model = _getSpecificRoomService.GetSpecificRoom();

            return PartialView("_SpecificRoomView", model);
        }


        public IActionResult GetSlidersSection(string id)

        {
            string dorm_url = id;
            if (dorm_url == null) return NotFound();


            var model = _getSlidersService.GetSliders();
            return PartialView("_SlidersSection", model);
        }

        public IActionResult GetTopnavDormitorySection(string id)
        {
            string dorm_url = id;
            if (dorm_url == null) return NotFound();


            var model = _getTopNavService.GetTopNav();

            return PartialView("_TopnavDormitorySection", model);
        }

        public IActionResult GetOnScrollAlert(string id)
        {
            string dorm_url = id;
            if (dorm_url == null) return NotFound();

            var modelList = _getOnScrollAlertService.GetOnScrollAlert();

            Random rnd = new Random();
            int randomNumber = rnd.Next(modelList.Count);

            return PartialView("_onScrollAlert", modelList[randomNumber]);
        }
    }
















}
