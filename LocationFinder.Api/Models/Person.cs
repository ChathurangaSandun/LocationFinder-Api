using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocationFinder.Api.Models
{
    [Table(name: "nearme.person")]
    public class Person : BaseEntity
    {
        public Person()
        {
            PointLocations = new HashSet<PointLocation>();
        }
        
        public long OrganizationId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string ImageUri { get; set; }
        public Organization Organization { get; set; }

        public ICollection<PointLocation> PointLocations { get; set; }

    }
}
