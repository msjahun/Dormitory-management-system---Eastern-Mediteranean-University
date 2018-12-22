using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Areas.Admin.Models.User
{
    public class UserListViewModel
    {

        public Dau.Core.Domain.Users.User User { get; set; }

       public List<String> userRoles { get; set; }
    }
}
