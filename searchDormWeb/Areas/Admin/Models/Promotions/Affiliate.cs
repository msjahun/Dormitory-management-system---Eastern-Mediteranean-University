using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Promotions
{
    public class AffiliatesVm
    {

        [Display(Name = "First name",
        Description = "Search by a first name."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string FirstName { get; set; }

        [Display(Name = "Last name",
        Description = "Search by a last name."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string LastName { get; set; }

        [Display(Name = "Friendly Url name",
        Description = "Search by a friendly url name."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string FriendlyURLName { get; set; }


        [Display(Name = "Load only with orders",
        Description = "Check to load affiliates only with orders placed (by affiliated customers).")]
        public bool LoadOnlyWithOrders { get; set; }


    }

    public class AffiliateAdd
    {
        [Display(Name = "Acive",
        Description = "A value indicating whether the affiliate is active.")]
        public bool Acive { get; set; }

        [Display(Name = "FirstName",
        Description = "Enter first name"), DataType(DataType.Text), MaxLength(256)]
        public string FirstName { get; set; }

        [Display(Name = "LastName",
        Description = "Enter last name"), DataType(DataType.Text), MaxLength(256)]
        public string LastName { get; set; }

        [Display(Name = "Email",
        Description = "Enter email"), DataType(DataType.Text), MaxLength(256)]
        public string Email { get; set; }

        [Display(Name = "Company",
        Description = "Enter company name"), DataType(DataType.Text), MaxLength(256)]
        public string Company { get; set; }

        [Display(Name = "Country",
        Description = "Select country"), MaxLength(256)]
        public int Country { get; set; }

        [Display(Name = "StateProvince",
        Description = "Select state/province"), MaxLength(256)]
        public int StateProvince { get; set; }

        [Display(Name = "City",
        Description = "Enter City"), DataType(DataType.Text), MaxLength(256)]
        public string City { get; set; }

        [Display(Name = "Address1",
        Description = "Enter Address 1"), DataType(DataType.Text), MaxLength(256)]
        public string Address1 { get; set; }

        [Display(Name = "Address2",
        Description = "Enter Address 2"), DataType(DataType.Text), MaxLength(256)]
        public string Address2 { get; set; }

        [Display(Name = "ZipPostalCode",
        Description = "Enter Zip/Postal code"), DataType(DataType.Text), MaxLength(256)]
        public string ZipPostalCode { get; set; }

        [Display(Name = "PhoneNumber",
        Description = "Enter Phone number"), DataType(DataType.Text), MaxLength(256)]
        public string PhoneNumber { get; set; }

        [Display(Name = "FaxNumber",
        Description = "Enter Fax number"), DataType(DataType.Text), MaxLength(256)]
        public string FaxNumber { get; set; }

        [Display(Name = "AdminComment",
        Description = "Admin comment.For internal use."), DataType(DataType.Text), MaxLength(256)]
        public string AdminComment { get; set; }

        [Display(Name = "FriendlyUrlName",
        Description = "A friendly name for generated affiliate URL(by default affiliate ID is used). It's more friendly for marketing purposes. Leave empty to use affiliate identifier."), DataType(DataType.Text), MaxLength(256)]
        public string FriendlyUrlName { get; set; }

        [Display(Name = "AffiliateURL",
        Description = "When this hyperlink is clicked from the affiliate site, this site looks for an Affiliate ID query string parameter. If one exists, the customer is tagged with that affiliate."), DataType(DataType.Text), MaxLength(256)]
        public string AffiliateURL { get; set; }




    }

    public class AffiliateEdit
    {
        [Display(Name = "Acive",
        Description = "A value indicating whether the affiliate is active.")]
        public bool Acive { get; set; }

        [Display(Name = "FirstName",
        Description = "Enter first name"), DataType(DataType.Text), MaxLength(256)]
        public string FirstName { get; set; }


        [Display(Name = "LastName",
        Description = "Enter last name"), DataType(DataType.Text), MaxLength(256)]
        public string LastName { get; set; }


        [Display(Name = "Email",
        Description = "Enter email"), DataType(DataType.Text), MaxLength(256)]
        public string Email { get; set; }


        [Display(Name = "Company",
        Description = "Enter company name"), DataType(DataType.Text), MaxLength(256)]
        public string Company { get; set; }


        [Display(Name = "Country",
        Description = "Select country"), MaxLength(256)]
        public int Country { get; set; }


        [Display(Name = "StateProvince",
        Description = "Select state/province"), MaxLength(256)]
        public int StateProvince { get; set; }


        [Display(Name = "City",
        Description = "Enter City"), DataType(DataType.Text), MaxLength(256)]
        public string City { get; set; }


        [Display(Name = "Address1",
        Description = "Enter Address 1"), DataType(DataType.Text), MaxLength(256)]
        public string Address1 { get; set; }


        [Display(Name = "Address2",
        Description = "Enter Address 2"), DataType(DataType.Text), MaxLength(256)]
        public string Address2 { get; set; }


        [Display(Name = "ZipPostalCode",
        Description = "Enter Zip/Postal code"), DataType(DataType.Text), MaxLength(256)]
        public string ZipPostalCode { get; set; }


        [Display(Name = "PhoneNumber",
        Description = "Enter Phone number"), DataType(DataType.Text), MaxLength(256)]
        public string PhoneNumber { get; set; }


        [Display(Name = "FaxNumber",
        Description = "Enter Fax number"), DataType(DataType.Text), MaxLength(256)]
        public string FaxNumber { get; set; }


        [Display(Name = "AdminComment",
        Description = "Admin comment.For internal use."), DataType(DataType.Text), MaxLength(256)]
        public string AdminComment { get; set; }


        [Display(Name = "FriendlyUrlName",
        Description = "A friendly name for generated affiliate URL(by default affiliate ID is used). It's more friendly for marketing purposes. Leave empty to use affiliate identifier."), DataType(DataType.Text), MaxLength(256)]
        public string FriendlyUrlName { get; set; }


    }


    public class AffilatedCustomersTable
    {
 public string Id {get; set;}
 public string Name {get; set;}
 public string View { get; set; }

    }

    public class AffiliatedBookingsTable
    {
public string OrderNo { get; set; }
public string OrderStatus {get; set;}
public string PaymentStatus {get; set;}
public string OrderTotal {get; set;}
public string CreatedOn {get; set;}
public string View {get; set;}

    }


    public class AffiliatedBookingsTab
    {
        [Display(Name = "StartDate",
      Description = "")]
        public DateTime StartDate {get; set;}

        [Display(Name = "EndDate",
      Description = "")]
        public DateTime EndDate {get; set;}


        [Display(Name = "BookingStatus",
            Description = "")]
        public int BookingStatus { get; set; }

    }

}
