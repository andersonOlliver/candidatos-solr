using Candidatos.Sync.Infra.Files;
using Quartz;
using Serilog;
using System.Threading.Tasks;
using System.Linq;

namespace Candidatos.Sync
{
    public class HelloJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            //var lastRun = context.PreviousFireTimeUtc?.DateTime.ToString() ?? string.Empty;
            //Log.Warning("Greetings from HelloJob! Previous run: {lasRun}", lastRun);
            var path = @"C:\Users\ander\Documents\Big data\dados\consulta_cand_2018_AC.csv";

            var data = new FileRepository().GetData(path);

            data.ToList().ForEach(d => Log.Information(d));

            return Task.CompletedTask;
        }
    }
}
