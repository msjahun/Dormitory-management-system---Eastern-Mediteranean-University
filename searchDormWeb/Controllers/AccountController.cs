using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dau.Services.Domain.BookingService;
using Dau.Services.Utilities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace searchDormWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IBookingService _bookingservice;
        private readonly IApiLogService _apiLogService;

        public AccountController(IApiLogService apiLogService,
            IBookingService bookingService)
        {
            _bookingservice = bookingService;
            _apiLogService = apiLogService;
        }

        public IActionResult Profile()
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (!isAuthenticated)
            {
                return RedirectToAction("", "Login");
                //redirect to login page
            }
            return View("AccountProfile");
        }





        public IActionResult Settings()
        {
            bool isAuthenticated = (User.Identity.IsAuthenticated);
            if (!isAuthenticated)
            {
                //redirect to login page
                return RedirectToAction("", "Login");
            }
            return View("AccountSettings");
        }

        public IActionResult Billing()
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (!isAuthenticated)
            {
                //redirect to login page
                return RedirectToAction("", "Login");
            }
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
         
            List <BookingAccountVM> model = _bookingservice.GetUserBookings(userId);





            return View("AccountBilling",model);
        }

        public IActionResult Notifications()
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (!isAuthenticated)
            {
                return RedirectToAction("", "Login");
                //redirect to login page
            }
            return View("AccountNotifications");
        }
    }

}
