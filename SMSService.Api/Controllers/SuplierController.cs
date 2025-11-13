using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSService.Api.Dapper;
using System.Data;

namespace SMSService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuplierController : ControllerBase
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public SuplierController(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var data = await _connectionFactory.DapperQuery<SuplierDto>("SupliersList", new { Skip = 10, Take = 10 });
            //await _connectionFactory.DapperQuery("SuplierDelete @Id", new { Id = 7 });
            await _connectionFactory.DapperQuery("SuplierDelete", new { Id = 7 });

            return Ok(data);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Get(int id)
        {

           
            
            await _connectionFactory.DapperQuery("SuplierDelete", new { Id =id });

            return Ok();

        }
        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] SuplierDto suplier)
        {



          var res=  await _connectionFactory.DapperQuery<int>("SuplierInsert", new { Name=suplier.Name });

            return Ok(res.First());

        }
        public record SuplierDto(int Id, string Country, string Name);
    }
}
