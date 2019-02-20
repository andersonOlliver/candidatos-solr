using System.Threading.Tasks;

namespace Candidatos.Domain.Interfaces.Processador
{
    public interface IProcessadorDocumento
    {
        void Processar(string path);
        Task ProcessarAsync(string path);
    }
}