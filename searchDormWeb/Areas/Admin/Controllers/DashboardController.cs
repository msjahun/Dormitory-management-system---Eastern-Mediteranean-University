using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dau.Services.Domain.BookingService;
using Dau.Services.Domain.FeaturesServices;
using Dau.Services.Domain.RoomServices;
using Dau.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace searchDormWeb.Areas.Admin.Controllers
{ 
    [Area("Admin")]
    [Route("Admin/[controller]")]
   [Authorize]
    public class DashboardController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;
        private readonly IStringLocalizer _localizer;
        private readonly IFeaturesService _featuresService;

        public DashboardController(
            IUsersService usersService,
            IBookingService bookingService,
            IRoomService roomService,
            IStringLocalizer Localizer,
             IFeaturesService featuresService)
        {
            _usersService = usersService;
            _bookingService=bookingService;
            _roomService = roomService;
            _localizer = Localizer;
            _featuresService=featuresService;
        }

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
                var Data = new List<BookingTotalsTable>
                {
                    new BookingTotalsTable
                    {
                        OrderStatus=_localizer["Pending"],
                        Today="0,00 tl",
                        ThisWeek="0,00 tl",
                        ThisMonth="0,00 tl",
                        ThisYear="0,00 tl",
                        AllTime="0,00 tl"
                    },

                     new BookingTotalsTable
                    {
                        OrderStatus=_localizer["Processing"],
                        Today="0,00 tl",
                        ThisWeek="0,00 tl",
                        ThisMonth="0,00 tl",
                        ThisYear="0,00 tl",
                        AllTime="0,00 tl"
                    },

                      new BookingTotalsTable
                    {
                        OrderStatus=_localizer["Complete"],
                        Today="0,00 tl",
                        ThisWeek="0,00 tl",
                        ThisMonth="0,00 tl",
                        ThisYear="0,00 tl",
                        AllTime="0,00 tl"
                    },

                       new BookingTotalsTable
                    {
                        OrderStatus=_localizer["Cancelled"],
                        Today="0,00 tl",
                        ThisWeek="0,00 tl",
                        ThisMonth="0,00 tl",
                        ThisYear="0,00 tl",
                        AllTime="0,00 tl"
                    }

                };

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
                var Data = new List<IncompleteBookingsTable> {

                new IncompleteBookingsTable{
                    Item=_localizer["Total unpain Orders(pending payment status)"],
                    Total="328,97 tl",
                    Count="4"

                },
                    new IncompleteBookingsTable{
                    Item=_localizer["Total awaiting comfirmation"],
                    Total="34,4 tl",
                    Count="7"

                },
                        new IncompleteBookingsTable{
                    Item=_localizer["Total incomplete orders (pending order status)"],
                    Total="328,97 tl",
                    Count="3"

                }


                };

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
                var Data = _bookingService.GetLatestBookingsDashboardList();

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
                var Data = _featuresService.GetFeaturesHitCount();

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


        [HttpPost("[action]")]
        public ActionResult NoOfBookings()
        {
            int numberOfBookings = _bookingService.GetTotalNumberOfBookings();
            return Json(numberOfBookings);
        }


        [HttpPost("[action]")]
        public ActionResult NoOfUsers()
        {
            int numberOfUser = _usersService.GetTotalNumberOfUser();
            return Json(numberOfUser);
        }


        [HttpPost("[action]")]
        public ActionResult NoOfPendingCancelledRequests()
        {
            int numberOfPendingCancelRequests = _bookingService.GetTotalNumberOfCancelRequests();
            return Json(numberOfPendingCancelRequests);
        }

        [HttpPost("[action]")]
        public ActionResult NoOfLowQuotaRooms()
        {
           int noOfLowQuotaRooms = _roomService.GetNumberOfRoomsWithLowQuota();
            return Json(noOfLowQuotaRooms);
        }


        [HttpPost("[action]")]
        public ActionResult GetBookingsChart(long Id)
        {
            //long Id = 1;//1 day, 2 month, 3 year
            var data =  _bookingService.GetBookingsChartById(Id);
            return Json(data);
        }



        [HttpPost("[action]")]
        public ActionResult GetnewCustomersChart(long Id)
        {
            //long Id = 1;//1 day, 2 month, 3 year
            var data = _usersService.GetnewCustomersChart(Id);
            return Json(data);
        }



    }



   

    public class BookingTotalsTable
    {
        public string OrderStatus    { get; set; }
        public string Today         { get; set; }
        public string ThisWeek      { get; set; }
        public string ThisMonth      { get; set; }
        public string ThisYear      { get; set; }
        public string AllTime       { get; set; }


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



    public class BestSellersTable
    {
        public string Name { get; set; }
        public string TotalQuantity { get; set; }
        public string TotalAmount { get; set; }
        //public button View { get; set; }


    }


}