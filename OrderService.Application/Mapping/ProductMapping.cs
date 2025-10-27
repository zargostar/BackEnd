using AutoMapper;
using OrderService.Application.Features.Products.Command.CreateProduct;
using OrderService.Application.Features.Products.Command.UpdateProduct;
using OrderService.Application.Features.Products.Queries.GetProductById;
using OrderService.Application.Features.Products.Queries.ProductList;
using OrderServise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Mapping
{
    public  class ProductMapping: Profile
    {
        public ProductMapping()
        {
            CreateMap<CreateProductCommand, Product>()

                .ForMember(des=>des.ProductFeatures,src=>src.
                MapFrom(x=>x.ProductFeatures.Select(x=>new ProductFeature() 
                { FeatureId=x.Id,Value=x.Value})))
                .ForMember(des => des.ProductSize,
                src => src.MapFrom(x => x.ProductSizes.Select(x => new ProductSize() { SizeId = x.Id, Weight = x.Weight })));
            CreateMap<Product, ProductListDto>();


            CreateMap<Product, ProductDto>()


                

                .ForMember(des=>des.ProductFeatures,
                src=>src.MapFrom(src=>src.ProductFeatures
                .Select(x=>new ProductFeatureDto() { Id=x.FeatureId,Value=x.Value}).ToList()))
                .ForMember(des => des.ProductSizes
            , src => src.MapFrom(src =>src.ProductSize
            .Select(x=>new ProductSizeDto() {Size=x.Size.Name ,Id=x.SizeId,Weight=x.Weight }).ToList()));






            CreateMap<UpdateProductCommand, Product>().
                ForMember(des => des.ProductFeatures,
                src=>src.MapFrom(src=>src.ProductFeatures.Select(x=>new ProductFeature() { FeatureId=x.Id,Value=x.Value}).ToList()))
                .ForMember(des => des.ProductSize,
                src => src.MapFrom(p => p.ProductSize
                .Select(x => new
                ProductSize()
                { SizeId = x.Id, Weight = x.Weight }).ToList()));
            

        }
    }
}
