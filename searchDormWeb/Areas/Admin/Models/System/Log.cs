using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.System
{
    public class LogVm
    {

        [Display(Name = "Created from",
        Description = "The creation from date for the search."),
        DataType(DataType.Date),
        MaxLength(256)]
        public DateTime CreatedFrom { get; set; }


        [Display(Name = "Created to",
        Description = "The creatino to date fro the serach."),
        DataType(DataType.Date),
        MaxLength(256)]
        public DateTime CreatedTo { get; set; }

        [Display(Name = "Message",
        Description = "Message."),
        DataType(DataType.Text),
        MaxLength(256)]
        public string Message { get; set; }

        [Display(Name = "Log level",
        Description = "Select a log level"),
        MaxLength(256)]
        public int LogLevel { get; set; }

    }

    public class LogView
    {
        [Display(Name = "Log Level",
        Description = "The level of log entity."), DataType(DataType.Text), MaxLength(256)]
        public string LogLevel { get; set; }




        [Display(Name = "Short Message",
        Description = "The log entry message."), DataType(DataType.Text), MaxLength(256)]
        public string ShortMessage { get; set; }



        [Display(Name = "Full Message",Description = "The details of the log entry."), DataType(DataType.Text), MaxLength(256)]
        public string FullMessage { get; set; }



        [Display(Name = "Ip Address",
        Description = "Ip address of the machine that caused the exception."), DataType(DataType.Text), MaxLength(256)]
        public string IpAddress { get; set; }



        [Display(Name = "Customer",
        Description = "Name of the customer who caused the exception."), DataType(DataType.Text), MaxLength(256)]
        public string Customer { get; set; }



        [Display(Name = "Page Url",
        Description = "Originating page exception."), DataType(DataType.Text), MaxLength(256)]
        public string PageUrl { get; set; }


        [Display(Name = "Referrer Url",
        Description = "The referrer URL."), DataType(DataType.Text), MaxLength(256)]
        public string ReferrerUrl { get; set; }


        [Display(Name = "Created On",
        Description = "Date/Time the log entry was created."), DataType(DataType.Text), MaxLength(256)]
        public string CreatedOn { get; set; }

    }
}
       

