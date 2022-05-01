﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge.Domain.Entities;

namespace Challenge.Application.IServices
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<City> GetCityByIdAsync(int? id);
        Task<City> GetCityByNameAsync(string name);
        Task<IEnumerable<City>> GetCityByUFAsync(string uf);
        Task<City> VeryfiCityExist(string name, string uf);
        Task<City> CreateAsync(City city);
        Task<City> UpdateAsync(City city);
        Task<City> DeleteAsync(City city);
    }
}
