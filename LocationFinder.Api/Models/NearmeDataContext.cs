
using Microsoft.EntityFrameworkCore;

namespace LocationFinder.Api.Models
{
    public class NearmeDataContext : DbContext
    {
        public NearmeDataContext(DbContextOptions<NearmeDataContext> options)
       : base(options)
        { }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PointLocation> PointLocations { get; set; }
        public DbSet<DeviceInformation> DeviceInformations { get; set; }
        public DbSet<OrganizationDevice> OrganizationDevices { get; set; }
    }
}
