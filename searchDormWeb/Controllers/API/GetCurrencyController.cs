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
    public class GetCurrencyController : Controller
    {
       


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


            return Json(Response);
        
        }
        
    }
}
