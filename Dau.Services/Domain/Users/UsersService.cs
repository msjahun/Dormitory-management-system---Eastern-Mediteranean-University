using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dau.Core.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Dau.Services.Users
{
   public class UsersService : IUsersService
    {
        private readonly UserManager<User> _userManager;

        public UsersService(UserManager<User> userManager)
        {
            _userManager = userManager;

        }


        public string GetFirstName(string id)
        {
          return  _userManager.Users.Where(c => c.Id == id).FirstOrDefault().FirstName.ToString();
        }



        public string GetLastName(string id)
        {
            return _userManager.Users.Where(c => c.Id == id).FirstOrDefault().LastName.ToString();
        }

        public string GetFirstLastNames(string id)
        {
           return GetFirstName( id) +" "+ GetLastName(id);
        }

        public string GetUserPhotoUrl(string id)
        {
            var userImage = from user in _userManager.Users.ToList()
                            where user.Id == id && user.UserImageUrl != null
                            select user;

            if (userImage.FirstOrDefault() == null)
                return null;
            else
                return userImage.FirstOrDefault().UserImageUrl;
        }

        public int GetTotalNumberOfUser()
        {
            return _userManager.Users.ToList().Count;
        }
    }
}
