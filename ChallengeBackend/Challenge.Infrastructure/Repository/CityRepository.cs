using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge.Domain.Entities;
using Challenge.Domain.IRepository;
using Challenge.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Infrastructure.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _context;
        public CityRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<City> CreateAsync(City city)
        {
             _context.City.Add(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task<City> DeleteAsync(City city)
        {
            _context.City.Remove(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            IEnumerable<City> cities = await _context.City.ToListAsync();
            return cities;
        }

        public async Task<City> GetCityByIdAsync(int? id)
        {
            return await _context.City.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<City> GetCityByNameAsync(string name)
        {
            return await _context.City.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<City>> GetCityByUFAsync(string uf)
        {
            IEnumerable<City> cities = await _context.City.Where(x => x.Uf == uf).ToListAsync();
            return cities;
        }

        public async Task<City> UpdateAsync(City city)
        {
            _context.City.Update(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task<City> VerifyCityExist(string name, string uf)
        {
            var cityFound = await _context.City.Where(x => x.Name == name && x.Uf == uf).FirstOrDefaultAsync();
            return cityFound;
        }
    }
}
