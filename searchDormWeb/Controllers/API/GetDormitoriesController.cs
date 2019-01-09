using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Dau.Services.Utilities;
using Dau.Core.Domain;
using Newtonsoft.Json;
using Dau.Services.Domain.MobileApiServices;

namespace searchDormWeb.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GetDormitoriesController : Controller
    {
        private readonly IApiLogService _apiLogService;
        private readonly IMobileApiService _mobileApiService;

        public GetDormitoriesController(IApiLogService apiLogService, IMobileApiService mobileApiService)
        {
            _apiLogService = apiLogService;
            _mobileApiService = mobileApiService;
        }

        // GET: api/GetDormitories
        [HttpGet]
        public JsonResult Get()
        {
            
            var Response = _mobileApiService.GetDormitoriesService();

            _apiLogService.LogApiRequest(new ApiDebugLog
            {

                ApiName = " GET: api/GetDormitories",
                Reponse = JsonConvert.SerializeObject(Response),
                CreateDateTime = DateTime.Now,
                ParameterRecieved = JsonConvert.SerializeObject(_apiLogService.GetRequestBody())
            });
            return Json(Response);
         
        }


    }
}
