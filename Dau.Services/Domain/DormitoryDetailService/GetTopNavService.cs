using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Domain.DormitoryDetailService
{
   public class GetTopNavService : IGetTopNavService
    {
        public TopNavDormitorySectionViewModel GetTopNav()
        {
            TopNavDormitorySectionViewModel model = new TopNavDormitorySectionViewModel
            {
                DormitoryName = "Alfam Dormitory EMU University",
                DormitoryStreetAddress = "EMU charles Darwin street",
                DormitoryType = "Dormitory belongs to the category of private school dormitories/ accomodations (BOT),",
                DormitoryLogoUrl = "https://is5-ssl.mzstatic.com/image/thumb/Purple118/v4/18/c4/73/18c473bc-cd1c-4e6e-4ba0-4a9afcae1fc4/source/512x512bb.jpg"
            };

            return model; }
    }


    public class TopNavDormitorySectionViewModel
    {
        public string DormitoryName { get; set; }
        public string DormitoryStreetAddress { get; set; }
        public string DormitoryType { get; set; }
        public string DormitoryLogoUrl { get; set; }

    }

}
