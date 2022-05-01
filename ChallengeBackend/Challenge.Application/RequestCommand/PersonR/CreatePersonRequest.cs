using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge.Application.Response;
using MediatR;

namespace Challenge.Application.RequestCommand.PersonR
{
    public class CreatePersonRequest : IRequest<PersonResponseBase>
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public int Age { get; set; }
        public string CityName { get; set; }
    }
}
