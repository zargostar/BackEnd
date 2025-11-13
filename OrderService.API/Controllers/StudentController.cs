using AutoMapper;
using Books.API.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using OrderService.API.Helpers.factory;
using OrderService.Application.Contracts.WepClientServices;
using OrderService.Application.Features.Genres.Queries.Getgenre;
using OrderService.Application.Features.Students.Commands.CreateStudent;
using OrderService.Application.Features.Students.Commands.DeleteStudent;
using OrderService.Application.Features.Students.Commands.UpdateStudent;
using OrderService.Application.Features.Students.Queries.EfTest;
using OrderService.Application.Features.Students.Queries.GetStudentById;
using OrderService.Application.Features.Students.Queries.StudentList;
using OrderService.Application.Models;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrderService.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Student")]
    public class StudentController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IFactoryUpload factoryUpload;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper mapper;
        private readonly IExternalApiService externalApiService;


        public StudentController(IMediator mediator, IFactoryUpload factoryUpload, IHttpClientFactory httpClientFactory, IMapper mapper, IExternalApiService externalApiService)
        {
            this.mediator = mediator;
            this.factoryUpload = factoryUpload;
            _httpClientFactory = httpClientFactory;
            this.mapper = mapper;
            this.externalApiService = externalApiService;
        }
        /// <summary>
        /// fghhty
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new DeletStudentCommand(id));
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateStudentCommand createStudent)
        {
            // factoryUpload.Uploader(null);
            await mediator.Send(createStudent);
            return NoContent();
        }
        //[ResponseCache(Duration = 3600)]
        [HttpGet]
        public async Task<ActionResult<List<StudentDto>>> Get([FromQuery] StudentListQuery pagination)
        {
            var result = await mediator.Send(pagination);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateStudentCommand student)
        {
            await mediator.Send(student);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await mediator.Send(new GetStudentByIdQuery(id));
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> BindingTest(int id, [FromHeader] string name)
        {
            var dd = name;
            return Ok(id);
        }
        [AllowAnonymous]
        [HttpGet("[action]/{ids}")]
        public async Task<IActionResult> BindingTestList(
            [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<string> ids)
        {
            var dd = ids;
            return Ok(dd);
        }
        [AllowAnonymous]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> CreateStudent(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var request = await client.GetAsync($"http://localhost:59816/api/Genre/{id}");
            if (request.IsSuccessStatusCode)
            {
                var response = await request.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<GenreApiDto>(response, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
                return Ok(data);
            }
            return Ok(null);
        }
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> CancelationTokenListIds([FromBody] List<int> ids)
        {
            var client = _httpClientFactory.CreateClient();
            var genreList = new List<GenreDto>();
            var cancelation = new CancellationTokenSource();
            foreach (var id in ids)
            {

                var request = await client.GetAsync($"http://localhost:59816/api/Genre/{id}", cancelation.Token);
                if (request.IsSuccessStatusCode)
                {
                    var response = await request.Content.ReadAsStringAsync(cancelation.Token);
                    var data = JsonSerializer.Deserialize<GenreApiDto>(response, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    });
                    // genreList.Add(mapper.Map<GenreDto>(data));
                    genreList.Add(new GenreDto()
                    {
                        Id = data.Id,
                        Name = data.Name,
                        Image = data.Image,
                    });

                }
                else
                {
                    cancelation.Cancel();

                }


            }


            return Ok(genreList); ;
        }
        /// <summary>
        /// در صورت بروز خطا تسک کلا کنسل می شود
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateStudentListIds([FromBody] List<int> ids)
        {
            var client = _httpClientFactory.CreateClient();
            var genreList = new List<GenreDto>();
            var cancelation = new CancellationTokenSource();
            foreach (var id in ids)
            {

                var request = await client.GetAsync($"http://localhost:59816/api/Genre/{id}");
                if (request.IsSuccessStatusCode)
                {
                    var response = await request.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<GenreApiDto>(response, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    });
                    // genreList.Add(mapper.Map<GenreDto>(data));
                    genreList.Add(new GenreDto()
                    {
                        Id = data.Id,
                        Name = data.Name,
                        Image = data.Image,
                    });

                }
                else
                {
                    cancelation.Cancel();

                }


            }


            return Ok(genreList); ;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateStudents([FromBody] List<int> ids)
        {
            var client = _httpClientFactory.CreateClient();
            var clientTask = new List<Task<HttpResponseMessage>>();
            foreach (var id in ids)
            {
                clientTask.Add(client.GetAsync($"http://localhost:59816/api/Genre/{id}"));

            }
            var taskList = await Task.WhenAll(clientTask);
            var genreList = new List<GenreDto>();
            foreach (var task in taskList)
            {
                var response = await task.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<GenreApiDto>(response, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
                genreList.Add(new GenreDto { Id = data.Id, Name = data.Name, Image = data.Image });

            }


            return Ok(genreList);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CancelByUserRequest([FromBody] List<int> ids, CancellationToken cancellationToken)
        {
            var data = await externalApiService.SaveExternalGenre(ids, cancellationToken);
            return Ok(data);
        }
        [HttpGet("EfTest")]
        public async Task<IActionResult> EfTest()
        {
            await mediator.Send(new EfTestQuery());

            return Ok();
        }
    }
}
