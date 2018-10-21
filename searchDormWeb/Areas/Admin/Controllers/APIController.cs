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
    public class APIController : Controller
    {
    
        #region Settings

        [HttpGet("[action]")]
        public IActionResult Settings()
        {
            return View("Settings");
        }

        #endregion

        #region Client

        [HttpGet("[action]")]
        public IActionResult Clients()
        {
            return View("Clients");
        }


         [HttpPost("[action]")]
        public IActionResult Clients( int dummy)
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


                List<ClientTable> List = new List<ClientTable>();
                List.Add(new ClientTable
                { Name = "Admin",
                    ClientId = "coiuvio23tu5icou2iucic215yociuy325k3h5kjch3iu2iuhc23kchkiuissd",
                    ClientSecret = "**********************************",
                    CallBackUrl = "https://dormitories.emu.edu.tr/API",
                    id = "2",
                    IsActive = true
                });

                List.Add(new ClientTable
                {
                    Name = "Admin",
                    ClientId = "coiuvio23tu5icou2iucic215yociuy325k3h5kjch3iu2iuhc23kchkiuissd",
                    ClientSecret = "**********************************",
                    CallBackUrl = "https://dormitories.emu.edu.tr/API",
                    id = "2",
                    IsActive = true
                });



                List.Add(new ClientTable
                {
                    Name = "Admin",
                    ClientId = "coiuvio23tu5icou2iucic215yociuy325k3h5kjch3iu2iuhc23kchkiuissd",
                    ClientSecret = "**********************************",
                    CallBackUrl = "https://dormitories.emu.edu.tr/API",
                    id = "2",
                    IsActive = false
                });



                List.Add(new ClientTable
                {
                    Name = "Dormapi",
                    ClientId = "coiuvio23tu5icou2iucic215yociuy325k3h5kjch3iu2iuhc23kchkiuissd",
                    ClientSecret = "**********************************",
                    CallBackUrl = "https://dormitories.emu.edu.tr/API",
                    id = "2",
                    IsActive = true
                });



                List.Add(new ClientTable
                {
                    Name = "Admin",
                    ClientId = "coiuvio23tu5icou2iucic215yociuy325k3h5kjch3iu2iuhc23kchkiuissd",
                    ClientSecret = "**********************************",
                    CallBackUrl = "https://dormitories.emu.edu.tr/API",
                    id = "2",
                    IsActive = true
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
        public IActionResult ClientAdd()
        {
            return View("_ClientAdd");
        }


        [HttpGet("[action]")]
        public IActionResult ClientEdit()
        {
            return View("_ClientEdit");
        }


        #endregion

        #region Documentation
        [HttpGet("[action]")]
        public IActionResult Documentation()
        {
            return View("Documentation");
        }

        #endregion
    }

    public class ClientTable {
        public string id { get; set; }
        public string Name { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string CallBackUrl { get; set; }
        public bool IsActive { get; set; }
      
    }

}