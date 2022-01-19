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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(

                    new ApplicationResponse
                    {
                        MovieId = 1,
                        Category = "Comedy",
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
                        Category = "Drama",
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
                        Category = "Family",
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
