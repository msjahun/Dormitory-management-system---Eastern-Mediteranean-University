using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Domain.OnScrollAlertService
{
   public class OnScrollAlertService : IOnScrollAlertService
    {
        public List<onScrollAlert> GetOnScrollAlert()
        {
            List<onScrollAlert> modelList = new List<onScrollAlert>
            {
                new onScrollAlert
            {
                Text="Someone just booked a room from {0}!, book yours now",
                Icon="fas fa-lock",
                name="Alfam Dormitory",
                link="/Dormitories/Akdeniz-private-Studio",
                Color="alert-danger"


            },
                new onScrollAlert
            {
                Text="Would you like to partake in a {0} survey?!",
            Icon="fas fa-lock",
                name="Student feedback",
                link="/Account/Billing",
                Color="alert-success"


            },
                new onScrollAlert
            {
                Text="{0}!, you still haven't confirmed your booking, would you like to do it now",
                Icon="fas fa-lock",
                name="Musa",
                Color="alert-success",
                 link="/Account/Billing"


            },
                new onScrollAlert
            {
                Text="Check out the  {0}!, students are saying it's awesome",
                Icon="fas fa-lock",
                name="EMU explore page",
                link="/Explore/Dormitories",
                Color="alert-info"


            },       new onScrollAlert
            {
                Text="Hi did you know you don't need creadit card to book a dormitory {0}!",
                Icon="fas fa-lock",
                name=" ",

                Color="alert-info"


            }
            };

            return modelList;
        }
    }

    public class onScrollAlert
    {
        public string Text { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
    }
}
