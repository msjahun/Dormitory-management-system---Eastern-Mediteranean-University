using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dau.Core.Domain.Users;
using Dau.Services.Domain.BookingService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace searchDormWeb.Controllers
{
    public class BookingController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IBookingService _bookingService;

        public BookingController(SignInManager<User> signInManager,
            IBookingService bookingService)
        {
            _signInManager = signInManager;
            _bookingService = bookingService;
        }

        public IActionResult Cart()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("", "Login", new { ReturnUrl="/Booking/Cart" });
            }
            return View("BookingCheckout");
        }

        //create booking Services and abstract all these stuff there

        public IActionResult CheckoutCustomer()
        {

            var model = _bookingService.GetCheckoutCustomerService();
            return PartialView("BookingCheckoutCustomer", model);
        }


        public IActionResult CheckoutCart()
        {
            var model = _bookingService.GetCheckoutCartService();
            
            if (model == null) {
                return PartialView("BookingCartEmpty");

            }
            return PartialView("BookingCart", model);
        }

        public IActionResult GetCartItemJson()
        {
            var model = _bookingService.GetCheckoutCartService();
            return Json(model);
        }

        public IActionResult CheckoutAddress()
        {
            return PartialView("BookingCheckoutAddress");
        }

        public IActionResult BookingConfirmation()
        {
            //transfer cart data to bookingData,
            //delete cart items
            var AddBookingSuccess = _bookingService.AddBooking();

            var DeleteItemFromCart = _bookingService.DeleteItemFromCart();

            
            return PartialView(AddBookingSuccess && DeleteItemFromCart);
        }

        public IActionResult CheckoutPayment()
        {

            var model = _bookingService.GetCheckoutPaymentService();
            return PartialView("BookingCheckoutPayment", model);
        }

        public IActionResult CartEmpty()
        {
            return PartialView("BookingCartEmpty");
        }

        public IActionResult DeleteCartItem()
        {
            var success =_bookingService.DeleteItemFromCart();
          
            return Json(success);
        }


        public IActionResult UpdateSemesterPeriod(long Id)
        {
            var success =_bookingService.UpdateSemesterPeriod(Id);
          
            return Json(success);
        }

        public IActionResult AddToCart(int Id)
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (!isAuthenticated)
            {
                return RedirectToAction("", "Login", new { ReturnUrl = "/Booking/Cart" });
            }
            var RoomId = Id;
            var success = _bookingService.AddToCart(RoomId);
            return RedirectToAction("Cart", "Booking");
       
        }
    }

  
}
