using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Challenge.Application.IServices;
using Challenge.Application.RequestCommand.PersonR;
using Challenge.Application.Response;
using Challenge.Domain.Entities;
using MediatR;

namespace Challenge.Application.RequestHandler.PersonH
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonRequest, PersonResponseBase>
    {
        private readonly IPersonService _personService;
        private readonly ICityService _cityService;
        public CreatePersonHandler(IPersonService personService, ICityService cityService)
        {
            _personService = personService;
            _cityService = cityService;
        }
        public async Task<PersonResponseBase> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
        {
            var city = await _cityService.GetCityByNameAsync(request.CityName);
            if (city == null)
                throw new ApplicationException($"The city {request.CityName} is not exist on table City");

            var personExiste = await _personService.GetPersonByCPFAsync(request.Cpf);
            if(personExiste != null)
            throw new ApplicationException("Already exist a person regirested with CPF");

            var personEntity = new Person(request.Name, request.Cpf, request.Age, city);

            var createPerson = await _personService.CreateAsync(personEntity);

            var response = new PersonResponseBase();
            response.AddPersonToResponse(createPerson);
            return response;

        }
    }
}
