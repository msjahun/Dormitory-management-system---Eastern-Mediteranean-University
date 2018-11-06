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
    public class GetBookingController : ControllerBase
    {
        // GET: api/GetBooking/34
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string Json = @"
    {
      ""Response"": ""Success"",
      ""Body"": {
        ""DateOfBooking"": ""12/10/2018"",
        ""TimeOfBooking"": ""2:48PM"",
        ""CheckInDate"": ""18/10/2018"",
        ""CheckInSemester"": ""Spring""
      }
    }";
            JsonResult result = new JsonResult(JsonConvert.DeserializeObject(Json));

            return result;
        }

      
    }
}
