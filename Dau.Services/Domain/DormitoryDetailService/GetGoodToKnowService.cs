using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Domain.DormitoryDetailService
{
   public class GetGoodToKnowService : IGetGoodToKnowService
    {

        public GoodToKnowSectionViewModel GetGoodToKnowInfo()
        {
            GoodToKnowSectionViewModel model = new GoodToKnowSectionViewModel
            {
                WeekdaysOpeningTime = new OpeningClosingTime
                {
                    OpeningTime = 9,
                    ClosingTime = 18
                },
                WeekendsOpeningTime = new OpeningClosingTime
                {
                    OpeningTime = 11,
                    ClosingTime = 14
                },
                OtherInfosList = new List<GoodToKnowTitleValue>
                { new GoodToKnowTitleValue
                    {
                    Icon="fas fa-paw",
                        Title="Pets",
                        Value="Pets are not allowed"
                    }
                }
            };

            return model;
        }
    }


    public class GoodToKnowSectionViewModel
    {
        public OpeningClosingTime WeekdaysOpeningTime { get; set; }
        public OpeningClosingTime WeekendsOpeningTime { get; set; }
        public List<GoodToKnowTitleValue> OtherInfosList { get; set; }
    }

    public class OpeningClosingTime
    {
        public int OpeningTime { get; set; }
        public int ClosingTime { get; set; }
    }
    public class GoodToKnowTitleValue
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
    }
}
