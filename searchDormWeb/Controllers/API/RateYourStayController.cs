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
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http.Internal;

namespace searchDormWeb.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RateYourStayController : Controller
    {
        private readonly IApiLogService _apiLogService;

        public RateYourStayController(IApiLogService apiLogService)
        {
            _apiLogService = apiLogService;
        }

        // POST: api/RateYourStay
        [HttpPost]
        public  JsonResult Post()
        {

           

            ResponseResult response = new ResponseResult
            {
                Response = true,
                StatusCode = "0x3234"
            };
        
            _apiLogService.LogApiRequest(new ApiDebugLog
            {
             
                ApiName = " // POST: api/RateYourStay",
                Reponse = JsonConvert.SerializeObject(response),
                CreateDateTime = DateTime.Now,
                ParameterRecieved = JsonConvert.SerializeObject(_apiLogService.GetRequestBody())
            });
            return Json(response);
        }

    }

    public class RateYourStayModel{
        public string DormitoryId { get; set; }
        public string FeedbackType { get; set; }
        public string Addcomment { get; set; }
        public string Facilities { get; set; }
        public string Services { get; set; }
        public string Compound { get; set; }

    }
}
