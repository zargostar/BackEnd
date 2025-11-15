namespace SMSService.Api.ApiService.BackGroundService
{
    public interface IBackgroundTaskQueue
    {
        void QueueWork(Func<CancellationToken, Task> workItem);
        Task<Func<CancellationToken, Task>> DequeueWorkAsync(CancellationToken cancellationToken);
    }
}
