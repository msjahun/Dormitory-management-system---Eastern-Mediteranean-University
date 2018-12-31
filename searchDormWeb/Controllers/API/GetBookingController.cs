using System;
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
    public class GetBookingController : Controller
    {
        private readonly IApiLogService _apiLogService;

        public GetBookingController(IApiLogService apiLogService)
        {
            _apiLogService = apiLogService;
        }

        // GET: api/GetBooking/34
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {


            var Response = new
            {
                Response = "Success",
                Body = new
                {   BookingId = 233443,
                    DateOfBooking = DateTime.Now.ToString("d"),
                    TimeOfBooking = DateTime.Now.ToString("T"),
                    CheckInDate = DateTime.Now.AddDays(50).ToString("d"),
                    CheckInSemester = "Spring"



                }

            };


            _apiLogService.LogApiRequest(new ApiDebugLog
            {

                ApiName = "  // GET: api/GetBooking",
                Reponse = JsonConvert.SerializeObject(Response),
                CreateDateTime = DateTime.Now,
                ParameterRecieved = JsonConvert.SerializeObject(_apiLogService.GetRequestBody())
            });
            return Json(Response);
       
        }

      
    }
}
