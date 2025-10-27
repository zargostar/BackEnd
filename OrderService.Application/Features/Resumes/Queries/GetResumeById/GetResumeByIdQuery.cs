using MediatR;
using OrderService.Domain.Common;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Resumes.Queries.GetResumeById
{
    public class GetResumeByIdQuery:IRequest<ResumeDto>
    {
        public GetResumeByIdQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }

    public class ResumeDto:BaseEntity
    {
      
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
