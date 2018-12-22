﻿using System;
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
    public class GetHighlyRatedDormitoriesController : Controller
    {
        private readonly IApiLogService _apiLogService;

        public GetHighlyRatedDormitoriesController(IApiLogService apiLogService)
        {
            _apiLogService = apiLogService;
        }

        // GET: api/GetHighlyRatedDormitories
        [HttpGet]
        public JsonResult Get()
        { 

            var Response = new
            {
                Response = "Success",
                Body = new
                {

                    Dormitories = new List<DormitoriesGetHighlyRatedDormitoriesVM>
                    {
                        new DormitoriesGetHighlyRatedDormitoriesVM
                        {  PictureUrl="https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg",
           DormitoryName="1Alfam Dormitories",
                    DealsText="1Deals start at $1990",
                    DormitoryId=5

                        },
                        new DormitoriesGetHighlyRatedDormitoriesVM
                        {
             PictureUrl="https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg",
            DormitoryName="2Alfam Dormitories",
            DealsText="2Deals start at $1990",
           DormitoryId=22
                        },
                        new DormitoriesGetHighlyRatedDormitoriesVM
                        {
             PictureUrl="https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg",
            DormitoryName="2Alfam Dormitories",
            DealsText="2Deals start at $1990",
           DormitoryId=22
                        },
                        new DormitoriesGetHighlyRatedDormitoriesVM
                        {
             PictureUrl="https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg",
            DormitoryName="2Alfam Dormitories",
            DealsText="2Deals start at $1990",
           DormitoryId=22
                        },
                        new DormitoriesGetHighlyRatedDormitoriesVM
                        {
             PictureUrl="https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg",
            DormitoryName="2Alfam Dormitories",
            DealsText="2Deals start at $1990",
           DormitoryId=22
                        }
                    }
                }

            };


            _apiLogService.LogApiRequest(new ApiDebugLog
            {

                ApiName = "// GET: api/GetHighlyRatedDormitories",
                Reponse = JsonConvert.SerializeObject(Response),
                CreateDateTime = DateTime.Now,
                ParameterRecieved = JsonConvert.SerializeObject(_apiLogService.GetRequestBody())
            });
            return Json(Response);
         
        }

        

        public class DormitoriesGetHighlyRatedDormitoriesVM
        {
            public string PictureUrl  {get; set;}
           public string  DormitoryName {get; set;}
            public string DealsText {get; set;}
            public long   DormitoryId  {get; set;}
            
        }
    }
}
