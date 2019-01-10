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
    // public class CreateUserController : Controller

    //public class AuthenticationController : Controller

    [Produces("application/json")]

    [ApiController]
    public class CreateUserController : Controller
    {
        private readonly IMobileApiService _mobileApiService;
        private readonly IApiLogService _apiLogService;

        public CreateUserController(IApiLogService apiLogService, IMobileApiService mobileApiService)
        {
            _mobileApiService = mobileApiService;
            _apiLogService = apiLogService;
        }


        [Route("api/[controller]")]
        // POST: api/CreateUser
        [HttpPost]
        public async Task<JsonResult> PostAsync()
        {



            var Response = await _mobileApiService.CreateUserAsync();
            if (Response != null)
            {//gets username and password and returns userIdGUID

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

                    ApiName = " // POST: api/CreateUser",
                    Reponse = JsonConvert.SerializeObject(response),
                    CreateDateTime = DateTime.Now,
                    ParameterRecieved = JsonConvert.SerializeObject(_apiLogService.GetRequestBody())
                });

                return Json(response);
            }
        }



    }

}