using GraphQL.Types;
using LocationFinder.Api.Models;

namespace LocationFinder.Api.GraphQLTypes
{
    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            Name = "Person";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("The ID of the person");
            Field(x => x.Name).Description("The Name of the person");
            Field(x => x.Mobile).Description("The Mobile of the person");
            Field(x => x.Address).Description("The Address of the person");
            Field(x => x.ImageUri).Description("The image of the person");
            Field(x => x.Organization, type: typeof(OrganizationType)).Description("The organization of the person");
            Field(x => x.PointLocation, type: typeof(PointLocationType)).Description("The point location of the person");
        }
    }
}
