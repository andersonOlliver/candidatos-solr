using SolrNet.Attributes;
using System;

namespace Candidatos.Domain.Entities
{
    public class DocumentoBase
    {

        //public Guid Id { get; set; }

        [SolrUniqueKey("Id")]
        public string Id { get; set; }

        public DocumentoBase()
        {
        }
    }
}
