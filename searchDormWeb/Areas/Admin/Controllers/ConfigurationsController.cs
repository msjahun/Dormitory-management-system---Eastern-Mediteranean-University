using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace searchDormWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class ConfigurationsController : Controller
    {
        [HttpGet("[action]")]
        [HttpGet("")]// GET: Configurations
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet("[action]")]
       
        public ActionResult EmailAccounts()
        {
            return View("EmailAccounts");
        }


        [HttpGet("[action]")]
        public ActionResult Dormitories()
        {
            return View("Dormitories");
        }


        [HttpGet("[action]")]
        public ActionResult Countries()
        {
            return View("Countries");
        }


        [HttpGet("[action]")]
        public ActionResult Languages()
        {
            return View("Languages");
        }


        [HttpGet("[action]")]
        public ActionResult AccessControlList()
        {
            return View("AccessControlList");
        }


        [HttpGet("[action]")]
        public ActionResult Currencies()
        {
            return View("Currencies");
        }



    }
}