using Candidatos.Domain.Entities;
using Candidatos.Domain.Factory;
using Candidatos.Domain.Interfaces.Processador;
using Candidatos.Domain.Interfaces.Providers;
using Candidatos.Domain.Interfaces.Solr;
using Candidatos.Domain.Processador;
using Candidatos.Domain.Providers;
using Candidatos.Domain.Services;
using Candidatos.Infra.Data.Solr;
using Microsoft.Extensions.DependencyInjection;
using SolrNet;

namespace Candidatos.IoC
{
    public static class DependencyExtensions
    {
        public static IServiceCollection RegisterTypes(this IServiceCollection services)
        {
            services.AddSolrNet<CandidatoDocumento>("http://192.168.0.14:8983/solr/candidatos");
            services.AddTransient<ISolrRepository, SolrRepository>();
            services.AddTransient<IProcessadorDocumentoCandidato, ProcessadorDocumentoCandidato>();
            services.AddTransient<ICandidatoDocumentoProvider, CandidatoDocumentoProvider>();
            services.AddTransient<IConsultaCandidatoService, ConsultaCandidatoService>();
            services.AddTransient<IQueryFactory, QueryFactory>();
            
            return services;
        }
    }
}
