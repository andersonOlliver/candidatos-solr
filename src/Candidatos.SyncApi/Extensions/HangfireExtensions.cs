using Candidatos.SyncApi.IoC;
using Candidatos.SyncApi.Service;
using Hangfire;
using Microsoft.AspNetCore.Builder;

namespace Candidatos.SyncApi.Extensions
{
    public static class HangfireExtensions
    {

        public static IApplicationBuilder InitializeHangfire(this IApplicationBuilder builder)
        {

            builder.UseHangfireServer();
            builder.UseHangfireDashboard();

            InitializeJob();

            return builder;
        }

        public static void InitializeJob()
        {
            var service = DependencyResolver.ServiceProvider.GetService(typeof(ISincronizaCandidatoService)) as ISincronizaCandidatoService;
            RecurringJob.AddOrUpdate("Sincroniza Candidato Job", () => service.SincronizaAsync(), Cron.Hourly);
        }
    }
}
