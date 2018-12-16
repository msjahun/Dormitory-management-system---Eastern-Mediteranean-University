using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dau.Services.Domain.ExploreEmuService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace searchDormWeb.Controllers
{
    public class ExploreController : Controller
    {
        private readonly IExploreEmuPicsService _exploreEmuPicsService;

        public ExploreController(IExploreEmuPicsService exploreEmuPicsService)
        {
            _exploreEmuPicsService = exploreEmuPicsService;
        }

        public IActionResult Dormitories()
        {
            return View("ExploreEMU");
        }



        public IActionResult ExploreEMUPicsApi()
        {




            return Json(_exploreEmuPicsService.GetExploreEmuPics());

        }


    }

 
}
