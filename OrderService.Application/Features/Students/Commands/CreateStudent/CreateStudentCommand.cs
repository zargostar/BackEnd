using MediatR;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommand:IRequest
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public List<SportStudentDto> SportStudents { get; set; }
        public List<string> Images { get; set; }

    }
    public class SportStudentDto
    {
        public short SportLevel { get; set; }
        public int SportId { get; set; }
    }
}
