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
    public class ActivityLogController : Controller
    {// GET: ActivityLog
        

        [HttpGet("[action]")]
        public IActionResult Log()
        {
            return View("_ActivityLog_Log");
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




                List<ActivityLogTable> List = new List<ActivityLogTable>();

                List.Add(new ActivityLogTable {
                    ActivityLogType = "Add a new room",
                    User = "msjahun@live.com",
                    IpAddress = "42.234.34.23",
                    MessageAction = "Added a new room(Alfam studio)",
                    CreatedOn = DateTime.Now,
                id="23"
                });

                List.Add(new ActivityLogTable {
                    ActivityLogType = "Add a new room",
                    User = "msjahun@live.com",
                    IpAddress = "42.234.34.23",
                    MessageAction = "Added a new room(Alfam studio)",
                    CreatedOn = DateTime.Now,
                id="23"
                });

                // getting all Discount data  
                var Data = List;

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
        public IActionResult Type()
        {
            return View("_ActivityLog_logtype");
        }

        [HttpPost("[action]")]
        public IActionResult Type( int dummy)
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




                List<ActivityLogTypeTable> List = new List<ActivityLogTypeTable>();
                List.Add(new ActivityLogTypeTable {
                Name="Add room",
                isEnabled=true});


                List.Add(new ActivityLogTypeTable
                {
                    Name = "Add room",
                    isEnabled = true
                });


                List.Add(new ActivityLogTypeTable
                {
                    Name = "Add room",
                    isEnabled = true
                });


                List.Add(new ActivityLogTypeTable
                {
                    Name = "Edit room",
                    isEnabled = true
                });


                List.Add(new ActivityLogTypeTable
                {
                    Name = "Add room",
                    isEnabled = true
                });


                List.Add(new ActivityLogTypeTable
                {
                    Name = "Add room",
                    isEnabled = true
                });


                List.Add(new ActivityLogTypeTable
                {
                    Name = "Add room",
                    isEnabled = true
                });

                // getting all Discount data  
                var Data = List;
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
    }



    public class ActivityLogTable {
    public string id { get; set; }
        public string ActivityLogType { get; set; }
        public string User { get; set; }
        public string IpAddress { get; set; }
        public string MessageAction { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Delete { get; set; }
    }
    public class ActivityLogTypeTable {
        public string Name { get; set; }
        public bool isEnabled { get; set; }
    }


}