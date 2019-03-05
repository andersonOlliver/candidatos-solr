using Candidatos.Domain.Entities;
using Candidatos.Domain.Interfaces.Processador;
using Candidatos.Domain.Interfaces.Providers;
using Candidatos.Domain.Interfaces.Solr;
using Candidatos.Domain.Processador;
using Candidatos.Domain.Providers;
using Candidatos.Infra.Data.Solr;
using Candidatos.SyncApi.IoC;
using Candidatos.SyncApi.Service;
using Microsoft.Extensions.DependencyInjection;
using SolrNet;

namespace Candidatos.SyncApi.Extensions
{
    public static class DependencyExtensions
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.AddTransient<ISincronizaCandidatoService, SincronizaCandidatoService>();
            
            //services.AddSolrNet("http://192.168.0.14:8983/solr");
            services.AddSolrNet<CandidatoDocumento>("http://192.168.0.14:8983/solr/candidatos");
            services.AddTransient<ISolrRepository, SolrRepository>();
            services.AddTransient<IProcessadorDocumentoCandidato, ProcessadorDocumentoCandidato>();
            services.AddTransient<ICandidatoDocumentoProvider, CandidatoDocumentoProvider>();
            
            DependencyResolver.ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
