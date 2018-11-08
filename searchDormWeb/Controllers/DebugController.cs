using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace searchDormWeb.Controllers
{
    public class DebugController : Controller
    {
        public IActionResult AccountProfile()
        {
            return View();
        }

        public IActionResult AccountSettings()
        {
            return View();
        }

        public IActionResult AccountBilling()
        {
            return View();
        }

        public IActionResult AccountNotifications()
        {
            return View();
        }

        public IActionResult BookingCart()
        {
            return View();
        }

        public IActionResult BookingCheckoutCustomer()
        {
            return View();
        }

        public IActionResult BookingCheckoutAddress()
        {
            return View();
        }

        public IActionResult BookingCheckoutPayment()
        {
            return View();
        }

        public IActionResult BookingCartEmpty()
        {
            return View();
        }



        public IActionResult Login()
        {
            return View();
        }



        public IActionResult Register()
        {
            return View();
        }



        public IActionResult RecoverAccount()
        {
            return View();
        }



        public IActionResult FrequentlyAskedQuestions()
        {
            return View();
        }


        [Route("Debug/")]
        public IActionResult ExploreEMU()
        {
            return View();
        }



        public IActionResult SearchDormMobileApp()
        {
            return View();
        }





    }
}