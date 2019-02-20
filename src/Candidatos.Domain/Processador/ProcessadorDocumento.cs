using Candidatos.Domain.Entities;
using Candidatos.Domain.Interfaces.Processador;
using Candidatos.Domain.Interfaces.Providers;
using Candidatos.Domain.Providers;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Candidatos.Domain.Processador
{

    public class ProcessadorDocumento<D> : IProcessadorDocumento where D : DocumentoBase
    {

        private readonly IDocumentoProvider<D> _provider;

        public ProcessadorDocumento(IDocumentoProvider<D> provider)
        {
            _provider = provider;
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
                await Gravar(content);
            }


            Log.Information("Tarefa finalizada");
            Log.Information("=========================================================");
        }

        private async Task<IEnumerable<DocumentoBase>> ReadContentFileAsync(string pathFile)
        {
            return await _provider.GetDocumentosFromCsvAsync(pathFile);
        }

        private static List<string> GetFiles(string path)
        {
            return Directory.GetFiles(path)
               .Where(f => f.EndsWith(".csv"))
               .ToList();
        }

        private Task Gravar(IEnumerable<DocumentoBase> dados)
        {
            dados.Take(5).ToList().ForEach(c => Log.Information(JsonConvert.SerializeObject(c)));
            return Task.CompletedTask;
        }

    }
}
