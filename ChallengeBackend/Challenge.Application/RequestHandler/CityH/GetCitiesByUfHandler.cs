using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Challenge.Application.IServices;
using Challenge.Application.RequestCommand.CityR;
using Challenge.Application.Response;
using Challenge.Domain.Entities;
using MediatR;

namespace Challenge.Application.RequestHandler.CityH
{
    public class GetCitiesByUfHandler : IRequestHandler<GetCitiesByUfRequest, IEnumerable<CityResponseBase>>
    {
        private readonly ICityService _cityService;
        public GetCitiesByUfHandler(ICityService cityService)
        {
            _cityService = cityService;
        }
        public async Task<IEnumerable<CityResponseBase>> Handle(GetCitiesByUfRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<City> cities = await _cityService.GetCityByUFAsync(request.Uf.ToUpper());
            if (cities == null)
                throw new ApplicationException($"Doesn't exist any cities registered with UF: {request.Uf}");

            var CityListResponse = new CityResponseBase();
            var response = CityListResponse.AddCityListToResponse(cities);
            return response;
        }
      
    }
}

