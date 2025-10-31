using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using MimeKit.Cryptography;

using System.Text.Json;
using System.Threading.Tasks;

namespace OrderService.API.ApiServices
{
    public class SMSService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public SMSService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public record SendMessageResponse(int id ,string Message);
        public async Task<List<SendMessageResponse>>  SendSMSInLINE(List<int> ids, CancellationToken cancellationToken)
        {
            var result=new List<SendMessageResponse>();
                //cancellationToken.ThrowIfCancellationRequested();
            if(cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine($"Client received: ===============================ooooo");
            }
            using (var cts=new CancellationTokenSource())
            {
                foreach (var id in ids)
                {

                    var url = $"http://localhost:5000/api/SendSMS/send/{id}";

                    var content = await _httpClient.GetAsync(url, cancellationToken);


                    if (!content.IsSuccessStatusCode)
                    {
                        return null;

                    }
                    var res = await content.Content.ReadAsStringAsync(cancellationToken);
                    await Task.Delay(5000);

                    if (string.IsNullOrEmpty(res))
                    {

                        continue;
                    }
                    var data = JsonSerializer.Deserialize<SendMessageResponse>(res, _options);
                    result.Add(data);
                }

            }

              

               


            
            return result;
        }

        public async Task<List<SendMessageResponse>> SendSmsByWhenAll(HashSet<int> ids)
        {
            var result=new List<SendMessageResponse>();
            var taskList = new List<Task<HttpResponseMessage>>();
        
            foreach (var id in ids)
            {
                
               
                var url = $"http://localhost:5000/api/SendSMS/send/{id}";
              taskList.Add( _httpClient.GetAsync(url));
              

            }
            var taskResult=await Task.WhenAll(taskList);
            foreach (var item in taskResult)
            {
                var x= JsonSerializer.Deserialize<SendMessageResponse>(await item.Content.ReadAsStringAsync(), _options);
                result.Add(x);
                
            }
            return result;
        }
    
    }
}
