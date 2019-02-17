using Dau.Core.Domain.Bookings;
using Dau.Core.Domain.Catalog;
using Dau.Core.Domain.Users;
using Dau.Data.Repository;
using Dau.Services.Domain.BookingService;
using Dau.Services.Domain.DormitoryServices;
using Dau.Services.Domain.DropdownServices;
using Dau.Services.Domain.ImageServices;
using Dau.Services.Languages;
using Dau.Services.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dau.Services.Export
{
 public   class ExportService : IExportService
    {
        private readonly IDropdownService _dropdownService;
        private readonly IHostingEnvironment _environment;
        private readonly IRepository<Dormitory> _dormitoryRepo;
        private readonly IRepository<DormitoryTranslation> _dormitoryTransRepo;
        private readonly ILanguageService _languageService;
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<Room> _roomRepository;
        private readonly IRepository<RoomTranslation> _roomTransRepository;
        private readonly IRepository<Dormitory> _dormitoryRepository;
        private readonly IRepository<DormitoryTranslation> _dormitoryTranslationRepository;
        private readonly IRepository<SemesterPeriod> _SemesterPeriodRepo;
        private readonly IRepository<SemesterPeriodTranslation> _semesterPeriodTransRepo;
        private readonly IRepository<Booking> _bookingRepository;
        private readonly IRepository<CancelBookingRequests> _cancelBookingRequests;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<BookingStatus> _bookingStatusRepo;
        private readonly IRepository<BookingStatusTranslation> _bookingStatusTransRepo;
        private readonly IRepository<PaymentStatus> _paymentStatusRepo;
        private readonly IRepository<PaymentStatusTranslation> _paymentStatusTransRepo;
        private readonly IDormitoryService _dormitoryService;
        private readonly IUserRolesService _userRolesService;
        private readonly IImageService _imageService;
        private readonly IRepository<DormitoryBlock> _dormitoryBlockRepo;
        private readonly IRepository<DormitoryBlockTranslation> _dormitoryBlockTransRepo;

        public ExportService(IHostingEnvironment IHostingEnvironment,
             IRepository<Dormitory> dormitoryRepository,
            IRepository<DormitoryTranslation> dormitoryTransRepository,
            IRepository<Booking> bookingRepository,
            ILanguageService languageService,
            IRepository<Cart> CartRepository,
            IRepository<Room> RoomRepository,
            IRepository<RoomTranslation> RoomTransRepository,
            IRepository<Dormitory> DormitoryRepository,
            IRepository<DormitoryTranslation> DormitoryTranslationRepository,
            IRepository<DormitoryBlock> DormitoryBlockRepository,
            IRepository<DormitoryBlockTranslation> DormitoryBlockTranslationRepository,
            IRepository<SemesterPeriod> SemesterPeriodRepository,
            IRepository<SemesterPeriodTranslation> semesterPeriodTransRepository,
          
            IRepository<BookingStatus> bookingStatusRepository,
            IRepository<BookingStatusTranslation> bookingStatusTransRepository,
            IRepository<PaymentStatus> paymentStatusRepository,
            IRepository<PaymentStatusTranslation> paymentStatusTransRepository,
            IRepository<CancelBookingRequests> cancelBookingRequests,
           
             UserManager<User> userManager,
          IHttpContextAccessor httpContextAccessor,
          IImageService imageService,
           IUserRolesService userRolesService,
           IDormitoryService dormitoryService,
           IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
            _environment = IHostingEnvironment;
            _dormitoryRepo = dormitoryRepository;
            _dormitoryTransRepo = dormitoryTransRepository;
            _languageService = languageService;


            _dormitoryService = dormitoryService;
            _userRolesService = userRolesService;
            _imageService = imageService;
            _languageService = languageService;
            _dormitoryBlockRepo = DormitoryBlockRepository;
            _dormitoryBlockTransRepo = DormitoryBlockTranslationRepository;
            _cartRepository = CartRepository;
            _roomRepository = RoomRepository;
            _roomTransRepository = RoomTransRepository;
            _dormitoryRepository = DormitoryRepository;
            _dormitoryTranslationRepository = DormitoryTranslationRepository;
            _SemesterPeriodRepo = SemesterPeriodRepository;
            _semesterPeriodTransRepo = semesterPeriodTransRepository;
            _bookingRepository = bookingRepository;
            _cancelBookingRequests = cancelBookingRequests;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;


            _bookingStatusRepo = bookingStatusRepository;
            _bookingStatusTransRepo = bookingStatusTransRepository;
            _paymentStatusRepo = paymentStatusRepository;
            _paymentStatusTransRepo = paymentStatusTransRepository;
        }


        public string ExportDormitoryToExcel(int id)
        {


            


            //base information without other tables
            //dormitory  raw info
            
        var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var dormitory = from dorm in _dormitoryRepo.List().ToList()
                             select dorm;



            var dormTransEN = from dormTrans in _dormitoryTransRepo.List().ToList()
                              where dormTrans.LanguageId == 1
                              select dormTrans;

            var dormTransTR = from dormTrans in _dormitoryTransRepo.List().ToList()
                              where dormTrans.LanguageId == 2 
                              select dormTrans;

            //pupulate columns header

            //started from one because we saved something in the 


            string storageFolder = "Files/ExcelFiles/";
            IWorkbook workbook = new XSSFWorkbook();

            ISheet sheet1 = workbook.CreateSheet("Sheet1");

            sheet1.CreateRow(0).CreateCell(0).SetCellValue("Exported excel file of exported dormitories - Date and time of export: " + DateTime.Now.ToString());


            List<string> columns = new List<string> {
      "Id",
      "Dormitory Name English",
      "Dormitory Name Turkish",
      "Short Description English",
      "Short Description Turkish",
      "Dormitory Description English",
      "Dormitory Description Turkish",
      "Rating Text",
      "Rating Text",
      "No Of Students",
      "Rating No",
      "Review No",
      "SKU",
      "No Of New Facilities",
      "No Of Staff",
      "No Of Awards",
      "Map Section Id",
      "Dormitory StreetAddress",
      "Dormitory LogoUrl",
      "Published",
      "Weekends OpeningTime",
      "Weekends ClosingTime",
      "Weekdays OpeningTime",
      "Weekdays ClosingTime",
      "SeoId",
      "Booking Limit",
      "LocationOn Campus",
      "AdminComment",
      "Cancel Wait Days",
      "Mark As New",
      "Allow Reviews WithBookingOnly",
      "Opened On Sundays",
      "Created On",
      "Updated On"
        };

            IRow Headerrow = sheet1.CreateRow(1);

            for (int j = 0; j < columns.Count; j++)
            {
                Headerrow.CreateCell(j).SetCellValue(columns[j]);
            }



            //populate content
            int i = 2;
            foreach (var dorm in dormitory)
            {
                IRow row = sheet1.CreateRow(i);
                //rows according to column
                //id then translated dorm data

                //then dormitory data
                row.CreateCell(0).SetCellValue(dorm.Id);

                row.CreateCell(1).SetCellValue(dormTransEN.Where(c=>c.DormitoryNonTransId==dorm.Id).FirstOrDefault().DormitoryName);
                row.CreateCell(2).SetCellValue(dormTransTR.Where(c=>c.DormitoryNonTransId==dorm.Id).FirstOrDefault().DormitoryName);

                row.CreateCell(3).SetCellValue(dormTransEN.Where(c=>c.DormitoryNonTransId==dorm.Id).FirstOrDefault().ShortDescription);
                row.CreateCell(4).SetCellValue(dormTransTR.Where(c=>c.DormitoryNonTransId==dorm.Id).FirstOrDefault().ShortDescription);

                row.CreateCell(5).SetCellValue(dormTransEN.Where(c=>c.DormitoryNonTransId==dorm.Id).FirstOrDefault().DormitoryDescription);
                row.CreateCell(6).SetCellValue(dormTransEN.Where(c=>c.DormitoryNonTransId==dorm.Id).FirstOrDefault().DormitoryDescription);


                row.CreateCell(7).SetCellValue(dormTransEN.Where(c=>c.DormitoryNonTransId==dorm.Id).FirstOrDefault().RatingText);
                row.CreateCell(8).SetCellValue(dormTransEN.Where(c=>c.DormitoryNonTransId==dorm.Id).FirstOrDefault().RatingText);

                row.CreateCell(9).SetCellValue(dorm.NoOfStudents);
                row.CreateCell(10).SetCellValue(dorm.RatingNo);
                row.CreateCell(11).SetCellValue(dorm.ReviewNo);
                row.CreateCell(12).SetCellValue(dorm.SKU);
                row.CreateCell(13).SetCellValue(dorm.NoOfNewFacilities);
                row.CreateCell(14).SetCellValue(dorm.NoOfStaff);
                row.CreateCell(15).SetCellValue(dorm.NoOfAwards);
                row.CreateCell(16).SetCellValue(dorm.MapSectionId);
                row.CreateCell(17).SetCellValue(dorm.DormitoryStreetAddress);
                row.CreateCell(18).SetCellValue(dorm.DormitoryLogoUrl);
                row.CreateCell(19).SetCellValue(dorm.Published);
                row.CreateCell(20).SetCellValue(dorm.WeekendsOpeningTime.ToString("HH:mm"));
                row.CreateCell(21).SetCellValue(dorm.WeekendsClosingTime.ToString("HH:mm"));
                row.CreateCell(22).SetCellValue(dorm.WeekdaysOpeningTime.ToString("HH:mm"));
                row.CreateCell(23).SetCellValue(dorm.WeekdaysClosingTime.ToString("HH:mm"));
                row.CreateCell(24).SetCellValue(dorm.SeoId);
                row.CreateCell(25).SetCellValue(dorm. BookingLimit);
                row.CreateCell(26).SetCellValue(dorm.LocationOnCampus);
                row.CreateCell(27).SetCellValue(dorm.AdminComment);
                row.CreateCell(28).SetCellValue(dorm.CancelWaitDays);
                row.CreateCell(29).SetCellValue(dorm.MarkAsNew);
                row.CreateCell(30).SetCellValue(dorm.AllowReviewsWithBookingOnly);
                row.CreateCell(31).SetCellValue(dorm.OpenedOnSundays);
                row.CreateCell(32).SetCellValue(dorm.CreatedOn.ToString());
                row.CreateCell(33).SetCellValue(dorm.UpdatedOn.ToString());

                i++;
            }

            string filename = Path.Combine(_environment.WebRootPath, storageFolder) + "Dormitories List" + (DateTime.Now).ToString(@"yyyy-MM-dd HH-mm-ss") + ".xlsx";
            FileStream sw = File.Create(filename);

            workbook.Write(sw);

            sw.Close();

            return filename;
        }
        public string ExportBookingsToExcel(int id)
        {



            //base information without other tables
            //dormitory  raw info
            
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            var bookingStatusEN = from bookingStatsTrans in _bookingStatusTransRepo.List().ToList()
                                  where bookingStatsTrans.LanguageId == 1
                                  select bookingStatsTrans;


              var bookingStatusTR = from bookingStatsTrans in _bookingStatusTransRepo.List().ToList()
                                    where bookingStatsTrans.LanguageId == 2
                                    select bookingStatsTrans;


            var paymentStatusEN = from payStatsTrans in _paymentStatusTransRepo.List().ToList()
                                  where payStatsTrans.LanguageId == 1
                                  select payStatsTrans;

            var paymentStatusTR = from payStatsTrans in _paymentStatusTransRepo.List().ToList()
                                  where payStatsTrans.LanguageId == 1
                                  select payStatsTrans;

            var RoomNameEN = _roomTransRepository.List().Where(c => c.LanguageId == 1).ToList();
            var RoomNameTR = _roomTransRepository.List().Where(c => c.LanguageId == 2).ToList();

            var DormitoryNameEN = _dormitoryTranslationRepository.List().Where(c => c.LanguageId == 1).ToList();
            var DormitoryNameTR = _dormitoryTranslationRepository.List().Where(c => c.LanguageId == 2).ToList();


            var Bookings = _bookingRepository.List().ToList();
                         
                          


          
                           //translations
                           //roomname
                            //paymentstatus
                       //dormitory name
                     //bookingStatus
                                       //get basic user information


            //started from one because we saved something in the 


            string storageFolder = "Files/ExcelFiles/";
            IWorkbook workbook = new XSSFWorkbook();

            ISheet sheet1 = workbook.CreateSheet("Sheet1");

            sheet1.CreateRow(0).CreateCell(0).SetCellValue("Exported excel file of exported Bookings - Date and time of export: " + DateTime.Now.ToString());


            List<string> columns = new List<string> {

           "Id",
           "BookingStatusId",
           "BookingStatus",
           "BookingStatus",
           "PaymentStatusId",
           "PaymentStatus",
           "PaymentStatus",
           "RoomId",
           "RoomName",
           "RoomName",
           "DormitoryId",
           "DormitoryName",
           "DormitoryName",
           "receiptUrl",
           "UserId",
           "FirstName",
           "LastName",
            "Email",
            "DaysToExpire",
           "CustomerIpAddress",
           "BookingOrderSubtotal",
           "BookingFee",
           "BookingTotal",
           "IsDeleted",
           "StudentAddress1",
           "StudentAddress2",
           "City",
           "StateProvince",
           "ZipCode",
           "Country",
           "CreatedOn"
        };

            IRow Headerrow = sheet1.CreateRow(1);

            for (int j = 0; j < columns.Count; j++)
            {
                Headerrow.CreateCell(j).SetCellValue(columns[j]);
            }



            //populate content
            int i = 2;
            foreach (var booking in Bookings)
            {
                IRow row = sheet1.CreateRow(i);
                //rows according to column
                //id then translated dorm data
                var count = 0;
                row.CreateCell(count++).SetCellValue(booking.Id);
                row.CreateCell(count++).SetCellValue(booking.BookingStatusId);
                row.CreateCell(count++).SetCellValue(bookingStatusEN.Where(c => c.BookingStatusNonTransId == booking.BookingStatusId).FirstOrDefault().BookingStatus);
                row.CreateCell(count++).SetCellValue(bookingStatusTR.Where(c => c.BookingStatusNonTransId == booking.BookingStatusId).FirstOrDefault().BookingStatus);
                row.CreateCell(count++).SetCellValue(booking.PaymentStatusId);
                row.CreateCell(count++).SetCellValue(paymentStatusEN.Where(c => c.PaymentStatusNonTransId == booking.PaymentStatusId).FirstOrDefault().PaymentStatus);
                row.CreateCell(count++).SetCellValue(paymentStatusTR.Where(c => c.PaymentStatusNonTransId == booking.PaymentStatusId).FirstOrDefault().PaymentStatus);
                row.CreateCell(count++).SetCellValue(booking.RoomId);
                row.CreateCell(count++).SetCellValue(RoomNameEN.Where(c => c.RoomNonTransId == booking.RoomId).FirstOrDefault().RoomName);
                row.CreateCell(count++).SetCellValue(RoomNameTR.Where(c => c.RoomNonTransId == booking.RoomId).FirstOrDefault().RoomName);
                row.CreateCell(count++).SetCellValue(_roomRepository.GetById(booking.RoomId).DormitoryId);
                row.CreateCell(count++).SetCellValue(DormitoryNameEN.Where(c => c.DormitoryNonTransId == _roomRepository.GetById(booking.RoomId).DormitoryId).FirstOrDefault().DormitoryName);
                row.CreateCell(count++).SetCellValue(DormitoryNameTR.Where(c => c.DormitoryNonTransId == _roomRepository.GetById(booking.RoomId).DormitoryId).FirstOrDefault().DormitoryName);
                row.CreateCell(count++).SetCellValue(booking.ReceiptUrl);
                row.CreateCell(count++).SetCellValue(booking.UserId);
                row.CreateCell(count++).SetCellValue(_userManager.Users.Where(c => c.Id == booking.UserId).FirstOrDefault().FirstName);
                row.CreateCell(count++).SetCellValue(_userManager.Users.Where(c => c.Id == booking.UserId).FirstOrDefault().LastName);
                row.CreateCell(count++).SetCellValue(_userManager.Users.Where(c => c.Id == booking.UserId).FirstOrDefault().Email);
                row.CreateCell(count++).SetCellValue(booking.DaysToExpire);
                row.CreateCell(count++).SetCellValue(booking.CustomerIpAddress);
                row.CreateCell(count++).SetCellValue(booking.BookingOrderSubtotal);
                row.CreateCell(count++).SetCellValue(booking.BookingFee);
                row.CreateCell(count++).SetCellValue(booking.BookingTotal);
                row.CreateCell(count++).SetCellValue(booking.IsDeleted);
                row.CreateCell(count++).SetCellValue(booking.StudentAddress1);
                row.CreateCell(count++).SetCellValue(booking.StudentAddress2);
                row.CreateCell(count++).SetCellValue(booking.City);
                row.CreateCell(count++).SetCellValue(booking.StateProvince);
                row.CreateCell(count++).SetCellValue(booking.ZipCode);
                row.CreateCell(count++).SetCellValue(booking.Country);
                row.CreateCell(count++).SetCellValue(booking.CreatedOn.ToString());
                i++;
            }

            string filename = Path.Combine(_environment.WebRootPath, storageFolder) + "Bookings List " + (DateTime.Now).ToString(@"yyyy-MM-dd HH-mm-ss") + ".xlsx";
            FileStream sw = File.Create(filename);

            workbook.Write(sw);

            sw.Close();

            return filename;
        }

        public string ExportDormitoryBlocksToExcel(int id)
        {

            //base information without other tables
            //dormitory  raw info

            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            var dormitories = _dormitoryRepo.List().ToList();

                             

            var dormitoryBlockEN = from dormBlockTrans in _dormitoryBlockTransRepo.List().ToList()
                                   where dormBlockTrans.LanguageId == 1
                                   select dormBlockTrans;

            var dormitoryBlockTR = from dormBlockTrans in _dormitoryBlockTransRepo.List().ToList()
                                   where dormBlockTrans.LanguageId == 2
                                   select dormBlockTrans;

            var dormitoryBlocks = _dormitoryBlockRepo.List().ToList();

            var rooms = _roomRepository.List().ToList();


            //add dormitory information



        


        //started from one because we saved something in the 


        string storageFolder = "Files/ExcelFiles/";
            IWorkbook workbook = new XSSFWorkbook();

            ISheet sheet1 = workbook.CreateSheet("Sheet1");

            sheet1.CreateRow(0).CreateCell(0).SetCellValue("Exported excel file of exported DormitoryBlocks - Date and time of export: " + DateTime.Now.ToString());


            List<string> columns = new List<string> {

           "Id",
           "DormitoryBlockName",
           "DormitoryBlockName",
           "DormitoryId",
           "DormitoryName English",//english
           "DormitoryName Turkish",//turkish
           "Published",
           "DisplayOrder"

        };

            IRow Headerrow = sheet1.CreateRow(1);

            for (int j = 0; j < columns.Count; j++)
            {
                Headerrow.CreateCell(j).SetCellValue(columns[j]);
            }



            //populate content
            int i = 2;
            foreach (var dormBlock in dormitoryBlocks)
            {
                IRow row = sheet1.CreateRow(i);
                //rows according to column
                //id then translated dorm data
                var count = 0;
                row.CreateCell(count++).SetCellValue(dormBlock.Id);
                row.CreateCell(count++).SetCellValue(dormitoryBlockEN.Where(c=> c.DormitoryBlockNonTransId == dormBlock.Id).FirstOrDefault().Name);
                row.CreateCell(count++).SetCellValue(dormitoryBlockTR.Where( c=>c.DormitoryBlockNonTransId == dormBlock.Id).FirstOrDefault().Name);
                row.CreateCell(count++).SetCellValue(dormBlock.DormitoryId);
                row.CreateCell(count++).SetCellValue(_dormitoryTranslationRepository.List().Where(c => c.DormitoryNonTransId == dormBlock.DormitoryId && c.LanguageId == 1).FirstOrDefault().DormitoryName);//english
                row.CreateCell(count++).SetCellValue(_dormitoryTranslationRepository.List().Where(c => c.DormitoryNonTransId == dormBlock.DormitoryId && c.LanguageId == 2).FirstOrDefault().DormitoryName);//turkish
                row.CreateCell(count++).SetCellValue(dormBlock.Published);
                row.CreateCell(count++).SetCellValue(dormBlock.DisplayOrder);
         
                
          


                i++;
            }

            string filename = Path.Combine(_environment.WebRootPath, storageFolder) + "Dormitory Blocks List " + (DateTime.Now).ToString(@"yyyy-MM-dd HH-mm-ss") + ".xlsx";
            FileStream sw = File.Create(filename);

            workbook.Write(sw);

            sw.Close();

            return filename;
        }

        public string ExportRoomsToExcel(int id)
        {

            //base information without other tables
            //dormitory  raw info

            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            var dormitoryBlockEN = from dormBlockTrans in _dormitoryBlockTransRepo.List().ToList()
                                   where dormBlockTrans.LanguageId == 1
                                   select dormBlockTrans;

            var dormitoryBlockTR = from dormBlockTrans in _dormitoryBlockTransRepo.List().ToList()
                                   where dormBlockTrans.LanguageId == 2
                                   select dormBlockTrans;

            var dormitoryBlock = _dormitoryBlockRepo.List().ToList();

            var rooms = _roomRepository.List().ToList();

            var roomTransEn = from roomTran in _roomTransRepository.List().ToList()
                              where roomTran.LanguageId == 1
                              select roomTran;

            var roomTransTR = from roomTran in _roomTransRepository.List().ToList()
                              where roomTran.LanguageId == 2
                              select roomTran;

            
            //add dormitory information

                        
  



            //started from one because we saved something in the 


            string storageFolder = "Files/ExcelFiles/";
            IWorkbook workbook = new XSSFWorkbook();

            ISheet sheet1 = workbook.CreateSheet("Sheet1");

            sheet1.CreateRow(0).CreateCell(0).SetCellValue("Exported excel file of exported Rooms - Date and time of export: " + DateTime.Now.ToString());


            List<string> columns = new List<string> {

          "room.Id",
          "RoomName English",
          "RoomName Turkish",
          "GenderAllocation English",
          "GenderAllocation Turkish",
          "BedType English",
          "BedType Turkish",
          "BedType Turkish",
          "NoOfStudents ",
          "HasDeposit",
          "ShowPrice",
          "DormitoryId",
          "DormitoryName English",//DormitoryNameEN
          "DormitoryName Turkish",//DormitoryNameTR
          "DormitoryBlockId",
          "DormitoryBlockName English",//dormitoryblocknameEn
          "DormitoryBlockName Turkish",//dormitoryblocknameTR
          "Price Cash",
          "PriceOld Cash",
          "Price Installment",
          "PriceOld Installment",
          "NoRoomQuota",
          "RoomSize",
          "Minimum BookingFee",
          "PaymentPerSemesterNotYear",
          "SKU",
          "DealEndTime",
          "DisplayDeal",
          "PercentageOff",
          "DisplayNoRoomsLeft",
          "MarkAsNew",
          "AdminComment",
          "CreatedOn",
          "UpdatedOn"

        };

            IRow Headerrow = sheet1.CreateRow(1);

            for (int j = 0; j < columns.Count; j++)
            {
                Headerrow.CreateCell(j).SetCellValue(columns[j]);
            }



            //populate content
            int i = 2;
            foreach (var room in rooms)
            {
                IRow row = sheet1.CreateRow(i);
                //rows according to column
                //id then translated dorm data
                var count = 0;
                row.CreateCell(count++).SetCellValue(room.Id);
                row.CreateCell(count++).SetCellValue(roomTransEn.Where(c => c.RoomNonTransId == room.Id).FirstOrDefault().RoomName);
                row.CreateCell(count++).SetCellValue(roomTransTR.Where(c => c.RoomNonTransId == room.Id).FirstOrDefault().RoomName);
                row.CreateCell(count++).SetCellValue(roomTransEn.Where(c => c.RoomNonTransId == room.Id).FirstOrDefault().GenderAllocation);
                row.CreateCell(count++).SetCellValue(roomTransTR.Where(c => c.RoomNonTransId == room.Id).FirstOrDefault().GenderAllocation);
                row.CreateCell(count++).SetCellValue(roomTransEn.Where(c => c.RoomNonTransId == room.Id).FirstOrDefault().BedType);
                row.CreateCell(count++).SetCellValue(roomTransTR.Where(c => c.RoomNonTransId == room.Id).FirstOrDefault().BedType);
                row.CreateCell(count++).SetCellValue(roomTransTR.Where(c => c.RoomNonTransId == room.Id).FirstOrDefault().BedType);
                row.CreateCell(count++).SetCellValue(room.NoOfStudents);
                row.CreateCell(count++).SetCellValue(room.HasDeposit);
                row.CreateCell(count++).SetCellValue(room.ShowPrice);
                row.CreateCell(count++).SetCellValue(room.DormitoryId);
                row.CreateCell(count++).SetCellValue(_dormitoryTranslationRepository.List().Where(c=> c.DormitoryNonTransId==room.DormitoryId && c.LanguageId==1).FirstOrDefault().DormitoryName);//DormitoryNameEN
                row.CreateCell(count++).SetCellValue(_dormitoryTranslationRepository.List().Where(c=> c.DormitoryNonTransId==room.DormitoryId && c.LanguageId==2).FirstOrDefault().DormitoryName);//DormitoryNameTR
                row.CreateCell(count++).SetCellValue(room.DormitoryBlockId);
                row.CreateCell(count++).SetCellValue(_dormitoryBlockTransRepo.List().Where(c=> c.DormitoryBlockNonTransId== room.DormitoryBlockId &&  c.LanguageId==1).FirstOrDefault().Name);//dormitoryblocknameEn
                row.CreateCell(count++).SetCellValue(_dormitoryBlockTransRepo.List().Where(c=> c.DormitoryBlockNonTransId== room.DormitoryBlockId &&  c.LanguageId==2).FirstOrDefault().Name);//dormitoryblocknameTR
                row.CreateCell(count++).SetCellValue(room.PriceCash);
                row.CreateCell(count++).SetCellValue(room.PriceOldCash);
                row.CreateCell(count++).SetCellValue(room.PriceInstallment);
                row.CreateCell(count++).SetCellValue(room.PriceOldInstallment);
                row.CreateCell(count++).SetCellValue(room.NoRoomQuota);
                row.CreateCell(count++).SetCellValue(room.RoomSize);
                row.CreateCell(count++).SetCellValue(room.MinBookingFee);
                row.CreateCell(count++).SetCellValue(room.PaymentPerSemesterNotYear);
                row.CreateCell(count++).SetCellValue(room.SKU);
                row.CreateCell(count++).SetCellValue(room.DealEndTime.ToString());
                row.CreateCell(count++).SetCellValue(room.DisplayDeal);
                row.CreateCell(count++).SetCellValue(room.PercentageOff);
                row.CreateCell(count++).SetCellValue(room.DisplayNoRoomsLeft);
                row.CreateCell(count++).SetCellValue(room.MarkAsNew);
                row.CreateCell(count++).SetCellValue(room.AdminComment);
                row.CreateCell(count++).SetCellValue(room.CreatedOn.ToString());
                row.CreateCell(count++).SetCellValue(room.UpdatedOn.ToString());




                i++;
            }

            string filename = Path.Combine(_environment.WebRootPath, storageFolder) + "Rooms List " + (DateTime.Now).ToString(@"yyyy-MM-dd HH-mm-ss") + ".xlsx";
            FileStream sw = File.Create(filename);

            workbook.Write(sw);

            sw.Close();

            return filename;
        }

        public string ExportUsersToExcel(int id)
        {

            //base information without other tables
            //dormitory  raw info

            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            var Users = _userManager.Users.ToList();


            //add dormitory information






            //started from one because we saved something in the 


            string storageFolder = "Files/ExcelFiles/";
            IWorkbook workbook = new XSSFWorkbook();

            ISheet sheet1 = workbook.CreateSheet("Sheet1");

            sheet1.CreateRow(0).CreateCell(0).SetCellValue("Exported excel file of exported Users - Date and time of export: " + DateTime.Now.ToString());


            List<string> columns = new List<string> {

           "Id",
           "FirstName",
           "LastName",
           "UserName",
           "Email",
           "NormalizedUserName",
           "EmailConfirmed",
           "NormalizedEmail",
           "PhoneNumberConfirmed",
           "PhoneNumber",
           "ConcurrencyStamp",
           "SecurityStamp",
           "PasswordHash",
           "DateOfBirth",
           "Gender",
           "City",
           "Country",
           "StudentNumber",
           "ParmanentAddress",
           "AffiliateId",
           "UserImageUrl",
           "AdminComment",
           "NewsletterSubscription",
           "Active",
           "Deleted",
           "LastIpAddress",
           "CreatedOnUtc",
           "LastLoginDateUtc.ToString()",
           "LockoutEnd.ToString()",
           "LastActivityDateUtc.ToString()",
           "TwoFactorEnabled",
           "LockoutEnabled",
           "AccessFailedCount"

        };

            IRow Headerrow = sheet1.CreateRow(1);

            for (int j = 0; j < columns.Count; j++)
            {
                Headerrow.CreateCell(j).SetCellValue(columns[j]);
            }



            //populate content
            int i = 2;
            foreach (var user in Users)
            {
                IRow row = sheet1.CreateRow(i);
                //rows according to column
                //id then translated dorm data
                var count = 0;
                row.CreateCell(count++).SetCellValue(user.Id);
                row.CreateCell(count++).SetCellValue(user.FirstName);
                row.CreateCell(count++).SetCellValue(user.LastName);
                row.CreateCell(count++).SetCellValue(user.UserName);
                row.CreateCell(count++).SetCellValue(user.Email);
                row.CreateCell(count++).SetCellValue(user.NormalizedUserName);
                row.CreateCell(count++).SetCellValue(user.EmailConfirmed);
                row.CreateCell(count++).SetCellValue(user.NormalizedEmail);
                row.CreateCell(count++).SetCellValue(user.PhoneNumberConfirmed);
                row.CreateCell(count++).SetCellValue(user.PhoneNumber);
                row.CreateCell(count++).SetCellValue(user.ConcurrencyStamp);
                row.CreateCell(count++).SetCellValue(user.SecurityStamp);
                row.CreateCell(count++).SetCellValue(user.PasswordHash);
                row.CreateCell(count++).SetCellValue(user.DateOfBirth.ToString());
                row.CreateCell(count++).SetCellValue(_dropdownService.ResolveDropdown( user.GenderId, _dropdownService.Gender()));
                row.CreateCell(count++).SetCellValue(user.City);
                row.CreateCell(count++).SetCellValue(_dropdownService.ResolveDropdown( user.CountryId, _dropdownService.Country()));
                row.CreateCell(count++).SetCellValue(user.StudentNumber);
                row.CreateCell(count++).SetCellValue(user.ParmanentAddress);
                row.CreateCell(count++).SetCellValue(user.AffiliateId);
                row.CreateCell(count++).SetCellValue(user.UserImageUrl);
                row.CreateCell(count++).SetCellValue(user.AdminComment);
                row.CreateCell(count++).SetCellValue(user.NewsletterSubscription);
                row.CreateCell(count++).SetCellValue(user.Active);
                row.CreateCell(count++).SetCellValue(user.Deleted);
                row.CreateCell(count++).SetCellValue(user.LastIpAddress);
                row.CreateCell(count++).SetCellValue(user.CreatedOnUtc.ToString());
                row.CreateCell(count++).SetCellValue(user.LastLoginDateUtc.ToString());
                row.CreateCell(count++).SetCellValue(user.LockoutEnd.ToString());
                row.CreateCell(count++).SetCellValue(user.LastActivityDateUtc.ToString());
                row.CreateCell(count++).SetCellValue(user.TwoFactorEnabled);
                row.CreateCell(count++).SetCellValue(user.LockoutEnabled);
                row.CreateCell(count++).SetCellValue(user.AccessFailedCount);


                i++;
            }

            string filename = Path.Combine(_environment.WebRootPath, storageFolder) + "Users List " + (DateTime.Now).ToString(@"yyyy-MM-dd HH-mm-ss") + ".xlsx";
            FileStream sw = File.Create(filename);

            workbook.Write(sw);

            sw.Close();

            return filename;
        }

        public string ExportToExcel()
        {//export each excel differently
            //bring column array and 
            string storageFolder = "Files/ExcelFiles/";
            IWorkbook workbook = new XSSFWorkbook();

            ISheet sheet1 = workbook.CreateSheet("Sheet1");

            sheet1.CreateRow(0).CreateCell(0).SetCellValue("Exported excel file of exported dormitories - Date and time of export: "+DateTime.Now.ToString());

            int x = 1;
        
            int numberOfColumns = 10;
            List<string> columns = new List<string> {
                "No",
                "Dormitory name",
                "Dormitory Type",
                "Dormitory address",
                "No of students",
                "Rating no",
                "Is published",
                "Administrator comment",
                "Date created",
                "Date updated" };



            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var dormitory = (from dorm in _dormitoryRepo.List().ToList()
                            join dormTrans in _dormitoryTransRepo.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                            where dormTrans.LanguageId == CurrentLanguageId
                            select new
                            {
                              
                                dormitoryName = dormTrans.DormitoryName,
                                dormitoryDescription = dormTrans.ShortDescription,
                                ratingNumber = dorm.RatingNo,
                                ratingText = dormTrans.RatingText,
                                dormitoryId = dorm.Id,
                                dormitoryTypeId = dorm.DormitoryTypeId,
                                dorm.DormitoryStreetAddress,
                                dorm.AdminComment,

                                CreatedOn=dorm.CreatedOn.ToString(),
                               UpdatedOn= dorm.UpdatedOn.ToString(),
                                dorm.SKU,
                                dorm.NoOfStudents,
                                dorm.Published
                            }).ToList();
            //pupulate columns header

            //started from one because we saved something in the 
            IRow Headerrow = sheet1.CreateRow(1); 

                for (int j = 0; j < numberOfColumns; j++)
                {
                    Headerrow.CreateCell(j).SetCellValue(columns[j]);
                }



            //populate content
            int i = 2;
            foreach (var dorm in dormitory)
            {
                IRow row = sheet1.CreateRow(i);


                row.CreateCell(0).SetCellValue(dorm.dormitoryId);
                row.CreateCell(1).SetCellValue(dorm.dormitoryName);
                row.CreateCell(2).SetCellValue(dorm.dormitoryTypeId);
                row.CreateCell(3).SetCellValue(dorm.DormitoryStreetAddress);
                row.CreateCell(4).SetCellValue(dorm.NoOfStudents);
                row.CreateCell(5).SetCellValue(dorm.ratingNumber);
                row.CreateCell(6).SetCellValue(dorm.Published);
                row.CreateCell(7).SetCellValue(dorm.AdminComment);
                row.CreateCell(8).SetCellValue(dorm.CreatedOn);
                row.CreateCell(9).SetCellValue(dorm.UpdatedOn);
                i++;
            }
       
            string filename= Path.Combine(_environment.WebRootPath, storageFolder)+"test " + (DateTime.Now).ToString(@"yyyy-MM-dd HH-mm-ss") + ".xlsx";
            FileStream sw = File.Create(filename);

            workbook.Write(sw);

            sw.Close();

            return filename;
        }




  


        public void ExportToPdf()
        {

        }

      
    }
}
