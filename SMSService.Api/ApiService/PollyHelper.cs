using Polly;
using Polly.Extensions.Http;

namespace SMSService.Api.ApiService
{
    public  class PollyHelper
    {
        public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            // Retry up to 3 times with exponential backoff
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                //.WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
                .WaitAndRetryAsync(10, retryAttempt => TimeSpan.FromSeconds(5), (x, t) =>
                { 
                    Console.WriteLine($"tttt {DateTime.Now.ToString()}");
                }
                );
         
        }
        public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            // Circuit Breaker: Break after 2 consecutive failures and reset after 10 seconds
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(2, TimeSpan.FromSeconds(10));
        }
    }
}
