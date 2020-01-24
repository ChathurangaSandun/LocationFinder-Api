
using LocationFinder.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
namespace LocationFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly NearmeDataContext context;
        private readonly IConfiguration configuration;

        public DevicesController(NearmeDataContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task RegisterDevice([FromBody] DeviceInformation deviceInformation)
        {
            // register device 
            await this.context.DeviceInformations.AddAsync(deviceInformation);
            await this.context.SaveChangesAsync();

            var org = configuration.GetValue<string>("Organization").ToString();
            await this.context.OrganizationDevices.AddAsync(new OrganizationDevice()
            {
                DeviceId = deviceInformation.Id,
                OrganizationId = int.Parse(org)
            });
            await this.context.SaveChangesAsync();



        }
    }
}