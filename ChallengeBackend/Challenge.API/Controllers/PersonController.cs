using System.Threading.Tasks;
using Challenge.Application.RequestCommand.PersonR;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PersonController : Controller
    {

        private readonly IMediator _mediator;
        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/all/person")]
        public async Task<IActionResult> GetAllPerson()
        {
            GetAllPersonRequest request = new GetAllPersonRequest();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("/personById/{id}")]
        public async Task<IActionResult> GetPersonById([FromRoute] int id)
        {
            GetPersonByIdRequest request = new GetPersonByIdRequest();
            request.Id = id;
            var response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpGet]
        [Route("/personByName/{name}")]
        public async Task<IActionResult> GetPersonByName([FromRoute] string name)
        {
            GetPersonByNameRequest request = new GetPersonByNameRequest();
            request.Name = name;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("/personByCpf/{cpf}")]
        public async Task<IActionResult> GetPersonByCpf([FromRoute] string cpf)
        {
            GetPersonByCpfRequest request = new GetPersonByCpfRequest();
            request.Cpf = cpf;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("/create/person")]
        public async Task<IActionResult> Create([FromBody] CreatePersonRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("/update/person:{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePersonRequest request)
        {
            request.Id = id;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("/delete/person:{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeletePersonRequest request = new DeletePersonRequest();
            request.Id = id;
            var response = await _mediator.Send(request);
            return Ok($"{response.Name} was deleted");
        }

    }

}
