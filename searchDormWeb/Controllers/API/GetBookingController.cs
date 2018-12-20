using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;


namespace searchDormWeb.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GetBookingController : Controller
    {
        // GET: api/GetBooking/34
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {


            var Response = new
            {
                Response = "Success",
                Body = new
                {
                    DateOfBooking = DateTime.Now.ToString("d"),
                    TimeOfBooking = DateTime.Now.ToString("T"),
                    CheckInDate = DateTime.Now.AddDays(50).ToString("d"),
                    CheckInSemester = "Spring"



                }

            };



            return Json(Response);
       
        }

      
    }
}
