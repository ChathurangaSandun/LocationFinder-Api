using GraphQL.Types;
using LocationFinder.Api.Models;

namespace LocationFinder.Api.GraphQLTypes
{
    public class PointLocationType : ObjectGraphType<PointLocation>
    {
        public PointLocationType()
        {
            Name = "PointLocation";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("The ID of the pointLocation");
            //Field(x => x.MarkGuid).Description("The ID of the pointLocation");
            Field(x => x.Latitude).Description("The ID of the pointLocation");
            Field(x => x.Longtitude).Description("The ID of the pointLocation");
            //Field(x => x.Person, type: typeof(PersonType)).Description("The ID of the pointLocation");
        }
    }
}
