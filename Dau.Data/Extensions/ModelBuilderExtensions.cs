using Dau.Core.Domain.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        private static RoleManager<UserRole> _roleManager;

        //public static void Init(RoleManager<UserRole> roleManager)
        //{
        //    _roleManager = roleManager;
        //}

        public static void Seed(this ModelBuilder modelBuilder)
        {
           

            ////create user role and redirect to edit_userRole page
            //var role = new UserRole();
            //role.Name = "Registered";
            //role.Access = "[{\"Id\":\":\",\"Name\":\"\",\"DisplayName\":null,\"AreaName\":\"\",\"Actions\":[]}]";
            //role.IsActive = true;
            //role.IsSystemRole = true;
            //_roleManager.CreateAsync(role);

            //role = new UserRole();
            //role.Name = "ADMINISTRATOR";
            //role.Access = "[{\"Id\":\":\",\"Name\":\"\",\"DisplayName\":null,\"AreaName\":\"\",\"Actions\":[]}]";
            //role.IsActive = true;
            //role.IsSystemRole = true;
            //_roleManager.CreateAsync(role);

            // role = new UserRole();
            //role.Name = "DORMITORY ADMINISTRATOR";
            //role.Access = "[{\"Id\":\":\",\"Name\":\"\",\"DisplayName\":null,\"AreaName\":\"\",\"Actions\":[]}]";
            //role.IsActive = true;
            //role.IsSystemRole = true;
            //_roleManager.CreateAsync(role);
            //put all your seed data here,

            //One user name and password for login
            //language and other stuff
            //modelBuilder.Entity<Author>().HasData(
            //    new Author
            //    {
            //        AuthorId = 1,
            //        FirstName = "William",
            //        LastName = "Shakespeare"
            //    }
            //);
            //modelBuilder.Entity<Book>().HasData(
            //    new Book { BookId = 1, AuthorId = 1, Title = "Hamlet" },
            //    new Book { BookId = 2, AuthorId = 1, Title = "King Lear" },
            //    new Book { BookId = 3, AuthorId = 1, Title = "Othello" }
            //);



        }
    }
}
