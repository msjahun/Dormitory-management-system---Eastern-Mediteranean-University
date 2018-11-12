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

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult DormitoryDetail()
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


        public IActionResult SearchResultPage()
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

        

        public IActionResult ExploreEMUPicsApi()
        {

           
            

            return Json(new List<ExploreImages> {
            new ExploreImages{
                ImageUrl = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047910.jpg?RenditionID=9",
                DormitoryName = "Alfam Dormitory6",
                DormitoryDescription = "Wonderful dormitory"},


                new ExploreImages { ImageUrl = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/photo6010428924410047915.jpg?RenditionID=5",
                DormitoryName = "Alfam Dormitory5",
                DormitoryDescription = "Wonderful dormitory"},


              new ExploreImages   { ImageUrl = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0050%20(1).jpg?RenditionID=8",
                DormitoryName = "Alfam Dormitory6",
                DormitoryDescription = "Wonderful dormitory"},

                      new ExploreImages   { ImageUrl = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0027%20(1).jpg?RenditionID=7",
                DormitoryName = "Alfam Dormitory7",
                DormitoryDescription = "Wonderful dormitory"},


                              new ExploreImages   { ImageUrl = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/nural/IMG_0004.jpg?RenditionID=8",
                DormitoryName = "Alfam Dormitory8",
                DormitoryDescription = "Wonderful dormitory"},

                              new ExploreImages   { ImageUrl = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/astra/IMG-20171014-WA0010.jpg?RenditionID=5",
                DormitoryName = "Alfam Dormitory5",
                DormitoryDescription = "Wonderful dormitory"},

                              new ExploreImages   { ImageUrl = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/2017/kamacioglu/S%C3%9C%C4%B0T_1.jpg?RenditionID=9",
                DormitoryName = "Alfam Dormitory6",
                DormitoryDescription = "Wonderful dormitory"},

                              new ExploreImages   { ImageUrl = "https://dormitories.emu.edu.tr/PhotoGalleries/dormitories/popart/TV%20ROOM%20KING%20EXCLUSIVE.jpg?RenditionID=8",
                DormitoryName = "Alfam Dormitory8",
                DormitoryDescription = "Wonderful dormitory"},


            }


                );
            
            }



        public IActionResult SearchDormMobileApp()
        {
            return View();
        }





    }


    public class ExploreImages
    {
        public string ImageUrl { get; set; }
        public string DormitoryName { get; set; }
        public string DormitoryDescription { get; set; }
    }
}