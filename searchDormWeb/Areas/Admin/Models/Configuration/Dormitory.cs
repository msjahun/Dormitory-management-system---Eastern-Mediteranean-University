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


        [Display(Name = "DormitoryType",
                Description = "Dormitory type can be School own dormitory and private dormitory."), MaxLength(256)]
        public int DormitoryType { get; set; }


        [Display(Name = "DormitoryName",
                Description = "Name of the dormotory"), DataType(DataType.Text), MaxLength(256)]
        public string DormitoryName { get; set; }

        [Display(Name = "ShortDescription",
        Description = "Short description is the text that is displayed in dormitory list pages."), DataType(DataType.Text), MaxLength(256)]
        public string ShortDescription { get; set; }

        [Display(Name = "FullDescription",
        Description = "Full description is the text that is displayed in dormitory page."), DataType(DataType.Text), MaxLength(256)]
        public string FullDescription { get; set; }




        [Display(Name = "DormitoryUrl",
                Description = "The URL of the website e.g.http://dormitory.emu.edu.tr"), DataType(DataType.Text), MaxLength(256)]
        public string DormitoryUrl { get; set; }

        [Display(Name = "DisplayOrder",
        Description = "The display order for this dormitory. 1 represents the top of the list."), MaxLength(256)]
        public int DisplayOrder { get; set; }

        [Display(Name = "CompanyName",
        Description = "Enter your company name."), DataType(DataType.Text), MaxLength(256)]
        public string CompanyName { get; set; }

        [Display(Name = "CompanyAddress",
        Description = "Enter your company address."), DataType(DataType.Text), MaxLength(256)]
        public string CompanyAddress { get; set; }

        [Display(Name = "CompanyPhoneNumber",
        Description = "Enter your company phone number."), DataType(DataType.Text), MaxLength(256)]
        public string CompanyPhoneNumber { get; set; }

        [Display(Name = "Published",
        Description = "Check to publish this dormitory (visible in customer area). Uncheck to unpublish (dormitory not available in customer area).")]
        public bool Published { get; set; }

        [Display(Name = "ShowOnHomePage",
        Description = "Check to display this dormitory on your home page.Recommended for your most popular dormitory.")]
        public bool ShowOnHomePage { get; set; }

        [Display(Name = "AllowCustomerReviews",
        Description = "Check to allow customers to review this dormitory.")]
        public bool AllowCustomerReviews { get; set; }

        [Display(Name = "MarkAsNew",
        Description = "Check to mark the dormitory as new. Use this option for promoting new dormitories.")]
        public bool MarkAsNew { get; set; }

        [Display(Name = "AdminComment",
        Description = "This comment is for internal use only, not visible for customers."), DataType(DataType.Text), MaxLength(256)]
        public string AdminComment { get; set; }


        [Display(Name = "UserRoles",
        Description = "Choose one or several customer roles i.e.administrators, guests, who will be able to see this dormitory in dormitory list.If you don't need this option just leave this field empty."), MaxLength(256)]
        public int UserRoles { get; set; }





    }


    public class DormitoryEdit
    {
        [Display(Name = "DormitoryName",
        Description = "Name of the dormotory"), DataType(DataType.Text), MaxLength(256)]
        public string DormitoryName { get; set; }

        [Display(Name = "ShortDescription",
        Description = "Short description is the text that is displayed in dormitory list pages."), DataType(DataType.Text), MaxLength(256)]
        public string ShortDescription { get; set; }

        [Display(Name = "FullDescription",
        Description = "Full description is the text that is displayed in dormitory page."), DataType(DataType.Text), MaxLength(256)]
        public string FullDescription { get; set; }




        [Display(Name = "DormitoryUrl",
                Description = "The URL of the website e.g.http://dormitory.emu.edu.tr"), DataType(DataType.Text), MaxLength(256)]
        public string DormitoryUrl { get; set; }

        [Display(Name = "DisplayOrder",
        Description = "The display order for this dormitory. 1 represents the top of the list."), MaxLength(256)]
        public int DisplayOrder { get; set; }

        [Display(Name = "CompanyName",
        Description = "Enter your company name."), DataType(DataType.Text), MaxLength(256)]
        public string CompanyName { get; set; }

        [Display(Name = "CompanyAddress",
        Description = "Enter your company address."), DataType(DataType.Text), MaxLength(256)]
        public string CompanyAddress { get; set; }

        [Display(Name = "CompanyPhoneNumber",
        Description = "Enter your company phone number."), DataType(DataType.Text), MaxLength(256)]
        public string CompanyPhoneNumber { get; set; }

        [Display(Name = "Published",
        Description = "Check to publish this dormitory (visible in customer area). Uncheck to unpublish (dormitory not available in customer area).")]
        public bool Published { get; set; }

        [Display(Name = "ShowOnHomePage",
        Description = "Check to display this dormitory on your home page.Recommended for your most popular dormitory.")]
        public bool ShowOnHomePage { get; set; }

        [Display(Name = "AllowCustomerREviews",
        Description = "Check to allow customers to review this dormitory.")]
        public bool AllowCustomerREviews { get; set; }

        [Display(Name = "MarkAsNew",
        Description = "Check to mark the dormitory as new. Use this option for promoting new dormitories.")]
        public bool MarkAsNew { get; set; }

        [Display(Name = "AdminComment",
        Description = "This comment is for internal use only, not visible for customers."), DataType(DataType.Text), MaxLength(256)]
        public string AdminComment { get; set; }

        [Display(Name = "CreatedOn",
        Description = "Date/Time this dormitory was created."), DataType(DataType.Text), MaxLength(256)]
        public string CreatedOn { get; set; }

        [Display(Name = "UpdatedOn",
        Description = "Date/Time this dormitory was last updated."), DataType(DataType.Text), MaxLength(256)]
        public string UpdatedOn { get; set; }

        [Display(Name = "UserRoles",
        Description = "Choose one or several customer roles i.e.administrators, guests, who will be able to see this dormitory in dormitory list.If you don't need this option just leave this field empty."), MaxLength(256)]
        public int UserRoles { get; set; }


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
        [Display(Name = "AttributeType", Description = ""), MaxLength(256)]
        public int AttributeType { get; set; }

        [Display(Name = "Attribute", Description = ""), MaxLength(256)]
        public int Attribute { get; set; }

        [Display(Name = "AttributeOptions", Description = ""), MaxLength(256)]
        public int AttributeOptions { get; set; }

        [Display(Name = "AllowFiltering", Description = ""), MaxLength(256)]
        public bool AllowFiltering { get; set; }

        [Display(Name = "ShowOnRoomPage", Description = ""), MaxLength(256)]
        public bool ShowOnRoomPage { get; set; }

        [Display(Name = "DisplayOrder", Description = ""), MaxLength(256)]
        public int DisplayOrder { get; set; }


    }
}
