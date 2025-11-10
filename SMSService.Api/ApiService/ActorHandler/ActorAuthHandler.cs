
using System.Diagnostics;
using System.Net.Http.Headers;

namespace SMSService.Api.ApiService.ActorHandler
{
    public class ActorAuthHandler:DelegatingHandler
    {
       private ILogger<ActorAuthHandler> logger;

        public ActorAuthHandler(ILogger<ActorAuthHandler> logger)
        {
            this.logger = logger;
        }

        protected override   async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var stopwatch = Stopwatch.StartNew();
            logger.LogInformation("===========================");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "token");
            await Task.Delay(2000, cancellationToken);
            //return await  base.SendAsync(request, cancellationToken);
            var response = await base.SendAsync(request, cancellationToken);

            stopwatch.Stop();
            Console.WriteLine("$\"Time about {stopwatch.ElapsedMilliseconds}\"");
            logger.LogInformation($"Time about {stopwatch.ElapsedMilliseconds}");
            return response;
        }
    }
}
