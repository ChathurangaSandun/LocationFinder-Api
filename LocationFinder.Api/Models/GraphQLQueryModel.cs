
using Newtonsoft.Json.Linq;
namespace LocationFinder.Api.Models
{
    public class GraphQLQueryModel
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}
