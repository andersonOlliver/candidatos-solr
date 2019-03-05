using Candidatos.IoC;
using Candidatos.SyncApi.IoC;
using Candidatos.SyncApi.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Candidatos.SyncApi.Extensions
{
    public static class DependencyExtensions
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.AddTransient<ISincronizaCandidatoService, SincronizaCandidatoService>();
            services.RegisterTypes();
            
            DependencyResolver.ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
