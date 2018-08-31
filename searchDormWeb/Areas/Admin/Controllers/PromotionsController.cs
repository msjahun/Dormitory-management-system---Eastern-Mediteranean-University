using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace searchDormWeb.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize]
    public class PromotionsController : Controller
    {
        // GET: Promotions
    
        #region Discounts
        [HttpGet("[action]")]
        public IActionResult Discounts()
        {
            return View("_Discounts");
        }


        [HttpGet("[action]")]
        public IActionResult DiscountAdd()
        {
            return View("_DiscountAdd");
        }



        [HttpGet("[action]")]
        public IActionResult DiscountEdit()
        {
            return View("_DiscountEdit");
        }

        #endregion


        #region Affiliates
        [HttpGet("[action]")]
        public IActionResult Affiliates()
        {
            return View("_Affiliates");
        }


        [HttpGet("[action]")]
        public IActionResult AffiliateAdd()
        {
            return View("_AffiliateAdd");
        }



        [HttpGet("[action]")]
        public IActionResult AffiliateEdit()
        {
            return View("_AffiliateEdit");
        }



        #endregion 

        [HttpGet("[action]")]
        public IActionResult NewsLetterSubscribers()
        {
            return View("_NewsLetterSubscribers");
        }


        #region Campaigns
        [HttpGet("[action]")]
        public IActionResult Campaigns()
        {
            return View("_Campaigns");
        }


        [HttpGet("[action]")]
        public IActionResult CampaignAdd()
        {
            return View("_CampaignAdd");
        }

        [HttpGet("[action]")]
        public IActionResult CampaignEdit()
        {
            return View("_CampaignEdit");
        }

        #endregion
    }
}