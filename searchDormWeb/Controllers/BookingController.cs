using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace searchDormWeb.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Cart()
        {
            return View("BookingCart");
        }

        public IActionResult CheckoutCustomer()
        {
            return View("BookingCheckoutCustomer");
        }

        public IActionResult CheckoutAddress()
        {
            return View("BookingCheckoutAddress");
        }

        public IActionResult CheckoutPayment()
        {
            return View("BookingCheckoutPayment");
        }

        public IActionResult CartEmpty()
        {
            return View("BookingCartEmpty");
        }
    }
}
