using AutoMapper;
using OrderService.Application.Features.Students.Commands.CreateStudent;
using OrderService.Application.Features.Students.Commands.UpdateStudent;
using OrderService.Application.Features.Students.Queries.StudentList;
using OrderServise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Mapping
{
    public class StudentMapping:Profile
    {
        public StudentMapping() {
          //  CreateMap<SportStudentDto,SportStudent>();
            CreateMap<CreateStudentCommand, Student>().ForMember(des=>des.SportStudents,
                dto=>dto.MapFrom(dto=>dto.SportStudents.Select(x=>new SportStudent()
                { SportId=x.SportId,SportLevel=(SportLevel)x.SportLevel})));
            CreateMap<Student, StudentDto>()
                //.ForMember(x=>x.Age,dto=>dto.Ignore())
                .ForMember(x=>x.Sports,src=>src.MapFrom(src=>src.SportStudents.Count));
            CreateMap<UpdateStudentCommand, Student>()
                .ForMember(x => x.SportStudents,
                dto => dto.MapFrom(dto => dto.SportStudents
                .Select(p => new SportStudent() {SportLevel=(SportLevel)p.SportLevel,
                    SportId=p.SportId }).ToList()));
            CreateMap<Student, CreateStudentCommand>();
            CreateMap<SportStudent, SportStudentDto>();
        }
    }
}
