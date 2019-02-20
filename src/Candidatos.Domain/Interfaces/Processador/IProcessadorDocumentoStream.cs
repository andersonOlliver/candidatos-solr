using Candidatos.Domain.Entities;
using System;

namespace Candidatos.Domain.Interfaces.Processador
{
    public interface IProcessadorDocumentoStream
    {
        void Next(DocumentoBase documento);
        void Subscribe(string name, Action<DocumentoBase> action);
    }
}
