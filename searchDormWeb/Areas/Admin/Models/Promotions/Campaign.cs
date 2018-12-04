using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Promotions
{
    public class CampaignAdd
    {
        [Display(Name = "Allowed Tokens",
      Description = "This is a list of the message tokens you can use in your campaign emails."), DataType(DataType.Text), MaxLength(256)]
        public string AllowedTokens { get; set; }

        [Display(Name = "Name",
        Description = "Name of your compaign."), DataType(DataType.Text), MaxLength(256)]
        public string Name { get; set; }

        [Display(Name = "Subject",
        Description = "The subject of your campaign"), DataType(DataType.Text), MaxLength(256)]
        public string Subject { get; set; }

        [Display(Name = "Body",
        Description = "The body of your campaign"), DataType(DataType.Text), MaxLength(256)]
        public string Body { get; set; }

        [Display(Name = "Planned Date Of Sending",
        Description = "Enter a specific date and time to send the campaign.Leave empty to send it immediately.")]
        public DateTime PlannedDateOfSending { get; set; }

        [Display(Name = "Limited To Customer Role",
        Description = "Choose a customer role to which this email will be sent."), MaxLength(256)]
        public int LimitedToCustomerRole { get; set; }

    }

    public class CampaignEdit
    {
        [Display(Name = "Allowed Tokens",
  Description = "This is a list of the message tokens you can use in your campaign emails."), DataType(DataType.Text), MaxLength(256)]
        public string AllowedTokens { get; set; }

        [Display(Name = "Email Account",
        Description = "The email account that will be used to send this campaign."), MaxLength(256)]
        public int EmailAccount { get; set; }

        [Display(Name = "Send Test Email To",
        Description = "The email address to which you want to send your test email."), DataType(DataType.Text), MaxLength(256)]
        public string SendTestEmailTo { get; set; }

        [Display(Name = "Name",
        Description = "The name of this campaign."), DataType(DataType.Text), MaxLength(256)]
        public string Name { get; set; }

        [Display(Name = "Subject",
        Description = "The subject of your campaign"), DataType(DataType.Text), MaxLength(256)]
        public string Subject { get; set; }

        [Display(Name = "Body",
        Description = "The body of your campaign"), DataType(DataType.Text), MaxLength(256)]
        public string Body { get; set; }

        [Display(Name = "Planned Date Of Sending",
        Description = "Enter a specific date and time to send the campaign.Leave empty to send it immediately.")]
        public DateTime PlannedDateOfSending { get; set; }

        [Display(Name = "Limited To Customer Role",
        Description = "Choose a customer role to which this email will be sent."), MaxLength(256)]
        public int LimitedToCustomerRole { get; set; }

    }

}
