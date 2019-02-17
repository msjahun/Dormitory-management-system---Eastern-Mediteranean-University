using System.Collections.Generic;
using System.Threading.Tasks;
using Dau.Core.Domain.Users;

namespace Dau.Services.Domain.Users
{
    public interface IOnlineUsersService
    {
        List<OnlineUsers> GetOnlineUsers();
       Task UpdateOnlineUserAsync(OnlineUsers user);
    }
}