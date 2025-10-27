using MediatR;
using OrderService.Application.Models.utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Students.Queries.StudentList
{
    public class StudentListQuery:PaginationDto,IRequest<List<StudentDto>>
    {
        public string? Name { get; set; }
    }
}
