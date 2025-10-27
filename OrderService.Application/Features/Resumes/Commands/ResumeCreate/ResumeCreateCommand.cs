using MediatR;
using OrderServise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Resumes.Commands.ResumeCreate
{
    public class ResumeCreateCommand:IRequest
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public List<SkillDto> Skills { get; set; }
    }
    public class SkillDto
    {
       
        public string Title { get; set; }
        public string Level { get; set; }
    }
}
