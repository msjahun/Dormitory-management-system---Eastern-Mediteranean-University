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
    public class GiveAppFeedBackController : ControllerBase
    {
       

        // POST: api/GiveAppFeedBack
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