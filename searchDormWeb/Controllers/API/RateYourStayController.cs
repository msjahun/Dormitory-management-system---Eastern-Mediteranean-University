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
    public class RateYourStayController : Controller
    {

        // POST: api/RateYourStay
        [HttpPost]
        public JsonResult Post(RateYourStayModel data)
        {


            ResponseResult response = new ResponseResult
            {
                Response = true,
                StatusCode = "0x3234"
            };

            return Json(response);
        }

    }

    public class RateYourStayModel{
        public string FeedbackType { get; set; }
        public string Addcomment { get; set; }
        public string Facilities { get; set; }
        public string Services { get; set; }
        public string Compound { get; set; }

    }
}
