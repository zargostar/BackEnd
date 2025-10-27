using AutoMapper;
using OrderService.Application.Contracts.WepClientServices;
using OrderService.Application.Features.Genres.Queries.Getgenre;
using OrderService.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderServise.Infrastructure.WebClientApiservice
{
    public class ExternalApiService : IExternalApiService
    {
        private IHttpClientFactory _clientFactory;
        private IMapper mapper;

        public ExternalApiService(IHttpClientFactory clientFactory, IMapper mapper)
        {
            _clientFactory = clientFactory;
            this.mapper = mapper;
        }

        public async Task<List<GenreDto>> SaveExternalGenre(List<int> ids, CancellationToken cancellationToken)
        {
            var client=_clientFactory.CreateClient();
           var genreList=new List<GenreDto>();
            foreach (var id in ids)
            {
                var request =await client.GetAsync($"http://localhost:59816/api/Genre/{id}", cancellationToken);
                if (request.IsSuccessStatusCode)
                {
                    var response=await request.Content.ReadAsStringAsync(cancellationToken);
                    var data = JsonSerializer.Deserialize<GenreApiDto>(response, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    });
                    genreList.Add(mapper.Map<GenreDto>(data));

                    for (int i = 0; i < 100; i++)
                    {
                    cancellationToken.ThrowIfCancellationRequested();   
                           
                        await Console.Out.WriteLineAsync(i.ToString());
                    }
                }
                else
                {

                }

            }
           
            return genreList;
            
        }
    }
}
