using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dau.Services.Domain.AnnouncementsServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace searchDormWeb.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize]
    public class NotificationsController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public NotificationsController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        // GET: Notifications

        [HttpGet("[action]")]
        public IActionResult List()
        {
            return View("_List");
        }

        #region Announcements
        [HttpGet("[action]")]
        public IActionResult Announcements()
        {
            return View("_Announcements");
        }

        [HttpPost("[action]")]
        public IActionResult Announcements(int dummy)
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault(); // Skip number of Rows count
                var passedParam = Request.Form["myKey"].FirstOrDefault();//passed parameter
                var length = Request.Form["length"].FirstOrDefault();  // Paging Length 10,20  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault(); // Sort Column Name  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();// Sort Column Direction (asc, desc)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();// Search Value from (Search box) 
                int pageSize = length != null ? Convert.ToInt32(length) : 0; //Paging Size (10, 20, 50,100)  
                int skip = start != null ? Convert.ToInt32(start) : 0;






                // getting all Discount data  
                var Data = _announcementService.GetAnnoucementsTableList();

                ////Sorting  
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    DiscountData = DiscountData.OrderBy(c => c.sortColumn sortColumnDirection);
                //}
                ////Search  
                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    DiscountData = DiscountData.Where(m => m.Name == searchValue);
                //}


                //total number of rows counts   
                int recordsTotal = 0;
                recordsTotal = Data.Count();
                //Paging   
                var data = Data.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("[action]")]
        public IActionResult AnnouncementAdd()
        {

            return View("_AnnouncementAdd");
        }



        [HttpPost("[action]")]
        public IActionResult AnnouncementAdd(AnnouncementCrud vm)


        {

            if (!ModelState.IsValid)
            {
                return View("_AnnouncementAdd", vm);
            }
            var announcementId = _announcementService.AddNewAnnouncement(vm);

            return RedirectToAction("AnnouncementEdit", "Notifications", new { Id = announcementId });
        }


        [HttpGet("[action]")]
        public IActionResult AnnouncementEdit(long Id)
        {
            var model = _announcementService.GetAnnouncementById(Id);
            if (model == null) return RedirectToAction("Announcements", "Notifications");

            return View("_AnnouncementEdit", model);
        }


        [HttpPost("[action]")]
        public IActionResult AnnouncementEdit(AnnouncementCrud vm)
        {
            if (!ModelState.IsValid)
            {
                return View("_AnnouncementEdit", vm);
            }

            var success = _announcementService.updateAnnoucement(vm);
            var model = _announcementService.GetAnnouncementById(vm.Id);

            return View("_AnnouncementEdit", model);
        }


        [HttpPost("[action]")]
        public IActionResult DeleteAnnouncement(AnnouncementCrud vm)
        {
            
            var success = _announcementService.DeleteAnnouncement(vm);

            return RedirectToAction("Announcements", "Notifications"); 
        }


        #endregion

    }



}