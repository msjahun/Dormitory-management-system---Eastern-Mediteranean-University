using Dau.Core.Domain;
using Dau.Services.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using searchDormWeb.Models;
using System;

namespace searchDormWeb.Controllers.API
{
    [Produces("application/json")]
  
    [ApiController]
    public class PaymentConfirmationController : Controller
    {
        private readonly IApiLogService _apiLogService;

        public PaymentConfirmationController(IApiLogService apiLogService)
        {
            _apiLogService = apiLogService;
        }


    


        [Route("api/[controller]")]
        // POST: api/PaymentConfirmation"
        [HttpPost]
        public JsonResult Post()
        {
            ResponseResult response = new ResponseResult
            {
                Response = true,
                StatusCode = "0x3234"
            };


            _apiLogService.LogApiRequest(new ApiDebugLog
            {

                ApiName = "// POST: api/PaymentConfirmation",
                Reponse = JsonConvert.SerializeObject(response),
                CreateDateTime = DateTime.Now,
                ParameterRecieved = JsonConvert.SerializeObject(_apiLogService.GetRequestBody())
            });
            return Json(response);
        }




    }


}
