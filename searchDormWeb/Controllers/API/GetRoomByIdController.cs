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
    public class GetRoomByIdController : Controller
    {
       
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
