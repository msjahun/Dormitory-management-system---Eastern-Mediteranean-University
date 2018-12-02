using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
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
