using Dau.Core.Domain.User;
using Dau.Services.Domain.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dau.Services.Middleware
{
    public class OnlineUsersMiddleware : IMiddleware
    {
        private readonly IOnlineUsersService _onlineUsersService;
        private readonly UserManager<User> _userManager;

        public OnlineUsersMiddleware(UserManager<User> userManager, IOnlineUsersService onlineUsersService)
        {
            _onlineUsersService = onlineUsersService;
            _userManager = userManager;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var user = context.User;


            string name = context.User.Identity.Name;
            if(name=="")
            {
                name = "Guest";
            }
            var url = context.Request.Path;
            var remoteIpAddress = context.Connection.RemoteIpAddress;

            var OnlineUser = new OnlineUsers() {
                IpAddress = remoteIpAddress.ToString(),
                LastVisitedPage = url,
                UserInfo = name,
                Location=" ",
                LastActivity=" ",
                LastActivityTime= DateTime.Now.AddMinutes(5)

        };

            _onlineUsersService.UpdateOnlineUserAsync(OnlineUser);
            
           

            //input the data in the online users table, as with 5mins time and ip address
       
            await next(context);
        }
    }
}
