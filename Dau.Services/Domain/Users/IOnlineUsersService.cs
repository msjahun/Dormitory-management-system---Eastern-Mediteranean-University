using System.Collections.Generic;
using Dau.Core.Domain.Users;

namespace Dau.Services.Domain.Users
{
    public interface IOnlineUsersService
    {
        List<OnlineUsers> GetOnlineUsers();
        void UpdateOnlineUserAsync(OnlineUsers user);
    }
}