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

    public class DormitoryCrud
    {


        [Display(Name = "Dormitory Type",
                Description = "Dormitory type can be School own dormitory and private dormitory."), MaxLength(256)]
        public int DormitoryType { get; set; }

        public List<LocalizedContent> localizedContent { get; set; }

        [Display(Name = "Dormitory Logo",
      Description = "The Logo of the dormitory "), DataType(DataType.Text), MaxLength(256)]
        public string DormitoryLogo { get; set; }


        [Display(Name = "Dormitory Website Url",
                Description = "The URL of the website e.g.http://dormitory.emu.edu.tr"), DataType(DataType.Text), MaxLength(256)]
        public string DormitoryWebsiteUrl { get; set; }

        [Display(Name = "Company Name",
        Description = "Enter your company name."), DataType(DataType.Text), MaxLength(256)]
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }//placeholder that will be deleted later

        [Display(Name = "Dormitory Address",
        Description = "Enter your Dormitory Address."), DataType(DataType.Text), MaxLength(256)]
        public string DormitoryAddress { get; set; }

        [Display(Name = "Company Phone Number",
        Description = "Enter your company phone number."), DataType(DataType.Text), MaxLength(256)]
        public string CompanyPhoneNumber { get; set; }

        [Display(Name = "Published",
        Description = "Check to publish this dormitory (visible in customer area). Uncheck to unpublish (dormitory not available in customer area).")]
        public bool Published { get; set; }

        //[Display(Name = "Show On Home Page",
        //Description = "Check to display this dormitory on your home page.Recommended for your most popular dormitory.")]
        //public bool ShowOnHomePage { get; set; }

        [Display(Name = "Allow Customer Reviews",
        Description = "Check to allow customers to review this dormitory.")]
        public bool AllowCustomerReviews { get; set; }

        [Display(Name = "Mark As New",
        Description = "Check to mark the dormitory as new. Use this option for promoting new dormitories.")]
        public bool MarkAsNew { get; set; }

        [Display(Name = "Admin Comment",
        Description = "This comment is for internal use only, not visible for customers."), DataType(DataType.Text), MaxLength(256)]
        public string AdminComment { get; set; }


   

        public SeoTab seoTab {get; set;}

        [Display(Name = "ID",
              Description = "The Dormitory Id"), DataType(DataType.Text), MaxLength(256)]
        public string Id { get; set; }

     
        [Display(Name = "Created On",
        Description = "Date/Time this dormitory was created."), DataType(DataType.Text), MaxLength(256)]
        public string CreatedOn { get; set; }

        [Display(Name = "Updated On",
        Description = "Date/Time this dormitory was last updated."), DataType(DataType.Text), MaxLength(256)]
        public string UpdatedOn { get; set; }

                                                   //what students love
                                            //number of students
                                            //number of staffs
                                            //number of awards

        public PicturesTab picturesTab { get; set; }

        public FacilitiesTab facilitiesTab { get; set; }


        //Booking settings
        public bool AllowSummerBooking { get; set; }
        public int BookingLimit { get; set; }//1year, 1 semester

        [Display(Name = "Cancel Wait Days",
        Description = "Days Booking Will Be Cancelled If Not Confirmed")]
        public int CancelWaitDays { get; set; }


        //
        public bool AllowReviews { get; set; }

        [Display(Name = "Building for map",
     Description = "The building that you select here will be used to show building location on the map")]
        public int BuildingsOnMap { get; set; }


        [Display(Name = "Close location",
     Description = "The building that you select here will be shown on the Area information close locations list")]
        public int CloseLocation { get; set; } 


        public bool PetsAreAllowed { get; set; }

        public string OpeningTimeWeekdays { get; set; }
        public string OpeningTimeWeekends { get; set; }
        public bool OpenedOnSundays { get; set; }


        public int LocationOnCampus { get; set; }


        //Additional information
        public int NumberOfStudents { get; set; }
        public int NumberOfStaffs { get; set; }
        public int NumberOfAwards { get; set; }
        public int NumberOfNewFacilities { get; set; }

        [Display(Name = "Students love",
   Description = "What students love about the dormitory")]

        public string WhatStudentsLove { get; set; }
    }




    public class LocalizedContent
    {
        [Display(Name = "Dormitory Name",
       Description = "Name of the dormotory"), DataType(DataType.Text), MaxLength(256)]
        public string DormitoryName { get; set; }

   

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

        public long DormitoryId { get; set; }
        [Display(Name = "Feature Category", Description = "The category of the feature, it may be under room feature category, bed type and so on")]
        public long FeatureCategory { get; set; }

        [Display(Name = "Feature", Description = "Feature name")]
        public long Feature { get; set; }


    }
}
