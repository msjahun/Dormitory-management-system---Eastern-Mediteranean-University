using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Dau.Services.Utilities;
using Dau.Core.Domain;
using Newtonsoft.Json;

namespace searchDormWeb.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GetDormitoriesController : Controller
    {
        private readonly IApiLogService _apiLogService;

        public GetDormitoriesController(IApiLogService apiLogService)
        {
            _apiLogService = apiLogService;
        }

        // GET: api/GetDormitories
        [HttpGet]
        public JsonResult Get()
        {
          
          



            var Response = new
            {
                Response = "Success",
                Body = new 
                {
                    Dormitories = new List<GetDormitoriesVM>
                    {
                        new GetDormitoriesVM
                        {
                            PictureUrl="https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg",
                            DormitoryName="Alfam Dormitories",
                            DormitoryDescription="Alfam dormitories has four blocks seperate.....",
                            RatingNumber=4.5,
                            RatingText="Very Good",
                            DormitoryId=5
                        },
                        new GetDormitoriesVM
                        {
                            PictureUrl="https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg",
                            DormitoryName="Alfam Dormitories",
                            DormitoryDescription="Alfam dormitories has four blocks seperate.....",
                            RatingNumber=4.5,
                            RatingText="Very Good",
                            DormitoryId=7
                        }
                    }



                }

            };

            _apiLogService.LogApiRequest(new ApiDebugLog
            {

                ApiName = " GET: api/GetDormitories",
                Reponse = JsonConvert.SerializeObject(Response),
                CreateDateTime = DateTime.Now,
                ParameterRecieved = JsonConvert.SerializeObject(_apiLogService.GetRequestBody())
            });
            return Json(Response);
         
        }


        public class GetDormitoriesVM
        {
          public string PictureUrl { get; set; }
          public string DormitoryName {get; set;}
          public string DormitoryDescription {get; set;}
          public double RatingNumber {get; set;}
          public string RatingText {get; set;}
          public long DormitoryId {get; set;}
        }
    }
}
