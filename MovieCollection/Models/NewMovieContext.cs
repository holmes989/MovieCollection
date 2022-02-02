using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class NewMovieContext : DbContext
    {
        public NewMovieContext(DbContextOptions<NewMovieContext> options) : base(options)
        {

        }

        public DbSet<ApplicationResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                    new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                    new Category { CategoryId = 2, CategoryName = "Comedy" },
                    new Category { CategoryId = 3, CategoryName = "Drama" },
                    new Category { CategoryId = 4, CategoryName = "Family" },
                    new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                    new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                    new Category { CategoryId = 7, CategoryName = "Television" },
                    new Category { CategoryId = 8, CategoryName = "VHS" }
                );
            mb.Entity<ApplicationResponse>().HasData(

                    new ApplicationResponse
                    {
                        MovieId = 1,
                        CategoryId = 2,
                        Title = "Better Off Dead",
                        Year = 1985,
                        Director = "Savage Steve Holland",
                        Rating = "PG",
                        Edited = false,
                        LentTo = "",
                        Notes = ""
                    },
                    new ApplicationResponse
                    {
                        MovieId = 2,
                        CategoryId = 3,
                        Title = "La La Land",
                        Year = 2016,
                        Director = "Damien Chazelle",
                        Rating = "PG-13",
                        Edited = false,
                        LentTo = "",
                        Notes = ""
                    },
                    new ApplicationResponse
                    {
                        MovieId = 3,
                        CategoryId = 4,
                        Title = "Home Alone",
                        Year = 1990,
                        Director = "Christ Columbus",
                        Rating = "PG",
                        Edited = false,
                        LentTo = "",
                        Notes = ""
                    }
                );
        }
    }
}
