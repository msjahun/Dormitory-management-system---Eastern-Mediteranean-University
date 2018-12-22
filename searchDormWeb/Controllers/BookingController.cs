using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dau.Core.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace searchDormWeb.Controllers
{
    public class BookingController : Controller
    {
        private readonly SignInManager<User> _signInManager;

        public BookingController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Cart()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("", "Login");
            }
            return View("BookingCheckout");
        }



        public IActionResult CheckoutCustomer()
        {

            BookingCheckoutCustomerInfoViewModel model = new BookingCheckoutCustomerInfoViewModel
            {
                BookingDetails = new BookingCartViewModel
                {
                    DormitoryName = "Alfam Dormitories",
                    RoomName = "Single room",
                    RoomBlock = "A. block",
                    RoomSize = "42.5 m2",
                    TaxAmount="$25.00",
                    BookingFee="25.00",
                    StayDuration= "3 months - Summer 2019",
                    SubtotalAmount ="$800 USD",
                    RoomPricePerSemester = "$900 USD",
                    AmountTotal = "$1,800 USD",
                    DormitoryLogoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuzxmbcw2jxGlHQ_ZuICaAowpUUjFoOYTJH9oGmsQmz3WG4IpkSw"
                },
          FirstName="Musa Suleiman",
       
      LastName ="Jahun",
      StudentNumber ="153923",
      ParmanentAddress="No.13 karkasara qtrs kano",
      Country ="Nigeria",
      City ="Kano",
      EmailAddress ="msjahun@live.com",
      PhoneNumber ="+905338264432"
    };
            return PartialView("BookingCheckoutCustomer", model);
        }
        public IActionResult CheckoutCart()
        {
            BookingCartViewModel model = new BookingCartViewModel
            {
                DormitoryName = "Alfam Dormitories",
                RoomName = "Single room",
                RoomBlock = "A. block",
                RoomSize = "42.5 m2",
                RoomPricePerSemester = "$900 USD",
                AmountTotal = "$1,800 USD",
                DormitoryLogoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuzxmbcw2jxGlHQ_ZuICaAowpUUjFoOYTJH9oGmsQmz3WG4IpkSw"
            };

         
            if (model == null) {
                return PartialView("BookingCartEmpty");

            }
            return PartialView("BookingCart", model);
        }

        public IActionResult CheckoutAddress()
        {
            return PartialView("BookingCheckoutAddress");
        }

        public IActionResult BookingConfirmation()
        {
            return PartialView("_bookingConfirmationPage");
        }

        public IActionResult CheckoutPayment()
        {

            BookingCheckoutCustomerInfoViewModel model = new BookingCheckoutCustomerInfoViewModel
            {
                BookingDetails = new BookingCartViewModel
                {
                    DormitoryName = "Alfam Dormitories",
                    RoomName = "Single room",
                    RoomBlock = "A. block",
                    RoomSize = "42.5 m2",
                    TaxAmount = "$25.00",
                    BookingFee = "25.00",
                    StayDuration = "3 months - Summer 2019",
                    SubtotalAmount = "$800 USD",
                    RoomPricePerSemester = "$900 USD",
                    AmountTotal = "$1,800 USD",
                    DormitoryLogoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuzxmbcw2jxGlHQ_ZuICaAowpUUjFoOYTJH9oGmsQmz3WG4IpkSw"
                },
                FirstName = "Musa Suleiman",
                DateBookingExpiresWithoutConfirmation ="09 January 2019",
       NumberOfWorkingDaysBeforeBookingExpires=14,
                LastName = "Jahun",
                StudentNumber = "153923",
                ParmanentAddress = "No.13 karkasara qtrs kano",
                Country = "Nigeria",
                City = "Kano",
                EmailAddress = "msjahun@live.com",
                PhoneNumber = "+905338264432"
            };
            return PartialView("BookingCheckoutPayment", model);
        }

        public IActionResult CartEmpty()
        {
            return PartialView("BookingCartEmpty");
        }
    }

    public class BookingCartViewModel
    {
        public string DormitoryName { get; set; }
        public string DormitoryLogoUrl { get; set; }
        public string RoomName { get; set; }
        public string RoomBlock { get; set; }
        public string RoomSize { get; set; }
        public string AmountTotal { get; set; }
        public string StayDuration { get; set; }
        public string RoomPricePerSemester { get; set; }

        public string SubtotalAmount { get; set; }
        public string BookingFee { get; set; }
        public string TaxAmount { get; set; }
    }

    public class BookingCheckoutCustomerInfoViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentNumber { get; set; }
        public string ParmanentAddress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string DateBookingExpiresWithoutConfirmation { get; set; }
        public int NumberOfWorkingDaysBeforeBookingExpires { get; set; }
        public BookingCartViewModel BookingDetails { get; set; }
        //summary

    }
}
