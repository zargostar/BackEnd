using AutoMapper;
using MediatR;
using OrderService.Application.Contracts;
using OrderService.Application.Features.Actors.Dto;

namespace OrderService.Application.Features.Actors.Queries.ActorsList
{
    public class ActorsListQueryHandler : IRequestHandler<ActorsListQuery, List<ActorDto>>
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper mapper;

        public ActorsListQueryHandler(IActorRepository actorRepository, IMapper mapper)
        {
            _actorRepository = actorRepository;
            this.mapper = mapper;
        }

        public async Task<List<ActorDto>> Handle(ActorsListQuery request, CancellationToken cancellationToken)
        {
           var actors= await _actorRepository.GetAsync(x => x.Name.Contains(request.Name),null);
          //  var actor = await _actorRepository.GetAsync(x => x.Name.Contains("ali"),);
            return mapper.Map<List<ActorDto>>(actors);

        }
    }
}
