using MediatR;
using OrderService.Application.Features.Actors.Dto;
using OrderService.Application.Models.utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Actors.Queries.ActorsList
{
    public class ActorsListQuery:PaginationDto ,IRequest<List<ActorDto>>
    {
        public string Name { get; set; }

    }
}
