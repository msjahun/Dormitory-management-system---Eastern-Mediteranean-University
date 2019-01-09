using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json.Linq;
using Dau.Services.Utilities;
using Dau.Core.Domain;
using Dau.Services.Domain.MobileApiServices;
using searchDormWeb.Models;

namespace searchDormWeb.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingByBookingIdController : Controller
    {
        private readonly IApiLogService _apiLogService;
        private readonly IMobileApiService _mobileApiService;

        public BookingByBookingIdController(IApiLogService apiLogService, IMobileApiService mobileApiService)
        {
            _apiLogService = apiLogService;
            _mobileApiService = mobileApiService;
        }


        // GET: api/BookingByBookingId/5
        [HttpGet("{id}")]
        public JsonResult Get(long id)
        {
            

            var Response = _mobileApiService.BookingByBookingIdService(id);
            if (Response != null)
            {
                _apiLogService.LogApiRequest(new ApiDebugLog
                {

                    ApiName = "// GET: api/BookingByBookingId",
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

                    ApiName = "// GET: api/BookingByBookingId",
                    Reponse = JsonConvert.SerializeObject(response),
                    CreateDateTime = DateTime.Now,
                    ParameterRecieved = JsonConvert.SerializeObject(_apiLogService.GetRequestBody())
                });

                return Json(response);
            }
        }

  
   

   
    }
}
