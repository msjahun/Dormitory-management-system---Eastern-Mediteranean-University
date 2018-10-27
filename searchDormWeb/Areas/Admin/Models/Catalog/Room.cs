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
        [Display(Name = "RoomType",
        Description = "Room type"), MaxLength(256)]
        public int RoomType { get; set; }


        [Display(Name = "RoomName",
                Description = "The name of the rooom."), DataType(DataType.Text), MaxLength(256)]
        public string RoomName_sd { get; set; }

        [Display(Name = "ShortDescription",
        Description = "Short description is the text that is displayed in room list i.e.dormitory-block pages."), DataType(DataType.Text), MaxLength(256)]
        public string ShortDescription_sd { get; set; }

        [Display(Name = "FullDescription",
        Description = "Full description is the text that is displayed in room page."), DataType(DataType.Text), MaxLength(256)]
        public string FullDescription_sd { get; set; }


        [Display(Name = "RoomName",
              Description = "The name of the rooom."), DataType(DataType.Text), MaxLength(256)]
        public string RoomName_en { get; set; }

        [Display(Name = "ShortDescription",
        Description = "Short description is the text that is displayed in room list i.e.dormitory-block pages."), DataType(DataType.Text), MaxLength(256)]
        public string ShortDescription_en { get; set; }

        [Display(Name = "FullDescription",
        Description = "Full description is the text that is displayed in room page."), DataType(DataType.Text), MaxLength(256)]
        public string FullDescription_en { get; set; }



        [Display(Name = "RoomName",
                      Description = "The name of the rooom."), DataType(DataType.Text), MaxLength(256)]
        public string RoomName_tr { get; set; }

        [Display(Name = "ShortDescription",
        Description = "Short description is the text that is displayed in room list i.e.dormitory-block pages."), DataType(DataType.Text), MaxLength(256)]
        public string ShortDescription_tr { get; set; }

        [Display(Name = "FullDescription",
        Description = "Full description is the text that is displayed in room page."), DataType(DataType.Text), MaxLength(256)]
        public string FullDescription_tr { get; set; }






        [Display(Name = "SKU",
        Description = "Room stock keeping unit(SKU). Your internal unique identifier that can be used to track this room."), DataType(DataType.Text), MaxLength(256)]
        public string SKU { get; set; }

        [Display(Name = "Published",
        Description = "Check to publish this roomt (visible in customer area). Uncheck to unpublish (room not available in customer area).")]
        public bool Published { get; set; }

        [Display(Name = "RoomTags",
        Description = "Room tags are the keywords for room identification.The more rooms associated with a particular tag, the larger it will show on the tag cloud."), DataType(DataType.Text), MaxLength(256)]
        public string RoomTags { get; set; }

        [Display(Name = "ShowOnHomePage",
        Description = "Check to display this room on the site home page. Recommended for your most popular room.")]
        public bool ShowOnHomePage { get; set; }

        [Display(Name = "AllowCustomerReviews",
        Description = "Check to allow customers to review this room.")]
        public bool AllowCustomerReviews { get; set; }

        [Display(Name = "AvailableStartDate",
        Description = "The start of the room's availability in Coordinated Universal Time (UTC).")]
        public DateTime AvailableStartDate { get; set; }

        [Display(Name = "AvailableEndDate",
        Description = "The end of the room's availability in Coordinated Universal Time (UTC).")]
        public DateTime AvailableEndDate { get; set; }

        [Display(Name = "MarkAsNew",
        Description = "Check to mark the room as new. Use this option for promoting new rooms.")]
        public bool MarkAsNew { get; set; }

        [Display(Name = "AdminComment",
        Description = "This comment is for internal use only, not visible for customers."), DataType(DataType.Text), MaxLength(256)]
        public string AdminComment { get; set; }



        [Display(Name = "Price",
        Description = "The price of the room.You can manage currency by selecting Configuration > Currencies."), MaxLength(256)]
        public int Price { get; set; }

        [Display(Name = "OldPrice",
        Description = "The old price of the room.If you set an old price, this will display alongside the current price on the room page to show the difference in price."), MaxLength(256)]
        public int OldPrice { get; set; }

        [Display(Name = "RoomCost",
        Description = "Room cost is a prime room cost.This field is only for internal use, not visible for customers."), MaxLength(256)]
        public int RoomCost { get; set; }

        [Display(Name = "DisableBuyButton",
        Description = "Check to disable the book room button for this room.This may be necessary for rooms that are 'available upon request'.")]
        public bool DisableBuyButton { get; set; }

        [Display(Name = "DisableWishlistButton",
        Description = "Check to disable the wishlist button for this product.")]
        public bool DisableWishlistButton { get; set; }


        [Display(Name = "AvailableForPreBooking",
        Description = "Check if this item is available for Pre-Booking.It also displays \"Pre-Booking\" button instead of \"Add to booking list\".")]
        public bool AvailableForPreBooking { get; set; }

        [Display(Name = "CallForPrice",
        Description = "Check to show \"Call for Pricing\" or \"Call for quote\" instead of price.")]
        public bool CallForPrice { get; set; }

        [Display(Name = "Discounts",
        Description = "Select discounts to apply to this room.You can manage discounts by selecting Discounts from the Promotions menu.")]
        public IEnumerable<int> Discounts { get; set; }


        [Display(Name = "InventoryMethod",
        Description = "Select inventory method.There are two methods: Don’t track inventory and Track inventory. "), MaxLength(256)]
        public int InventoryMethod { get; set; }


        [Display(Name = "DormitoryBlock",
        Description = "Choose dormitory block.You can manage dormitory block by selecting Dormitory blocks> Dormitory blocks"), DataType(DataType.Text), MaxLength(256)]
        public string DormitoryBlock { get; set; }

        [Display(Name = "Dormitory",
        Description = "Choose dormitory to associate room with."), MaxLength(256)]
        public int Dormitory { get; set; }


        [Display(Name = "UserRoles",
        Description = "Choose one or several customer roles i.e.administrators, guests, who will be able to see this room in catalog.If you don't need this option just leave this field empty.")]
        public IEnumerable<int> UserRoles { get; set; }





        [Display(Name = "MetaKeywords",
        Description = "Meta keywords to be added to Room page header."), DataType(DataType.Text), MaxLength(256)]
        public string MetaKeywords_sd { get; set; }


        [Display(Name = "MetaDescription",
        Description = "Meta description to be added to Room page header."), DataType(DataType.Text), MaxLength(256)]
        public string MetaDescription_sd { get; set; }


        [Display(Name = "MetaTitle",
        Description = "Override the page title. The default is the name of the Room."), DataType(DataType.Text), MaxLength(256)]
        public string MetaTitle_sd { get; set; }


        [Display(Name = "SearchEngineFriendlyPageName",
        Description = "Set a search engine friendly page name e.g. 'the-best-room' to make your page URL 'http://www.domain.com/the-best-room'. Leave empty to generate it automatically based on the name of the Room."), DataType(DataType.Text), MaxLength(256)]
        public string SearchEngineFriendlyPageName_sd { get; set; }



        [Display(Name = "MetaKeywords",
Description = "Meta keywords to be added to Room page header."), DataType(DataType.Text), MaxLength(256)]
        public string MetaKeywords_en { get; set; }


        [Display(Name = "MetaDescription",
        Description = "Meta description to be added to Room page header."), DataType(DataType.Text), MaxLength(256)]
        public string MetaDescription_en { get; set; }


        [Display(Name = "MetaTitle",
        Description = "Override the page title. The default is the name of the Room."), DataType(DataType.Text), MaxLength(256)]
        public string MetaTitle_en { get; set; }


        [Display(Name = "SearchEngineFriendlyPageName",
        Description = "Set a search engine friendly page name e.g. 'the-best-room' to make your page URL 'http://www.domain.com/the-best-room'. Leave empty to generate it automatically based on the name of the Room."), DataType(DataType.Text), MaxLength(256)]
        public string SearchEngineFriendlyPageName_en { get; set; }




        [Display(Name = "MetaKeywords",
Description = "Meta keywords to be added to Room page header."), DataType(DataType.Text), MaxLength(256)]
        public string MetaKeywords_tr { get; set; }


        [Display(Name = "MetaDescription",
        Description = "Meta description to be added to Room page header."), DataType(DataType.Text), MaxLength(256)]
        public string MetaDescription_tr { get; set; }


        [Display(Name = "MetaTitle",
        Description = "Override the page title. The default is the name of the Room."), DataType(DataType.Text), MaxLength(256)]
        public string MetaTitle_tr { get; set; }


        [Display(Name = "SearchEngineFriendlyPageName",
        Description = "Set a search engine friendly page name e.g. 'the-best-room' to make your page URL 'http://www.domain.com/the-best-room'. Leave empty to generate it automatically based on the name of the Room."), DataType(DataType.Text), MaxLength(256)]
        public string SearchEngineFriendlyPageName_tr { get; set; }


    }

    public class RoomEdit
    {
        [Display(Name = "Id",
        Description = ""), DataType(DataType.Text), MaxLength(256)]
        public string Id { get; set; }

        [Display(Name = "RoomType",
        Description = ""), MaxLength(256)]
        public int RoomType { get; set; }



        [Display(Name = "RoomName",
        Description = ""), DataType(DataType.Text), MaxLength(256)]
        public string RoomName { get; set; }

        [Display(Name = "ShortDescription",
        Description = ""), DataType(DataType.Text), MaxLength(256)]
        public string ShortDescription { get; set; }

        [Display(Name = "FullDescription",
        Description = ""), DataType(DataType.Text), MaxLength(256)]
        public string FullDescription { get; set; }



        [Display(Name = "SKU",
        Description = "Room stock keeping unit(SKU). Your internal unique identifier that can be used to track this room."), DataType(DataType.Text), MaxLength(256)]
        public string SKU { get; set; }

        [Display(Name = "Published",
        Description = "Check to publish this roomt (visible in customer area). Uncheck to unpublish (room not available in customer area).")]
        public bool Published { get; set; }

        [Display(Name = "RoomTags",
        Description = "Room tags are the keywords for room identification.The more rooms associated with a particular tag, the larger it will show on the tag cloud."), DataType(DataType.Text), MaxLength(256)]
        public string RoomTags { get; set; }

        [Display(Name = "ShowOnHomePage",
        Description = "Check to display this room on the site home page. Recommended for your most popular room.")]
        public bool ShowOnHomePage { get; set; }

        [Display(Name = "AllowCustomerReviews",
        Description = "Check to allow customers to review this room.")]
        public bool AllowCustomerReviews { get; set; }

        [Display(Name = "AvailableStartDate",
        Description = "The start of the room's availability in Coordinated Universal Time (UTC).")]
        public DateTime AvailableStartDate { get; set; }

        [Display(Name = "AvailableEndDate",
        Description = "The end of the room's availability in Coordinated Universal Time (UTC).")]
        public DateTime AvailableEndDate { get; set; }

        [Display(Name = "MarkAsNew",
        Description = "Check to mark the room as new. Use this option for promoting new rooms.")]
        public bool MarkAsNew { get; set; }

        [Display(Name = "AdminComment",
        Description = "This comment is for internal use only, not visible for customers."), DataType(DataType.Text), MaxLength(256)]
        public string AdminComment { get; set; }

        [Display(Name = "CreatedOn",
        Description = "Date and time when this room was created."), DataType(DataType.Text), MaxLength(256)]
        public string CreatedOn { get; set; }

        [Display(Name = "UpdatedOn",
        Description = "Date and time when this room was updated."), DataType(DataType.Text), MaxLength(256)]
        public string UpdatedOn { get; set; }


        [Display(Name = "Price",
        Description = "The price of the room.You can manage currency by selecting Configuration > Currencies."), MaxLength(256)]
        public int Price { get; set; }

        [Display(Name = "OldPrice",
        Description = "The old price of the room.If you set an old price, this will display alongside the current price on the room page to show the difference in price."), MaxLength(256)]
        public int OldPrice { get; set; }

        [Display(Name = "RoomCost",
        Description = "Room cost is a prime room cost.This field is only for internal use, not visible for customers."), MaxLength(256)]
        public int RoomCost { get; set; }

        [Display(Name = "DisableBuyButton",
        Description = "Check to disable the book room button for this room.This may be necessary for rooms that are 'available upon request'.")]
        public bool DisableBuyButton { get; set; }

        [Display(Name = "DisableWishlistButton",
        Description = "Check to disable the wishlist button for this product.")]
        public bool DisableWishlistButton { get; set; }

        [Display(Name = "AvailableForPreBooking",
        Description = "Check if this item is available for Pre-Booking.It also displays \"Pre-Booking\" button instead of \"Add to booking list\".")]
        public bool AvailableForPreBooking { get; set; }

        [Display(Name = "CallForPrice",
        Description = "Check to show \"Call for Pricing\" or \"Call for quote\" instead of price.")]
        public bool CallForPrice { get; set; }

        [Display(Name = "Discounts",
        Description = "Select discounts to apply to this room.You can manage discounts by selecting Discounts from the Promotions menu.")]
        public IEnumerable<int> Discounts { get; set; }

        [Display(Name = "InventoryMethod",
        Description = "Select inventory method.There are two methods: Don’t track inventory and Track inventory. "), MaxLength(256)]
        public int InventoryMethod { get; set; }

        [Display(Name = "DormitoryBlock",
        Description = "Choose dormitory block.You can manage dormitory block by selecting Dormitory blocks> Dormitory blocks")]
        public IEnumerable<int> DormitoryBlock { get; set; }

        [Display(Name = "Dormitory",
        Description = "Choose dormitory to associate room with."), MaxLength(256)]
        public int Dormitory { get; set; }

        [Display(Name = "UserRoles",
        Description = "Choose one or several customer roles i.e.administrators, guests, who will be able to see this room in catalog.If you don't need this option just leave this field empty.")]
        public IEnumerable<int> UserRoles { get; set; }

        [Display(Name = "Room",
        Description = "null"), DataType(DataType.Text), MaxLength(256)]
        public string Room { get; set; }

        [Display(Name = "DisplayOrder",
        Description = "null"), DataType(DataType.Text), MaxLength(256)]
        public string DisplayOrder { get; set; }

    }
}
