using Autofac;
using Serilog;

namespace Candidatos.Sync.IoC
{
    public class LoggingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var config = new LoggerConfiguration().MinimumLevel.Verbose()
                .WriteTo.Trace()
                .WriteTo.LiterateConsole();

            var logger = config.CreateLogger();
            Log.Logger = logger;

            builder.RegisterInstance(logger).As<ILogger>();
        }
    }
}
