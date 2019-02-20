using Autofac;
using Autofac.Extras.Quartz;
using Candidatos.Domain.Interfaces.Processador;
using Candidatos.Domain.Interfaces.Providers;
using Candidatos.Domain.Interfaces.Reporter;
using Candidatos.Domain.Processador;
using Candidatos.Domain.Providers;
using Candidatos.Domain.Reporter;
using Candidatos.Sync.IoC;
using Candidatos.Sync.Job;
using Candidatos.Sync.Service;
using System;
using System.Collections.Specialized;
using Topshelf;
using Topshelf.Autofac;

namespace Candidatos.Sync
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = BuildContainer();

            var rc = HostFactory.Run(configurator =>
            {
                configurator.UseSerilog();
                configurator.UseAutofacContainer(container);

                configurator.Service<ITestService>(serviceConfigurator =>
                {
                    serviceConfigurator.ConstructUsingAutofacContainer();
                    serviceConfigurator.WhenStarted(service => service.Start());
                    serviceConfigurator.WhenStopped(service => service.Stop());
                });

                configurator.RunAsLocalSystem();
                configurator.StartAutomaticallyDelayed();

                configurator.SetDescription("Sample Topshelf/Quartz scheduler");
                configurator.SetDisplayName("Topshelf Quartz Scheduler");
                configurator.SetServiceName("TQScheduler");
            });

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
        }

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ConventionModule>();
            builder.RegisterModule<LoggingModule>();
            //builder.RegisterType<SimpleTypeLoadHelper>().As<ITypeLoadHelper>();

            builder.RegisterType<ProcessadorDocumentoCandidato>().As<IProcessadorDocumentoCandidato>();
            builder.RegisterType<CandidatoDocumentoProvider>().As<ICandidatoDocumentoProvider>();
            builder.RegisterType<CandidatoGravadorReporter>().As<ICandidatoGravadorReporter>();

            builder.RegisterModule(new QuartzAutofacFactoryModule { ConfigurationProvider = QuartzConfigurationProvider });
            builder.RegisterModule(new QuartzAutofacJobsModule(typeof(Program).Assembly));
            return builder.Build();
        }

        private static NameValueCollection QuartzConfigurationProvider(IComponentContext arg)
        {
            return new NameValueCollection
            {
                ["quartz.scheduler.instanceName"] = "XmlConfiguredInstance",
                ["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz",
                ["quartz.threadPool.threadCount"] = "5",
                ["quartz.plugin.xml.type"] = "Quartz.Plugin.Xml.XMLSchedulingDataProcessorPlugin, Quartz.Plugins",
                ["quartz.plugin.xml.fileNames"] = "quartz-jobs.config",
                ["quartz.plugin.xml.FailOnFileNotFound"] = "true",
                ["quartz.plugin.xml.failOnSchedulingError"] = "true"
            };
        }
    }
}
