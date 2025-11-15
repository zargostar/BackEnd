using System.Threading.Channels;

namespace SMSService.Api.ApiService.BackGroundService
{
    public class BackgroundTaskQueue : IBackgroundTaskQueue
    {
        private readonly Channel<Func<CancellationToken, Task>> _queue;
        public BackgroundTaskQueue()
        {
            _queue = Channel.CreateUnbounded<Func<CancellationToken, Task>>();
        }

        public async Task<Func<CancellationToken, Task>> DequeueWorkAsync(CancellationToken cancellationToken)
        {
            return await _queue.Reader.ReadAsync(cancellationToken);
        }

        public void QueueWork(Func<CancellationToken, Task> workItem)
        {
            _queue.Writer.TryWrite(workItem);
        }
    }
}
