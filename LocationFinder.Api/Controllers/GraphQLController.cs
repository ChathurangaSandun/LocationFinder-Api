using GraphQL;
using GraphQL.Types;
using LocationFinder.Api.GraphQLQuery;
using LocationFinder.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace LocationFinder.Api.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class GraphQLController : Controller
    {
        private readonly NearmeDataContext _db;

        public GraphQLController(NearmeDataContext db) => _db = db;

        public async Task<IActionResult> Post([FromBody] GraphQLQueryModel query)
        {
            var inputs = query.Variables.ToInputs();

            var schema = new Schema
            {
                Query = new QueryPlan(_db)
            };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            });

            if (result.Errors?.Count > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(result);
        }
    }
}