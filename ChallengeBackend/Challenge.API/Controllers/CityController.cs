using System.Threading.Tasks;
using Challenge.Application.RequestCommand;
using Challenge.Application.RequestCommand.CityR;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CityController : Controller
    {

        private readonly IMediator _mediator;
        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //TODO - ADCIONAR INSTRUÇOES
        [HttpGet]
        [Route("/all/city")]
        public async Task<IActionResult> GetAllCities()
        {
            GetAllCitiesRequest request = new GetAllCitiesRequest();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("/cityById/{id}")]
        public async Task<IActionResult> GetCityById([FromRoute] int id)
        {
            GetCityByIdRequest request = new GetCityByIdRequest();
            request.Id = id;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("/cityByName/{name}")]
        public async Task<IActionResult> GetCityByName([FromRoute] string name)
        {
            GetCityByNameRequest request = new GetCityByNameRequest();
            request.Name = name;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("/citiesByUf/{uf}")]
        public async Task<IActionResult> GetCityByUf([FromRoute] string uf)
        {
            GetCitiesByUfRequest request = new GetCitiesByUfRequest();
            request.Uf = uf;
            var response = await _mediator.Send(request);
            return Ok(response);
        }


        //TODO - ADCIONAR INSTRUÇOES
        [HttpPost]
        [Route("/create/city")]
        public async Task<IActionResult> Create([FromBody] CreateCityRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpPut]
        [Route("/update/city:{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCityRequest request)
        {
            request.Id = id;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("/delete/city:{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteCityRequest request = new DeleteCityRequest();
            request.Id = id;
            var response = await _mediator.Send(request);
            return Ok($"The city {response.Name} was deleted");
        }
    }

}
