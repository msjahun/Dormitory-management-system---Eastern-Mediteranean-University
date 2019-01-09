
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using searchDormWeb.Models;
using Dau.Services.Utilities;
using Dau.Core.Domain;
using System;
using Dau.Services.Domain.MobileApiServices;

namespace searchDormWeb.Controllers.API
{
    //public class AuthenticationController : Controller

    [Produces("application/json")]

    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IMobileApiService _mobileApiService;
        private readonly IApiLogService _apiLogService;

        public AuthenticationController(IApiLogService apiLogService, IMobileApiService mobileApiService)
        {
            _mobileApiService = mobileApiService;
            _apiLogService = apiLogService;
        }


        [Route("api/[controller]")]
        // POST: api/Authentication,
        [HttpPost]
        public async Task<JsonResult> PostAsync()
        {
            


            var Response =await _mobileApiService.AuthenticationAsync();
            if (Response != null)
            {//gets username and password and returns userIdGUID
              
                _apiLogService.LogApiRequest(new ApiDebugLog
                {

                    ApiName = " // POST: api/Authentication",
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
                    Response = false,
                    StatusCode = "0x3234"
                };


                _apiLogService.LogApiRequest(new ApiDebugLog
                {

                    ApiName = " // POST: api/Authentication",
                    Reponse = JsonConvert.SerializeObject(response),
                    CreateDateTime = DateTime.Now,
                    ParameterRecieved = JsonConvert.SerializeObject(_apiLogService.GetRequestBody())
                });

                return Json(response);
            }
        }



    }


}