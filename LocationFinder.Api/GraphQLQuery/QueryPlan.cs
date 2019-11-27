using GeoCoordinatePortable;
using GraphQL.Types;
using LocationFinder.Api.GraphQLTypes;
using LocationFinder.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    .ThenInclude(p => p.PointLocation).ToList()
                    .FirstOrDefault(i => i.Id == id);
                  return organization;
              });

            Field<ListGraphType<OrganizationType>>(
              "Organizations",
              resolve: context =>
              {
                  var organizations = db.Organizations.Include(a => a.Persons).ThenInclude(p => p.PointLocation);
                  return organizations;
              });

            Field<PersonType>(
              "Person",
              arguments: new QueryArguments(
                new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the person." }),
              resolve: context =>
              {
                  var id = context.GetArgument<long>("id");
                  var person = db.Persons
                    .Include(a => a.PointLocation)
                    .FirstOrDefault(i => i.Id == id);
                  return person;
              });

            Field<ListGraphType<PersonType>>(
              "Persons",
              resolve: context =>
              {
                  var organizations = db.Persons.Include(p => p.PointLocation);
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

                    var coord = new GeoCoordinate(pointLat, pointLong);

                    var a= db.Persons.Where(o=> o.OrganizationId == orgId)
                            .Select(x => new { locations = new GeoCoordinate { Latitude = x.PointLocation.Latitude, Longitude = x.PointLocation.Longtitude }, person = x })
                            .OrderBy(x => x.locations.GetDistanceTo(coord))
                            .Take(3)
                            .Select( y => y.person)
                            .AsEnumerable();

                    return a;

                }
                );
        }


    }
}

