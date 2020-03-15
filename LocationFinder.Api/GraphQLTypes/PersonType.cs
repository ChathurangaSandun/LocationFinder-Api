using GraphQL.Types;
using LocationFinder.Api.Models;
using System.Collections.Generic;

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
            Field(x => x.ImageUri).DefaultValue(null).Description("The image of the person");
            Field(x => x.Organization, type: typeof(OrganizationType)).Description("The organization of the person");
            Field<ListGraphType<PointLocationType>>("pointList", "persons point list of address",  resolve : context => context.Source.PointLocations);
           
        }
    }
}
