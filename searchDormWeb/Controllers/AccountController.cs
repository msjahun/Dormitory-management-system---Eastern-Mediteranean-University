﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace searchDormWeb.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Profile()
        {
            return View("AccountProfile");
        }





        public IActionResult Settings()
        {
            return View("AccountSettings");
        }

        public IActionResult Billing()
        {
            return View("AccountBilling");
        }

        public IActionResult Notifications()
        {
            return View("AccountNotifications");
        }
    }
}