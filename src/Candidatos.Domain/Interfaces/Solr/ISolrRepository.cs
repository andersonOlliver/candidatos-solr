using Candidatos.Domain.Entities;
using SolrNet;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidatos.Domain.Interfaces.Solr
{
    public interface ISolrRepository
    {
        Task AddAsync(CandidatoDocumento documento);
        Task AddManyAsync(IEnumerable<CandidatoDocumento> documentos);
        Task<IEnumerable<CandidatoDocumento>> SearchAsync(AbstractSolrQuery query);
    }
}
