using Dau.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.User;
using System.Linq;
using Dau.Data.Repository;

namespace Dau.Services.Domain.Users
{
   public class OnlineUsersService : IOnlineUsersService
    {
        private readonly IRepository<OnlineUsers> _onlineUsersRepository;

        public OnlineUsersService(IRepository<OnlineUsers> OnlineUsersRepository)
        {
            _onlineUsersRepository = OnlineUsersRepository;
        }

        public List<OnlineUsers> GetOnlineUsers()
        {
            var OnlineUsers = new List<OnlineUsers>();
            
            return _onlineUsersRepository.List().OrderByDescending(d => d.LastActivityTime).Where(t => t.LastActivityTime >= DateTime.Now).ToList();
        }


        public  void UpdateOnlineUserAsync(OnlineUsers user)
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
        }



    }
}
