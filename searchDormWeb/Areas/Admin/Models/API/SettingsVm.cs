using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.API
{
    public class SettingsVm
    {

        [Display(Name = "Enable API",
        Description = "By checking this setting you can Enable/Disable the Web Api"),
      ]
        public bool EnableAPI { get; set; }


        [Display(Name = "Allow requests from swagger",
        Description = "Swagger is the documentation generation tool used for the API (/Swagger). It has a client that enables it to make GET requests to the API endpoints. By enabling this option you will allow all requests from the swagger client. Do not Enable on a live site, it i only for demo sites or local testing!!!"),
       ]
        public bool AllowRequestsFromSwagger { get; set; }

    }
}
