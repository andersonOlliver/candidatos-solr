using Candidatos.Domain.Entities;
using Candidatos.Domain.Services;
using GraphQL.Types;

namespace Candidatos.QueryApi.Models
{
    public partial class CandidatoStatsSchema
    {
        public class FiltroInputType: InputObjectGraphType
        {
            public FiltroInputType()
            {
                Name = "Filtro";
                Field<NonNullGraphType<StringGraphType>>("NomeCandidato");
                Field<StringGraphType>("Partido");
            }
        }
    }

    public class CandidatoStatsQuery: ObjectGraphType
    {
        public CandidatoStatsQuery(IConsultaCandidatoService consultaCandidatoService)
        {
            //Field<Filtro>("filtro",
            //    resolve: context => consultaCandidatoService.ConsultaPaginadaAsync());
        }
    }
}
