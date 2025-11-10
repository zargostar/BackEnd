using SMSService.Api.ApiService.Dtos;
using System.IO.Compression;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;


namespace SMSService.Api.ApiService
{
    public record ActorDto(long Id,string Name,string Title);
    public class ActorApiService
    {
        private readonly HttpClient httpClient;
       

        public ActorApiService(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient.CreateClient("actor");
           
        }

        public async Task< List<ActorDto>> Actors(string lan)
        {
         
            var response = await httpClient.GetAsync($"/api/actor/GetJasons?lan={lan}");
            response.EnsureSuccessStatusCode();
            var data =await response.Content.ReadFromJsonAsync<List<ActorDto>>();
            return data;
        }

        public async Task<ActorDto> Actor(int id,string lan)
        {
            httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            var response = await  httpClient.GetAsync($"/api/actor/GetJason/{id}?lan={lan}");
            response.EnsureSuccessStatusCode();
            var data=await response.Content.ReadFromJsonAsync<ActorDto>();
            return data;

        }

        public async Task AddActor(ActorModel actor)
        {
            var json = JsonSerializer.Serialize(actor);
            var bytes = Encoding.UTF8.GetBytes(json);
            using var ms = new MemoryStream();
            using (var gzip = new GZipStream(ms, CompressionMode.Compress, leaveOpen: true))
            {
                gzip.Write(bytes, 0, bytes.Length);
            }
            ms.Position = 0;
            var content = new StreamContent(ms);
            content.Headers.ContentEncoding.Add("gzip");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await httpClient.PostAsync("/api/actor/AddDictionary", content);
            if (response.IsSuccessStatusCode) {
                Console.WriteLine("actor added successfull"+response.StatusCode.ToString());
            }




        }

    }
}
