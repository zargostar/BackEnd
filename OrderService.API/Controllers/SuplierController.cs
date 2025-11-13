using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Infrastructure.Persistance;

namespace OrderService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [ApiExplorerSettings(GroupName = "StudentTest")]
    public class SuplierController : ControllerBase
    {
        private readonly DataBaseContext _dataBaseContext;

        public SuplierController(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        [HttpGet]
        public async IAsyncEnumerable<SuplierDto> Get()
        {
            await foreach (var item in _dataBaseContext.Supliers.AsAsyncEnumerable())
            {
                await Task.Delay(1000);
                var res = new SuplierDto(item.Name, item.Country);
                yield return res;   
                
            }

        }
    }
    public record SuplierDto(string Name,string Country);
}
