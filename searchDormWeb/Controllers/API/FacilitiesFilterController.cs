using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Dau.Services.Utilities;
using Dau.Core.Domain;
using Dau.Services.Domain.MobileApiServices;

namespace searchDormWeb.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitiesFilterController : Controller
    {
        private readonly IApiLogService _apiLogService;
        private readonly IMobileApiService _mobileApiService;

        public FacilitiesFilterController(IApiLogService apiLogService, IMobileApiService mobileApiService)
        {
            _apiLogService = apiLogService;
            _mobileApiService = mobileApiService;
        }

        // GET: api/FacilitiesFilter
        [HttpGet]
        public JsonResult Get()
        {


            var Response = _mobileApiService.FacilitiesFilterService();

            _apiLogService.LogApiRequest(new ApiDebugLog
            {

                ApiName = "// GET: api/FacilitiesFilter",
                Reponse = JsonConvert.SerializeObject(Response),
                CreateDateTime = DateTime.Now,
                ParameterRecieved = JsonConvert.SerializeObject(_apiLogService.GetRequestBody())
            });
            return Json(Response);
           
        }

       
    }




}
