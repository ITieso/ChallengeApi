using System;
using System.Threading;
using System.Threading.Tasks;
using Challenge.Application.IServices;
using Challenge.Application.RequestCommand.CityR;
using Challenge.Application.Response;
using MediatR;

namespace Challenge.Application.RequestHandler.CityH
{
    public class GetCityByIdHandler : IRequestHandler<GetCityByIdRequest, CityResponseBase>
    {
        private readonly ICityService _cityService;
        public GetCityByIdHandler(ICityService cityService)
        {
            _cityService = cityService;
        }
        public async Task<CityResponseBase> Handle(GetCityByIdRequest request, CancellationToken cancellationToken)
        {
            var city = await _cityService.GetCityByIdAsync(request.Id);

            if (city == null)
                throw new ApplicationException($"Any city was not found with this {request.Id}");

            CityResponseBase response = new CityResponseBase();
            response.AddCityToResponse(city);

            return response;
        }
    }
}
