
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using System.Collections;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Globalization;

using Microsoft.Extensions.Localization;
using Dau.Data;

using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;
using Dau.Services.Domain.HomeService;

namespace searchDormWeb.Controllers
{

    //[Authorize]
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public IStringLocalizer Localizer { get; }

        private readonly IGetHomeDormitoriesService _getHomeDormitoriesService;
        private readonly IGetHomeBackgroundImagesService _getHomeBackgroundImagesService;

        public HomeController(IStringLocalizer _Localizer,

            IGetHomeDormitoriesService getHomeDormitoriesService,
            IGetHomeBackgroundImagesService getHomeBackgroundImagesService,
             IHomeService homeService
            )
        {
            _homeService = homeService;
            Localizer = _Localizer;
            _getHomeDormitoriesService = getHomeDormitoriesService;
            _getHomeBackgroundImagesService = getHomeBackgroundImagesService;
        }
        [Route("")]
        public IActionResult Home()
        {
            return View();
        }


        public IActionResult GetPopularDormitories(DormitoryPartialModel Model)
        {
            var model = _getHomeDormitoriesService.GetPopularDormitories(Model);


            return PartialView("DormitoryPartial", model);
        }


        public IActionResult GetHighlyRatedDormitories(DormitoryPartialModel Model)
        {
            var model = _getHomeDormitoriesService.GetHighlyRatedDormitories(Model);


            return PartialView("DormitoryPartial", model);
        }


        public IActionResult GetCoolOffersDeals(DormitoryPartialModel Model)
        {
            var model = _getHomeDormitoriesService.GetCoolOffersDeals(Model);


            return PartialView("DormitoryPartial", model);
        }


        public IActionResult GetHomeBackgroundImages()
        {
            return Json(_getHomeBackgroundImagesService.GetBackgrouindImages());

        }


        public IActionResult GetSearchSuggestion(string searchTerm)
        {
            var model = _homeService.GetSearchSuggestions(searchTerm);

            return PartialView(model);
        }

    }

    
}