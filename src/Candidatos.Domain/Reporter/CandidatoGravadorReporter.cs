using Candidatos.Domain.Entities;
using Candidatos.Domain.Interfaces.Reporter;

namespace Candidatos.Domain.Reporter
{
    public class CandidatoGravadorReporter : GravadorReporter<CandidatoDocumento>, ICandidatoGravadorReporter
    {

        public CandidatoGravadorReporter() : base("Candidato")
        {
        }
    }
}
