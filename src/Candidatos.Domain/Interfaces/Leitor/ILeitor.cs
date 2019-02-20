using Candidatos.Domain.Entities;
using System.Threading.Tasks;

namespace Candidatos.Domain.Interfaces.Leitor
{
    public interface ILeitor
    {
        Task<DocumentoBase> Ler();
    }
}
