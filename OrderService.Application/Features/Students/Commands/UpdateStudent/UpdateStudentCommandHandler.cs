using AutoMapper;
using MediatR;
using OrderService.Application.Contracts;
using OrderService.Application.Features.Students.Commands.CreateStudent;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public UpdateStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        public async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            List<Student> res = await studentRepository.GetAsync(st => st.Id == request.Id, null, "SportStudents",false);
            var studentToUpdate = res.FirstOrDefault();

            mapper.Map(request, studentToUpdate);

            await studentRepository.UpdateAsync(studentToUpdate);



        }
    }
}
