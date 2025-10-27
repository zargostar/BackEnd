
using MediatR;
using OrderService.Application.Features.Students.Commands.CreateStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public List<SportStudentDto> SportStudents { get; set; }
    }
   
}
