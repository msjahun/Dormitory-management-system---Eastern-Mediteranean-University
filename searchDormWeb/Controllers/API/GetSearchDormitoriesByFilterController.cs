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
    public class GetSearchDormitoriesByFilterController : ControllerBase
    {
      
        // POST: api/GetSearchDormitoriesByFilter
        [HttpPost]
        public string Post([FromBody] string value)
        {
            string Json = @" {
      ""Response"": ""Success"",
      ""Body"": {
        ""Dormitories"": [
          {
            ""PictureUrl"": ""https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg"",
            ""DormitoryName"": ""Alfam Dormitories"",
            ""DormitoryDescription"": ""Alfam dormitories has four blocks seperate....."",
            ""RatingNumber"": ""4.5"",
            ""RatingText"": ""Very Good"",
            ""DormitoryId"": ""23""
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

            return Json;

        }
        
    }
}
