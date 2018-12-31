using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Dau.Services.Utilities;
using Dau.Core.Domain;

namespace searchDormWeb.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GetBookingsByCustomerIdController : Controller
    {
        private readonly IApiLogService _apiLogService;

        public GetBookingsByCustomerIdController(IApiLogService apiLogService)
        {
            _apiLogService = apiLogService;
        }


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
                        BookingNumber = 344,
                        Dormitoryname = "Alfam Dormitories",
                        PictureUrl = "https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg",
                        RatingNumber = 4.5,
                        RatingText = "Very Good",
                        BookingDate = DateTime.Now.ToString("d"),
                        CheckInDate = DateTime.Now.AddDays(43).ToString("d"),
                        BookingStatus = "Competed",
                        RoomId = 2342

                        },

                        new BookingByIdAPIVM
                        {

                    DormitoryDescription = "Alfam dormitories has four blocks seperate.....",
                    DormitoryId  = 26,
                    BookingNumber = 34,
                    Dormitoryname = "Alfam Dormitories",
                    PictureUrl = "https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg",
                    RatingNumber = 4.5,
                    RatingText= "Very Good",
                    BookingDate  =  DateTime.Now.ToString("d"),
                    CheckInDate  = DateTime.Now.AddDays(543).ToString("d"),
                    BookingStatus = "Competed",
                       RoomId = 2242
                        }
                    }



                }
            };

            _apiLogService.LogApiRequest(new ApiDebugLog
            {

                ApiName = "api/GetBookingsByCustomerId/",
                Reponse = JsonConvert.SerializeObject(Response),
                CreateDateTime = DateTime.Now,
                ParameterRecieved = JsonConvert.SerializeObject(_apiLogService.GetRequestBody())
            });
            return Json(Response);


        }

        public class BookingByIdAPIVM
        {
            public long RoomId { get; set; }
            public string DormitoryDescription { get; set; }
            public long DormitoryId { get; set; }
            public string Dormitoryname { get; set; }
            public string PictureUrl { get; set; }
            public double RatingNumber { get; set; }
            public string RatingText { get; set; }
            public string BookingDate { get; set; }
            public string CheckInDate { get; set; }
            public string BookingStatus { get; set; }
            public long BookingNumber { get; set; }
        }
    }
}
