using Dau.Core.Domain.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Dau.Services.Domain.OnScrollAlertService
{
   public class OnScrollAlertService : IOnScrollAlertService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public OnScrollAlertService(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public List<onScrollAlert> GetOnScrollAlert()
        {

            
            // var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

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
                    Text="Check out the  {0}!, students are saying it's awesome",
                    Icon="fas fa-lock",
                    name="EMU explore page",
                    link="/Explore/Dormitories",
                    Color="alert-info"


                },
                new onScrollAlert
            {
                Text="Hi did you know you don't need creadit card to book a dormitory {0}!",
                Icon="fas fa-lock",
                name=" ",

                Color="alert-info"


            }
            };
            string userId = "";
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
   userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!string.IsNullOrEmpty(userId) && !string.IsNullOrWhiteSpace(userId))
            {
             
                var user = _userManager.Users.ToList().Where(c => c.Id == userId).FirstOrDefault();
                if (user != null)
                {

                    //if signed in 
                    modelList.Add(
                        new onScrollAlert
                        {
                            Text = "{0}!, you still haven't confirmed your booking, would you like to do it now",
                            Icon = "fas fa-lock",
                            name = user.FirstName,
                            Color = "alert-success",
                            link = "/Account/Billing"


                        });
                }
            }
            // or


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
