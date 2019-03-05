using Candidatos.Domain.Entities;
using Candidatos.Domain.Extensions;
using SolrNet;
using System.Text;

namespace Candidatos.Domain.Factory
{
    public class QueryFactory : IQueryFactory
    {
        private AbstractSolrQuery _query;
        public AbstractSolrQuery BuildQuery(Filtro filtro)
        {
            _query = new SolrQuery("*:*");
            if (!string.IsNullOrEmpty(filtro.NomeCandidato))
            {
                _query = _query && new SolrQuery($"NM_CANDIDATO:{filtro.NomeCandidato.ToUpper()}*");
            }
            if (!string.IsNullOrEmpty(filtro.Partido))
            {
                _query = _query && new SolrQuery($"NM_CANDIDATO:{filtro.Partido.ToUpper()}");
            }
            
            return _query;
        }

        public string BuildParsedQuery(Filtro filtro)
        {
            var query = new StringBuilder("*:*");

            if (!string.IsNullOrEmpty(filtro.NomeCandidato))
            {
                query = query.And().StartWith("NM_CANDIDATO", filtro.NomeCandidato.ToUpper());
            }
            if (!string.IsNullOrEmpty(filtro.Partido))
            {
                query = query.And().StartWith("NM_CANDIDATO", filtro.Partido.ToUpper());
            }

            return query.ToString();
        }

        
    }
}
