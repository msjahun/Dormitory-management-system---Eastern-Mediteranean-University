﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace searchDormWeb.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditBookingController : ControllerBase
    {
       
        // POST: api/EditBooking
        [HttpPost]
        public string Post([FromBody] string value)
        {
            string Json = @" {
                ""Response"": ""Success""
                }";

            return Json;
        }

        
    }
}