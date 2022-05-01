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
    public class UpdatePersonHandler : IRequestHandler<UpdatePersonRequest, PersonResponseBase>
    {
        private readonly IPersonService _PersonService;
        private readonly ICityService _CityService;
        public UpdatePersonHandler(IPersonService personService, ICityService cityService)
        {
            _PersonService = personService;
            _CityService = cityService;
        }

        public async Task<PersonResponseBase> Handle(UpdatePersonRequest request, CancellationToken cancellationToken)
        {
            var city = await _CityService.GetCityByNameAsync(request.CityName);
            if (city == null)
                throw new ApplicationException($"The {request.CityName} is not registered on table City");

            Person personUpdated = new Person(request.Id, request.Name, request.Cpf, request.Age, city.Id);
            var update = await _PersonService.UpdateAsync(personUpdated);

            PersonResponseBase response = new PersonResponseBase();
            response.AddPersonToResponse(update);

            return response;
        }
    }
}
