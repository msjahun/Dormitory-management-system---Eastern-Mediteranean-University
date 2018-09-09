using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Promotions
{
    public class NewsLetterSubscribersVm
    {

            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string Email { get; set; }
            public int Active { get; set;  }
            public int CustomerRoles { get; set; }


    }
}
