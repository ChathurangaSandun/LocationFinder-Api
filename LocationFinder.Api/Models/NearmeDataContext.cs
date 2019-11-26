using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFinder.Api.Models
{
    public class NearmeDataContext: DbContext
    {
        public NearmeDataContext(DbContextOptions<NearmeDataContext> options)
       : base(options)
        { }

        public DbSet<Organization> Organizations{ get; set; }
        public DbSet<Person> Persons{ get; set; }
        public DbSet<PointLocation> PointLocations { get; set; }
    }
}
