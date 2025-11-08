using AutoMapper;

using OrderService.Application.Features.Actors.Dto;
using OrderService.Domain.Entities;
using System.Text.Json;



namespace OrderService.Application.Mapping
{
    public class ActorMapping:Profile
    {
        
        //JsonSerializer.Serialize(actor.Title),
        // CreateMap<Movie, MovieDto>().ForMember(des=>des.Genres, src=>src.MapFrom(src=>src.GenreMovie.Select(p=>new Genre() { Id = p.GenreId,Name = p.Genre.Name}))).
        //  ForMember(des=>des.Theaters, res=>res.MapFrom(res=>res.MovieTheater.Select(p=>new TheaterDto() { Name = p.Theater.Name} )));
        public ActorMapping()
        {
            CreateMap<ActorModel, Actor>()
                .ForMember(des => des.Title, src => src.MapFrom(src => JsonOption(src)));
                //.ForMember(des => des.Title, src => src.MapFrom(src => JsonSerializer.Serialize(src.Title)));
            CreateMap<DiscriptionModel, Discription>();
           
        }
        public string JsonOption(ActorModel model)
        {
            return JsonSerializer.Serialize(model.Title);
        }

    }
}
