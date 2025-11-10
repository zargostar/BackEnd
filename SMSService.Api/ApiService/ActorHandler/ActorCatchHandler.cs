using StackExchange.Redis;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.IO.Compression;

namespace SMSService.Api.ApiService.ActorHandler
{
    public class ActorCatchHandler:DelegatingHandler
    {


        public class ActorAuthHandler : DelegatingHandler
        {
            private readonly ILogger<ActorAuthHandler> logger;
            private readonly IDatabase redisDb;

            public ActorAuthHandler(ILogger<ActorAuthHandler> logger, IConnectionMultiplexer redis)
            {
                this.logger = logger;
                this.redisDb = redis.GetDatabase();
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var stopwatch = Stopwatch.StartNew();
              

                // Try to get cached response from Redis
                try
                {
                    var cachedData = await redisDb.StringGetAsync(request.RequestUri.ToString());
                    if (!string.IsNullOrEmpty(cachedData))
                    {
                        logger.LogInformation("Cache hit for {Url}, returning data from Redis", request.RequestUri);

                        stopwatch.Stop();
                        logger.LogInformation($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");

                        // Return cached data as HttpResponseMessage
                        var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                        {
                            Content = new StringContent(cachedData)
                        };
                        return response;
                    }
                }
                catch (RedisConnectionException ex)
                {
                    logger.LogError(ex, "Redis connection failed. Will call API instead.");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Unexpected Redis error. Will call API instead.");
                }

                // If cache miss or Redis failed, call the API
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "token");

                try
                {
                    var response = await base.SendAsync(request, cancellationToken);

                    // Optionally cache the response in Redis
                    try
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        await redisDb.StringSetAsync(request.RequestUri.ToString(), content, TimeSpan.FromMinutes(10));
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "Failed to store API response in Redis");
                    }

                    stopwatch.Stop();
                    logger.LogInformation($"Request to {request.RequestUri} completed in {stopwatch.ElapsedMilliseconds} ms");

                    return response;
                }
                catch (HttpRequestException ex)
                {
                    stopwatch.Stop();
                    logger.LogError(ex, "HTTP request failed for {Url}. Time elapsed: {Elapsed} ms", request.RequestUri, stopwatch.ElapsedMilliseconds);
                    throw;
                }
                catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
                {
                    stopwatch.Stop();
                    logger.LogError(ex, "HTTP request timeout for {Url}. Time elapsed: {Elapsed} ms", request.RequestUri, stopwatch.ElapsedMilliseconds);
                    throw;
                }
                catch (Exception ex)
                {
                    stopwatch.Stop();
                    logger.LogError(ex, "Unexpected error during request to {Url}. Time elapsed: {Elapsed} ms", request.RequestUri, stopwatch.ElapsedMilliseconds);
                    throw;
                }
            }
        }
    }



}
