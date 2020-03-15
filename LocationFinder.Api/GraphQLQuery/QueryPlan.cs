using GeoCoordinatePortable;
using GraphQL.Types;
using LocationFinder.Api.GraphQLTypes;
using LocationFinder.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LocationFinder.Api.GraphQLQuery
{
    public class QueryPlan : ObjectGraphType
    {
        public QueryPlan(NearmeDataContext db)
        {
            Field<OrganizationType>(
              "Organization",
              arguments: new QueryArguments(
                new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the organization." }),
              resolve: context =>
              {
                  var id = context.GetArgument<long>("id");
                  var organization = db.Organizations
                    .Include(a => a.Persons)
                    //.ThenInclude(p => p.PointLocation).ToList()
                    .FirstOrDefault(i => i.Id == id);
                  return organization;
              });

            Field<ListGraphType<OrganizationType>>(
              "Organizations",
              resolve: context =>
              {
                  var organizations = db.Organizations.Include(a => a.Persons);
                  return  organizations;
              });

            Field<PersonType>(
              "Person",
              arguments: new QueryArguments(
                new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the person." }),
              resolve: context =>
              {
                  var id = context.GetArgument<long>("id");
                  var person = db.Persons
                    //.Include(a => a.PointLocation)
                    .Include(b => b.Organization)
                    .FirstOrDefault(i => i.Id == id);
                  return person;
              });

            Field<ListGraphType<PersonType>>(
              "Persons",
              resolve: context =>
              {
                  var organizations = db.Persons.Include(b => b.Organization);
                  return organizations;
              });

            Field<ListGraphType<PersonType>>(
                "nearestLocations",
                arguments: new QueryArguments(
                     new QueryArgument<FloatGraphType> { Name = "latitude", Description = "The ID of the person." },
                     new QueryArgument<FloatGraphType> { Name = "longtitude", Description = "The ID of the person." },
                     new QueryArgument<IdGraphType> { Name = "organizationId", Description = "The ID of the person." }
                     ),
                resolve: context =>
                {
                    var pointLat = context.GetArgument<double>("latitude");
                    var pointLong = context.GetArgument<double>("longtitude");
                    var orgId = context.GetArgument<long>("organizationId");

                    // create coordinates
                    var coord = new GeoCoordinate(pointLat, pointLong);

                    var list = db.PointLocations
                                .Select(x => new { locations = new GeoCoordinate { Latitude = x.Latitude, Longitude = x.Longtitude }, pointLocation = x })
                                .OrderBy(x => x.locations.GetDistanceTo(coord))
                                .Select(x => x.pointLocation).Include(y => y.Person)
                                .Where(x => x.PersonId != null && x.Person.OrganizationId.Equals(orgId))
                                //.GroupBy(x => x.PersonId);
                                .Select(y => y.PersonId)
                                .Distinct()
                                .Take(5);
                                
                                                              ;

                    var personList = db.Persons.Include(o => o.PointLocations).Include(o => o.Organization)
                                        .Join(list,
                                        person => person.Id,
                                        ids => ids,
                                        (person, ids) => person);

                    return personList;

                }
                );

            //Field<DeviceInformationType>(
            //     "createDeviceInformation",
            //     arguments: new QueryArguments(
            //       new QueryArgument<NonNullGraphType<DeviceInformationType>> { Name = "information" }
            //     ),
            //     resolve: context =>
            //     {
            //         var information = context.GetArgument<DeviceInformation>("information");
            //         var a = db.Add(information);
            //         db.SaveChangesAsync();
            //         return a;
            //     });
        }


    }
}

