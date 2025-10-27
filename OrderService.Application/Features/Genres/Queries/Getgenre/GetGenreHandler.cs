using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using OrderService.Application.Contracts;
using OrderService.Application.Exceptions;
using OrderService.Application.Redis;
using OrderServise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Genres.Queries.Getgenre
{
    public class GetGenreHandler : IRequestHandler<GetGenreQuery, GenreDto>
    {
        private readonly IMediator _mediator;
        private readonly IMapper mapper;
        private readonly IGenreRepository genreRepository;
        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache _redis;
        private readonly GenreProcessor _processor;




        public GetGenreHandler(IMediator mediator, IGenreRepository genreRepository, IMapper mapper, IMemoryCache memoryCache, IDistributedCache redis, GenreProcessor processor)
        {
            _mediator = mediator;
            this.genreRepository = genreRepository;
            this.mapper = mapper;
            this.memoryCache = memoryCache;
            _redis = redis;
            _processor = processor;
           
        }

        public async Task<GenreDto> Handle(GetGenreQuery request, CancellationToken cancellationToken)
        {
            //docker run --name redisDb -p 6379:6379 -d -v /redis-data:/data redis --requirepass "majid9050"
            //var mcatch= memoryCache.Get<GenreDto>(request.Id);
            //if (mcatch != null)
            //{
            //    return mcatch;
            //}
            //else
            //{
            //    string genreKey = $"genreKey-{request.Id}";
            //  var data=await  _redis.GetSet<Genre>(genreKey,async () => {
            //        var genre = await genreRepository.GetByIdAsync(request.Id);
            //      return genre;
            //    });

            //    if (data == null) {
            //        throw new ClientErrorMessage("یافت نشد");
            //    }
            //    var res= mapper.Map<GenreDto>(data);
            //    var cOption = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(1)) ;
            //    memoryCache.Set<GenreDto>(request.Id, re cOption);
            //    return res;

            //}
            
            string genreKey = $"genreKey-{request.Id}";
         //   _redis.Remove(genreKey);
            var data = await _redis.GetSet(genreKey, async () => {
              //  var genre0 = await genreRepository.GetByIdAsync(request.Id);
               var genre = await genreRepository.GetAsync(x=>true);
                return genre;
            });
           // var ids = data.Select(x => x.Id).ToList();
            _processor.ProccessHandler += _processor_ProccessHandler;
            _processor.ProccessFinalHandler += _processor_ProccessFinalHandler;
            _processor.ProccessFinalHandler += _processor_ProccessFinalHandler1;
                                            
           // ;

            //if (data == null)
            //{
            //    throw new ClientErrorMessage("یافت نشد");
            //}
            var res = mapper.Map<List<GenreDto>>(data);
            _processor.CalculateBestSelerGenre(res);


            var cOption = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(1));
            //memoryCache.Set<GenreDto>(request.Id, res, cOption);
            return res.FirstOrDefault();



        }

        private void _processor_ProccessFinalHandler1(object? sender, List<GenreArg> e)
        {
            foreach (var item in e)
            {
                Console.WriteLine($"Helo {item.Name} ");

            }
        }

        private void _processor_ProccessFinalHandler(object? sender, List<GenreArg> e)
        {
            foreach (var item in e)
            {
                Console.WriteLine( $"Helo {item.Name} id :{item.Id}");

            }
        }

        private void _processor_ProccessHandler(object? sender, EventArgs e)
        {
            Console.WriteLine("I am after proccess task with event registration");
        }
    }
}
