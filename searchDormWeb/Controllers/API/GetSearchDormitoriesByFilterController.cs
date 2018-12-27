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

    [ApiController]
    public class GetSearchDormitoriesByFilterController : Controller
    {
        private IApiLogService _apiLogService;

        public GetSearchDormitoriesByFilterController(IApiLogService apiLogService)
        {
            _apiLogService = apiLogService;
        }

        // POST: api/GetSearchDormitoriesByFilter
        [HttpPost]
        [Route("api/[controller]")]
        public JsonResult Post()
        {

            var Response = new
            {
                Response = "Success",
                Body = new
                {

                    Dormitories = new List<APIDormitoriesVM>
                    {
                        new APIDormitoriesVM
                        {

                            PictureUrl = "https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg",
                            DormitoryName = "Alfam Dormitories",
                            DormitoryDescription = "Alfam dormitories has four blocks seperate.....",
                            RatingNumber = "4.5",
                            RatingText = "Very Good",
                            DormitoryId = "23"
                        },
                        new APIDormitoriesVM
                        {

                            PictureUrl = "https://dormitories.emu.edu.tr/PublishingImages/Dormitories/alfam/6.jpg",
                            DormitoryName = "Alfam Dormitories",
                            DormitoryDescription = "Alfam dormitories has four blocks seperate.....",
                            RatingNumber = "4.5",
                            RatingText = "Very Good",
                            DormitoryId = "23"
                        }
                    }
                }

            };

            //ResponseResult response = new ResponseResult
            //{
            //    Response = true,
            //    StatusCode = "0x3234"
            //};


            _apiLogService.LogApiRequest(new ApiDebugLog
            {

                ApiName = " // POST: api/GetSearchDormitoriesByFilter",
                Reponse = JsonConvert.SerializeObject(Response),
                CreateDateTime = DateTime.Now,
                ParameterRecieved = JsonConvert.SerializeObject(_apiLogService.GetRequestBody())
            });
            return Json(Response);

        }

    }

    public class APIDormitoriesVM
    {
        public string PictureUrl { get; set; }
        public string DormitoryName { get; set; }
        public string DormitoryDescription { get; set; }
        public string RatingNumber { get; set; }
        public string RatingText { get; set; }
        public string DormitoryId { get; set; }

    }
}

