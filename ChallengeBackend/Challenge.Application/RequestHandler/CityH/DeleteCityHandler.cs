using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Challenge.Application.IServices;
using Challenge.Application.RequestCommand.CityR;
using Challenge.Application.Response;
using MediatR;

namespace Challenge.Application.RequestHandler.CityH
{
    public class DeleteCityHandler : IRequestHandler<DeleteCityRequest, CityResponseBase>
    {
        private readonly ICityService _cityService;
        public DeleteCityHandler(ICityService cityService)
        {
            _cityService = cityService;
        }
        public async Task<CityResponseBase> Handle(DeleteCityRequest request, CancellationToken cancellationToken)
        {
            var city = await _cityService.GetCityByIdAsync(request.Id);
            if (city == null)
                throw new ApplicationException("City not found");

            var deletedCity = await _cityService.DeleteAsync(city);

            var response = new CityResponseBase();
            response.AddCityToResponse(deletedCity);

            return response;
        }
    }
}
