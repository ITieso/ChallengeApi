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
    public class GetPersonByCpfHandler : IRequestHandler<GetPersonByCpfRequest, PersonResponseBase>
    {
        private readonly IPersonService _PersonService;
        public GetPersonByCpfHandler(IPersonService personService)
        {
            _PersonService = personService;
        }

        public async Task<PersonResponseBase> Handle(GetPersonByCpfRequest request, CancellationToken cancellationToken)
        {
            var person = await _PersonService.GetPersonByCPFAsync(request.Cpf);

            if (person == null)
                throw new ApplicationException("Person not found");

            PersonResponseBase response = new PersonResponseBase();
            response.AddPersonToResponse(person);

            return response;
        }

     
    }
}
