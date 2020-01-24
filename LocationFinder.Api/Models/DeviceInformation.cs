using System.ComponentModel.DataAnnotations.Schema;

namespace LocationFinder.Api.Models
{
    [Table(name: "nearme.deviceinformation")]
    public class DeviceInformation : BaseEntity
    {
        public string OsModel { get; set; }
        public string Model { get; set; }
        public string Uuid { get; set; }
        public string Osversion { get; set; }


    }
}
