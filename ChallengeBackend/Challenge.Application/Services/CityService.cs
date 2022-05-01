using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge.Application.IServices;
using Challenge.Domain.Entities;
using Challenge.Domain.IRepository;

namespace Challenge.Application.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<City> CreateAsync(City city)
        {
            var cityEntity = await _cityRepository.CreateAsync(city);
            return cityEntity;
        }

        public async Task<City> DeleteAsync(City city)
        {
            return await _cityRepository.DeleteAsync(city);

        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await  _cityRepository.GetCitiesAsync();
        }

        public async Task<City> GetCityByIdAsync(int? id)
        {
            var city = await _cityRepository.GetCityByIdAsync(id);
            return city;
        }

        public async Task<City> GetCityByNameAsync(string name)
        {
            var city = await _cityRepository.GetCityByNameAsync(name);
            return city;
        }

        public async Task<IEnumerable<City>> GetCityByUFAsync(string uf)
        {
            return await _cityRepository.GetCityByUFAsync(uf);
          
        }

        public async Task<City> UpdateAsync(City city)
        {
            var oldEntity = await _cityRepository.GetCityByIdAsync(city.Id);
            if(oldEntity == null)
                throw new ApplicationException($"Any city was not found with this {city.Id}");

            oldEntity.Name = city.Name;
            oldEntity.Uf = city.Uf;

            var response = await _cityRepository.UpdateAsync(oldEntity);
            return response;
        }

        public async Task<City> VeryfiCityExist(string name, string uf)
        {
            var cityFound = await _cityRepository.VerifyCityExist(name, uf);
            return cityFound;
        }
    }
}
