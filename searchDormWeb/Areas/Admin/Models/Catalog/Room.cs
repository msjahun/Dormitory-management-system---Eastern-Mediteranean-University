using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Catalog
{
    public class RoomsVm
    {
        [Display(Name = "Room name",
        Description = "A room name."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string RoomName { get; set; }

        [Display(Name = "Dormitory block",
        Description = "Search by a specific Dormitory Block"),
        MaxLength(256)]
        public int DormitoryBlock { get; set; }

        [Display(Name = "Published",
        Description = "Search by a \"published\" property"),
        MaxLength(256)]
        public int Published { get; set; }

        [Display(Name = "Go directly to Room SKU",
        Description = "Enter room SKU and click Go"),
        DataType(DataType.Text),
        MaxLength(256)]
        public string GoDirectoryToRoomSKU { get; set; }

    }

    public class RoomAdd
    {

        public List<LocalizedContent> localizedContent { get; set; }




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

        [Display(Name = "Short Description",
        Description = ""), DataType(DataType.Text), MaxLength(256)]
        public string ShortDescription { get; set; }

        [Display(Name = "Full Description",
        Description = ""), DataType(DataType.Text), MaxLength(256)]
        public string FullDescription { get; set; }

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
