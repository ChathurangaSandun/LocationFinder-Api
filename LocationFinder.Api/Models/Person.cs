using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFinder.Api.Models
{
    [Table(name:"nearme.person")]
    public class Person: BaseEntity
    {
        public long OrganizationId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }

        [ForeignKey("PointLocation")]
        public long PointLocatioId { get; set; }
        public  PointLocation PointLocation { get; set; }
        public  Organization Organization { get; set; }

    }
}
