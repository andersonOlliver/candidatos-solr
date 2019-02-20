using Quartz;
using Serilog;

namespace Candidatos.Sync.Service
{
    public class QuartzFileService : ITestService
    {
        private readonly IScheduler _jobScheduler;
        private readonly ILogger _logger;

        public QuartzFileService(IScheduler jobScheduler, ILogger logger)
        {
            _jobScheduler = jobScheduler;
            _logger = logger;
        }

        public void Start()
        {
            _jobScheduler.Start();
            _logger.Information("Job scheduler started");
        }

        public void Stop()
        {
            _jobScheduler.Shutdown(true);

            _logger.Information("Job scheduler stopped");
        }
    }
}
