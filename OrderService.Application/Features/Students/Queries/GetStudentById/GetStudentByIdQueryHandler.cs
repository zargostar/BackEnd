using AutoMapper;
using MediatR;
using OrderService.Application.Contracts;
using OrderService.Application.Features.Students.Commands.CreateStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Students.Queries.GetStudentById
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, CreateStudentCommand>
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public GetStudentByIdQueryHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        public async Task<CreateStudentCommand> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student =await studentRepository.GetAsync(x=>x.Id==request.Id,null, "SportStudents");
            var result=mapper.Map<CreateStudentCommand>(student.First());
            return result;
        }
    }
}
