using Microsoft.AspNetCore.Mvc;
using searchDormWeb.Models;

namespace searchDormWeb.Controllers.API
{
    [Produces("application/json")]
  
    [ApiController]
    public class PaymentConfirmationController : Controller
    {


        // POST: api/PaymentConfirmation
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Post(string value)
        {


            ResponseResult response = new ResponseResult
            {
                Response = true,
                StatusCode= "0x3234"
            };

            return Json(response);
        }

       



    }

  
}
