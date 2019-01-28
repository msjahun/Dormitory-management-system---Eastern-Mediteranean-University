using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dau.Core.Configuration.AccessControlList;
using Dau.Core.Domain.SliderImages;
using Dau.Core.Domain.Users;
using Dau.Services.AccessControlList;
using Dau.Services.Domain.CurrencyServices;
using Dau.Services.Domain.DormitoryBlockServices;
using Dau.Services.Domain.DormitoryServices;
using Dau.Services.Domain.FeaturesServices;
using Dau.Services.Domain.ImageServices;
using Dau.Services.Domain.LocationServices;
using Dau.Services.Domain.RoomServices;
using Dau.Services.Email;
using Dau.Services.Export;
using Dau.Services.Languages;
using Dau.Services.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using searchDormWeb.Areas.Admin.Models.Configuration;

namespace searchDormWeb.Areas.Admin.Controllers
{


    [Authorize]
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class ConfigurationsController : Controller
    {
        private readonly ICurrencyService _currencyService;
        private readonly ISliderImageService _sliderImageService;

        public IStringLocalizer Localizer { get; }

        private readonly IEmailAccountService _emailAccountService;
        private readonly RoleManager<UserRole> _roleManager;
        private readonly IUserRolesService _userRolesService;
        private readonly IMvcControllerDiscovery _mvcControllerDiscovery;
        private readonly IDormitoryService _dormitoryService;
        private readonly IImageService _imageService;
        private readonly IFeaturesService _featuresService;
        private readonly IRoomService _roomService;
        private readonly IDormitoryBlockService _dormitoryBlockService;
        private readonly ILocationService _locationService;
        private readonly IExportService _exportService;
        private readonly ILanguageService _languageService;
        private readonly IMessageQueueService _messageQueueService;

        public ConfigurationsController(IDormitoryService dormitoryService,
             IImageService imageService,
             IMvcControllerDiscovery mvcControllerDiscovery, IUserRolesService userRolesService, RoleManager<UserRole> roleManager,
             IFeaturesService featuresService,
             IRoomService roomService,
             IDormitoryBlockService dormitoryBlockService,
             ILocationService locationService,
              IExportService exportService,
              IStringLocalizer stringLocalizer,
              ILanguageService languageService,
              IEmailAccountService emailAccountService,
              IMessageQueueService messageQueueService,
              ISliderImageService sliderImageService,
              ICurrencyService currencyService)
        {

            _currencyService = currencyService;
            _sliderImageService = sliderImageService;
            Localizer = stringLocalizer;
            _emailAccountService = emailAccountService;
            _roleManager = roleManager;
            _userRolesService = userRolesService;
            _mvcControllerDiscovery = mvcControllerDiscovery;
            _dormitoryService = dormitoryService;
            _imageService = imageService;
            _featuresService = featuresService;
            _roomService = roomService;
            _dormitoryBlockService = dormitoryBlockService;
            _locationService = locationService;
            _exportService = exportService;
            _languageService = languageService;
            _messageQueueService = messageQueueService;
        }





        #region EmailAccounts

        [HttpGet("[action]")]

        public ActionResult EmailAccounts()
        {
            return View("EmailAccounts");
        }

        [HttpPost("[action]")]

        public ActionResult EmailAccounts(int dummy)
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
                var Data = _emailAccountService.GetEmailAccountsTableList();

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

        public ActionResult EmailAccountAdd()
        {
            return View("_EmailAccountAdd");
        }



        [HttpPost("[action]")]

        public ActionResult EmailAccountAdd(EmailAccountCrud vm)
        {

            if (!ModelState.IsValid)
                return View("_EmailAccountAdd", vm);

            if (string.IsNullOrEmpty(vm.EmailAccoutPassword) || string.IsNullOrWhiteSpace(vm.EmailAccoutPassword))
            {
                ModelState.AddModelError("", Localizer["Password is required"]);
                return View("_EmailAccountAdd", vm);
            }

            var emailId = _emailAccountService.AddNewEmail(vm);
            return RedirectToAction("EmailAccountEdit", "Configurations", new { @id = emailId});

          
        
        }


        [HttpPost("[action]")]

        public ActionResult EmailAccountChangePassword(EmailAccountCrud vm)
        {

            if (!ModelState.IsValid)
                return View("_EmailAccountEdit", vm);

            if (string.IsNullOrEmpty(vm.EmailAccoutPassword) || string.IsNullOrWhiteSpace(vm.EmailAccoutPassword))
            {
                ModelState.AddModelError("", Localizer["Password is required"]);
                return View("_EmailAccountEdit", vm);
            }
         var success=   _emailAccountService.UpdateEmailAccountPassword(vm);

            var model = _emailAccountService.GetEmailAccountById(vm.Id);
            return View("_EmailAccountEdit", vm);


        }

        [HttpGet("[action]")]

        public ActionResult EmailAccountEdit( long Id)
        {

            var model = _emailAccountService.GetEmailAccountById(Id);
            if (model == null)
              return  RedirectToAction("EmailAccounts", "Configurations");

            return View("_EmailAccountEdit", model);
        }





        [HttpPost("[action]")]

        public ActionResult EmailAccountEdit(EmailAccountCrud vm)
        {

            if (!ModelState.IsValid)
                return View("_EmailAccountEdit", vm);

            var success = _emailAccountService.UpdateEmailAccount(vm);
            var model = _emailAccountService.GetEmailAccountById(vm.Id);
            if (model == null)
                return RedirectToAction("EmailAccounts", "Configurations");

            return View("_EmailAccountEdit", model);



        }


        [HttpPost("[action]")]

        public ActionResult DeleteEmailAccount(EmailAccountCrud vm)
        {

            var model = _emailAccountService.DeleteEmailAccount(vm);
          return  RedirectToAction("EmailAccounts", "Configurations");


        }
        [HttpPost("[action]")]

        public ActionResult MarkEmailAsDefault(long EmailAccountId)
        {

            var success = _emailAccountService.SetEmailAccountToDefault(EmailAccountId);
            return Json(success);


        }

        [HttpPost("[action]")]

        public ActionResult TestEmailAccount(EmailAccountCrud vm)
        {
            if (!ModelState.IsValid)
                return View("_EmailAccountEdit", vm);

            if (string.IsNullOrEmpty(vm.SendEmailTo) || string.IsNullOrWhiteSpace(vm.SendEmailTo))
            {
                ModelState.AddModelError("", Localizer["Send test email is required"]);
                return View("_EmailAccountEdit", vm);
            }

            ModelState.AddModelError("", _messageQueueService.SendTestEmail(vm));
            var model = _emailAccountService.GetEmailAccountById(vm.Id);
            return View("_EmailAccountEdit", vm);


        }

        #endregion

        #region Dormitories
        [HttpGet("[action]")]
        public ActionResult Dormitories()
        {
            return View("Dormitories");
        }

        [HttpPost("[action]")]
        public ActionResult Dormitories(int dummy)
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
                var List = _dormitoryService.GetDormitoryListTable();


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
        public ActionResult DormitoryAdd()
        {
            return View("_DormitoryAdd");
        }


        [HttpPost("[action]")]
        public ActionResult DormitoryAdd(DormitoryCrud vm)
        {
            if (!ModelState.IsValid)
                return View("_DormitoryAdd", vm);

            var dormitoryId = _dormitoryService.AddDormitory(vm);
            return RedirectToAction("DormitoryEdit", "Configurations", new { @id = dormitoryId });
        }


        [HttpGet("[action]")]
        public ActionResult DormitoryEdit(long id)
        {
            var keyValue = HttpContext.Request.Query["Section"];
            ViewData["section"] = "";
            if (!string.IsNullOrWhiteSpace(keyValue))
            { ViewData["section"] = keyValue; }

            bool savedStatus = false;
            var saved = HttpContext.Request.Query["saved"];
            if (!string.IsNullOrWhiteSpace(saved))
            { savedStatus = bool.Parse(saved); }


            //send id, bringmodel, if false, redirect to Dormitories
            var model = _dormitoryService.GetDormitoryById(id);
            if (model == null)
                return RedirectToAction("Dormitories", "Configurations");
            model.SavedSuccessful = savedStatus;
            return View("_DormitoryEdit", model);
        }

        [HttpPost("[action]")]
        public ActionResult DormitoryEdit(DormitoryCrud vm)
        {
            if (!ModelState.IsValid)
                return View("_DormitoryEdit", vm);
            var updateSuccess = _dormitoryService.UpdateDormitoryById(vm);
            var success = _imageService.uploadDormitoryLogoImage(vm.Id);
            
            var model = _dormitoryService.GetDormitoryById(vm.Id);
            model.SavedSuccessful = updateSuccess;
            return View("_DormitoryEdit", model);
        }


        [HttpPost("[action]")]
        public ActionResult DormitorySeoEdit(DormitoryCrud vm)
        {
        
            var saveStatus = _dormitoryService.UpdateDormSeo(vm);
           
            return RedirectToAction("DormitoryEdit", "Configurations", new { @id = vm.Id , @section = "seo",@saved=saveStatus });
        }


        [HttpPost("[action]")]
        public ActionResult AddDormitoryFeature(FacilitiesTabDormitory vm)
        {
            var success = _featuresService.AddDormitoryFeature(vm);

            return Json(success);
        }

        [HttpPost("[action]")]
        public ActionResult RemoveDormitoryFeature(FacilitiesTabDormitory vm)
        {
            var success = _featuresService.RemoveDormitoryFeature(vm);

            return Json(success);
        }


        [HttpPost("[action]")]
        public ActionResult AddCloseLocation(CloseLocationVm vm)
        {
            var success = _locationService.AddDormitoryCloseLocationAsync(vm).Result; 
               

            return Json(success);
        }

        [HttpPost("[action]")]
        public ActionResult RemoveCloseLocation(CloseLocationVm vm)
        {
            var success = _locationService.RemoveDormitoryCloseLocation(vm);

            return Json(success);
        }


        [HttpPost("[action]")]
        public ActionResult UploadDormitoryImage(long id)
        {


            var success = _imageService.uploadDormitoryImage(id);
            return RedirectToAction("DormitoryEdit", "Configurations", new { id, @section = "picture" });
        }

        [HttpPost("[action]")]
        public ActionResult RemoveDormitoryImage(long Id)
        {
            var success = _imageService.RemoveImage(Id);

            return Json(success);
        }

        [HttpPost("[action]")]
        public ActionResult CloseLocationsTable(long id)
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
                var List = _locationService.GetDormitoryCloseLocationsListTable(id);


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



        [HttpPost("[action]")]
        public ActionResult DormitoryPicturesTable(long id)
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
                var List = _dormitoryService.GetDormitoryImagesTables(id);


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


        [HttpPost("[action]")]
        public ActionResult DormitoryFeaturesTable(long id)
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
                var List = _featuresService.GetDormitoryFeatures(id);


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


        [HttpPost("[action]")]
        public ActionResult DormitoryRoomsTable(long id)
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
                var List = _roomService.GetRoomsByDormitoryIdListTable(id);


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


        [HttpPost("[action]")]
        public ActionResult DormitoryBlocksTable(long id)
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
                var List = _dormitoryBlockService.GetDormitoryBlockByDormitoryIdListTable(id);


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
        public ActionResult ExportExcel(int Id)
        {
            //if id==1, today
            //id==2 //, last 7 days
            //id= 3 this month
            //var model = _exportService.getBookingExcel(id);
            string pathToFile = _exportService.ExportDormitoryToExcel(Id);


            return RedirectToAction("", "Download", new { area = "", filename = pathToFile });

        }

        #endregion

        #region Countries

        [HttpGet("[action]")]
        public ActionResult Countries()
        {
            return View("Countries");
        }


         [HttpPost("[action]")]
        public ActionResult Countries(int dummy)
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


        [HttpGet("[action]")]
        public ActionResult CountryAdd()
        {
            return View("_CountryAdd");
        }

        [HttpGet("[action]")]
        public ActionResult CountryEdit()
        {
            return View("_CountryEdit");
        }

        #endregion


        #region Languagues
        [HttpGet("[action]")]
        public ActionResult Languages()
        {
            return View("Languages");
        }


        [HttpPost("[action]")]
        public ActionResult Languages(int dummy)
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
                var Data = _languageService.GetAllLanguagesTable();

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
        public ActionResult LanguageAdd()
        {
            return View("_LanguageAdd");
        }


        [HttpGet("[action]")]
        public ActionResult LanguageEdit(long Id)


        {
            var Model = _languageService.GetLanguageById(Id);
            if (Model == null) RedirectToAction("Languages", "Configurations");
            return View("_LanguageEdit", Model);
        }
        
        [HttpPost("[action]")]
        public ActionResult GetResource(long Id)
        {
            var model = _languageService.GetResourceById(Id);
            if(model==null) return Json(new { success = false });
           
            return Json(new { success = true, model.ResourceName, model.ResourceValue });
        }



        [HttpPost("[action]")]
        public ActionResult SaveResource(ResourcesVm vm)
        {
           
            bool success = _languageService.UpdateResource(vm);


            return Json(new { success = success });

            
        }


        [HttpPost("[action]")]
        public ActionResult AddNewResource(ResourcesVm vm, long LanguageId)
        {
            vm.LanguageId = LanguageId;

            bool success = _languageService.AddNewResource(vm);

            return Json(new { success = success });


        }


        [HttpPost("[action]")]
        public ActionResult DeleteResource(long Id)
        {
            bool success = _languageService.DeleteResource(Id);

            return Json(new { success = success });


        }


        [HttpPost("[action]")]
        public ActionResult LanguagesResources(long LanguageId)
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault(); // Skip number of Rows count
                
                var length = Request.Form["length"].FirstOrDefault();  // Paging Length 10,20  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault(); // Sort Column Name  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();// Sort Column Direction (asc, desc)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();// Search Value from (Search box) 
                int pageSize = length != null ? Convert.ToInt32(length) : 0; //Paging Size (10, 20, 50,100)  
                int skip = start != null ? Convert.ToInt32(start) : 0;



                var passedParamResourceName = Request.Form["ResourceName"].FirstOrDefault();//passed parameter
                var passedParamResourceValue = Request.Form["ResourceValue"].FirstOrDefault();//passed parameter


                // getting all Discount data  
                var Data = _languageService.GetResoucesByLanguageId(LanguageId);
                if (!string.IsNullOrWhiteSpace(passedParamResourceValue))
                    Data = Data.Where(c => c.ResourceValue.Contains(passedParamResourceValue)).ToList();
                    
               if(!string.IsNullOrWhiteSpace(passedParamResourceName))
                 Data = Data.Where(c => c.ResourceName.Contains(passedParamResourceName)).ToList();


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

        #region AccessControl
        [HttpGet("[action]")]
        public ActionResult AccessControlList()
        { ViewData["CustomerRoles"]= _userRolesService.GetUserRolesItems();
          var mvcControllers = _mvcControllerDiscovery.GetControllers();
            ViewData["Controllers"] = mvcControllers;
            var roles = _roleManager.Roles;
            List<AclMvcControllerInfo2> controllerList = new List<AclMvcControllerInfo2>();
            foreach (var role in roles)
            {if(role.Access != null) { 
                var accessList =
                    JsonConvert.DeserializeObject<IEnumerable<MvcControllerInfo>>(role.Access);
                //if (accessList.SelectMany(c => c.Actions).Any(a => a.Id == actionId))
                //    return;
                controllerList.Add(new AclMvcControllerInfo2 { UserRole = role.NormalizedName.ToString(), mvcControllers = accessList });

                }
            }
            var list = controllerList;
            List<MvcActionInfoUserRole> actionList = new List<MvcActionInfoUserRole>();

            foreach (var controllerRoles in controllerList)
            {
                //controllerRoles.UserRole;
                var tempMVCControllersStorage = controllerRoles.mvcControllers;
                controllerRoles.mvcControllers = mvcControllers;
                foreach (var mvcC in controllerRoles.mvcControllers)
                {
                    foreach (var mvcControllerForUserRole in tempMVCControllersStorage)
                    {
                        if(mvcC.Name == mvcControllerForUserRole.Name && mvcC.AreaName == mvcControllerForUserRole.AreaName)
                        {//another forloop to check individual action
                            foreach (var mvcActions1 in mvcControllerForUserRole.Actions)
                            {
                                foreach (var mvcCActions in  mvcC.Actions )
                                {

                                    if(mvcActions1.Name == mvcCActions.Name)
                                    {
                                        mvcCActions.isSelected = true;
                                        actionList.Add(new MvcActionInfoUserRole { UserRole = controllerRoles.UserRole.ToString(), ControllerName = mvcC.Name, Name = mvcCActions.Name, isSelected = mvcCActions.isSelected , AreaName = mvcC.AreaName});
                                    }
                                    //push to userRoleAction
                                    

                            }
                           
                            }
                        }
                        // store
                     
                    }


                }
               

            }



            ViewData["ActionsList"] = actionList;
            return View("AccessControlList");
        }

         [HttpPost("[action]")]

       
        public async Task<ActionResult> AccessControlList( List<AclPostData> data)
        {
           
        var  roles =  data.Select(s => s.UserRole).Distinct().ToList();

            List<AclReady> aclReadyList = new List<AclReady>();
            AclReady aclReady = new AclReady();
            
            List<mini> miniList = new List<mini>();



            foreach (var role in roles)
            {
                foreach (var item in data)
                {
                   
                    if (item.UserRole == role)
                    {
                        miniList.Add( new mini { Area = item.Area , Controller = item.Controller , Action = item.Action });
                    }
                    
                }
                
                aclReadyList.Add(new AclReady { UserRole = role, data = miniList });
                miniList = new List<mini>();
            }

            List<AclMvcControllerInfo> mvcControllers = new List<AclMvcControllerInfo>();
            List<MvcControllerInfo> miniController = new List<MvcControllerInfo>();
            List<MvcActionInfo> mvcActionInfos = new List<MvcActionInfo>();
            var controllers = data.Select(s => s.Controller).Distinct().ToList();

            foreach (var role in aclReadyList)
            {  //mvcController array initiate
                
                    //for each controller type traverse data[Area: public, controller: users, Action: GetList]

                  
                    foreach (var controller in controllers)
                    {



                    var controllerName = ""; var areaName = "";
                            foreach (var i in role.data)
                            {
                     

                        
                                if (controller == i.Controller )
                                { 
                                    mvcActionInfos.Add(new MvcActionInfo { Name = i.Action ,ControllerId = i.Area+":"+i.Controller });

                            controllerName = i.Controller;
                            areaName = i.Area;
                                }

                        
                    }
                            
                            miniController.Add(new MvcControllerInfo { Name = controllerName, AreaName = areaName, Actions=mvcActionInfos});
                    mvcActionInfos = new List<MvcActionInfo>();
                    //add action array to miniController


                }
                    

                
                mvcControllers.Add(new AclMvcControllerInfo { UserRole = role.UserRole, mvcControllers = miniController });
                miniController = new List<MvcControllerInfo>();
                //add all corresponding array to mvcController list
            }

            var list = aclReadyList;

           


            foreach (var role in mvcControllers)
            {
                var accessJson = JsonConvert.SerializeObject(role.mvcControllers);
               var userRole = await _roleManager.FindByNameAsync(role.UserRole);
                userRole.Access = accessJson;
               await _roleManager.UpdateAsync(userRole);
            }
            
            var result = data;
            ViewData["Controllers"] = _mvcControllerDiscovery.GetControllers();


         //   var role = new ApplicationRole { Name = viewModel.Name };

            //get role i.e Administrator and set access field of the role

          //  if (viewModel.SelectedControllers != null && viewModel.SelectedControllers.Any())
            //if (data != null && data.Any())
            //{
            //    foreach (var item in data)
            //        foreach (var Role in item.UserRole)
            //        {
            //            //if userrole ==  administrator jsonfy access and save to database//do that for every role
            //        }
            //            action.ControllerId = controller.Id;

            //    var accessJson = JsonConvert.SerializeObject(viewModel.SelectedControllers);
            //    role.Access = accessJson;
            //}

       

            //foreach (var error in result.Errors)
            //    ModelState.AddModelError("", error.Description);

            ViewData["Controllers"] = _mvcControllerDiscovery.GetControllers();

            //  return View(viewModel);

            return Content("{success:true}");
        }

        #endregion


        #region Currencies
        [HttpGet("[action]")]
        public ActionResult Currencies()
        {
            return View("Currencies");
        }

        
        [HttpPost("[action]")]
        public ActionResult Currencies(int dummy)
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
                var Data = _currencyService.GetCurrenciesTablesList();

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
        public ActionResult CurrencyAdd()
        {
            return View("_CurrencyAdd");
        }
           [HttpPost("[action]")]
        public ActionResult CurrencyAdd(CurrencyCrud vm)
        {
            if (!ModelState.IsValid)
                return View("_CurrencyAdd", vm);

            var newCurrencyId=   _currencyService.AddCurrency(vm);
            return RedirectToAction("CurrencyEdit", "Configurations", new { Id = newCurrencyId });

          
        }


        [HttpGet("[action]")]
        public ActionResult CurrencyEdit(long Id)
        {
            var model = _currencyService.GetCurrencyById(Id);
            if (model == null) return RedirectToAction("Currencies", "Configurations");

            return View("_CurrencyEdit", model);
        }

        [HttpPost("[action]")]
        public ActionResult CurrencyEdit(CurrencyCrud vm)
        {
            if (!ModelState.IsValid)
                return View("_CurrencyEdit", vm);
            
            var success = _currencyService.UpdateCurrency(vm);

                var model = _currencyService.GetCurrencyById(vm.Id);
            return View("_CurrencyEdit", model);

        }

        #endregion


        #region SlideShowImages
        [HttpGet("[action]")]
        public ActionResult SlideShowImages()
        {
            return View("_SlideShowImages");
        }


         [HttpPost("[action]")]
        public ActionResult SliderImage(DormitoryCrud vm)
        {
            var model = vm;
            //get slider image
            //send parameters to imageService and allow image Service to do it's work
           bool success = _imageService.UploadSliderImage(vm);
             vm.SavedSuccessful = success; 
            return View("_SlideShowImages",vm);
        }


        [HttpPost("[action]")]
        public ActionResult SlideShowImages(int dummy)
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




                var List = _sliderImageService.GetHomeSlideShowImagesTable();

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



        [HttpPost("[action]")]
        public ActionResult ExploreEmuImagesTable(int dummy)
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault(); // Skip number of Rows count
               
                var length = Request.Form["length"].FirstOrDefault();  // Paging Length 10,20  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault(); // Sort Column Name  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();// Sort Column Direction (asc, desc)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();// Search Value from (Search box) 
                int pageSize = length != null ? Convert.ToInt32(length) : 0; //Paging Size (10, 20, 50,100)  
                int skip = start != null ? Convert.ToInt32(start) : 0;


                long dormitoryType =long.Parse(Request.Form["dormitoryType"].FirstOrDefault());//passed parameter
                var dormitoryName = Request.Form["dormitoryName"].FirstOrDefault();//passed parameter

                var List = _sliderImageService.GetExploreEmuImagesTable();

                // getting all Discount data  
                var Data = List;


               
                if (!string.IsNullOrWhiteSpace(dormitoryName))
                    Data = Data.Where(c => c.Dormitory.Contains(dormitoryName)).ToList();

                if (dormitoryType>0)
                    Data = Data.Where(c => c.DormitoryTypeId == dormitoryType).ToList();


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
        public ActionResult AllowImageExploreEmu(long ImageId)
        {
            var success = _sliderImageService.AllowImageExploreEmu(ImageId);

            return Json(success);
        }

        [HttpPost("[action]")]
        public ActionResult DisallowImageExploreEmu(long ImageId)
        {
            var success = _sliderImageService.DisallowImageExploreEmu(ImageId);

            return Json(success);
        }

        [HttpPost("[action]")]
        public ActionResult GetImageInformation(long ImageId)
        {
            SliderImage model = _sliderImageService.GetImageInformationById(ImageId);

            return Json(model);
        }

        [HttpPost("[action]")]
        public ActionResult SetImageInformation(SliderImage vm)
        {
            bool success= _sliderImageService.SetImageInformation(vm);

            return Json(success);
        }
        
        [HttpPost("[action]")]
        public ActionResult DeleteHomeSliderImage(long imageId)
        {
            bool success = _sliderImageService.DeleteHomeSliderImage(imageId);

            return Json(success);
        }



        #endregion


    }
    

    public class CountriesListTable {
        public string Name { get; set; }
        public string AllowBilling { get; set; }
        public string AllowBooking { get; set; }
        public string TwoLettersIsoCode { get; set; }
        public string ThreeLettersIsoCode { get; set; }
        public string NumberOfStates { get; set; }
        public string DisplayOrder { get; set; }
        public string Published { get; set; }
        public string Edit { get; set; }
    }






    //public class AccessControlListTable {
    //    public string PermissionName { get; set; }
    //    public string Registered { get; set; }
    //    public string Guest { get; set; }
    //    public string DormAdmin { get; set; }
    //    public string Administrator { get; set; }
    //}
    

}