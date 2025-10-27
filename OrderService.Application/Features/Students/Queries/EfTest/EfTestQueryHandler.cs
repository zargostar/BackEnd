using MediatR;
using OrderService.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Students.Queries.EfTest
{
     
    public class EfTestQueryHandler : IRequestHandler<EfTestQuery>
    {
        private readonly IStudentRepository studentRepository;

        public EfTestQueryHandler(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public async Task Handle(EfTestQuery request, CancellationToken cancellationToken)
        {
           await studentRepository.TestEf();
            
        }
    }
}
