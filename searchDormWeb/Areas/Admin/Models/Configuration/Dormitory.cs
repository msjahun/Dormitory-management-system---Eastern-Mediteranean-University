using searchDormWeb.Areas.Admin.Models.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Configuration
{
    public class DormitoriesVm
    {

        [Display(Name = "Dormitory name",
        Description = "A Dormitory name"),
        DataType(DataType.Text),
        MaxLength(256)]
        public string DormitoryName { get; set; }

        [Display(Name = "Dormitory type",
        Description = "Search by a specific Dormitory Type"),
        MaxLength(256)]
        public int DormitoryType { get; set; }

        [Display(Name = "Go directly to SKU",
        Description = "Enter dormitory SKU and click Go"),
        DataType(DataType.Text),
        MaxLength(256)]
        public string GoDirectlyToSKU { get; set; }





    }

    public class DormitoryAdd
    {


        [Display(Name = "Dormitory Type",
                Description = "Dormitory type can be School own dormitory and private dormitory."), MaxLength(256)]
        public int DormitoryType { get; set; }

        public LocalizedContent[] localizedContent { get; set; }


        [Display(Name = "Dormitory Url",
                Description = "The URL of the website e.g.http://dormitory.emu.edu.tr"), DataType(DataType.Text), MaxLength(256)]
        public string DormitoryUrl { get; set; }

        [Display(Name = "Display Order",
        Description = "The display order for this dormitory. 1 represents the top of the list."), MaxLength(256)]
        public int DisplayOrder { get; set; }

        [Display(Name = "Company Name",
        Description = "Enter your company name."), DataType(DataType.Text), MaxLength(256)]
        public string CompanyName { get; set; }

        [Display(Name = "Company Address",
        Description = "Enter your company address."), DataType(DataType.Text), MaxLength(256)]
        public string CompanyAddress { get; set; }

        [Display(Name = "Company Phone Number",
        Description = "Enter your company phone number."), DataType(DataType.Text), MaxLength(256)]
        public string CompanyPhoneNumber { get; set; }

        [Display(Name = "Published",
        Description = "Check to publish this dormitory (visible in customer area). Uncheck to unpublish (dormitory not available in customer area).")]
        public bool Published { get; set; }

        [Display(Name = "Show On Home Page",
        Description = "Check to display this dormitory on your home page.Recommended for your most popular dormitory.")]
        public bool ShowOnHomePage { get; set; }

        [Display(Name = "Allow Customer Reviews",
        Description = "Check to allow customers to review this dormitory.")]
        public bool AllowCustomerReviews { get; set; }

        [Display(Name = "Mark As New",
        Description = "Check to mark the dormitory as new. Use this option for promoting new dormitories.")]
        public bool MarkAsNew { get; set; }

        [Display(Name = "Admin Comment",
        Description = "This comment is for internal use only, not visible for customers."), DataType(DataType.Text), MaxLength(256)]
        public string AdminComment { get; set; }


        [Display(Name = "User Roles",
        Description = "Choose one or several customer roles i.e.administrators, guests, who will be able to see this dormitory in dormitory list.If you don't need this option just leave this field empty."), MaxLength(256)]
        public int UserRoles { get; set; }



        public SeoTab[] seoTab {get; set;}
        
       
    }

    
    public class DormitoryEdit
    {
        [Display(Name = "ID",
              Description = "The Dormitory Id"), DataType(DataType.Text), MaxLength(256)]
        public string Id { get; set; }

        [Display(Name = "Dormitory Type",
             Description = "Dormitory type can be School own dormitory and private dormitory."), MaxLength(256)]
        public int DormitoryType { get; set; }

        public LocalizedContent[] localizedContent { get; set; }

        [Display(Name = "Dormitory Url",
                Description = "The URL of the website e.g.http://dormitory.emu.edu.tr"), DataType(DataType.Text), MaxLength(256)]
        public string DormitoryUrl { get; set; }

        [Display(Name = "Display Order",
        Description = "The display order for this dormitory. 1 represents the top of the list."), MaxLength(256)]
        public int DisplayOrder { get; set; }

        [Display(Name = "Company Name",
        Description = "Enter your company name."), DataType(DataType.Text), MaxLength(256)]
        public string CompanyName { get; set; }

        [Display(Name = "Company Address",
        Description = "Enter your company address."), DataType(DataType.Text), MaxLength(256)]
        public string CompanyAddress { get; set; }

        [Display(Name = "Company Phone Number",
        Description = "Enter your company phone number."), DataType(DataType.Text), MaxLength(256)]
        public string CompanyPhoneNumber { get; set; }

        [Display(Name = "Published",
        Description = "Check to publish this dormitory (visible in customer area). Uncheck to unpublish (dormitory not available in customer area).")]
        public bool Published { get; set; }

        [Display(Name = "Show On HomePage",
        Description = "Check to display this dormitory on your home page.Recommended for your most popular dormitory.")]
        public bool ShowOnHomePage { get; set; }

        [Display(Name = "Allow Customer Reviews",
        Description = "Check to allow customers to review this dormitory.")]
        public bool AllowCustomerReviews { get; set; }

        [Display(Name = "Mark As New",
        Description = "Check to mark the dormitory as new. Use this option for promoting new dormitories.")]
        public bool MarkAsNew { get; set; }

        [Display(Name = "Admin Comment",
        Description = "This comment is for internal use only, not visible for customers."), DataType(DataType.Text), MaxLength(256)]
        public string AdminComment { get; set; }

        [Display(Name = "Created On",
        Description = "Date/Time this dormitory was created."), DataType(DataType.Text), MaxLength(256)]
        public string CreatedOn { get; set; }

        [Display(Name = "Updated On",
        Description = "Date/Time this dormitory was last updated."), DataType(DataType.Text), MaxLength(256)]
        public string UpdatedOn { get; set; }

        [Display(Name = "User Roles",
        Description = "Choose one or several customer roles i.e.administrators, guests, who will be able to see this dormitory in dormitory list.If you don't need this option just leave this field empty."), MaxLength(256)]
        public int UserRoles { get; set; }

        public SeoTab[] seoTab { get; set; }

        public PicturesTab picturesTab { get; set; }

        public FacilitiesTab facilitiesTab { get; set; }

    }

    public class LocalizedContent
    {
        [Display(Name = "Dormitory Name",
       Description = "Name of the dormotory"), DataType(DataType.Text), MaxLength(256)]
        public string DormitoryName { get; set; }

        [Display(Name = "Short Description",
        Description = "Short description is the text that is displayed in dormitory list pages."), DataType(DataType.Text), MaxLength(256)]
        public string ShortDescription { get; set; }

        [Display(Name = "Full Description",
        Description = "Full description is the text that is displayed in dormitory page."), DataType(DataType.Text), MaxLength(256)]
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


        [Display(Name = "DisplayOrder",
       Description = ""), DataType(DataType.Text), MaxLength(256)]
        public int DisplayOrder { get; set; }


    }


    public class FacilitiesTable
    {
        public string AttributeType { get; set; }
        public string Attribute {get; set;}
        public string Value {get; set;}
        public string AllowFiltering {get; set;}
        public string ShowOnRoomPage {get; set;}
        public string DisplayOrder {get; set;}

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

        [Display(Name = "Show On Room Page", Description = ""), MaxLength(256)]
        public bool ShowOnRoomPage { get; set; }

        [Display(Name = "Display Order", Description = ""), MaxLength(256)]
        public int DisplayOrder { get; set; }


    }
}
