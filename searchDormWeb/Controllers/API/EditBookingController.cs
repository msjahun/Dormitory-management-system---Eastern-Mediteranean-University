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
    public class EditBookingController : Controller
    {
        private readonly IApiLogService _apiLogService;

        public EditBookingController(IApiLogService apiLogService)
        {
            _apiLogService = apiLogService;
        }

        [Route("api/[controller]")]
        // POST: api/EditBooking
        [HttpPost]
        public JsonResult Post( string value)
        {
            ResponseResult response = new ResponseResult
            {
                Response = true,
                StatusCode = "0x3234"
            };


            _apiLogService.LogApiRequest(new ApiDebugLog
            {

                ApiName = " // POST: api/EditBooking",
                Reponse = JsonConvert.SerializeObject(response),
                CreateDateTime = DateTime.Now,
                ParameterRecieved = JsonConvert.SerializeObject(_apiLogService.GetRequestBody())
            });
            return Json(response);
        }

        
    }
}
