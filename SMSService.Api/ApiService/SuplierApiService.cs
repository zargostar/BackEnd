using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Channels;
using static System.Net.Mime.MediaTypeNames;

namespace SMSService.Api.ApiService
{
   
    public class SuplierApiService
    {
        private readonly HttpClient httpClient;

        public SuplierApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        private async Task SendMessage(string name,string country)
        {
            var random = new Random();
            var num = random.Next(1, 6);
            var err=new Random();
            var readomErr = err.Next(1, 5);
            if (random.Next(1, 10) <7)
                throw new Exception("Simulated send error");

            await Task.Delay(1000*num);
            Console.WriteLine($"Hello {name} from {name} delay {num}");

        }

        private async Task WithRetray(string name, string country)
        {
            const int  maxRetry= 3;
            for (int attempt = 1; attempt <= maxRetry; attempt ++)
            {
                try
                {
                    await SendMessage(name, country);
                    return;
                }
                catch(Exception e) 
                {
                        Console.WriteLine(e.Message);
                   // await SendMessage(name, country);
                    if (maxRetry== attempt)
                    {
                        Console.WriteLine($"🚨 Giving up on {name} after {maxRetry} attempts.");
                        return;

                    }

                }
                
            }
        }

        public async Task Get()
        {
                //  Flow:

                // The producer starts pushing items into the channel as it reads them from the API.

                // The 5 consumers start pulling items concurrently.

                //When a consumer finishes SendMessage() for one item, it immediately pulls the next item from the channel queue.

                //This continues until:

                //All 100 items have been read and processed.

                //The producer calls channel.Writer.Complete().

                //All consumers finish reading and exit their loops.

                //Finally:
            _ = Task.Run(async () =>
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                // Create a channel for streaming messages
                var channel = Channel.CreateUnbounded<SuplierDto>();

                // 1️⃣ Producer: read from stream and push to channel
                var producer = Task.Run(async () =>
                {
                    await using var res = await httpClient.GetStreamAsync("/api/suplier");
                    await foreach (var item in JsonSerializer.DeserializeAsyncEnumerable<SuplierDto>(res, options))
                    {
                        if (item != null)
                            await channel.Writer.WriteAsync(item);
                    }
                    channel.Writer.Complete(); // signal that no more items will come
                });

                // 2️⃣ Consumers: process items concurrently
               
                var consumerCount = 5; // number of parallel tasks
                consumerCount = Environment.ProcessorCount;
                Console.WriteLine($"consumerCount {consumerCount}");
                var consumers = Enumerable.Range(0, consumerCount).Select(async _ =>
                {
                    await foreach (var item in channel.Reader.ReadAllAsync())
                    {
                        await WithRetray(item.Name, item.Country);
                       // await SendMessage(item.Name, item.Country);
                    }
                });

                // 3️⃣ Run producer + consumers together
                await Task.WhenAll(consumers.Prepend(producer));
            });

            // This returns immediately — background work continues
            Console.WriteLine("Started background processing...");
        }



  
       
        public async Task Get00() {

            _ = Task.Run(async() =>
            {
                var semaphore = new SemaphoreSlim(5);
                var tasks = new List<Task>();
                await semaphore.WaitAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                using var res = await httpClient.GetStreamAsync("/api/suplier");
                await foreach (var item in JsonSerializer.DeserializeAsyncEnumerable<SuplierDto>(res, options))
                {
                    tasks.Add(Task.Run(
                        async () =>
                        {
                            try
                            {
                                await SendMessage(item.Name, item.Country);

                            }
                            finally
                            {
                                semaphore.Release();
                            }
                            
                        }
                    ));
                  
                }

            });
        }
    }
    public record SuplierDto(string Name, string Country);
}
