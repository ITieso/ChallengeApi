using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge.Domain.Entities;

namespace Challenge.Application.Response
{
    public class PersonResponseBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public int Age { get; set; }
        public string CityName { get; set; }
        public string CityUf { get; set; }

        public void AddPersonToResponse(Person person)
        {
            Id = person.Id;
            Name = person.Name;
            Cpf = person.Cpf;
            Age = person.Age;
            CityName = person.City.Name;
            CityUf = person.City.Uf;
        }

        public IEnumerable<PersonResponseBase> AddPersonListToResponse(IEnumerable<Person> persons)
        {
            var response = new List<PersonResponseBase>();
            foreach (var person in persons)
            {
                response.Add(new PersonResponseBase
                {
                    Id = person.Id,
                    Name = person.Name,
                    Cpf = person.Cpf,
                    Age = person.Age,
                    CityName = person.City.Name,
                    CityUf = person.City.Uf,
                });
            }
            return response;
        }
    }
}
