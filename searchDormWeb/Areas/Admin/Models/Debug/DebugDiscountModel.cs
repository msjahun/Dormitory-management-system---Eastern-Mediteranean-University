using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.Debug
{
    public class DebugDiscountModel
    {
     public int   DiscountId { get; set; }
       public string Namee{ get; set; }
         public string DiscountType{ get; set; }
        public string Discount{ get; set; }
        public DateTime StartDate{ get; set; }
        public DateTime EndDate{ get; set; }
    public int TimesUsed{ get; set; }
                                   
    }
}
