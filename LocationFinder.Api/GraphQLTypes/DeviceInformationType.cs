using GraphQL.Types;
using LocationFinder.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFinder.Api.GraphQLTypes
{
    public class DeviceInformationType : ObjectGraphType<DeviceInformation>
    {
        public DeviceInformationType()
        {
            Name = "DeviceInformation";
            Field(x => x.Id).Description("The ID of the device information");            
            Field(x => x.Model).Description("The model of the device information");
            Field(x => x.Osversion).Description("The osversion of the device information");
            Field(x => x.Uuid).Description("The uuid of the device information");
        }
    }
}
