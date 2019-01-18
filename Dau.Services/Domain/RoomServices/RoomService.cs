using Dau.Core.Domain.Catalog;
using Dau.Data.Repository;
using Dau.Services.Event;
using Dau.Services.Languages;
using Dau.Services.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Dau.Services.Domain.RoomServices
{
    public class RoomService : IRoomService
    {
        private readonly IEventService _eventService;
        private readonly IUserRolesService _userRolesService;
        private readonly IRepository<DormitoryBlock> _dormitoryBlockRepo;
        private readonly ILanguageService _languageService;
        private readonly IRepository<RoomTranslation> _roomTransRepo;
        private readonly IRepository<Room> _roomRepo;
        private readonly IRepository<Dormitory> _dormitoryRepo;
        private readonly IRepository<DormitoryTranslation> _dormitoryTransRepo;
        private readonly IRepository<RoomCatalogImage> _roomImageRepo;
        private readonly IRepository<CatalogImage> _imageRepo;
        private readonly IRepository<DormitoryBlockTranslation> _dormitoryBlockTransRepo;

        public RoomService(
            ILanguageService languageService,
            IRepository<Room> roomRepository,
            IRepository<RoomTranslation> roomTransRepository,
            IRepository<Dormitory> dormitoryRepository,
            IRepository<DormitoryTranslation> dormitoryTransRepository,
            IRepository<RoomCatalogImage> roomImageRepository,
            IRepository<CatalogImage> imageRepository,
            IRepository<DormitoryBlock> dormitoryBlockRepository,
            IRepository<DormitoryBlockTranslation> dormitoryBlockTransRepo,
             IUserRolesService userRolesService,
             IEventService eventservice
            )
        {
            _eventService = eventservice;
            _userRolesService = userRolesService;
            _dormitoryBlockRepo = dormitoryBlockRepository;
            _languageService = languageService;
            _roomTransRepo = roomTransRepository;
            _roomRepo = roomRepository;
            _dormitoryRepo = dormitoryRepository;
            _dormitoryTransRepo = dormitoryTransRepository;
            _roomImageRepo = roomImageRepository;
            _imageRepo = imageRepository;
            _dormitoryBlockTransRepo = dormitoryBlockTransRepo;


        }

        public int GetNumberOfRoomsWithLowQuota()
        {
            var roomswithLowQuota = from room in _roomRepo.List().ToList()
                                    where room.NoRoomQuota < 5
                                    select room;

            return roomswithLowQuota.Where(c => _userRolesService.RoleAccessResolver().Contains(c.DormitoryId)).ToList().Count;

        }

        public List<RoomsListTable> GetRoomsListTable()
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var rooms = from room in _roomRepo.List().ToList()
                        join roomTrans in _roomTransRepo.List().ToList() on room.Id equals roomTrans.RoomNonTransId
                        where roomTrans.LanguageId == CurrentLanguageId
                        select new { room.Id, roomTrans.RoomName, room.NoRoomQuota, room.Price, room.Published, room.SKU, room.DormitoryId };

            var dormitory = from dorm in _dormitoryRepo.List().ToList()
                            join dormTrans in _dormitoryTransRepo.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                            where dormTrans.LanguageId == CurrentLanguageId 
                            select new { dorm.Id, dormTrans.DormitoryName };

            var RoomImages = from roomImage in _roomImageRepo.List().ToList()
                             join Image in _imageRepo.List().ToList() on roomImage.CatalogImageId equals Image.Id
                             select new { roomImage.RoomId, Image.ImageUrl, Image.Published };

            var RoomDormitory = from room in rooms.ToList()
                                join dorm in dormitory.ToList() on room.DormitoryId equals dorm.Id
                                orderby room.Id descending
                                select new RoomsListTable
                                {
                                    dormitoryName = dorm.DormitoryName,
                                    dormitoryId = dorm.Id,
                                    roomId = room.Id,
                                    // Picture = RoomImages.ToList().Where(c=> c.RoomId == room.Id).FirstOrDefault().ImageUrl,
                                    RoomName = room.RoomName,
                                    SKU = room.SKU,
                                    Price = room.Price,
                                    Quota = room.NoRoomQuota,
                                    Published = room.Published
                                };

            var model = RoomDormitory.Where(c=> _userRolesService.RoleAccessResolver().Contains( c.dormitoryId)).ToList();
            return model;
        }


        public List<RoomsListTable> GetRoomsListTableByRoomId(long Id)
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var rooms = from room in _roomRepo.List().ToList()
                        join roomTrans in _roomTransRepo.List().ToList() on room.Id equals roomTrans.RoomNonTransId
                        where roomTrans.LanguageId == CurrentLanguageId && room.Id==Id
                        select new { room.Id, roomTrans.RoomName, room.NoRoomQuota, room.Price, room.Published, room.SKU, room.DormitoryId };

            var dormitory = from dorm in _dormitoryRepo.List().ToList()
                            join dormTrans in _dormitoryTransRepo.List().ToList() on dorm.Id equals dormTrans.DormitoryNonTransId
                            where dormTrans.LanguageId == CurrentLanguageId
                            select new { dorm.Id, dormTrans.DormitoryName };

            var RoomImages = from roomImage in _roomImageRepo.List().ToList()
                             join Image in _imageRepo.List().ToList() on roomImage.CatalogImageId equals Image.Id
                             select new { roomImage.RoomId, Image.ImageUrl, Image.Published };

            var RoomDormitory = from room in rooms.ToList()
                                join dorm in dormitory.ToList() on room.DormitoryId equals dorm.Id
                                orderby room.Id descending
                                select new RoomsListTable
                                {
                                    dormitoryName = dorm.DormitoryName,
                                    dormitoryId = dorm.Id,
                                    roomId = room.Id,
                                    // Picture = RoomImages.ToList().Where(c=> c.RoomId == room.Id).FirstOrDefault().ImageUrl,
                                    RoomName = room.RoomName,
                                    SKU = room.SKU,
                                    Price = room.Price,
                                    Quota = room.NoRoomQuota,
                                    Published = room.Published
                                };

            var model = RoomDormitory.Where(c => _userRolesService.RoleAccessResolver().Contains(c.dormitoryId)).ToList();
            return model;
        }


        public List<DormitoryRoomsTable> GetRoomsByDormitoryIdListTable(long DormitoryId)
        {
            if (!_userRolesService.IsAuthorized(DormitoryId)) return null;
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();

            var dormitoryBlock = from dormBlock in _dormitoryBlockRepo.List().ToList()
                                 join dormBlockTrans in _dormitoryBlockTransRepo.List().ToList() on dormBlock.Id equals dormBlockTrans.DormitoryBlockNonTransId
                                 where dormBlockTrans.LanguageId == CurrentLanguageId
                                 select new { dormBlock.Id, dormBlockTrans.Name };

            var rooms = from room in _roomRepo.List().ToList()
                        join roomTrans in _roomTransRepo.List().ToList() on room.Id equals roomTrans.RoomNonTransId
                        where roomTrans.LanguageId == CurrentLanguageId && room.DormitoryId ==DormitoryId
                        select new { room.Id, roomTrans.RoomName, room.NoRoomQuota, room.Price, room.Published,room.DormitoryBlockId, room.SKU, room.DormitoryId };

            var roomDormitoryBlock = from room in rooms.ToList()
                                     join dormBlock in dormitoryBlock.ToList() on room.DormitoryBlockId equals dormBlock.Id
                                     select new DormitoryRoomsTable
                                     {
                                         RoomId = room.Id,
                                         RoomName = room.RoomName,
                                         DormitoryBlock = dormBlock.Name,
                                         Price = room.Price.ToString("N2"),
                                         Published = room.Published,
                                         Quota = room.NoRoomQuota,
                                         SKU = room.SKU,

                                     };

            var model = roomDormitoryBlock.ToList();
            return model;
        }

        public long AddRoom(RoomViewCrud vm)
        {//vm.NoOfStudents
            //vm.HasDeposit
            string input = vm.DealEndTime;
            DateTime DealEndTime;
            DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture,
                     DateTimeStyles.None, out DealEndTime);


            var id = _roomRepo.Insert(new Room
            {
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,

                DormitoryBlockId = vm.DormitoryBlock,
                DormitoryId = vm.Dormitory,
                Price = vm.Price,
                PriceOld = vm.OldPrice,
                NoRoomQuota = vm.RoomQuota,
                SKU = vm.SKU,
                AdminComment = vm.AdminComment,
                DisplayDeal = vm.DisplayDeal,
                PercentageOff = vm.PercentageOff,
                DealEndTime = DealEndTime, //?
                RoomCost = vm.RoomCost,
                DisplayNoRoomsLeft = vm.DisplayNoRoomsLeft,
                Published = vm.Published,
                DisplayOrder = vm.DisplayOrder,
                MarkAsNew = vm.MarkAsNew,
                NoOfStudents = vm.NoOfStudents,
                HasDeposit = vm.HasDeposit,
                ShowPrice = vm.ShowPrice,

                RoomSize = vm.RoomSize,
                TaxAmount = vm.TaxAmount,
                BookingFee = vm.BookingFee,
                PaymentPerSemesterNotYear = vm.PaymentPerSemesterNotYear,
                RoomTranslation = new List<RoomTranslation>
               {
                        new RoomTranslation
                        {
                            RoomName =(vm.localizedContent[0].RoomName),
                           GenderAllocation =(vm.localizedContent[0].GenderAllocation),
                           BedType =(vm.localizedContent[0].BedType),
                            LanguageId = 1//english
                               
                        },
                        new RoomTranslation
                        {
                           RoomName =(vm.localizedContent[1].RoomName),
                           GenderAllocation =(vm.localizedContent[1].GenderAllocation),
                           BedType =(vm.localizedContent[1].BedType),
                           LanguageId = 2//turkish
                               
                        }
                }


            });

            return id;
        }
          public bool updateRoom(RoomViewCrud vm)
        {//vm.NoOfStudents
         //vm.HasDeposit
            if (!_userRolesService.IsAuthorized(vm.Dormitory)) return false;
            try {
           
            string input = vm.DealEndTime;
            DateTime DealEndTime;
            DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture,
                     DateTimeStyles.None, out DealEndTime);
            var Room= _roomRepo.GetById(vm.Id);
            if (Room == null) return false;

                var eventRoomQuotaHolder = Room.NoRoomQuota;
            Room.UpdatedOn = DateTime.Now;
                Room.DormitoryBlockId = vm.DormitoryBlock;
                Room.DormitoryId = vm.Dormitory;
                Room.Price = vm.Price;
                Room.PriceOld = vm.OldPrice;
                Room.NoRoomQuota = vm.RoomQuota;
                Room.SKU = vm.SKU;
                Room.AdminComment = vm.AdminComment;
                Room.DisplayDeal = vm.DisplayDeal;
                Room.PercentageOff = vm.PercentageOff;
                Room.DealEndTime = DealEndTime; //?
                Room.RoomCost = vm.RoomCost;
                Room.DisplayNoRoomsLeft = vm.DisplayNoRoomsLeft;
                Room.Published = vm.Published;
                Room.DisplayOrder = vm.DisplayOrder;
                Room.MarkAsNew = vm.MarkAsNew;
                Room.NoOfStudents = vm.NoOfStudents;
                Room.HasDeposit = vm.HasDeposit;
                Room.ShowPrice = vm.ShowPrice;
                Room.RoomSize = vm.RoomSize;
                Room.TaxAmount = vm.TaxAmount;
                Room.BookingFee = vm.BookingFee;
                Room.PaymentPerSemesterNotYear = vm.PaymentPerSemesterNotYear;

         
            var englishId = 1;
            var turkishId = 2;

          var englishTrans=  _roomTransRepo.List().Where(l => l.LanguageId == englishId && l.RoomNonTransId == vm.Id).FirstOrDefault();
          var turkishTrans=  _roomTransRepo.List().Where(l => l.LanguageId == turkishId && l.RoomNonTransId == vm.Id).FirstOrDefault();

                           englishTrans.RoomName = vm.localizedContent[0].RoomName;
                           englishTrans.GenderAllocation = vm.localizedContent[0].GenderAllocation;
                           englishTrans.BedType = vm.localizedContent[0].BedType;

            turkishTrans.RoomName = vm.localizedContent[1].RoomName;
            turkishTrans.GenderAllocation = vm.localizedContent[1].GenderAllocation;
            turkishTrans.BedType = vm.localizedContent[1].BedType;

            _roomRepo.Update(Room);
            _roomTransRepo.Update(englishTrans);
            _roomTransRepo.Update(turkishTrans);

                if(eventRoomQuotaHolder<=0 && vm.RoomQuota > 0)
                {
                    //quota has been increased
                    _eventService.Trigger_Student_BackInStock_Event(Room.Id);
                }

            return true;
            }
            catch
            {
                return false;
            }
        }


        public RoomViewCrud GetRoomById(long id)
        {
            var room = _roomRepo.GetById(id);
            if (room == null)
                return null;
            if (!_userRolesService.IsAuthorized(room.DormitoryId)) return null;

            var roomT = from roomTrans in _roomTransRepo.List().ToList()
                        where roomTrans.RoomNonTransId == room.Id
                        select roomTrans;
            var englishRoom = roomT.Where(c => c.LanguageId == 1).FirstOrDefault();
            var turkishRoom = roomT.Where(c => c.LanguageId == 2).FirstOrDefault();

            return new RoomViewCrud
            {
                Id = room.Id,
                SKU = room.SKU,
                Published = room.Published,
                MarkAsNew = room.MarkAsNew,
              
                Price = room.Price,
                OldPrice = room.PriceOld,
                RoomCost = room.RoomCost,
                AdminComment = room.AdminComment,
                CreatedOn =room.CreatedOn.ToString(),
                UpdatedOn = room.UpdatedOn.ToString(),
                RoomQuota = room.NoRoomQuota,
                DisplayOrder = room.DisplayOrder,


                DormitoryBlock = room.DormitoryBlockId,
                Dormitory = room.DormitoryId,


                DisplayDeal = room.DisplayDeal,
                DealEndTime = room.DealEndTime.ToString("MM/dd/yyyy"),
                PercentageOff=room.PercentageOff,
             DisplayNoRoomsLeft=room.DisplayNoRoomsLeft,

                NoOfStudents=room.NoOfStudents,
               HasDeposit=room.HasDeposit,
                ShowPrice=room.ShowPrice,

                RoomSize=room.RoomSize,
                TaxAmount=room.TaxAmount,
                BookingFee=room.BookingFee,
               PaymentPerSemesterNotYear=room.PaymentPerSemesterNotYear,
                localizedContent = new List<LocalizedContent>
                  {
                      
                      new LocalizedContent
                      {
                          RoomName =englishRoom.RoomName,
                         GenderAllocation =englishRoom.GenderAllocation,
                             BedType =englishRoom.BedType,
                             languageId = englishRoom.LanguageId
                      },
                      new LocalizedContent
                      {RoomName =turkishRoom.RoomName,
                         GenderAllocation =turkishRoom.GenderAllocation,
                             BedType =turkishRoom.BedType,
                             languageId = turkishRoom.LanguageId

                      }
                  }
            };
        }

        public bool Delete(RoomViewCrud vm)
        {
            if (!_userRolesService.IsAuthorized(vm.Dormitory)) return false;
            try
            {
                var Room = _roomRepo.GetById(vm.Id);
              //  if (Room == null) return false;
                _roomRepo.Delete(Room);
                return true;
            }
            catch
            {
                return false;

            }
        }

        public List<PicturesTable> GetRoomImagesTables(long id)
        {
            var RoomImages = from roomImage in _roomImageRepo.List().ToList()
                             join Image in _imageRepo.List().ToList() on roomImage.CatalogImageId equals Image.Id
                             where roomImage.RoomId == id
                             orderby Image.CreatedDate descending
                             select new PicturesTable { Id=Image.Id, Picture= Image.ImageUrl, 
                                 DisplayOrder = "4",
                                 Alt = "image",
                                 UploadDate = Image.CreatedDate.ToString(),
                             };
            var model = RoomImages.ToList();
            return model;
        }

        public string GetRoomWithLowestDealByDormitoryId(long DormitoryId, long languageId)
        {  //this is for api
            var CurrentLanguageId = languageId;
            var rooms = from room in _roomRepo.List().ToList()
                        join roomTrans in _roomTransRepo.List().ToList() on room.Id equals roomTrans.RoomNonTransId
                        where roomTrans.LanguageId == CurrentLanguageId &&  room.DormitoryId==DormitoryId
                        orderby room.Price ascending
                        select new { room.Id, roomTrans.RoomName, room.NoRoomQuota, room.Price, room.Published, room.SKU, room.DormitoryId };

            if (rooms.ToList().Count <= 0) return null;
            return rooms.ToList().FirstOrDefault().Price.ToString("N2");

        }
    }

    public class RoomsListTable
    {
        public string dormitoryName { get; set; }
        public long dormitoryId { get; set; }
        public long roomId { get; set; }
        public string Picture { get; set; }
        public string RoomName { get; set; }
        public string SKU { get; set; }
        public double Price { get; set; }
        public int Quota { get; set; }
        public bool Published { get; set; }
        //public string Edit { get; set; }
    }




    public class RoomViewCrud
    {

        public List<LocalizedContent> localizedContent { get; set; }

        public bool SavedSuccessful { get; set; }
        public string DealEndTime { get; set; }
        public bool DisplayDeal { get; set; }
        [Range(5, 100)]
        [Display(Name = "Percentage off")]
        public int PercentageOff { get; set; }

        public bool DisplayNoRoomsLeft { get; set; }//

        public int DisplayOrder { get; set; }//
        public int NoOfStudents { get; set; }//
        public bool HasDeposit { get; set; }//

        public bool ShowPrice { get; set; }
        public double RoomSize { get; set; }
        public double TaxAmount { get; set; }
        public double BookingFee { get; set; }
        public bool PaymentPerSemesterNotYear { get; set; }


        [Display(Name = "SKU",
        Description = "Room stock keeping unit(SKU). Your internal unique identifier that can be used to track this room."), DataType(DataType.Text), MaxLength(256)]
        public string SKU { get; set; }

        [Display(Name = "Published",
        Description = "Check to publish this roomt (visible in customer area). Uncheck to unpublish (room not available in customer area).")]
        public bool Published { get; set; }



   

        [Display(Name = "Mark As New",
        Description = "Check to mark the room as new. Use this option for promoting new rooms.")]
        public bool MarkAsNew { get; set; }

        [Display(Name = "Admin Comment",
        Description = "This comment is for internal use only, not visible for customers."), DataType(DataType.Text), MaxLength(256)]
        public string AdminComment { get; set; }



        [Display(Name = "Price",
        Description = "The price of the room.You can manage currency by selecting Configuration > Currencies.")]
        public double Price { get; set; }

        [Display(Name = "Old Price",
        Description = "The old price of the room.If you set an old price, this will display alongside the current price on the room page to show the difference in price.")]
        public double OldPrice { get; set; }



        [Display(Name = "Room Cost",
        Description = "Room cost is a prime room cost.This field is only for internal use, not visible for customers.")]
        public double RoomCost { get; set; }

     

        [Display(Name = "Discounts",
        Description = "Select discounts to apply to this room.You can manage discounts by selecting Discounts from the Promotions menu.")]
        public int Discounts { get; set; }

        [Display(Name = "Room Quota",
               Description = "Select inventory method.There are two methods: Don’t track inventory and Track inventory. ")]
        public int RoomQuota { get; set; }

        [Required]
        [Display(Name = "Dormitory Block",
        Description = "Choose dormitory block.You can manage dormitory block by selecting Dormitory blocks> Dormitory blocks")]
        public long DormitoryBlock { get; set; }
        [Required]
        [Display(Name = "Dormitory",
        Description = "Choose dormitory to associate room with.")]
        public long Dormitory { get; set; }



        [Display(Name = "Id",
        Description = "")]
        public long Id { get; set; }


        [Display(Name = "Created On",
        Description = "Date and time when this room was created."), DataType(DataType.Text), MaxLength(256)]
        public string CreatedOn { get; set; }

        [Display(Name = "Updated On",
        Description = "Date and time when this room was updated."), DataType(DataType.Text), MaxLength(256)]
        public string UpdatedOn { get; set; }


      
    

        

        [Display(Name = "Room",
        Description = "null"), DataType(DataType.Text), MaxLength(256)]
        public string Room { get; set; }

     


        public PicturesTab picturesTab { get; set; }
      
        public FacilitiesTab facilitiesTab { get; set; }
    }




    public class LocalizedContent
    {
        public long languageId { get; set; }
        [Required]
        [Display(Name = "Room Name",
      Description = ""), DataType(DataType.Text), MaxLength(256)]
        public string RoomName { get; set; }

       
        [Required]
        [Display(Name = "Gender Allocation",
       Description = ""), DataType(DataType.Text),MinLength(3), MaxLength(256)]
        public string GenderAllocation { get; set; }
        [Required]
        [Display(Name = "Bed Type",
        Description = ""), DataType(DataType.Text), MaxLength(256)]
        public string BedType { get; set; }
    

        
         

    }



    public class PicturesTable
    {
        public string Picture { get; set; }
        public string DisplayOrder { get; set; }
        public string Alt { get; set; }
        public string UploadDate { get; set; }
        public long Id { get; set; }


    }

    public class PicturesTab
    {
        [Display(Name = "Alt",
       Description = ""), DataType(DataType.Text), MaxLength(256)]
        public string Alt { get; set; }


        [Display(Name = "title",
       Description = ""), DataType(DataType.Text), MaxLength(256)]
        public string title { get; set; }


        [Display(Name = "Display Order",
       Description = ""), DataType(DataType.Text), MaxLength(256)]
        public int DisplayOrder { get; set; }


    }


    public class FacilitiesTable
    {
        public string AttributeType { get; set; }
        public string Attribute { get; set; }
        public string Value { get; set; }
        public string AllowFiltering { get; set; }
        public string ShowOnRoomPage { get; set; }
        public string DisplayOrder { get; set; }

    }

    public class FacilitiesTab
    {
        public long RoomId { get; set; }
        [Display(Name = "Feature Category", Description = "The category of the feature, it may be under room feature category, bed type and so on")]
        public long FeatureCategory { get; set; }

        [Display(Name = "Feature", Description = "Feature name")]
        public long Feature { get; set; }
        
    


    }


    public class DormitoryRoomsTable
    {

        public long RoomId { get; set; }
        public string RoomName { get; set; }
        public string DormitoryBlock { get; set; }
        public string SKU { get; set; }
        public string Price { get; set; }
        public int Quota { get; set; }
        public bool Published { get; set; }

    }


}
