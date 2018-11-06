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
    public class GetMostPopularDormitoriesController : ControllerBase
    {
        // GET: api/GetMostPopularDormitories
        [HttpGet]
        public string Get()
        {
            string Json = @"{
      ""Response"": ""Success"",
      ""Body"": {
                ""Dormitories"": [
                  {
            ""PictureUrl"": ""https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg"",
            ""DormitoryName"": ""1Alfam Dormitories"",
                    ""DealsText"": ""1Deals start at $1990"",
                    ""DormitoryId"": ""21""

          },
          {
            ""PictureUrl"": ""https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg"",
            ""DormitoryName"": ""2Alfam Dormitories"",
            ""DealsText"": ""2Deals start at $1990"",
            ""DormitoryId"": ""22""

          }
        ]
      }

    }";
            return Json;
        }


    }
}
