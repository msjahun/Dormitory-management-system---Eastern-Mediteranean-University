using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using searchDormWeb.Models;
using Dau.Services.Utilities;
using Dau.Core.Domain;

namespace searchDormWeb.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GetDormitoryDetailByIdController : Controller
    {
        private readonly IApiLogService _apiLogService;

        public GetDormitoryDetailByIdController(IApiLogService apiLogService)
        {
            _apiLogService = apiLogService;
        }


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

                _apiLogService.LogApiRequest(new ApiDebugLog
                {

                    ApiName = "// GET: api/GetDormitoryDetailById/",
                    Reponse = JsonConvert.SerializeObject(Response),
                    CreateDateTime = DateTime.Now,
                    ParameterRecieved = JsonConvert.SerializeObject(_apiLogService.GetRequestBody())
                });
                return Json(Response);


            }
            else
            {
                ResponseResult response = new ResponseResult
                {
                    Response = true,
                    StatusCode = "0x3234"
                };


                _apiLogService.LogApiRequest(new ApiDebugLog
                {

                    ApiName = "// GET: api/GetDormitoryDetailById/",
                    Reponse = JsonConvert.SerializeObject(response),
                    CreateDateTime = DateTime.Now,
                    ParameterRecieved = JsonConvert.SerializeObject(_apiLogService.GetRequestBody())
                });
                return Json(response);

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

