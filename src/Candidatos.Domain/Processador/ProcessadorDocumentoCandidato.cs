using Candidatos.Domain.Entities;
using Candidatos.Domain.Interfaces.Processador;
using Candidatos.Domain.Interfaces.Providers;
using Candidatos.Domain.Interfaces.Solr;

namespace Candidatos.Domain.Processador
{
    public class ProcessadorDocumentoCandidato : ProcessadorDocumento<CandidatoDocumento>, IProcessadorDocumentoCandidato
    {
        public ProcessadorDocumentoCandidato(ICandidatoDocumentoProvider provider, ISolrRepository solrRepository) 
            : base(provider, solrRepository)
        {
        }
    }
}
