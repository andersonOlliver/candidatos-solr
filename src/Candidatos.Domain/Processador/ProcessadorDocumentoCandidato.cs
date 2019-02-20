using Candidatos.Domain.Entities;
using Candidatos.Domain.Interfaces.Processador;
using Candidatos.Domain.Interfaces.Providers;
using Candidatos.Domain.Providers;

namespace Candidatos.Domain.Processador
{
    public class ProcessadorDocumentoCandidato : ProcessadorDocumento<CandidatoDocumento>, IProcessadorDocumentoCandidato
    {
        public ProcessadorDocumentoCandidato(ICandidatoDocumentoProvider provider) : base(provider)
        {
        }
    }
}
