using Dau.Core.Domain.Catalog;
using Dau.Data.Repository;
using Dau.Services.Languages;
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
        private readonly ILanguageService _languageService;
        private readonly IRepository<RoomTranslation> _roomTransRepo;
        private readonly IRepository<Room> _roomRepo;
        private readonly IRepository<Dormitory> _dormitoryRepo;
        private readonly IRepository<DormitoryTranslation> _dormitoryTransRepo;
        private readonly IRepository<RoomCatalogImage> _roomImageRepo;
        private readonly IRepository<CatalogImage> _imageRepo;

        public RoomService(
            ILanguageService languageService,
            IRepository<Room> roomRepository,
            IRepository<RoomTranslation> roomTransRepository,
            IRepository<Dormitory> dormitoryRepository,
            IRepository<DormitoryTranslation> dormitoryTransRepository,
            IRepository<RoomCatalogImage> roomImageRepository,
            IRepository<CatalogImage> imageRepository)
        {
            _languageService = languageService;
            _roomTransRepo =roomTransRepository;
           _roomRepo = roomRepository;
            _dormitoryRepo=dormitoryRepository;
            _dormitoryTransRepo=dormitoryTransRepository;
            _roomImageRepo=roomImageRepository;
            _imageRepo=imageRepository;


        }

        public int GetNumberOfRoomsWithLowQuota()
        {
            var roomswithLowQuota = from room in _roomRepo.List().ToList()
                                    where room.NoRoomQuota < 5
                                    select room;

            return roomswithLowQuota.ToList().Count;

        }

        public List<RoomsListTable> GetRoomsListTable()
        {
            var CurrentLanguageId = _languageService.GetCurrentLanguageId();
            var rooms = from room in _roomRepo.List().ToList()
                        join roomTrans in _roomTransRepo.List().ToList() on room.Id equals roomTrans.RoomNonTransId
                        where roomTrans.LanguageId == CurrentLanguageId
                        select new { room.Id, roomTrans.RoomName, room.NoRoomQuota, room.Price, room.Published, room.SKU, room.DormitoryId};

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

            var model = RoomDormitory.ToList();
            return model;
        }

        public long AddRoom(RoomAdd vm)
        {//vm.NoOfStudents
            //vm.HasDeposit
            string input = vm.DealEndTime;
            DateTime DealEndTime;
            DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture,
                     DateTimeStyles.None, out DealEndTime);
            

        var id=  _roomRepo.Insert(new Room
            {
                DealEndTime = DealEndTime, //?

                DormitoryBlockId =vm.DormitoryBlock,
               DormitoryId =vm.Dormitory,
               Price =vm.Price,
               PriceOld=vm.OldPrice,
               NoRoomQuota =vm.RoomQuota,
               SKU =vm.SKU,
             
               DisplayDeal =vm.DisplayDeal,
               PercentageOff =vm.PercentageOff,
               DisplayNoRoomsLeft=vm.DisplayNoRoomsLeft,
               Published =vm.Published,
               DisplayOrder =vm.DisplayOrder,
               
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
                          RoomName =(vm.localizedContent[1].RoomName!=null)?vm.localizedContent[1].RoomName:vm.localizedContent[0].RoomName,
                          GenderAllocation =(vm.localizedContent[1].GenderAllocation!=null)?vm.localizedContent[1].GenderAllocation:vm.localizedContent[0].GenderAllocation,
                          BedType =(vm.localizedContent[1].BedType!=null)?vm.localizedContent[1].BedType:vm.localizedContent[0].BedType,
                          LanguageId = 1//english
                               
                        },
                        new RoomTranslation
                        {
                           RoomName =(vm.localizedContent[2].RoomName!=null)?vm.localizedContent[2].RoomName:vm.localizedContent[0].RoomName,
                           GenderAllocation =(vm.localizedContent[2].GenderAllocation!=null)?vm.localizedContent[2].GenderAllocation:vm.localizedContent[0].GenderAllocation,
                           BedType =(vm.localizedContent[2].BedType!=null)?vm.localizedContent[2].BedType:vm.localizedContent[0].BedType,
                           LanguageId = 2//english
                               
                        }
                }

    
    });

            return id;
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

    public class RoomAdd
    {

        public List<LocalizedContent> localizedContent { get; set; }


        public string DealEndTime { get; set; }
        public bool DisplayDeal { get; set; }
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



        [Display(Name = "Available Start Date",
        Description = "The start of the room's availability in Coordinated Universal Time (UTC).")]
        public string AvailableStartDate { get; set; }

        [Display(Name = "Available End Date",
        Description = "The end of the room's availability in Coordinated Universal Time (UTC).")]
        public string AvailableEndDate { get; set; }

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

        [Display(Name = "Disable Booking Button",
        Description = "Check to disable the book room button for this room.This may be necessary for rooms that are 'available upon request'.")]
        public bool DisableBookingButton { get; set; }

        [Display(Name = "Disable Wishlist Button",
        Description = "Check to disable the wishlist button for this product.")]
        public bool DisableWishlistButton { get; set; }


        [Display(Name = "Available For Pre-Booking",
        Description = "Check if this item is available for Pre-Booking.It also displays \"Pre-Booking\" button instead of \"Add to booking list\".")]
        public bool AvailableForPreBooking { get; set; }

        [Display(Name = "Call For Price",
        Description = "Check to show \"Call for Pricing\" or \"Call for quote\" instead of price.")]
        public bool CallForPrice { get; set; }

        [Display(Name = "Discounts",
        Description = "Select discounts to apply to this room.You can manage discounts by selecting Discounts from the Promotions menu.")]
        public int Discounts { get; set; }

        [Display(Name = "Room Quota",
               Description = "Select inventory method.There are two methods: Don’t track inventory and Track inventory. ")]
        public int RoomQuota { get; set; }


        [Display(Name = "Dormitory Block",
        Description = "Choose dormitory block.You can manage dormitory block by selecting Dormitory blocks> Dormitory blocks")]
        public int DormitoryBlock { get; set; }

        [Display(Name = "Dormitory",
        Description = "Choose dormitory to associate room with.")]
        public int Dormitory { get; set; }


    }


    public class RoomEdit
    {
        [Display(Name = "Id",
        Description = ""), DataType(DataType.Text), MaxLength(256)]
        public string Id { get; set; }



        [Display(Name = "SKU",
        Description = "Room stock keeping unit(SKU). Your internal unique identifier that can be used to track this room."), DataType(DataType.Text), MaxLength(256)]
        public string SKU { get; set; }

        [Display(Name = "Published",
        Description = "Check to publish this roomt (visible in customer area). Uncheck to unpublish (room not available in customer area).")]
        public bool Published { get; set; }


        [Display(Name = "Available Start Date",
        Description = "The start of the room's availability in Coordinated Universal Time (UTC).")]
        public DateTime AvailableStartDate { get; set; }

        [Display(Name = "Available End Date",
        Description = "The end of the room's availability in Coordinated Universal Time (UTC).")]
        public DateTime AvailableEndDate { get; set; }

        [Display(Name = "Mark As New",
        Description = "Check to mark the room as new. Use this option for promoting new rooms.")]
        public bool MarkAsNew { get; set; }

        [Display(Name = "Admin Comment",
        Description = "This comment is for internal use only, not visible for customers."), DataType(DataType.Text), MaxLength(256)]
        public string AdminComment { get; set; }

        [Display(Name = "Created On",
        Description = "Date and time when this room was created."), DataType(DataType.Text), MaxLength(256)]
        public string CreatedOn { get; set; }

        [Display(Name = "Updated On",
        Description = "Date and time when this room was updated."), DataType(DataType.Text), MaxLength(256)]
        public string UpdatedOn { get; set; }


        [Display(Name = "Price",
        Description = "The price of the room.You can manage currency by selecting Configuration > Currencies.")]
        public int Price { get; set; }

        [Display(Name = "Old Price",
        Description = "The old price of the room.If you set an old price, this will display alongside the current price on the room page to show the difference in price."), MaxLength(256)]
        public int OldPrice { get; set; }

        [Display(Name = "Room Cost",
        Description = "Room cost is a prime room cost.This field is only for internal use, not visible for customers.")]
        public int RoomCost { get; set; }

        [Display(Name = "Disable Booking Button",
        Description = "Check to disable the book room button for this room.This may be necessary for rooms that are 'available upon request'.")]
        public bool DisableBookingButton { get; set; }

        [Display(Name = "Disable Wishlist Button",
        Description = "Check to disable the wishlist button for this product.")]
        public bool DisableWishlistButton { get; set; }

        [Display(Name = "Available For Pre-Booking",
        Description = "Check if this item is available for Pre-Booking.It also displays \"Pre-Booking\" button instead of \"Add to booking list\".")]
        public bool AvailableForPreBooking { get; set; }

        [Display(Name = "Call For Price",
        Description = "Check to show \"Call for Pricing\" or \"Call for quote\" instead of price.")]
        public bool CallForPrice { get; set; }

        [Display(Name = "Discounts",
        Description = "Select discounts to apply to this room.You can manage discounts by selecting Discounts from the Promotions menu.")]
        public IEnumerable<int> Discounts { get; set; }

        [Display(Name = "Room Quota",
        Description = "Select inventory method.There are two methods: Don’t track inventory and Track inventory. ")]
        public int RoomQuota { get; set; }

        [Display(Name = "Dormitory Block",
        Description = "Choose dormitory block.You can manage dormitory block by selecting Dormitory blocks> Dormitory blocks")]
        public int DormitoryBlock { get; set; }

        [Display(Name = "Dormitory",
        Description = "Choose dormitory to associate room with.")]
        public int Dormitory { get; set; }


        [Display(Name = "Room",
        Description = "null"), DataType(DataType.Text), MaxLength(256)]
        public string Room { get; set; }

        [Display(Name = "Display Order",
        Description = "null"), DataType(DataType.Text), MaxLength(256)]
        public string DisplayOrder { get; set; }


        public PicturesTab picturesTab { get; set; }
        public LocalizedContent[] localizedContent { get; set; }
        public FacilitiesTab facilitiesTab { get; set; }
    }




    public class LocalizedContent
    {
        [Display(Name = "Room Name",
      Description = ""), DataType(DataType.Text), MaxLength(256)]
        public string RoomName { get; set; }

        //[Display(Name = "Short Description",
        //Description = ""), DataType(DataType.Text), MaxLength(256)]
        //public string ShortDescription { get; set; }

        //[Display(Name = "Full Description",
        //Description = ""), DataType(DataType.Text), MaxLength(256)]
        //public string FullDescription { get; set; }

        [Display(Name = "Gender Allocation",
       Description = ""), DataType(DataType.Text),MinLength(13), MaxLength(256)]
        public string GenderAllocation { get; set; }

        [Display(Name = "Bed Type",
        Description = ""), DataType(DataType.Text), MaxLength(256)]
        public string BedType { get; set; }
    

        
         

    }



    public class PicturesTable
    {
        public string Picture { get; set; }
        public string DisplayOrder { get; set; }
        public string Alt { get; set; }
        public string Title { get; set; }

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
        [Display(Name = "Attribute Type", Description = ""), MaxLength(256)]
        public int AttributeType { get; set; }

        [Display(Name = "Attribute", Description = ""), MaxLength(256)]
        public int Attribute { get; set; }

        [Display(Name = "Attribute Options", Description = ""), MaxLength(256)]
        public int AttributeOptions { get; set; }

        [Display(Name = "Allow Filtering", Description = ""), MaxLength(256)]
        public bool AllowFiltering { get; set; }

        [Display(Name = "Show On RoomPage", Description = ""), MaxLength(256)]
        public bool ShowOnRoomPage { get; set; }

        [Display(Name = "Display Order", Description = ""), MaxLength(256)]
        public int DisplayOrder { get; set; }


    }


}
