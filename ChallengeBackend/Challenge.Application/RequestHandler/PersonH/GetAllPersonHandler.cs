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
    public class GetAllPersonHandler : IRequestHandler<GetAllPersonRequest, IEnumerable<PersonResponseBase>>
    {
        private readonly IPersonService _personService;
        public GetAllPersonHandler(IPersonService personService)
        {
            _personService = personService;
        }
        public async Task<IEnumerable<PersonResponseBase>> Handle(GetAllPersonRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Person> person = await _personService.GetPersonsAsync();
            if (person == null)
                throw new ApplicationException("Person Not Found");

            var PersonListResponse = new PersonResponseBase();
            var response = PersonListResponse.AddPersonListToResponse(person);

            return response;
        }
    }
}
