﻿using System;
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
    public class GetRoomByIdController : ControllerBase
    {
       
        // GET: api/GetRoomById/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string Json = @" {
      ""Response"": ""Success"",
      ""Body"": {
                ""pictureUrl"": [
                  ""https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg"",
          ""https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg"",
          ""https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg""
        ],
        ""roomId"": ""13"",
        ""roomQuota"": ""23"",
        ""roomPrice"": ""$2,340"",
        ""facilitiesList"": [
          {
            ""pictureUrl"": ""https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg"",
            ""facilityname"": ""Wifi"",
            ""facilityId"": ""12""
          },
          {
            ""pictureUrl"": ""https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg"",
            ""facilityname"": ""Wifi"",
            ""facilityId"": ""12""
          },
          {
            ""pictureUrl"": ""https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg"",
            ""facilityname"": ""Wifi"",
            ""facilityId"": ""12""
          }
        ]
      }
    }";
             JsonResult result = new JsonResult(JsonConvert.DeserializeObject(Json));
            return result;
        }
        
    }
}
