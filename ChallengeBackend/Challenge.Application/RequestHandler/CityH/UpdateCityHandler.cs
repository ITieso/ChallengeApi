using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Challenge.Application.IServices;
using Challenge.Application.RequestCommand.CityR;
using Challenge.Application.Response;
using Challenge.Domain.Entities;
using MediatR;

namespace Challenge.Application.RequestHandler.CityH
{
    public class UpdateCityHandler : IRequestHandler<UpdateCityRequest, CityResponseBase>
    {
        private readonly ICityService _cityService;
        public UpdateCityHandler(ICityService cityService)
        {
            _cityService = cityService;
        }
        public async Task<CityResponseBase> Handle(UpdateCityRequest request, CancellationToken cancellationToken)
        {

            var oldEntity = await _cityService.GetCityByIdAsync(request.Id);
            if (oldEntity == null)
                throw new ApplicationException($"Any city was not found with this {request.Id}");

            oldEntity.Name = request.Name;
            oldEntity.Uf = request.Uf;

            //City productUpdated = new City(request.Id, request.Name, request.Uf);
            var update = await _cityService.UpdateAsync(oldEntity);

            CityResponseBase response = new CityResponseBase();
            response.AddCityToResponse(update);

            return response;
        }
    }
}
