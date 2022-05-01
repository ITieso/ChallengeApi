using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Challenge.Application.Response;
using MediatR;

namespace Challenge.Application.RequestCommand.CityR
{
    public class UpdateCityRequest : IRequest<CityResponseBase>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Uf { get; set; }
    }
}
