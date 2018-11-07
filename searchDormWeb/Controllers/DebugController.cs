using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace searchDormWeb.Controllers
{
    public class DebugController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}