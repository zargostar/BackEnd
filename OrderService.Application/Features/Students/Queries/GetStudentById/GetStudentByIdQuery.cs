using MediatR;
using OrderService.Application.Features.Students.Commands.CreateStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Students.Queries.GetStudentById
{
    public class GetStudentByIdQuery:IRequest<CreateStudentCommand>
    {
        public int Id { get; set; }

        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
