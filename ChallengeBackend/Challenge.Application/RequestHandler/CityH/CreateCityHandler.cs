using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Challenge.Application.IServices;
using Challenge.Application.RequestCommand.CityR;
using Challenge.Application.Response;
using Challenge.Domain.Entities;
using MediatR;

namespace Challenge.Application.RequestHandler.CityH
{
    public class CreateCityHandler : IRequestHandler<CreateCityRequest, CityResponseBase>
    {
        private readonly ICityService _cityService;
        public CreateCityHandler(ICityService cityService)
        {
            _cityService = cityService;
        }
        public async Task<CityResponseBase> Handle(CreateCityRequest request, CancellationToken cancellationToken)
        {
            var verifyCityExist = await _cityService.VeryfiCityExist(request.Name.ToLower(), request.Uf.ToUpper());

            if (verifyCityExist != null)
                throw new ApplicationException($"This city informed already registered");

            City city = new City(request.Name.ToLower(), request.Uf.ToUpper());
            
            var registerCity = await _cityService.CreateAsync(city);

            CityResponseBase response = new CityResponseBase();
            response.AddCityToResponse(registerCity);

            return response;
        }
    }
}
