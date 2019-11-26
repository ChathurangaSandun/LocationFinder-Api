using GraphQL.Types;
using LocationFinder.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFinder.Api.GraphQLTypes
{
    public class OrganizationType: ObjectGraphType<Organization>
    {
        public OrganizationType()
        {
            Name = "Organization";
            Field(x => x.Id).Description("The ID of the organizaion");
            Field(x => x.Name).Description("The name of the organizaion");            
            Field(x => x.Details).Description("The details of the organizaion");
            Field(x => x.Persons, type: typeof(ListGraphType<PersonType>)).Description("The persons of the organizaion");
        }
    }
}
