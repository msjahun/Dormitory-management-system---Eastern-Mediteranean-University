
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using System.Collections;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Globalization;
using Dau.Services.SearchService;
using Microsoft.Extensions.Localization;
using Dau.Data;
using Dau.Services.Dormitory;
using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;

namespace searchDormWeb.Controllers
{

    //[Authorize]
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Home()
        {
            return View();
        }



    }
}