using AutoMapper;
using OrderService.Application.Features.Genres.Queries.Getgenre;
using OrderService.Application.Features.Orders.Comands.CreateNewOrder;
using OrderService.Application.Models;
using OrderServise.Domain.Entities;

namespace OrderService.API.Mapping
{
    public class GenreApiMaping:Profile
    {
        public GenreApiMaping()
        {
          //  CreateMap<OrderLine, OrderItem>().ReverseMap();
            CreateMap<GenreApiDto,GenreDto>().ReverseMap();
        }
    }
}
