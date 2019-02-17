using Dau.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Users;
using System.Linq;
using Dau.Data.Repository;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Dau.Services.Domain.Users
{
   public class OnlineUsersService : IOnlineUsersService
    {
        private readonly IRepository<OnlineUsers> _onlineUsersRepository;
        private readonly UserManager<User> _userManager;
        private readonly Fees_and_facilitiesContext _dbContext;

        public OnlineUsersService(IRepository<OnlineUsers> OnlineUsersRepository, UserManager<User> userManager, Fees_and_facilitiesContext dbContext)
        {
            _onlineUsersRepository = OnlineUsersRepository;
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public List<OnlineUsers> GetOnlineUsers()
        {
            var OnlineUsers = new List<OnlineUsers>();
            
            return _onlineUsersRepository.List().OrderByDescending(d => d.LastActivityTime).Where(t => t.LastActivityTime >= DateTime.Now).ToList();
        }


        public async Task UpdateOnlineUserAsync(OnlineUsers user)
        {
            var userInDb = _onlineUsersRepository.List().Where(d => d.UserInfo == user.UserInfo && d.IpAddress == user.IpAddress).FirstOrDefault();
            if (userInDb != null)
            {


                //check if user already exist on the table,
                userInDb.LastActivityTime = DateTime.Now.AddMinutes(1);
                userInDb.LastVisitedPage = user.LastVisitedPage;
                _onlineUsersRepository.Update(userInDb);
               
            }
            else {
                //if user doesn't exist add user to the table
                user.LastActivityTime= DateTime.Now.AddMinutes(1);
                 _onlineUsersRepository.Insert(user);
             
                //if user exist update time, use ip address and userInfo for checking
            }

            if(user!=null && !string.IsNullOrEmpty(user.UserId))
            {
                var User = _userManager.Users.Where(c => c.Id == user.UserId).FirstOrDefault();
                if (User != null)
                {
                    User.LastActivityDateUtc = DateTime.UtcNow;
                //var result = await    _userManager.UpdateAsync(User);
                }
            }



        }



    }
}
