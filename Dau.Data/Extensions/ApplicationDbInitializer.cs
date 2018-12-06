using Dau.Core.Domain.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Extensions
{
    public static class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<User> userManager)
        {
            if (userManager.FindByEmailAsync("Admin@emu.edu.tr").Result == null)
            {
                User user = new User
                {
                    UserName = "Admin@emu.edu.tr",
                    Email = "Admin@emu.edu.tr"
                };

                IdentityResult result = userManager.CreateAsync(user, "Administrator").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }
    }
}
