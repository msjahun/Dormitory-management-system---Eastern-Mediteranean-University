using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dau.Core.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;
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

      

        public Charts GetnewCustomersChart(long id)
        {


            if (id == 1)
            {
                //per week
                var data = NewUsersPerWeekAllCode(DateTime.Now.AddDays(1), DateTime.Now.AddDays(-7));
                return data;
            }
            else if (id == 2)
            {
                //per month
                var data = NewUsersPerMonthAllCode(DateTime.Now.AddDays(1), DateTime.Now.AddMonths(-1));
                return data;
            }
            else
            {
                //per year
                var data = NewUsersPerYearAllCode(DateTime.Now.AddMonths(1), DateTime.Now.AddYears(-1));
                return data;
            }

        }



        private int NewUsersPerWeekCounter(DateTime baselineDate)
        {
            var count = _userManager.Users.ToList().Where(x => x.CreatedOnUtc .ToString("d dddd") == baselineDate.ToString("d dddd")).Count();
            return count;
        }

        private Charts NewUsersPerWeekAllCode(DateTime EndDate, DateTime startDate)
        {

            var dates = new List<DateTime>();
            var Labels = new List<string>();
            var Data = new List<int>();

            for (var dt = startDate; dt <= EndDate; dt = dt.AddDays(1))
            {
                Labels.Add(dt.ToString("d dddd"));
                Data.Add(NewUsersPerWeekCounter(dt));
            }

            var data = new Charts
            {
                Labels = Labels,
                Data = Data,

            };

            return data;
        }

        private int NewUsersPerMonthCounter(DateTime baselineDate)
        {
            var count = _userManager.Users.ToList().Where(x => x.CreatedOnUtc.ToString("MMMM d") == baselineDate.ToString("MMMM d")).Count();
            return count;
        }

        private Charts NewUsersPerMonthAllCode(DateTime EndDate, DateTime startDate)
        {

            var dates = new List<DateTime>();
            var Labels = new List<string>();
            var Data = new List<int>();

            for (var dt = startDate; dt <= EndDate; dt = dt.AddDays(1))
            {
                Labels.Add(dt.ToString("MMMM d"));
                Data.Add(NewUsersPerMonthCounter(dt));
            }

            var data = new Charts
            {
                Labels = Labels,
                Data = Data,

            };

            return data;
        }

        private int NewUsersPerYearCounter(DateTime baselineDate)
        {
            var count = _userManager.Users.ToList().Where(x => x.CreatedOnUtc.ToString("MMMM yyyy") == baselineDate.ToString("MMMM yyyy")).Count();
            return count;
        }

        private Charts NewUsersPerYearAllCode(DateTime EndDate, DateTime startDate)
        {

            var dates = new List<DateTime>();
            var Labels = new List<string>();
            var Data = new List<int>();

            for (var dt = startDate; dt <= EndDate; dt = dt.AddMonths(1))
            {
                Labels.Add(dt.ToString("MMMM yyyy"));
                Data.Add(NewUsersPerYearCounter(dt));
            }

            var data = new Charts
            {
                Labels = Labels,
                Data = Data,

            };

            return data;
        }

        public async Task<AccountProfileVm> GetUserDetailsAsync(string userId)
        {

           var User = await _userManager.FindByIdAsync(userId);

            if (User == null)
                return null;

            var model = new AccountProfileVm
            {
                StudentNumber = User.StudentNumber,
                FirstName = User.FirstName,
                LastName = User.LastName,
                DateOfBirth = User.DateOfBirth,
                Gender = User.GenderId,
                Email = User.Email,
                PhoneNumber = User.PhoneNumber,
                Address = User.ParmanentAddress,
                CountryId = User.CountryId,
                City = User.City



            };

            return model;
        }

        public async Task<bool> UpdateUserInfoAsync(string userId,AccountProfileVm vm)
        {
            try
            {
                var User = await _userManager.FindByIdAsync(userId);
                if (User == null) return false;

                User.StudentNumber = vm.StudentNumber;
                User.FirstName = vm.FirstName;
                User.LastName = vm.LastName;
                User.GenderId = vm.Gender;
                User.PhoneNumber = vm.PhoneNumber;
                User.ParmanentAddress = vm.Address;
                User.City = vm.City;
                User.CountryId = vm.CountryId;

                    await _userManager.UpdateAsync(User);

                return true;
            }
            catch(Exception e)
            {
                return false;
            }


        }
    }




    public class AccountProfileVm
    {
        public bool SavedSuccessfully { get; set; }
        public string SuccessMessage { get; set; }

        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Address { get; set; }
        public string City { get; set; }


        public int CountryId { get; set; }


        public bool SetPassword { get; set; }
        //[Required]
        public string OldPassword { get; set; }

        //[Required, MinLength(6), MaxLength(50), DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }

        //[Required, MinLength(6), MaxLength(50), DataType(DataType.Password), Display(Name = "Confirm Password")]
        // [Compare("Password", ErrorMessage = "The password does not match the confirmation password.")]
        public string ConfirmPassword { get; set; }
    }

}
