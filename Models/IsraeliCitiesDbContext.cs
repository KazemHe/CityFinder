using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; // Entity Framework 6.x namespace

namespace CityFinder.Models
{
    public class IsraeliCitiesDbContext : DbContext // Inherit from EF 6.x DbContext
    {
        // Constructor to configure the context
        public IsraeliCitiesDbContext()
            : base("name=DefaultConnection") // Connection string name
        {
        }

        // DbSet to represent the Cities table in the database
        public DbSet<City> Cities { get; set; }
    }
}
