using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json.Linq;
using Dau.Services.Utilities;
using Dau.Core.Domain;

namespace searchDormWeb.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingByBookingIdController : Controller
    {
        private readonly IApiLogService _apiLogService;

        public BookingByBookingIdController(IApiLogService apiLogService)
        {
            _apiLogService = apiLogService;
        }


        // GET: api/BookingByBookingId/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
    


            var Response = new
            {
                Response = "Success",
                Body = new
                {
                    DormitoryId = 23,
                    BookingDate = DateTime.Now.ToString("d"),
                    BookingStatus = "Confirmed",
                    paymentConfirmationExpiryDate = DateTime.Now.ToString("d"),
                    BookingNo = "34343434",
                    RoomBooked = "Alfam single room",
                    DormitoryName = "Alfam dormitories"
                }

            };

            _apiLogService.LogApiRequest(new ApiDebugLog
            {

                ApiName = "// GET: api/BookingByBookingId",
                Reponse = JsonConvert.SerializeObject(Response),
                CreateDateTime = DateTime.Now,
                ParameterRecieved = JsonConvert.SerializeObject(_apiLogService.GetRequestBody())
            });
            return Json(Response);
           
          
        }

  
    }
}
