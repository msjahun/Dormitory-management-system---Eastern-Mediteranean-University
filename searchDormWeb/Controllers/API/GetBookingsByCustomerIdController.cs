using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;


namespace searchDormWeb.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GetBookingsByCustomerIdController : Controller
    {


        // GET: api/GetBookingsByCustomerId/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {


            var Response = new
            {
                Response = "Success",
                Body = new
                {
                    Bookings = new List<BookingByIdAPIVM>
                    {
                        new BookingByIdAPIVM
                        {
                            DormitoryDescription = "Alfam dormitories has four blocks seperate.....",
                        DormitoryId = 23,
                        Dormitoryname = "Alfam Dormitories",
                        PictureUrl = "https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg",
                        RatingNumber = 4.5,
                        RatingText = "Very Good",
                        BookingDate = DateTime.Now.ToString("d"),
                        CheckInDate = DateTime.Now.AddDays(43).ToString("d"),
                        BookingStatus = "Competed"
                        },

                        new BookingByIdAPIVM
                        {

                    DormitoryDescription = "Alfam dormitories has four blocks seperate.....",
                    DormitoryId  = 26,
                    Dormitoryname = "Alfam Dormitories",
                    PictureUrl = "https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg",
                    RatingNumber = 4.5,
                    RatingText= "Very Good",
                    BookingDate  =  DateTime.Now.ToString("d"),
                    CheckInDate  = DateTime.Now.AddDays(543).ToString("d"),
                    BookingStatus = "Competed"
                        }
                    }



                }
            };


            return Json(Response);


        }

        public class BookingByIdAPIVM
        {
            public string DormitoryDescription { get; set; }
            public long DormitoryId { get; set; }
            public string Dormitoryname { get; set; }
            public string PictureUrl { get; set; }
            public double RatingNumber { get; set; }
            public string RatingText { get; set; }
            public string BookingDate { get; set; }
            public string CheckInDate { get; set; }
            public string BookingStatus { get; set; }
        }
    }
}
