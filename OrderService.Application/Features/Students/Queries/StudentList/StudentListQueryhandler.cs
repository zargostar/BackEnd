using AutoMapper;
using MediatR;

using OrderService.Application.Contracts;
using OrderService.Application.helper;
using OrderService.Application.Models.utiles;
using OrderServise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Students.Queries.StudentList
{
    public class StudentListQueryhandler : IRequestHandler<StudentListQuery, List<StudentDto>>
    {   private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentListQueryhandler(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        public async Task<List<StudentDto>> Handle(StudentListQuery request, CancellationToken cancellationToken)
        {
           
            var includes = new List<Expression<Func<Product, Object>>>()
            {
                x=>x.ProductSize,
                x=>x.ProductFeatures,
               


            };
            List<Expression<Func<Student, object>>> include = new List<Expression<Func<Student, object>>>() {
            x=>x.SportStudents
            };
            Expression<Func<Student, bool>> query=null ;
            

            if (!String.IsNullOrEmpty(request.Name) && request.Name != "null")
            {
                query = query.And(c => c.Name.Contains(request.Name));
               
            };
           
            var result = studentRepository.GetQueryAble(query,st=>st.OrderByDescending(x=>x.BirthDate), include);
            var stydents =  result.ToPage(new PaginationDto() { Page = request.Page, Rows = request.Rows });
        
            var data=mapper.Map<List<StudentDto>>(stydents);
            return data;
        }
            
    }
}
