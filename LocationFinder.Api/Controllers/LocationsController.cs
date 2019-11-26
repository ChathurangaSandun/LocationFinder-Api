using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCoordinatePortable;
using LocationFinder.Api.DataModels;
using LocationFinder.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocationFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly PaperGeneration_TESTContext context;
        public LocationsController(PaperGeneration_TESTContext context)
        {
            this.context = context;
        }

        // GET api/values
        [HttpGet]
        [Route("{lat}/{lng}")]
        [Obsolete]
        public ActionResult<IEnumerable<Location>> GetByCity([FromRoute] float lat, [FromRoute] float lng, [FromQuery] int count = 3)
        { 

            var coord = new GeoCoordinate(lat,lng);
            var nearest = this.context.PersonalLocations.Select(x => new Location() { Point = new GeoCoordinate(x.Lat, x.Long), Name = x.Name, Address = x.Address, ImageUrl = x.ImageUrl, MobileNumber = x.MobileNumber })
                                   .OrderBy(x => x.Point.GetDistanceTo(coord)).Take(count).AsEnumerable();
            return Ok(nearest);
        }



        
    }
}
