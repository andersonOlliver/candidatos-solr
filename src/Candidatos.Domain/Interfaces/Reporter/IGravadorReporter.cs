using System;
using Candidatos.Domain.Entities;

namespace Candidatos.Domain.Interfaces.Reporter
{
    public interface IGravadorReporter<D> where D : DocumentoBase
    {
        void OnCompleted();
        void OnError(Exception error);
        void OnNext(D value);
        void Subscribe(IObservable<D> provider);
        void Unsubscribe();
    }
}