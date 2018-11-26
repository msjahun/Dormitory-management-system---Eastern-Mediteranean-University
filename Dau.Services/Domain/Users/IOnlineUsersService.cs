using System.Collections.Generic;
using Dau.Core.Domain.User;

namespace Dau.Services.Domain.Users
{
    public interface IOnlineUsersService
    {
        List<OnlineUsers> GetOnlineUsers();
        void UpdateOnlineUserAsync(OnlineUsers user);
    }
}