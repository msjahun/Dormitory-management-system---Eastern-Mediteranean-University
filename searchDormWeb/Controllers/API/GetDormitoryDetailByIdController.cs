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
    public class GetDormitoryDetailByIdController : ControllerBase
    {
       

        // GET: api/GetDormitoryDetailById/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            string Json = @" {
      ""Response"": ""Success"",
      ""Body"": {
                ""Dormitoryname"": ""Dormitory name"",
        ""DormitoryShortDescription"": ""Dormitory full description"",
        ""ImageUrls"": [
          ""https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg"",
          ""https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg"",
          ""https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg""
        ],
        ""DormitotyFullDescription"": ""Dormitory full description"",


        ""FacilitiesList"": [
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
        ],

        ""DormitoryPolicies"": ""Dormitory policies""
      }
    }";
            return Json;
        }
        
    }
}
