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
    public class DeletePersonHandler : IRequestHandler<DeletePersonRequest, PersonResponseBase>
    {
        private readonly IPersonService _PersonService;
        public DeletePersonHandler(IPersonService personService)
        {
            _PersonService = personService;
        }

        public async Task<PersonResponseBase> Handle(DeletePersonRequest request, CancellationToken cancellationToken)
        {
            var person = await _PersonService.GetPersonByIdAsync(request.Id);
            if (person == null)
                throw new ApplicationException("Person not found");

            var deletedPerson = await _PersonService.DeleteAsync(person);

            var response = new PersonResponseBase();
            response.AddPersonToResponse(deletedPerson);

            return response;
        }
    }
}
