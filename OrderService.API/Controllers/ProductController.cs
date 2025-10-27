using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.API.Dtos;
using OrderService.API.Filters;
using OrderService.API.Helpers.FileStorage;
using OrderService.Application.Exceptions;
using OrderService.Application.Features.Products.Command.CreateProduct;
using OrderService.Application.Features.Products.Command.UpdateProduct;
using OrderService.Application.Features.Products.Queries.GetProductById;
using OrderService.Application.Features.Products.Queries.ProductList;
using OrderService.Application.Models.utiles;
using OrderService.Domain.Entities;

namespace OrderService.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IFileStorageService uploader;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IMediator mediator, IFileStorageService uploader, ILogger<ProductController> logger)
        {
            _mediator = mediator;
            this.uploader = uploader;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateProductCommand create)
        {
           
            await _mediator.Send(create);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            return await _mediator.Send(new GetProductByIdQuery(id));
        }
        [ResourceCatch]
        [HttpGet()]
        public async Task<ActionResult<List<ProductListDto>>> Get([FromQuery] ProductListQuery pagination)
        {

          
            // var request = new ProductListQuery() { Page = pagination.Page,PageSize=3 };
            return await _mediator.Send(pagination);
        }
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody]UpdateProductCommand updateProduct)
        {
          
            await _mediator.Send(updateProduct);
            return NoContent();
        }
        [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadImage([FromForm] ImageUploadDto image)
        {
            var url =await uploader.SaveFile(image.Image, "productImage");
            return Ok(new {imgeUrl= url });
           
        }



    }
}
