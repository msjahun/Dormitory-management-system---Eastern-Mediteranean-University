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
    public class GetRoomByDormitoryIdController : ControllerBase
    {

        // GET: api/GetRoomByDormitoryId/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            string Json = @" {
      ""Response"": ""Success"",
      ""Body"": {
                ""Rooms"": [
                  {

            ""pictureUrl"": ""https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg"",
            ""dormitoryName"": ""Alfam Dormitories"",
                    ""bedType"": ""23m2"",
                    ""roomSize"": ""58m2"",
                    ""roomQuotaRemaining"": ""34"",
                    ""RoomPrice"": ""1990"",
                    ""RoomId"": ""12"",
                    ""DormitoryId"": ""23""

          },
          {


            ""pictureUrl"": ""https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg"",
            ""dormitoryName"": ""Alfam Dormitories"",
            ""bedType"": ""23m2"",
            ""roomSize"": ""58m2"",
            ""roomQuotaRemaining"": ""34"",
            ""RoomPrice"": ""1990"",
            ""RoomId"": ""12"",
            ""DormitoryId"": ""23""

          },
          {
            ""Response"": ""Success"",

            ""pictureUrl"": ""https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg"",
            ""dormitoryName"": ""Alfam Dormitories"",
            ""bedType"": ""23m2"",
            ""roomSize"": ""58m2"",
            ""roomQuotaRemaining"": ""34"",
            ""RoomPrice"": ""1990"",
            ""RoomId"": ""12"",
            ""DormitoryId"": ""23""

          }
        ]

      }

    }";
            return Json;
        }

        
    }
}
