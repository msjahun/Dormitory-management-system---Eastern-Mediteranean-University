using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using searchDormWeb.Models;

namespace searchDormWeb.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CreateBookingController : Controller
    {
        

        // POST: api/CreateBooking
        [HttpPost]
        public JsonResult Post(string value)
        {
            ResponseResult response = new ResponseResult
            {
                Response = true,
                StatusCode = "0x3234"
            };

            return Json(response);
        }

        
    }
}
