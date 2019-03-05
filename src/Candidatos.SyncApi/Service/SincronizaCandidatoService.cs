using Candidatos.Domain.Interfaces.Processador;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Candidatos.SyncApi.Service
{
    public class SincronizaCandidatoService : ISincronizaCandidatoService
    {
        private readonly IProcessadorDocumentoCandidato _processadorDocumento;

        public SincronizaCandidatoService(IProcessadorDocumentoCandidato processadorDocumento)
        {
            _processadorDocumento = processadorDocumento;
        }

        public async Task SincronizaAsync()
        {
            var path = @"C:\Users\ander\Documents\Big data\Projeto\candidatos-solr\data";
            await _processadorDocumento.ProcessarAsync(path);
            Console.WriteLine("Sincronizando candidatos");
            Debug.WriteLine(new string('=', 100));
            Debug.WriteLine(new string(' ', 10));
            Debug.WriteLine("Candidatos Sincronizados");
            Debug.WriteLine(new string(' ', 10));
            Console.WriteLine("Sincronizando candidatos");
        }
    }
}
