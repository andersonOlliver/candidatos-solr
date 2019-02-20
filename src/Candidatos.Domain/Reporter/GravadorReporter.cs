using Candidatos.Domain.Entities;
using Candidatos.Domain.Interfaces.Reporter;
using System;

namespace Candidatos.Domain.Reporter
{

    public class GravadorReporter<D> : IObserver<D>, IGravadorReporter<D> where D : DocumentoBase
    {
        private IDisposable unsubscriber;
        private readonly string instName;

        public GravadorReporter()
        {

        }

        public GravadorReporter(string name)
        {
            this.instName = name;
        }

        public string Name => instName;

        public virtual void Subscribe(IObservable<D> provider)
        {
            if (provider != null)
                unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        public virtual void OnCompleted()
        {
            Console.WriteLine("Leitor finalizou transmissão para {0}.", this.Name);
            this.Unsubscribe();
        }

        public virtual void OnError(Exception error)
        {
            Console.WriteLine("{0}: Teve leitura indeterminada", Name);
        }


        public virtual void OnNext(D value)
        {
            Console.WriteLine("{1}: Foi sincronizado com valor de {0}", value.ToString(), Name);
        }
    }
}
