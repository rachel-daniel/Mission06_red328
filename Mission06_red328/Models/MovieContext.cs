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
        public DbSet<Category> Categories { get; set; }


        // put some data entries into the model
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID=1, CategoryName="Action/Adventure"},
                new Category { CategoryID=2, CategoryName="Comedy"},
                new Category { CategoryID=3, CategoryName="Drama"},
                new Category { CategoryID=4, CategoryName="Family"},
                new Category { CategoryID=5, CategoryName="Horror"},
                new Category { CategoryID=6, CategoryName= "Miscellaneous" },
                new Category { CategoryID=7, CategoryName="Television"},
                new Category { CategoryID=8, CategoryName="VHS"}
                );
            
            mb.Entity<AddMovie>().HasData(
                new AddMovie
                {
                    MovieId = 1,
                    CategoryID = 2,
                    Title = "Crazy Rich Asians",
                    Year = "2018",
                    Director = "John M. Chu",
                    Rating = "PG-13"
                },
                new AddMovie
                {
                    MovieId = 2,
                    CategoryID = 2,
                    Title = "The Proposal",
                    Year = "2009",
                    Director = "Anne Fletcher",
                    Rating = "PG-13"
                },
                new AddMovie
                {
                    MovieId = 3,
                    CategoryID = 4,
                    Title = "The Sound of Music",
                    Year = "1965",
                    Director = "Robert Wise",
                    Rating = "G"
                }
                );
        }
    }
}
