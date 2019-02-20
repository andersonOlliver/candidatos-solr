using Candidatos.Domain.Entities;
using Candidatos.Domain.Interfaces.Processador;
using Candidatos.Domain.Interfaces.Providers;
using Candidatos.Domain.Interfaces.Reporter;

namespace Candidatos.Domain.Processador
{
    public class ProcessadorDocumentoCandidato : ProcessadorDocumento<CandidatoDocumento>, IProcessadorDocumentoCandidato
    {
        public ProcessadorDocumentoCandidato(ICandidatoDocumentoProvider provider, ICandidatoGravadorReporter reporter) 
            : base(provider, reporter)
        {
        }
    }
}
