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
    public class FacilitiesFilterController : Controller
    {
        // GET: api/FacilitiesFilter
        [HttpGet]
        public JsonResult Get()
        {
   
            
            var Response = new 
            {
                Response = "Success",
                Body = new
                {

                    Facilities = new List<FacilityAPIVm>
                    {
                      new FacilityAPIVm
                      {
                          facilityId = 1,
                          facilityName = "Refrigerator"
                      },

                      new FacilityAPIVm
                      {
                          facilityId = 2,
                          facilityName = "Wifi"
                      },

                        new FacilityAPIVm
                      {
                          facilityId = 3,
                          facilityName = "TV"
                      }

                       }

                   }
                
            };


            return Json(Response);
           
        }

       
    }

public class FacilityAPIVm
{
    public long facilityId { get; set; }
    public string facilityName { get; set; }
}
}
