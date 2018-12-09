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
    public class GetDormitoriesController : ControllerBase
    {
        // GET: api/GetDormitories
        [HttpGet]
        public JsonResult Get()
        {
          
          
            string Json = @"    {
      ""Response"": ""Success"",
      ""Body"": {
                ""Dormitories"": [
                  {
            ""PictureUrl"": ""https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg"",
            ""DormitoryName"": ""Alfam Dormitories"",
                    ""DormitoryDescription"": ""Alfam dormitories has four blocks seperate....."",
                    ""RatingNumber"": ""4.5"",
                    ""RatingText"": ""Very Good"",
                    ""DormitoryId"": ""5""
          },
          {
            ""PictureUrl"": ""https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg"",
            ""DormitoryName"": ""Alfam Dormitories"",
            ""DormitoryDescription"": ""Alfam dormitories has four blocks seperate....."",
            ""RatingNumber"": ""4.5"",
            ""RatingText"": ""Very Good"",
            ""DormitoryId"": ""23""
          }
        ]
      }
    }";
             JsonResult result = new JsonResult(JsonConvert.DeserializeObject(Json));
            return result;
        }

    }
}
