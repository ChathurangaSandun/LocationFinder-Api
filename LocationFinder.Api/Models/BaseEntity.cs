using System.ComponentModel.DataAnnotations;

namespace LocationFinder.Api.Models
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
