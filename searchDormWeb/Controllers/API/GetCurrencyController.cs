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
    public class GetCurrencyController : Controller
    {
        private readonly IApiLogService _apiLogService;

        public GetCurrencyController(IApiLogService apiLogService)
        {
            _apiLogService = apiLogService;
        }



        // GET: api/GetCurrency/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {





            var Response = new
            {
                Response = "Success",
                Body = new
                {
                    CurrencyName = "Turkish lira",
                    CurrencyId = "0",
                    CurrencyRate = "1"

                }

            };

            _apiLogService.LogApiRequest(new ApiDebugLog
            {

                ApiName = "// GET: api/GetCurrency",
                Reponse = JsonConvert.SerializeObject(Response),
                CreateDateTime = DateTime.Now,
                ParameterRecieved = JsonConvert.SerializeObject(_apiLogService.GetRequestBody())
            });
            return Json(Response);
        
        }
        
    }
}
