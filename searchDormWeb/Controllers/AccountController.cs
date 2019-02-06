using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dau.Services.Domain.BookingService;
using Dau.Services.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace searchDormWeb.Controllers
{
    [Authorize]
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
                return RedirectToAction("", "Login", new { ReturnUrl = "/Account/Profile" });
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
                return RedirectToAction("", "Login",new { ReturnUrl = "/Account/Settings" });
            }
            return View("AccountSettings");
        }

        public IActionResult Billing()
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (!isAuthenticated)
            {
                //redirect to login page
                return RedirectToAction("", "Login", new { ReturnUrl = "/Account/Billing" });
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
                return RedirectToAction("", "Login", new { ReturnUrl = "/Account/Notifications" });
                //redirect to login page
            }
            return View("AccountNotifications");
        }
    }

}
