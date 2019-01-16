using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Users
{
   public class UsersDormitory
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public long DormitoryId { get; set; }
        public UsersDormitory Dormitory { get; set; } 

    }
}
