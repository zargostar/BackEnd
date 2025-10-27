
using Hangfire;

namespace OrderService.API.HangFireServices
{
    public class WorkerHangfire : IHostedService
    {
        
        private readonly ReOccuringSendMessage message;
        private readonly ILogger<WorkerHangfire> logger;

        public WorkerHangfire(ReOccuringSendMessage message, ILogger<WorkerHangfire> logger)
        {
            this.message = message;
            this.logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("start hangfir");
            RecurringJob.AddOrUpdate("test recurring666 from message",
                 () => message.SendEmail(), Cron.Minutely);
            var timr = new DateTime();
            // logger.LogInformation("test jjjjj}");
            //throw new NotImplementedException();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
           throw new NotImplementedException();
        }
    }
}
