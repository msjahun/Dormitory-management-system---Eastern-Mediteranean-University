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
}
