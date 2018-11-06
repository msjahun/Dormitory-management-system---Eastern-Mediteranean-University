using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace searchDormWeb.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetBookingController : ControllerBase
    {
        // GET: api/GetBooking/34
        [HttpGet("{id}")]
        public string Get(int id)
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
            return Json;
        }

      
    }
}
