using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Dau.Services.Utilities;
using Dau.Core.Domain;

namespace searchDormWeb.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GetRoomByIdController : Controller
    {
        private readonly IApiLogService _apiLogService;

        public GetRoomByIdController(IApiLogService apiLogService)
        {
            _apiLogService = apiLogService;
        }

        // GET: api/GetRoomById/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        { 

            var Response = new
            {
                Response = "Success",
                Body = new
                {

                    pictureUrl = new List<string>
                    {   "https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg",
                        "https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg",
                        "https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg"
                           },

                    roomId = "13",
                    roomQuota = "23",
                    roomPrice = "$2,340",
                    facilitiesList = new List<FacilitiesGetRoomByIdAPIVM>
                    {
                        new FacilitiesGetRoomByIdAPIVM
                        {
                             pictureUrl="https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg",
                             facilityname="Wifi",
                             facilityId=12
                        },

                        new FacilitiesGetRoomByIdAPIVM
                        {
                             pictureUrl="https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg",
                             facilityname="Wifi",
                             facilityId=16
                        },

                        new FacilitiesGetRoomByIdAPIVM
                        {

                                                         pictureUrl="https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg",
                             facilityname="Wifi",
                             facilityId=14
                        }
                    }
                }

            };

            _apiLogService.LogApiRequest(new ApiDebugLog
            {

                ApiName = " // GET: api/GetRoomById/",
                Reponse = JsonConvert.SerializeObject(Response),
                CreateDateTime = DateTime.Now,
                ParameterRecieved = JsonConvert.SerializeObject(_apiLogService.GetRequestBody())
            });
            return Json(Response);

        }
        
        public class FacilitiesGetRoomByIdAPIVM
        {
           public string pictureUrl { get; set; }
           public string facilityname {get; set;}
           public long  facilityId {get; set;}
        }
    }
}
