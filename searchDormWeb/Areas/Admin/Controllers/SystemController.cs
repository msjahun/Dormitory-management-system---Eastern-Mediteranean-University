using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dau.Core.Domain.Logging;
using Dau.Services.Domain.DormitoryServices;
using Dau.Services.Email;
using Dau.Services.Event;
using Dau.Services.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using searchDormWeb.Areas.Admin.Models.System;
using static Dau.Services.Email.MessageQueueService;

namespace searchDormWeb.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize]
    public class SystemController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IDormitoryService _dormitoryService;
        private readonly ILoggingService _loggingService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMessageQueueService _messageQueueService;

        public SystemController(ILoggingService loggingService,
            IHttpContextAccessor httpContextAccessor,
            IMessageQueueService messageQueueService,
            IDormitoryService dormitoryService,
            IEventService eventService)
        {
            _eventService = eventService;
            _dormitoryService = dormitoryService;
            _loggingService = loggingService;
            _httpContextAccessor = httpContextAccessor;
            _messageQueueService = messageQueueService;
        }

        // GET: System

        #region System Information
        [HttpGet("[action]")]
        public IActionResult Information()
        {
            var model = new SystemInformationVm
            {
                Version = "v.1.0.0",
                OperatingSystem= System.Runtime.InteropServices.RuntimeInformation.OSDescription,
                AspDotNetInfo = "v2.2",
                IsFullTrustLevel= " True ",
                ServerTimeZone= "W.Europe standard time",
                ServerLocalTime= DateTime.UtcNow.ToString(),
                CoordinateUniversalTime =DateTime.Now.ToString(),
                CurrentUserTime=DateTime.Now.ToString(),
                HttpHost = (_httpContextAccessor.HttpContext.Request.IsHttps) ? "https://" : "http://" + _httpContextAccessor.HttpContext.Request.Host.Value.ToString()

        };
            return View("_Information", model);
        }

        #endregion


        #region log

        [HttpGet("[action]")]
        public IActionResult Log()
        {

            return View("_Log");
        }


        [HttpPost("[action]")]
        public IActionResult Log(int dummy)
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






                var newList = _eventService.GetAllEvents(); 
                //var List = new List<LogTable>();
                //foreach (var item in newList)
                //{
                //    List.Add(new LogTable
                //    {
                //       ShortMessage = new string(item.Message.Take(120).ToArray()),
                //       LogLevel = item.LogLevel,
                //       CreatedOn = item.CreatedTime,
                //       Id = item.Id,
                //       EventId = item.EventId

                //    });

                //}
                // getting all Discount data  
                var Data = newList;
                // getting all Discount data  
             
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
        public IActionResult LogView()
        {
            
            return View("_LogView");
        }

        [HttpPost("[action]")]
        public void ClearAllLogs()
        {
            _loggingService.DeleteAllLogs();
          
        }



        #endregion


        #region Warnings

        [HttpGet("[action]")]
        public IActionResult Warnings()
        {
            return View("_Warnings");
        }
        #endregion


        #region Maintenance
        [HttpGet("[action]")]
        public IActionResult Maintenance()
        {
            return View("_Maintenance");
        }

        [HttpPost("[action]")]
        public IActionResult Maintenance(int dummy)
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
                var Data = new List<int>();

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
        #endregion


        #region MessageQueues
        [HttpGet("[action]")]
        public IActionResult MessageQueues()
        {
            return View("_MessageQueues");
        }

        [HttpPost("[action]")]
        public IActionResult MessageQueues(int dummy)
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
                var Data = _messageQueueService.messageQueueListTable();

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
        public IActionResult MessageQueueEdit(long Id)
        {
           var model= _messageQueueService.GetMessageQueueById(Id);
            if(model==null)
                return RedirectToAction("MessageQueues", "System");
            return View("_MessageQueueEdit", model);
        }


        [HttpPost("[action]")]
        public IActionResult RequeueMessage(MessageQueueEdit vm)
        {
            bool success = _messageQueueService.RequeueMessage(vm);
            var model = _messageQueueService.GetMessageQueueById(vm.Id);

            return View("_MessageQueueEdit", model);
        }



        [HttpPost("[action]")]
        public IActionResult MessageQueueEdit(MessageQueueEdit vm)
        {
            bool success = _messageQueueService.UpdateMessageQueue(vm);
            var model = _messageQueueService.GetMessageQueueById(vm.Id);
               
            return View("_MessageQueueEdit", model);
        }



        [HttpPost("[action]")]
        public IActionResult DeleteMessageFromQueue(MessageQueueEdit vm)
        {
            bool success = _messageQueueService.DeleteMessageFromQueue(vm);
     
                return RedirectToAction("MessageQueues", "System");
           
        }
        #endregion


        #region Schedule Tasks
        [HttpGet("[action]")]
        public IActionResult ScheduleTasks()
        {
            return View("_ScheduleTasks");
        }

        [HttpPost("[action]")]
        public IActionResult ScheduleTasks(int dummy)
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
                var Data = new List<int>();

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

        #endregion

        #region SEOFriendlyPageNames

        [HttpGet("[action]")]
        public IActionResult SEOFriendlyPageNames()
        {
            return View("_SEOFriendlyPageNames");
        }

        [HttpPost("[action]")]
        public IActionResult SEOFriendlyPageNames(int dummy)
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
                var Data = _dormitoryService.GetSEOFriendlyPageNamesTable();

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

        #endregion


    }


    public class LogTable {
        public string LogLevel { get; set; }
        public string ShortMessage { get; set; }
        public DateTime CreatedOn { get; set; }
        public string View { get; set; }
        public long Id { get; set; }
        public long EventId { get; set; }
    }
    public class MaintenanceTable {
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string Download { get; set; }
        public string Restore { get; set; }
        public string Delete { get; set; }
    }

    public class ScheduleTasksTable {
        public string Name { get; set; }
        public string RunPeriod { get; set; }
        public string Enabled { get; set; }
        public string StopOnError { get; set; }
        public string LastStartDate { get; set; }
        public string LastEndDate { get; set; }
        public string RunNow { get; set; }
        public string Edit { get; set; }
    }
 



}