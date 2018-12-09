using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace searchDormWeb.Controllers
{
    public class PageController : Controller
    {
        public IActionResult FrequentlyAskedQuestions()
        {
            return View();
        }



        public IActionResult MobileApp()
        {
            return View("SearchDormMobileApp");
        }
    }
}
