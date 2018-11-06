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
    public class FacilitiesFilterController : ControllerBase
    {
        // GET: api/FacilitiesFilter
        [HttpGet]
        public string Get()
        {
            string Json = @"{
      ""Response"": ""Success"",
      ""Body"": {
                ""Facilities"": [
                  {
            ""facilityId"": ""1"",
                    ""facilityname"": ""Refrigerator""

          },
          {
            ""facilityId"": ""2"",
            ""facilityname"": ""Wifi""

          },
          {
            ""facilityId"": ""3"",
            ""facilityname"": ""TV""

          }
        ]
      }

    }";
            return Json;
        }

       
    }
}
