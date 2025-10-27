using AutoMapper;
using MongoDB.Driver;
using OrderService.Application.Features.Sizes.Queries.GetSizes;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Mapping
{
    public class SizeMapping:Profile
    {
        public SizeMapping()
        {
            CreateMap<Size,SizeDto>().ReverseMap();
        }
    }
}
