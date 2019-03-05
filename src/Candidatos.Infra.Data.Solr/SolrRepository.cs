using Candidatos.Domain.Entities;
using Candidatos.Domain.Interfaces.Solr;
using Newtonsoft.Json;
using SolrNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Candidatos.Infra.Data.Solr
{
    public class SolrRepository : ISolrRepository, IDisposable
    {
        private readonly ISolrOperations<CandidatoDocumento> _solr;

        public SolrRepository(ISolrOperations<CandidatoDocumento> solr)
        {
            _solr = solr;
        }

        public async Task AddAsync(CandidatoDocumento documento)
        {

            await _solr.AddAsync(documento);
            await _solr.CommitAsync();
        }

        public async Task AddManyAsync(IEnumerable<CandidatoDocumento> documentos)
        {

            try
            {
                _solr.AddRange(documentos);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }

            await _solr.CommitAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<CandidatoDocumento>> SearchAsync(AbstractSolrQuery query)
        {
            return await _solr.QueryAsync(query);
        }
    }
}
