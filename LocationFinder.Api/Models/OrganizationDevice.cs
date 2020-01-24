using System.ComponentModel.DataAnnotations.Schema;

namespace LocationFinder.Api.Models
{
    [Table(name: "nearme.organizationdevice")]
    public class OrganizationDevice : BaseEntity
    {

        [ForeignKey("Organization")]
        public long OrganizationId { get; set; }

        [ForeignKey("DeviceInformation")]
        public long DeviceId { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual DeviceInformation DeviceInformation { get; set; }
    }
}
