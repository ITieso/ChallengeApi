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
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly ICityRepository _cityRepository;
        public PersonService(IPersonRepository personRepository, ICityRepository cityRepository)
        {
            _personRepository = personRepository;
            _cityRepository = cityRepository;
        }
        public async Task<Person> CreateAsync(Person person)
        {
            var cityEntity = await _personRepository.CreateAsync(person);
            return cityEntity;
        }

        public async Task<Person> DeleteAsync(Person person)
        {
            return await _personRepository.DeleteAsync(person);
        }

        public async Task<Person> GetPersonByCPFAsync(string cpf)
        {
            var person = await _personRepository.GetPersonByCPFAsync(cpf);
            return person;
        }

        public async Task<Person> GetPersonByIdAsync(int? id)
        {
            var person = await _personRepository.GetPersonByIdAsync(id);
            return person;
        }

        public async Task<Person> GetPersonByNameAsync(string name)
        {
            var person = await _personRepository.GetPersonByNameAsync(name);
            return person;
        }

        public async Task<IEnumerable<Person>> GetPersonsAsync()
        {
            return await _personRepository.GetPersonsAsync();
        }

        public async Task<Person> UpdateAsync(Person person)
        {
            var newCity = await _cityRepository.GetCityByIdAsync(person.CityId);
            var oldEntity = await _personRepository.GetPersonByIdAsync(person.Id);
            oldEntity.Name = person.Name;
            oldEntity.Age = person.Age;
            oldEntity.City = newCity;
            oldEntity.Cpf = person.Cpf;

            var response = await _personRepository.UpdateAsync(oldEntity);
            return response;
        }
    }
}
