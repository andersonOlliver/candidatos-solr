using System.Collections.Generic;
using System.Threading.Tasks;
using Candidatos.Domain.Entities;

namespace Candidatos.Domain.Interfaces.Providers
{
    public interface IDocumentoProvider<T> where T : DocumentoBase
    {
        Task<IEnumerable<T>> GetDocumentosFromCsvAsync(string path);
    }
}