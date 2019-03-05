using Candidatos.CrossCutting.Exceptions;
using Candidatos.Domain.Entities;
using Candidatos.Domain.Interfaces.Processador;
using Candidatos.Domain.Interfaces.Providers;
using Candidatos.Domain.Interfaces.Solr;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Candidatos.Domain.Processador
{

    public class ProcessadorDocumento<D> : IProcessadorDocumento where D : DocumentoBase
    {

        private readonly IDocumentoProvider<D> _provider;
        private readonly ISolrRepository _solrRepository;

        public ProcessadorDocumento(IDocumentoProvider<D> provider, ISolrRepository solrRepository)
        {
            _provider = provider;
            _solrRepository = solrRepository;
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
                Debug.WriteLine(new string(' ', 10));
                Debug.WriteLine("Sincronizado: ", pathFile.Substring(path.LastIndexOf(@"\") + @"\data\".Length));
                Debug.WriteLine(new string(' ', 10));
                await TransmitirAsync(content);
            }

            
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
        private async Task TransmitirAsync(IEnumerable<D> dados)
        {
            await _solrRepository.AddManyAsync(dados as IEnumerable<CandidatoDocumento>);
        }
    }
}
