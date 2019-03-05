using Candidatos.Domain.Entities;
using SolrNet;

namespace Candidatos.Domain.Factory
{
    public interface IQueryFactory
    {
        AbstractSolrQuery BuildQuery(Filtro filtro);
    }
}