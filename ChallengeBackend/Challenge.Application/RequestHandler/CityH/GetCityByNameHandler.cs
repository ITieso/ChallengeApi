using System;
using System.Threading;
using System.Threading.Tasks;
using Challenge.Application.IServices;
using Challenge.Application.RequestCommand.CityR;
using Challenge.Application.Response;
using MediatR;

namespace Challenge.Application.RequestHandler.CityH
{
    public class GetCityByNameHandler : IRequestHandler<GetCityByNameRequest, CityResponseBase>
    {
        private readonly ICityService _cityService;
        public GetCityByNameHandler(ICityService cityService)
        {
            _cityService = cityService;
        }
        public async Task<CityResponseBase> Handle(GetCityByNameRequest request, CancellationToken cancellationToken)
        {
            var city = await _cityService.GetCityByNameAsync(request.Name.ToLower());

            if (city == null)
                throw new ApplicationException($"Any city was not found with this {request.Name}");

            CityResponseBase response = new CityResponseBase();
            response.AddCityToResponse(city);

            return response;
        } 

    }
}
