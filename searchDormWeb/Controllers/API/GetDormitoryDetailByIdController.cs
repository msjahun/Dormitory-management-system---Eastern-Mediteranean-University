using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using searchDormWeb.Models;

namespace searchDormWeb.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GetDormitoryDetailByIdController : Controller
    {


        // GET: api/GetDormitoryDetailById/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            if (id == 5)
            {


                var Response = new
                {
                    Response = "Success",
                    Body = new
                    {
                        Dormitoryname = "Dormitory name",
                        DormitoryShortDescription = "Dormitory full description",
                        ImageUrls = new List<string>{
          "https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg",
          "https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg",
                "https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg"
       },
                        DormitotyFullDescription = "Dormitory full description",


                        FacilitiesList = new List<FacilityGetDormitoryDetailVM> {
          new FacilityGetDormitoryDetailVM{
            pictureUrl="https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg",
            facilityname="Wifi",
            facilityId=12
          },

         new FacilityGetDormitoryDetailVM  {
           pictureUrl="https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg",
           facilityname="Wifi",
           facilityId=14
          }
        },

                        DormitoryPolicies = "Dormitory policies"


                    }

                };


                return Json(Response);


            }
            else
            {
                ResponseResult response = new ResponseResult
                {
                    Response = true,
                    StatusCode = "0x3234"
                };

                return Json(Response);

            }

        }



        public class FacilityGetDormitoryDetailVM
        {
            public string pictureUrl { get; set; }
            public string facilityname { get; set; }
            public long facilityId { get; set; }
        }


    }





}

