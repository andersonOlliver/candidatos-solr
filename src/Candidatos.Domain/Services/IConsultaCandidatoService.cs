using System.Collections.Generic;
using System.Threading.Tasks;
using Candidatos.Domain.Entities;

namespace Candidatos.Domain.Services
{
    public interface IConsultaCandidatoService
    {
        Task<IEnumerable<CandidatoDocumento>> ConsultarAsync(Filtro filtro);
    }
}