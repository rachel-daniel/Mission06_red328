using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_red328.Models
{
    public class MovieContext : DbContext
    {
        // create a constructor that inherits from the base class
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
            //leave blank for now
        }
        public DbSet<AddMovie> Movies { get; set; }


        // put some data entries into the model
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<AddMovie>().HasData(
                new AddMovie
                {
                    MovieId = 1,
                    Category = "Comedy",
                    Title = "Crazy Rich Asians",
                    Year = "2018",
                    Director = "John M. Chu",
                    Rating = "PG-13"
                },
                new AddMovie
                {
                    MovieId = 2,
                    Category = "Comedy",
                    Title = "The Proposal",
                    Year = "2009",
                    Director = "Anne Fletcher",
                    Rating = "PG-13"
                },
                new AddMovie
                {
                    MovieId = 3,
                    Category = "Family",
                    Title = "The Sound of Music",
                    Year = "1965",
                    Director = "Robert Wise",
                    Rating = "G"
                }
                );
        }
    }
}
