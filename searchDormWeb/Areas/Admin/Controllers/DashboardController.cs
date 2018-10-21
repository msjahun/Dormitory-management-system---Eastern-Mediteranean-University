using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace searchDormWeb.Areas.Admin.Controllers
{ 
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        [HttpGet("[action]")]
        [HttpGet("")]
       [DisplayName("General")]
        public ActionResult Index()
        {
          
            return View("Dashboard");
         
        }

        [HttpPost("[action]")]
        public ActionResult BookingTotals()
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

        [HttpPost("[action]")]
        public ActionResult IncompleteBookings()
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

        [HttpPost("[action]")]
        public ActionResult LatestBookings()
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


        [HttpPost("[action]")]
        public ActionResult PopularFilters()
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


        [HttpPost("[action]")]
        public ActionResult BestSellersQuantity()
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


        [HttpPost("[action]")]
        public ActionResult BestSellersAmount()
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




    }





    public class BookingTotalsTable
    {
        public string OrderStatus { get; set; }
        public string Today { get; set; }
        public string ThisWeek { get; set; }
        public string ThisMonth { get; set; }
        public string ThisYear { get; set; }
        public string AllTime { get; set; }


    }


    public class IncompleteBookingsTable
    {
        public string Item { get; set; }
        public string Total { get; set; }
        public string Count { get; set; }


    }

    public class LatestBookingsTable
    {
        public string OrderNo { get; set; }
        public string OrderStatus { get; set; }
        public string Customer { get; set; }
        public string CreatedOn { get; set; }
        //public button View { get; set; }


    }

    public class PopularFiltersTable
    {
        public string Filter { get; set; }
        public string Count { get; set; }


    }


    public class BestSellersTable
    {
        public string Name { get; set; }
        public string TotalQuantity { get; set; }
        public string TotalAmount { get; set; }
        //public button View { get; set; }


    }


}