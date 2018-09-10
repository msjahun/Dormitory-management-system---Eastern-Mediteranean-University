using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using searchDormWeb.Areas.Admin.Models.Debug;

namespace searchDormWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize]
    public class DebugController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult TagHelpers()
        {
            return View();
        }

        [HttpGet("[action]")]
        public IActionResult DataTables()
        {
            return View();
        }

        [HttpPost("[action]")]
        public IActionResult LoadData()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

                // Skip number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();


                 //passed parameter 
                var passedParam = Request.Form["myKey"].FirstOrDefault();

                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();

                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

                // Sort Column Direction (asc, desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10, 20, 50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;

                int skip = start != null ? Convert.ToInt32(start) : 0;

                int recordsTotal = 0;



                List<DebugDiscountModel> DiscountList = new List<DebugDiscountModel>();
                DiscountList.Add(new DebugDiscountModel
                {
                    DiscountId = 1,
                    Namee = "sample discount",
                    DiscountType = "unique discount",
                    Discount = "all people discount",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Today,
                    TimesUsed = 39

                });

                DiscountList.Add(new DebugDiscountModel
                {
                    DiscountId = 2,
                    Namee = "sample dissfdcount",
                    DiscountType = "unisdfque discount",
                    Discount = "all peosdfple discount",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Today,
                    TimesUsed = 39

                });

                DiscountList.Add(new DebugDiscountModel
                {
                    DiscountId = 3,
                    Namee = "sample dsdfiscount",
                    DiscountType = "unsdfique discount",
                    Discount = "all peaasdfople discount",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Today,
                    TimesUsed = 2

                });

                DiscountList.Add(new DebugDiscountModel
                {
                    DiscountId = 4,
                    Namee = "samplasfde discount",
                    DiscountType = "asunique discount",
                    Discount = "all aapeople discount",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Today,
                    TimesUsed = 44

                });

                DiscountList.Add(new DebugDiscountModel
                {
                    DiscountId = 5,
                    Namee = "sample asdfdiscount",
                    DiscountType = "unique discount",
                    Discount = "all pefaople discount",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Today,
                    TimesUsed = 53

                });

                DiscountList.Add(new DebugDiscountModel
                {
                    DiscountId = 45,
                    Namee = "samasfdple disasdfcount",
                    DiscountType = "asdfunique discount",
                    Discount = "aasfdll people discount",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Today,
                    TimesUsed = 342

                });

                // getting all Discount data  
                var DiscountData = DiscountList;
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
                recordsTotal = DiscountData.Count();
                //Paging   
                var data = DiscountData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}