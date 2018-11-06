using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace searchDormWeb.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GetBookingsByCustomerIdController : ControllerBase
    {
      

        // GET: api/GetBookingsByCustomerId/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            string Json = @"{
      ""Response"": ""Success"",
      ""Body"": {
                ""Bookings"": [
                  {
            ""DormitoryDescription"": ""Alfam dormitories has four blocks seperate....."",
                    ""DormitoryId"": ""23"",
                    ""Dormitoryname"": ""Alfam Dormitories"",
                    ""PictureUrl"": ""https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg"",
            ""RatingNumber"": ""4.5"",
                    ""RatingText"": ""Very Good"",
                    ""BookingDate"": ""12/2/2018"",
                    ""CheckInDate"": ""23/12/2019"",
                    ""BookingStatus"": ""Competed""
          },
          {
            ""DormitoryDescription"": ""Alfam dormitories has four blocks seperate....."",
            ""DormitoryId"": ""23"",
            ""Dormitoryname"": ""Alfam Dormitories"",
            ""PictureUrl"": ""https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg"",
            ""RatingNumber"": ""4.5"",
            ""RatingText"": ""Very Good"",
            ""BookingDate"": ""12/2/2018"",
            ""CheckInDate"": ""23/12/2019"",
            ""BookingStatus"": ""Competed""
          }

        ]
      }

    }";
            return Json;
        }

    }
}
