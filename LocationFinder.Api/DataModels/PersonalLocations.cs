using System;
using System.Collections.Generic;

namespace LocationFinder.Api.DataModels
{
    public partial class PersonalLocations
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
        public string MobileNumber { get; set; }
        public string ImageUrl { get; set; }
    }
}
