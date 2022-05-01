using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Challenge.Application.IServices;
using Challenge.Application.RequestCommand.PersonR;
using Challenge.Application.Response;
using MediatR;

namespace Challenge.Application.RequestHandler.PersonH
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdRequest, PersonResponseBase>
    {
        private readonly IPersonService _PersonService;
        public GetPersonByIdHandler(IPersonService personService)
        {
            _PersonService = personService;
        }

        public async Task<PersonResponseBase> Handle(GetPersonByIdRequest request, CancellationToken cancellationToken)
        {
            var person = await _PersonService.GetPersonByIdAsync(request.Id);

            if (person == null)
                throw new ApplicationException("Person not found");

            PersonResponseBase response = new PersonResponseBase();
            response.AddPersonToResponse(person);

            return response;
        }
    }
}
