using AutoMapper;
using OrderService.Application.Features.Genres.Queries.Getgenre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Genres
{
    public class GenreProcessor
    {
        public event EventHandler ProccessHandler;
        public event EventHandler<List<GenreArg>> ProccessFinalHandler;
        private readonly IMapper mapper;

        public GenreProcessor(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public void CalculateBestSelerGenre(List<GenreDto> genres)
        {
            Console.WriteLine(genres.Count);
            AfterProcces();
            FinalProcess(genres);

        }
        protected virtual void AfterProcces()
        {
            ProccessHandler?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void FinalProcess(List<GenreDto> genres) {
            var data =mapper.Map<List<GenreArg>>(genres);
            ProccessFinalHandler.Invoke(this, data);
        }
    }
}
public class GenreArg:EventArgs
{
    public int Id { get; set; }
    public string Name { get; set; }
  

}
