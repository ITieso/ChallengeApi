using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public int Age { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }

        public Person(int id, string name, string cpf, int age, int cityId)
        {
            Id = id;
            Name = name;
            Cpf = cpf;
            Age = age;
            CityId = cityId;
        }

        public Person(string name, string cpf, int age, City city)
        {
            Name = name;
            Cpf = cpf;
            Age = age;
            City = city;
            CityId = city.Id;
        }

        public bool Any()
        {
            throw new NotImplementedException();
        }
    }
}
