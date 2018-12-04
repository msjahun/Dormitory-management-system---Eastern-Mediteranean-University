using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Catalog
{
    public class DormitoryBlocksVm
    {
        [Display(Name = "Block name",
        Description = "A dormitory block name."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string BlockName { get; set; }
    }

    public class DormitoryBlockAdd
    {

      


        [Display(Name = "Picture",
        Description = "The dormitory block picutre"), DataType(DataType.Text), MaxLength(256)]
        public string Picture { get; set; }

        [Display(Name = "price Range",
        Description = "The price range of the rooms in the dormitory block"), DataType(DataType.Text), MaxLength(256)]
        public string priceRange { get; set; }

        [Display(Name = "Include In Top Menu",
        Description = "Display in the top menu bar. ")]
        public bool IncludeInTopMenu { get; set; }

        [Display(Name = "Discount",
        Description = "Select discounts to apply to this dormitory block. You can manage discounts by selecting Discounts from the Promotions menu.")]
        public IEnumerable<int> Discount { get; set; }

        [Display(Name = "Limited To Customer Roles",
        Description = "Select customer roles for which the dormitory block will be shown.Leave empty if you want this dormitory block to be visible to all users.")]
        public IEnumerable<int> LimitedToCustomerRoles { get; set; }

        [Display(Name = "Limit To Dormitories",
        Description = "Option to limit this dormitory block to a certain dormitory. If you have multiple dormitory, choose one or several from the list.If you don't use this option just leave this field empty.")]
        public IEnumerable<int> LimitToDormitories { get; set; }

        [Display(Name = "Published",
        Description = "Check to publish this dormitory block (visible in customer area). Uncheck to unpublish (dormitory block is not available in customer area).")]
        public bool Published { get; set; }

        [Display(Name = "Display Order",
        Description = "Set the  dormitory block's display order. 1 represents the top of the list."), MaxLength(256)]
        public int DisplayOrder { get; set; }


        public DormitoryBlockSeoTab[] seoTab { get; set; }

        public DormitoryBlockContentLocalizedTab[] localizedContent { get; set; }
    }

    public class DormitoryBlockContentLocalizedTab
    {
        [Display(Name = "Name",
      Description = "The dormitory block name"), DataType(DataType.Text), MaxLength(256)]
        public string Name { get; set; }

        [Display(Name = "Description",
        Description = "The description of the dormitory block"), DataType(DataType.Text), MaxLength(256)]
        public string Description { get; set; }

    }

    public class DormitoryBlockEdit
    {
        [Display(Name = "Name",
        Description = "The dormitory block name"), DataType(DataType.Text), MaxLength(256)]
        public string Name { get; set; }


        [Display(Name = "Description",
        Description = "The description of the dormitory block"), DataType(DataType.Text), MaxLength(256)]
        public string Description { get; set; }


        [Display(Name = "Picture",
        Description = "The dormitory block picutre"), DataType(DataType.Text), MaxLength(256)]
        public string Picture { get; set; }

        [Display(Name = "Price Range",
        Description = "The price range of the rooms in the dormitory block"), DataType(DataType.Text), MaxLength(256)]
        public string priceRange { get; set; }

        [Display(Name = "Include In Top Menu",
        Description = "Display in the top menu bar. ")]
        public bool IncludeInTopMenu { get; set; }

        [Display(Name = "Discount",
        Description = "Select discounts to apply to this dormitory block. You can manage discounts by selecting Discounts from the Promotions menu.")]
        public IEnumerable<int> Discount { get; set; }

        [Display(Name = "Limited To Customer Roles",
        Description = "Select customer roles for which the dormitory block will be shown.Leave empty if you want this dormitory block to be visible to all users.")]
        public IEnumerable<int> LimitedToCustomerRoles { get; set; }

        [Display(Name = "Limit To Dormitories",
        Description = "Option to limit this dormitory block to a certain dormitory. If you have multiple dormitory, choose one or several from the list.If you don't use this option just leave this field empty.")]
        public IEnumerable<int> LimitToDormitories { get; set; }

        [Display(Name = "Published",
        Description = "Check to publish this dormitory block (visible in customer area). Uncheck to unpublish (dormitory block is not available in customer area).")]
        public bool Published { get; set; }

        [Display(Name = "Display Order",
        Description = "Set the  dormitory block's display order. 1 represents the top of the list."), MaxLength(256)]
        public int DisplayOrder { get; set; }


        public DormitoryBlockSeoTab[] seoTab { get; set; }

      

        public DormitoryBlockContentLocalizedTab[] localizedContent { get; set; }
    }


    public class RoomsTable
    {
public string Room {get; set;}
public string isFeaturedRoom {get; set;}
public string DisplayOrder {get; set;}
public string View { get; set; }

    }


    public class DormitoryBlockSeoTab
    {
        [Display(Name = "Meta Keywords",
        Description = "Meta keywords to be added to Room page header."), DataType(DataType.Text), MaxLength(256)]
        public string MetaKeywords { get; set; }


        [Display(Name = "Meta Description",
        Description = "Meta description to be added to Room page header."), DataType(DataType.Text), MaxLength(256)]
        public string MetaDescription { get; set; }


        [Display(Name = "Meta Title",
        Description = "Override the page title. The default is the name of the Room."), DataType(DataType.Text), MaxLength(256)]
        public string MetaTitle { get; set; }


        [Display(Name = "Search Engine Friendly PageName",
        Description = "Set a search engine friendly page name e.g. 'the-best-room' to make your page URL 'http://www.domain.com/the-best-room'. Leave empty to generate it automatically based on the name of the Room."), DataType(DataType.Text), MaxLength(256)]
        public string SearchEngineFriendlyPageName { get; set; }
    }

}
