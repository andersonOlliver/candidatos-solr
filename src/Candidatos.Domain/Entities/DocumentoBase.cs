using System;

namespace Candidatos.Domain.Entities
{
    public class DocumentoBase
    {
        public Guid Id { get; set; }

        public DocumentoBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
