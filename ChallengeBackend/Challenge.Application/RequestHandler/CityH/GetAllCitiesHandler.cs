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
    public class GetAllCitiesHandler : IRequestHandler<GetAllCitiesRequest, IEnumerable<CityResponseBase>>
    {
        private readonly ICityService _cityService;
        public GetAllCitiesHandler(ICityService cityService)
        {
            _cityService = cityService;
        }
        public async Task<IEnumerable<CityResponseBase>> Handle(GetAllCitiesRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<City> cities = await _cityService.GetCitiesAsync();
            if(cities == null)
                throw new ApplicationException("City Not Found");

            var CityListResponse = new CityResponseBase();
            var response = CityListResponse.AddCityListToResponse(cities);
            return response;
        }

    }
}
