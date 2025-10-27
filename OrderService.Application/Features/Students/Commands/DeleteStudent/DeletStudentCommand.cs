using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Students.Commands.DeleteStudent
{
    public class DeletStudentCommand:IRequest
    {
        public DeletStudentCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
