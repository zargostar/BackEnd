using AutoMapper;
using OrderService.Application.Features.Orders.Comands.CreateNewOrder;
using OrderService.Application.Features.Resumes.Commands.ResumeCreate;
using OrderService.Application.Features.Resumes.Queries.GetResumeById;
using OrderService.Domain.Entities;
using OrderService.Domain.Entities.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Mapping
{
    public class ResumeMapping:Profile
    {
        public ResumeMapping()
        {
            CreateMap<ResumeCreateCommand,Resume>();
            CreateMap<SkillDto, Skill>();
            CreateMap<Resume, ResumeDto>();

           
           
        }
    }
     //CreateMap<OrderItemCommand, OrderMongo>().ForMember(des => des.Id, src => src.Ignore());
}
