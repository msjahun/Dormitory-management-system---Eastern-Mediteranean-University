using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace searchDormWeb.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetCurrencyController : ControllerBase
    {
       


        // GET: api/GetCurrency/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
           
            string Json = @"{ ""Response"": ""Success"",""Body"": {""CurrencyName"": ""Turkish lira"",""CurrencyId"": ""0"",""CurrencyRate"": ""1"" } ";
            return Json;
        }
        
    }
}
