using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFinder.Api.Models
{
    [Table(name: "nearme.organization")]
    public class Organization: BaseEntity
    {
        public string Name { get; set; }
        public string Details { get; set; }

        public  ICollection<Person> Persons { get; set; }

    }
}
