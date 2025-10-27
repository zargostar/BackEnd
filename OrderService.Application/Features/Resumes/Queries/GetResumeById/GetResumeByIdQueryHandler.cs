using AutoMapper;
using MediatR;
using OrderService.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Resumes.Queries.GetResumeById
{
    public class GetResumeByIdQueryHandler : IRequestHandler<GetResumeByIdQuery, ResumeDto>
    {
        private readonly IMapper mapper;
        private readonly IResumeRepository repository;

        public GetResumeByIdQueryHandler(IMapper mapper, IResumeRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<ResumeDto> Handle(GetResumeByIdQuery request, CancellationToken cancellationToken)
        {
            var resume = await repository.GetAsync(r => r.UserId == request.UserId,orderBy:null,"Skills");
            var result= mapper.Map<ResumeDto>(resume.First());
            return result;
        }
    }
}
