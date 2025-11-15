namespace SMSService.Api.ApiService.BackGroundService
{
    public class SupplierWorker : BackgroundService
    {
        private readonly IBackgroundTaskQueue _queue;
        private readonly IHttpClientFactory _httpFactory;

        public SupplierWorker(IBackgroundTaskQueue queue, IHttpClientFactory httpFactory)
        {
            _queue = queue;
            _httpFactory = httpFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var workItem = await _queue.DequeueWorkAsync(stoppingToken);

                try
                {
                    await workItem(stoppingToken);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Background task error: {ex}");
                }
            }
        }
    }
}
