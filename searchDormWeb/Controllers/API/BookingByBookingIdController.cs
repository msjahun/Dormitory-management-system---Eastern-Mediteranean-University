using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json.Linq;

namespace searchDormWeb.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingByBookingIdController : Controller
    {

      
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


            return Json(Response);
           
          
        }

  
    }
}
