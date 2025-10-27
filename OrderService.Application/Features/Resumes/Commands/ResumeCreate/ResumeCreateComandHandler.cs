using AutoMapper;
using MediatR;
using OrderService.Application.Contracts;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Resumes.Commands.ResumeCreate
{
    public class ResumeCreateComandHandler : IRequestHandler<ResumeCreateCommand>
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly IMapper mapper;

        public ResumeCreateComandHandler(IResumeRepository resumeRepository, IMapper mapper)
        {
            _resumeRepository = resumeRepository;
            this.mapper = mapper;
        }

        public async Task Handle(ResumeCreateCommand request, CancellationToken cancellationToken)
        {
           var resume=mapper.Map<Resume>(request);
            await _resumeRepository.AddAsync(resume);

        }
    }
}
