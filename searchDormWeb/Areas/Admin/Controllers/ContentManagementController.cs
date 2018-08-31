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
    public class ContentManagementController : Controller
    {


        #region Topics
        [HttpGet("[action]")]
        public IActionResult Topics()
        {
            return View("_Topics");
        }

        [HttpGet("[action]")]
        public IActionResult TopicAdd()
        {
            return View("_TopicAdd");
        }


        [HttpGet("[action]")]
        public IActionResult TopicEdit()
        {
            return View("_TopicEdit");
        }

        #endregion


        #region MessageTemplates
        [HttpGet("[action]")]
        public IActionResult MessageTemplates()
        {
            return View("_MessageTemplates");
        }

        [HttpGet("[action]")]
        public IActionResult MessageTemplateEdit()
        {
            return View("_MessageTemplateEdit");
        }


        #endregion


        #region Polls
        [HttpGet("[action]")]
        public IActionResult Polls()
        {
            return View("_Polls");
        }

        [HttpGet("[action]")]
        public IActionResult PollAdd()
        {
            return View("_PollAdd");
        }

        [HttpGet("[action]")]
        public IActionResult PollEdit()
        {
            return View("_PollEdit");
        }
        #endregion


        #region Survey

        [HttpGet("[action]")]
        public IActionResult Survey()
        {
            return View("_Survey");
        }

        [HttpGet("[action]")]
        public IActionResult SurveyAdd()
        {
            return View("_SurveyAdd");
        }



        [HttpGet("[action]")]
        public IActionResult SurveyEdit()
        {
            return View("_SurveyEdit");
        }




        #endregion
    }
}