using Dau.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchDormWeb.Configuration
{
    public class UserRoleSeed
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRoleSeed(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        //this is our seed, if guest doesn't exist we'll create it here
        public async void Seed()
        {
            //if ((await _roleManager.FindByNameAsync("Guest"))== null)
            //{
            //  await  _roleManager.CreateAsync(new IdentityRole { Name = "Guest" });
            //}


            //if ((await _roleManager.FindByNameAsync("Administrator")) == null)
            //{
            //    await _roleManager.CreateAsync(new IdentityRole { Name = "Administrator" });
            //}

            if ((await _roleManager.FindByNameAsync("Dormitorymanager")) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Dormitorymanager" });
            }

        }
    }
}
