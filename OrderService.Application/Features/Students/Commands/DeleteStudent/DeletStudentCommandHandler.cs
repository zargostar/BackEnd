using MediatR;
using OrderService.Application.Contracts;
using OrderService.Application.Exceptions;
using OrderServise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Students.Commands.DeleteStudent
{
  
    public class DeletStudentCommandHandler : IRequestHandler<DeletStudentCommand>
    {
        private readonly IStudentRepository studentRepositor;

        public DeletStudentCommandHandler(IStudentRepository studentRepositor)
        {
            this.studentRepositor = studentRepositor;
        }

        public async Task Handle(DeletStudentCommand request, CancellationToken cancellationToken)
        {
            throw new ClientErrorMessage("حذف با موفقیت انجام نشد ");
          await  studentRepositor.DeleteAsync(new Student { Id = request.Id });
        }
    }
}
