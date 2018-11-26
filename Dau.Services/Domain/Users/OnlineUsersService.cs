using Dau.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.User;
using System.Linq;

namespace Dau.Services.Domain.Users
{
   public class OnlineUsersService : IOnlineUsersService
    {
        private Fees_and_facilitiesContext _context = new Fees_and_facilitiesContext();


        public List<OnlineUsers> GetOnlineUsers()
        {
            var OnlineUsers = new List<OnlineUsers>();
           return _context.OnlineUsers.OrderByDescending(d => d.LastActivityTime).Where(t => t.LastActivityTime >= DateTime.Now).ToList();
        }


        public async void UpdateOnlineUserAsync(OnlineUsers user)
        {
            var userInDb = _context.OnlineUsers.Where(d => d.UserInfo == user.UserInfo && d.IpAddress == user.IpAddress).FirstOrDefault();
            if (userInDb != null)
            {


                //check if user already exist on the table,
                userInDb.LastActivityTime = DateTime.Now.AddMinutes(1);
                userInDb.LastVisitedPage = user.LastVisitedPage;
                _context.OnlineUsers.Update(userInDb);
                await _context.SaveChangesAsync();
            }
            else {
                //if user doesn't exist add user to the table
                user.LastActivityTime= DateTime.Now.AddMinutes(1);
                _context.OnlineUsers.Add(user);
                await _context.SaveChangesAsync();
                //if user exist update time, use ip address and userInfo for checking
            }
        }



    }
}
