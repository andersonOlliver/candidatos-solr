using Candidatos.Domain.Entities;
using System.Threading.Tasks;

namespace Candidatos.Domain.Interfaces.Solr
{
    public interface ISolrRepository
    {
        Task Adicionar(DocumentoBase documento);
    }
}
