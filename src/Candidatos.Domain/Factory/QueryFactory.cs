using Candidatos.Domain.Entities;
using SolrNet;

namespace Candidatos.Domain.Factory
{
    public class QueryFactory : IQueryFactory
    {

        public AbstractSolrQuery BuildQuery(Filtro filtro)
        {
            AbstractSolrQuery query = new SolrQuery("*:*");
            if (!string.IsNullOrEmpty(filtro.NomeCandidato))
            {
                query = query && new SolrQuery($"NM_CANDIDATO:{filtro.NomeCandidato.ToUpper()}*");
            }
            if (!string.IsNullOrEmpty(filtro.Partido))
            {
                query = query && new SolrQuery($"NM_CANDIDATO:{filtro.Partido.ToUpper()}");
            }

            return query;
        }
    }
}
