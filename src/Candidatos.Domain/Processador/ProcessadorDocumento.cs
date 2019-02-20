using Candidatos.CrossCutting.Exceptions;
using Candidatos.Domain.Entities;
using Candidatos.Domain.Interfaces.Processador;
using Candidatos.Domain.Interfaces.Providers;
using Candidatos.Domain.Interfaces.Reporter;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Candidatos.Domain.Processador
{

    public class ProcessadorDocumento<D> : IObservable<D>, IProcessadorDocumento where D : DocumentoBase
    {

        private readonly IDocumentoProvider<D> _provider;
        private readonly IGravadorReporter<D> _reporter;
        private List<IObserver<D>> _observers;

        public ProcessadorDocumento(IDocumentoProvider<D> provider, IGravadorReporter<D> reporter)
        {
            _provider = provider;
            _reporter = reporter;
            _observers = new List<IObserver<D>>();
            _reporter.Subscribe(this);
        }

        public void Processar(string path)
        {
            ProcessarAsync(path).Wait();
        }

        public async Task ProcessarAsync(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("message", nameof(path));
            }

            Log.Information("=========================================================");
            Log.Information("Iniciando tarefa");

            List<string> pathFiles = GetFiles(path);

            foreach (var pathFile in pathFiles)
            {
                var content = await ReadContentFileAsync(pathFile);
                await Transmitir(content);
            }


            this.FinalizarTransmissao();
            Log.Information("Tarefa finalizada");
            Log.Information("=========================================================");
        }

        private async Task<IEnumerable<D>> ReadContentFileAsync(string pathFile)
        {
            return await _provider.GetDocumentosFromCsvAsync(pathFile);
        }

        private static List<string> GetFiles(string path)
        {
            return Directory.GetFiles(path)
               .Where(f => f.EndsWith(".csv"))
               .ToList();
        }

        // TODO: Alterar para emitir vários
        private Task Transmitir(IEnumerable<D> dados)
        {
            //dados.Take(2).ToList().ForEach(c => Log.Information(JsonConvert.SerializeObject(c)));

            foreach (var observer in _observers)
            {
                if (dados == null)
                    observer.OnError(new ReaderUnknownException());
                else
                    observer.OnNext(dados.First());
            }

            return Task.CompletedTask;
        }

        public void FinalizarTransmissao()
        {
            foreach (var observer in _observers.ToArray())
                if (_observers.Contains(observer))
                    observer.OnCompleted();

            _observers.Clear();
        }

        public IDisposable Subscribe(IObserver<D> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }


        private class Unsubscriber : IDisposable
        {
            private List<IObserver<D>> _observers;
            private IObserver<D> _observer;

            public Unsubscriber(List<IObserver<D>> observers, IObserver<D> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }
}
