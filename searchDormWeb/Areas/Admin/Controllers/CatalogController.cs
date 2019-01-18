using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dau.Services.Facility;
using Dau.Services.Domain.RoomServices;
using Dau.Services.Domain.DormitoryBlockServices;
using Dau.Services.Domain.ReviewsServices;
using searchDormWeb.Areas.Admin.Models.Catalog;
using System.Globalization;
using Microsoft.Extensions.Localization;
using Dau.Services.Domain.DropdownServices;
using Dau.Services.Domain.FeaturesServices;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Dau.Services.Domain.ImageServices;
using Dau.Services.Export;
using static Dau.Services.Domain.DormitoryBlockServices.DormitoryBlockService;

namespace searchDormWeb.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class CatalogController : Controller
    {
       
        private readonly IFeaturesService _featuresService;
        private readonly IRoomService _roomService;
        private readonly IDormitoryBlockService _dormitoryBlockService;
        private readonly IReviewService _reviewService;
        private readonly IStringLocalizer _localizer;
        private readonly IDropdownService _dropdownService;
        private readonly IHostingEnvironment _environment;
        private readonly IImageService _imageService;
        private readonly IExportService _exportService;

        public CatalogController(
           IFeaturesService featuresService,
            IRoomService roomService, 
            IDormitoryBlockService dormitoryBlockService,
            IReviewService reviewService,
            IStringLocalizer Localizer,
            IDropdownService dropdownService,
            IHostingEnvironment IHostingEnvironment,
            IImageService imageService,
             IExportService exportService)
        {
            _featuresService = featuresService;
            _roomService = roomService;
            _dormitoryBlockService = dormitoryBlockService;
            _reviewService = reviewService;
            _localizer = Localizer;
            _dropdownService = dropdownService;
            _environment = IHostingEnvironment;
            _imageService = imageService;
            _exportService = exportService;
        }
        

        #region Rooms
        [HttpGet("[action]")]
        public ActionResult Rooms()
        {
          //  var Claims = User.Claims;
            return View("Rooms");
        }


         [HttpPost("[action]")]
        public ActionResult Rooms(int dummy)
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




                // List<RoomsListTable> List = _RoomService.GetAllRooms();
                var List = _roomService.GetRoomsListTable();
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
        public ActionResult RoomAdd()
        {
            return View("_RoomAdd");
        }

        [HttpPost("[action]")]
        public ActionResult RoomAdd(RoomViewCrud vm)
        {
            


            if (!ModelState.IsValid)
                return View("_RoomAdd", vm);

            var roomId = _roomService.AddRoom(vm);
            return RedirectToAction("RoomEdit", "Catalog", new { @id = roomId });
         //   return View("_RoomAdd", vm);
        }


        [HttpGet("[action]")]
        public ActionResult RoomEdit(long id)
        {
          var keyValue =  HttpContext.Request.Query["Section"];
            ViewData["section"] = "";
            if (!string.IsNullOrWhiteSpace(keyValue))
            { ViewData["section"] = keyValue; }

                var model = _roomService.GetRoomById(id);
            if(model==null)
                return RedirectToAction("Rooms", "Catalog");
            return View("_RoomEdit", model);
        }


        [HttpPost("[action]")]
        public ActionResult RoomEdit(RoomViewCrud vm)
        {



            if (!ModelState.IsValid)
                return View("_RoomEdit", vm);

            var model = new RoomsVm();
            vm.SavedSuccessful = _roomService.updateRoom(vm);
            model.AlertSuccessful = vm.SavedSuccessful;
            if (!model.AlertSuccessful)
            {
                model.AlertMessage = _localizer["Unable to update room, error encountered while updating room"];
                return View("Rooms", model);
            }


           
            return View("_RoomEdit", vm);
        }


        [HttpPost("[action]")]
        public ActionResult AddRoomFeature(FacilitiesTab vm)
        {
          var success=  _featuresService.AddRoomFeature(vm);

            return Json(true);
        }


        [HttpPost("[action]")]
        public ActionResult RemoveRoomFeature(FacilitiesTab vm)
        {
            var success = _featuresService.RemoveRoomFeature(vm);

            return Json(true);
        }


         [HttpPost("[action]")]
        public ActionResult RemoveRoomImage(long Id)
        {
            var success = _imageService.RemoveImage(Id);

            return Json(true);
        }


        [HttpPost("[action]")]
        public ActionResult GetFeaturesDropdown(long id)
        {
            return Json(_dropdownService.FeaturesByCategoryId(id));
        }

        [HttpPost("[action]")]
        public ActionResult GetDormitoryBlockByDormitoryIdDropdown(long id)
        {
            return Json(_dropdownService.GetDormitoryBlockByDormitoryIdDropdown(id));
        }


          [HttpPost("[action]")]
        public ActionResult RoomFeaturesMapping(long id)
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


             

               
                var List = _featuresService.GetRoomFeatures(id);
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

        [HttpPost("[action]")]
        public ActionResult DeleteRoom(RoomViewCrud vm)
        {



            var model = new RoomsVm();

           model.AlertSuccessful = _roomService.Delete(vm);
            if (model.AlertSuccessful)
            {
               model.AlertMessage = _localizer["Room has been deleted successfully"];
            }
            else
            {
                model.AlertMessage = _localizer["Unable to delete room, error encountered while deleting room"];
            }

        
            return View("Rooms",model);
        }

        [HttpPost("[action]")]
        public ActionResult GetRoomImages(long id)
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





                var List = _roomService.GetRoomImagesTables(id);
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


        [HttpPost("[action]")]
        public ActionResult UploadRoomImage(long id)
        {
           

         var success =   _imageService.UploadRoomImage(id);
            return RedirectToAction("RoomEdit", "Catalog", new {  id, @section="picture"});
        }



        [HttpGet("[action]")]
        public ActionResult ExportRoomsExcel(int Id)
        {
            //if id==1, today
            //id==2 //, last 7 days
            //id= 3 this month
            //var model = _exportService.getBookingExcel(id);
            string pathToFile = _exportService.ExportRoomsToExcel(Id);


            return RedirectToAction("", "Download", new { area = "", filename = pathToFile });

        }
        
        [HttpGet("[action]")]
        public ActionResult ExportDormitoryBlocksExcel(int Id)
        {
            //if id==1, today
            //id==2 //, last 7 days
            //id= 3 this month
            //var model = _exportService.getBookingExcel(id);
            string pathToFile = _exportService.ExportDormitoryBlocksToExcel(Id);


            return RedirectToAction("", "Download", new { area = "", filename = pathToFile });

        }

        #endregion

        #region DormitoryBlocks
        [HttpGet("[action]")]
        public ActionResult DormitoryBlocks()
        {
            return View("DormitoryBlocks");
        }
        
        [HttpPost("[action]")]
        public ActionResult DormitoryBlocks(int dummy)
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



                var List = _dormitoryBlockService.GetDormitoryBlockListTable();
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
        public ActionResult DormitoryBlockAdd()
        {
            return View("_DormitoryBlockAdd");
        }

        [HttpPost("[action]")]
        public ActionResult DormitoryBlockAdd(DormitoryBlockCrud vm)
        {

            if (!ModelState.IsValid)
                return View("_DormitoryBlockAdd", vm);

        var model=    _dormitoryBlockService.AddNewDormitoryBlock(vm);
            return RedirectToAction("DormitoryBlockEdit", "Catalog", new {vm.Id});
        }

        [HttpGet("[action]")]
        public ActionResult DormitoryBlockEdit(long Id)
        {

      var model=    _dormitoryBlockService.GetDormitoryBlockById(Id);
            if(model==null)
                return RedirectToAction("DormitoryBlocks", "Catalog");
            return View("_DormitoryBlockEdit", model);


        }


        [HttpPost("[action]")]
        public ActionResult DeleteDormitoryBlock(DormitoryBlockCrud vm)
        {

          

            var model = _dormitoryBlockService.DeleteDormitoryBlockById(vm.Id);
            return RedirectToAction("DormitoryBlocks", "Catalog"); 
        }

        [HttpPost("[action]")]
        public ActionResult DormitoryBlockEdit(DormitoryBlockCrud vm)
        {


            if (!ModelState.IsValid)
                return View("_DormitoryBlockEdit", vm);

            var model = new DormitoryBlockCrud();
            vm.SavedSuccessful = _dormitoryBlockService.UpdateDormitoryBlock(vm);
   
        



            return View("_DormitoryBlockEdit", vm);
           


        }


        [HttpPost("[action]")]
        public ActionResult DormitoryBlocksRoomsTable(long id)
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


                //  List<DormitoriesDataTable> List = _DormitoryService.GetAllDormitoriesForTable();
                var List = _roomService.GetRoomsByDormitoryBlockIdListTable(id);


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


        #endregion

        #region BulkRoomEdit
        [HttpGet("[action]")]
        public ActionResult BulkRoomEdit()
        {
            return View("BulkRoomEdit");
        }
        

        [HttpPost("[action]")]
        public ActionResult BulkRoomEdit(int dummy)
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



                List<BulkEditRoomsTable> List = new List<BulkEditRoomsTable>();
                List.Add(new BulkEditRoomsTable
                {
                    Name = "Alfam B block",
                    SKU = "2343kjlkdsdfjo",
                    Price = "$123,282.00",
                    OldPrice = "$23,400.00",
                    Quota = "23",
                    published = true,

                });



                List.Add(new BulkEditRoomsTable
                {
                    Name = "Alfam B block",
                    SKU = "2343kjlkdsdfjo",
                    Price = "$123,282.00",
                    OldPrice = "$23,400.00",
                    Quota = "23",
                    published = true,

                });

                List.Add(new BulkEditRoomsTable
                {
                    Name = "Alfam B block",
                    SKU = "2343kjlkdsdfjo",
                    Price = "$123,282.00",
                    OldPrice = "$23,400.00",
                    Quota = "23",
                    published = true,

                });

                List.Add(new BulkEditRoomsTable
                {
                    Name = "Alfam B block",
                    SKU = "2343kjlkdsdfjo",
                    Price = "$123,282.00",
                    OldPrice = "$23,400.00",
                    Quota = "23",
                    published = true,

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


        #endregion

        #region LowQuotaReport
        [HttpGet("[action]")]
        public ActionResult LowQuotaReport()
        {
            return View("LowQuotaReport");
        }


        [HttpPost("[action]")]
        public ActionResult LowQuotaReport(int dummy)
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




                List<LowQuotaReportTable> List = new List<LowQuotaReportTable>();
                List.Add(new LowQuotaReportTable
                {
                    RoomName = "Alfam B block",
                    RoomRemainingQuota = "2",
                    RoomLastSetQuota = "40",
                    Published = true
                });

                List.Add(new LowQuotaReportTable
                {
                    RoomName = "Alfam B block",
                    RoomRemainingQuota = "2",
                    RoomLastSetQuota = "40",
                    Published = true
                });

                List.Add(new LowQuotaReportTable
                {
                    RoomName = "Alfam B block",
                    RoomRemainingQuota = "2",
                    RoomLastSetQuota = "40",
                    Published = true
                });

                List.Add(new LowQuotaReportTable
                {
                    RoomName = "Alfam B block",
                    RoomRemainingQuota = "2",
                    RoomLastSetQuota = "40",
                    Published = true
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
        #endregion

        #region RoomReviews
        [HttpGet("[action]")]
        public ActionResult RoomReviews()
        {
            return View("RoomReviews");
        }


        [HttpPost("[action]")]
        public ActionResult RoomReviews(int dummy)
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



                var List = _reviewService.GetReviewsListTable();

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
        public ActionResult RoomReviewEdit()
        {
            return View("_RoomReviewEdit");
        }

        #endregion

        #region Features
        [HttpGet("[action]")]
        public ActionResult Features()
        {
            return View("Facilities");
        }

        [HttpPost("[action]")]
        public ActionResult Features(int dummy)
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


              //var newList =  FacilityService.GetFacilities();
              //  var List = new List<FacilitiesSpecificationAttributesTable>();
          var List = new List<FacilitiesSpecificationAttributesTable>();
              //  foreach (var item in newList)
              //  {
              //      List.Add(new FacilitiesSpecificationAttributesTable
              //      {
              //          Name = item.FacilityTitle,
              //          DisplayOrder = "2"
              //      });

              //  }
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
        public ActionResult FeaturesAdd()
        {
            return View("_FacilityAdd");
        }

        [HttpGet("[action]")]
        public ActionResult FeaturesEdit()
        {
            return View("_FacilityEdit");
        }

        #endregion

        #region FeaturesCategory
        [HttpGet("[action]")]
        public ActionResult FeaturesCategory()
        {
            return View("Facilities");
        }

        [HttpPost("[action]")]
        public ActionResult FeaturesCategory(int dummy)
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


                //var newList =  FacilityService.GetFacilities();
                //  var List = new List<FacilitiesSpecificationAttributesTable>();
                var List = new List<FacilitiesSpecificationAttributesTable>();
                //  foreach (var item in newList)
                //  {
                //      List.Add(new FacilitiesSpecificationAttributesTable
                //      {
                //          Name = item.FacilityTitle,
                //          DisplayOrder = "2"
                //      });

                //  }
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
        public ActionResult FeaturesCategoryAdd()
        {
            return View("_FacilityAdd");
        }

        [HttpGet("[action]")]
        public ActionResult FeaturesCategoryEdit()
        {
            return View("_FacilityEdit");
        }
        #endregion
    }


    public class BulkEditRoomsTable {
        public string Name { get; set; }
        //public string View { get; set; }
        public string SKU { get; set; }
        public string Price { get; set; }
        public string OldPrice { get; set; }
        public string Quota { get; set; }
        public bool published { get; set; }
        //public string Delete { get; set; }
    }

    public class LowQuotaReportTable {
        public string RoomName { get; set; }
        public string RoomRemainingQuota { get; set; }
        public string RoomLastSetQuota { get; set; }
        public bool Published { get; set; }
        //public string Edit { get; set; }
    }


    public class FacilitiesSpecificationAttributesTable
    {
        public string Name { get; set; }
        public string DisplayOrder { get; set; }
        public string Edit { get; set; }
    }

}