using Candidatos.Domain.Interfaces.Processador;
using Quartz;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Candidatos.Sync.Job
{
    public class FileSyncJob : IJob
    {
        private readonly IProcessadorDocumentoCandidato _processadorDocumentoCandidato;

        public FileSyncJob(IProcessadorDocumentoCandidato processadorDocumentoCandidato)
        {
            _processadorDocumentoCandidato = processadorDocumentoCandidato;
        }

        public async Task Execute(IJobExecutionContext context)
        {   
            var dir = @"C:\Users\ander\Documents\Big data\dados";

            await _processadorDocumentoCandidato.ProcessarAsync(dir);
        }
    }
}
