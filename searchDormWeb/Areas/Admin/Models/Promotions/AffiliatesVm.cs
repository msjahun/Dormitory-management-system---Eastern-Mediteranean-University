using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Promotions
{
    public class AffiliatesVm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FriendlyURLName { get; set; }
        public bool LoadOnlyWithOrders { get; set; }


    }
}
