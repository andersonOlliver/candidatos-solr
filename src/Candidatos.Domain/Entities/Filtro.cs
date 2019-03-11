using Newtonsoft.Json.Linq;

namespace Candidatos.Domain.Entities
{
    public class Filtro : Paginated
    {

        public string NomeCandidato { get; set; }
        public string Partido { get; set; }
    }

    public class Paginated
    {
        private const int MaxPageSize = 50;
        private int pageSize = 10;

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get => pageSize;
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
    }

    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; } //https://github.com/graphql-dotnet/graphql-dotnet/issues/389
    }
}
