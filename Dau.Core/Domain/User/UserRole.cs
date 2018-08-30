using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.User
{
   public class UserRole : IdentityRole 
    {

        public string Access { get; set; }
        public bool IsSystemRole { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
