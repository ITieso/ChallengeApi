using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge.Domain.Entities;

namespace Challenge.Application.Response
{
    public class CityResponseBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Uf { get; set; }
        

        public void AddCityToResponse(City city)
        {
            Id = city.Id;
            Name = city.Name;
            Uf = city.Uf;
        }

        public IEnumerable<CityResponseBase> AddCityListToResponse(IEnumerable<City> cities)
        {
            var response = new List<CityResponseBase>();
            foreach (var city in cities)
            {
                response.Add(new CityResponseBase
                {
                    Id = city.Id,
                    Name = city.Name,
                    Uf = city.Uf
                });
            }
            return response;
        }
    }

}
