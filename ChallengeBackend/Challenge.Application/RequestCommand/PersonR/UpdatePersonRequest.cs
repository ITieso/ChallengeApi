using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Challenge.Application.Response;
using MediatR;

namespace Challenge.Application.RequestCommand.PersonR
{
    public class UpdatePersonRequest : IRequest<PersonResponseBase>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public int Age { get; set; }
        public string CityName { get; set; }
    }
}
