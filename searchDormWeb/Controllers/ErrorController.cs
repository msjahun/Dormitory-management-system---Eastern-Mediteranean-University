using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace searchDormWeb.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult AccessDenied(string ReturnUrl)
        {
            ViewData["ReturnUrl"] = ReturnUrl;
            return View("AccessDenied");
        }


        public IActionResult UnAuthorized()
        {
            return View("UnAuthorized");
        }


        public IActionResult PageNotFound()
        {
            return View("PageNotFound");
        }

        public IActionResult Status(string error_id)
        {
            if(error_id == "401")
            {
                return View("UnAuthorized", error_id);
            }
            else
                return View("PageNotFound", error_id);
        }
    }
}