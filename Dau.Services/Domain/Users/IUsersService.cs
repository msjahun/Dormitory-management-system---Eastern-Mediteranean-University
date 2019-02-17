using System.Threading.Tasks;

namespace Dau.Services.Users
{
    public interface IUsersService
    {
        string GetFirstLastNames(string id);
        string GetFirstName(string id);
        string GetLastName(string id);
        string GetUserPhotoUrl(string id);
       int GetTotalNumberOfUser();
       Charts GetnewCustomersChart(long id);
        Task<AccountProfileVm> GetUserDetailsAsync(string userId);
        Task<bool> UpdateUserInfoAsync(string userId, AccountProfileVm vm);
       // object UpdateUserUserPassword(string userId, AccountProfileVm vm);
    }
}